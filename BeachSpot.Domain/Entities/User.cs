namespace BeachSpot.Domain.Entities;

public class User : BaseEntity
{
    public string Username { get; set; }
    public string Password { get; set; }
    public string Salt { get; set; }
    public string Email { get; set; }    
    public ICollection<Like>? Likes { get; set; }
}
