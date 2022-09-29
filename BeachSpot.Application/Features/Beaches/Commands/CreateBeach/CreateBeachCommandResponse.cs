namespace BeachSpot.Application.Features.Beaches.Commands.CreateBeach;

public class CreateBeachCommandResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string ImageUrl { get; set; }
    public string Description { get; set; }
}
