namespace BeachSpot.Application.Features.Beaches.Queries.GetBeachesListListWithSightings;

public class BeachSightingsListVm
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string ImageUrl { get; set; }
    public string Description { get; set; }
    public ICollection<SightingsDto> Sightings { get; set; }
}
