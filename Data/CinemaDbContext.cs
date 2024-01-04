using Microsoft.EntityFrameworkCore;
using DotNetMinimalAPI.Models;

namespace DotNetMinimalAPI.Data
{
    public class CinemaApiDbContext : DbContext
    {
        public CinemaApiDbContext(DbContextOptions<CinemaApiDbContext> options) : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Room> Rooms { get; set; }
    }
}