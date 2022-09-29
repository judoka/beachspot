namespace BeachSpot.Application.Features.Sightings.Queries.GetSightingsList;

public class SightingListVm
{
    public Guid Id { get; set; }
    public string? Longitude { get; set; }
    public string? Latitude { get; set; }
    public string User { get; set; }
    public string Beach { get; set; }
    public string ImageUrl { get; set; }
    public string Quote { get; set; }
}
