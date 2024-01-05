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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Movie>()
                .HasOne(m => m.Room)
                .WithMany(r => r.Movies)
                .HasForeignKey(m => m.RoomId);
        }
    }
}
