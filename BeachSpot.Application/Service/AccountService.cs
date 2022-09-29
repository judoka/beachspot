using BeachSpot.Application.Abstraction.Identity;
using BeachSpot.Application.Abstraction.Persistence;
using BeachSpot.Application.Models.Authentication;
using BeachSpot.Application.Responses;
using BeachSpot.Domain.Entities;

namespace BeachSpot.Application.Service
{
    public class AccountService : IAccountService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;

        public AccountService(IUserRepository userRepository, IPasswordHasher passwordHasher)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
        }


        private (bool valid, List<string> errors) Validate(string username, string password, string email = "", bool validateEmail = false)
        {
            List<string> errors = new List<string>();
            if (string.IsNullOrWhiteSpace(username))
            {
                errors.Add("Username is required field!");
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                errors.Add("Password is required field!");
            }

            if (validateEmail && string.IsNullOrWhiteSpace(email))
            {
                //TODO validate email format
                errors.Add("Email is required field!");
            }

            return (!errors.Any(), errors);
        }

        public async Task<Response<AuthenticatedUser>> AuthenticateAsync(AuthenticationRequest request)
        {
            var username = request.UsernameSafe;
            var password = request.PasswordSafe;

            var validation = Validate(username, password);
            if (!validation.valid)
            {
                return Response<AuthenticatedUser>.ValidationFailed(validation.errors);
            }


            var user = await _userRepository.GetByUsername(username);
            if (user == null)
            {
                return Response<AuthenticatedUser>.Empty(username);
            }

            var passwordIsCorrect = _passwordHasher.VerifyHashedPassword(user.Password, password, user.Salt);
            if (!passwordIsCorrect)
            {
                return Response<AuthenticatedUser>.ValidationFailed("Bad username or password!");
            }

            var response = new AuthenticatedUser { Id = user.Id, Email = user.Email, Username = user.Username };

            return Response<AuthenticatedUser>.Ok(response);
        }

        public async Task<Response<AuthenticatedUser>> RegisterAsync(RegistrationRequest request)
        {
            var username = request.UsernameSafe;
            var password = request.PasswordSafe;
            var email = request.Email;

            //validate fields
            var validation = Validate(username, password, email, validateEmail: true);
            if (!validation.valid)
            {
                return Response<AuthenticatedUser>.ValidationFailed(validation.errors);
            }

            //check if the username already exists in the system
            var existingUser = await _userRepository.GetByUsername(username);
            if (existingUser != null)
            {
                return Response<AuthenticatedUser>.ValidationFailed($"Username '{username}' already exists in the system!");
            }

            var hashed = _passwordHasher.HashPassword(password);

            var user = new User { Username = username, Password = hashed.password, Salt = hashed.salt, Email = email };
            var newUser = await _userRepository.AddAsync(user);
            if (newUser == null)
            {
                return Response<AuthenticatedUser>.Empty("new user");
            }


            var authenticatedUser = new AuthenticatedUser { Id = user.Id, Username = user.Username, Email = user.Email };
            return Response<AuthenticatedUser>.Ok(authenticatedUser);
        }
    }
}
