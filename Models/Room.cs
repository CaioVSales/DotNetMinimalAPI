using System.Collections.Generic;

namespace DotNetMinimalAPI.Models
{
    public class Room
    {
        public int RoomId { get; set; }
        public int RoomNumber { get; set; }
        public string? Description { get; set; }

        // New property to represent the relationship
        public ICollection<Movie>? Movies { get; set; }
    }
}
