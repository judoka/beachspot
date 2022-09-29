namespace BeachSpot.Domain.Entities;

public class Like : BaseEntity
{
    public Guid UserId { get; set; }
    public User User { get; set; }

    public Sighting Sighting { get; set; }
    public Guid SightingId { get; set; }
}
