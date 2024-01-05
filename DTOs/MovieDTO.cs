namespace DotNetMinimalAPI.DTOs
{
    public class MovieDTO
    {
        public int MovieId { get; set; }
        public string? Name { get; set; }
        public int Duration { get; set; }
        public string? Description { get; set; }

        public int RoomId { get; set; }
    }
}
