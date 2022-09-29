namespace BeachSpot.Application.Features.Sightings.Commands.CreateSighting;

public class CreateSightingCommandResponse
{
    public Guid Id { get; set; }
    public string? Longitude { get; set; }
    public string? Latitude { get; set; }
    public CreateSightingDto User { get; set; }
    public CreateSightingDto Beach { get; set; }
    public string ImageUrl { get; set; }
    public string Quote { get; set; }
}
