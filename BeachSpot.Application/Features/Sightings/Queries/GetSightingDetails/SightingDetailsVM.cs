namespace BeachSpot.Application.Features.Sightings.Queries.GetSightingDetails;

public class SightingDetailsVM
{
    public Guid Id { get; set; }
    public string? Longitude { get; set; }
    public string? Latitude { get; set; }
    public GetSightingDetailsDto User { get; set; }
    public GetSightingDetailsDto Beach { get; set; }
    public string ImageUrl { get; set; }
    public string Quote { get; set; }
    public int Likes { get; set; }
}
