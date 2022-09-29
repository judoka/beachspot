namespace BeachSpot.Domain.Entities;

public class Beach : BaseEntity
{
    public string Name { get; set; }
    public string ImageUrl { get; set; }
    public string Description { get; set; }
    public ICollection<Sighting> Sightings { get; set; }
}
