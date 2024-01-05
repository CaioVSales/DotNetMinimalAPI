namespace DotNetMinimalAPI.Models
{
    public class Movie
    {
        public int MovieId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int Duration { get; set; }
        public int RoomId { get; set; }  // Foreign key property
        public Room? Room { get; set; }   // Navigation property

    }
}
