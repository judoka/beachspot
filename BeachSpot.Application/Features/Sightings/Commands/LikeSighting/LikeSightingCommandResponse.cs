namespace BeachSpot.Application.Features.Sightings.Commands.LikeSighting;

public class LikeSightingCommandResponse
{
    public string? Longitude { get; set; }
    public string? Latitude { get; set; }
    public string User { get; set; }
    public string Beach { get; set; }
    public string ImageUrl { get; set; }
    public string Quote { get; set; }
    public int Likes { get; set; }
}
