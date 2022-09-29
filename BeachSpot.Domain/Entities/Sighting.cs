namespace BeachSpot.Domain.Entities;

public class Sighting : BaseEntity
{
    public string? Longitude { get; set; }
    public string? Latitude { get; set; }
    
    //User
    public Guid UserId { get; set; }
    public User User { get; set; }


    //Beach
    public Guid BeachId { get; set; }
    public Beach Beach { get; set; }

    public string ImageUrl { get; set; }
    public string Quote { get; set; }

    public ICollection<Like>? Likes { get; set; }
}
