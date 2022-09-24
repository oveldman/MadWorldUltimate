namespace MadWorld.Shared.Models.API.Stories;

public class ResponseStory
{
    public string Id { get; set; } = string.Empty;
    public bool Found { get; set; }
    public string Comment { get; set; } = string.Empty;
    public string BodyBase64 { get; set; } = string.Empty;
    public bool IsConcept { get; set; }
}