namespace DotNetMinimalAPI.Models;

public class Room
{
    public int RoomId { get; set; }
    public string RoomNumber { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public List<Movie> Movies { get; set; }

    public Room()
    {
        RoomNumber = string.Empty;
        Description = string.Empty;
        Movies = new List<Movie>();
    }
}