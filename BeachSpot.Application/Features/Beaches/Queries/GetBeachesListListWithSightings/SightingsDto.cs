namespace BeachSpot.Application.Features.Beaches.Queries.GetBeachesListListWithSightings;

public class SightingsDto
{
    public Guid Id { get; set; }
    public string? Longitude { get; set; }
    public string? Latitude { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string ImageUrl { get; set; }
    public string Quote { get; set; }
    public int Likes { get; set; }
}
