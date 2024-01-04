namespace DotNetMinimalAPI.Models;

public class Movie
{
    public int MovieId { get; set; }
    public int Duration { get; set;}
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}