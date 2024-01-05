// Services/MovieService.cs
using Microsoft.EntityFrameworkCore;
using DotNetMinimalAPI.Data;
using DotNetMinimalAPI.DTOs;
using DotNetMinimalAPI.Models;

namespace DotNetMinimalAPI.Services
{
    public class MovieService : IMovieService
    {
        private readonly CinemaApiDbContext _context;

        public MovieService(CinemaApiDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MovieDTO>> GetAllMovies()
        {
            var movies = await _context.Movies
                .Select(m => new MovieDTO
                {
                    MovieId = m.MovieId,
                    Duration = m.Duration,
                    Name = m.Name,
                    Description = m.Description
                })
                .ToListAsync();

            return movies;
        }

        public async Task<MovieDTO> GetMovieById(int id)
        {
            var movie = await _context.Movies
                .Where(m => m.MovieId == id)
                .Select(m => new MovieDTO
                {
                    MovieId = m.MovieId,
                    Duration = m.Duration,
                    Name = m.Name,
                    Description = m.Description
                })
                .FirstOrDefaultAsync();

            return movie;
        }

        public async Task CreateMovie(MovieDTO movieDTO)
        {
            var movie = new Movie
            {
                Duration = movieDTO.Duration,
                Name = movieDTO.Name,
                Description = movieDTO.Description
            };

            _context.Movies.Add(movie);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateMovie(int id, MovieDTO movieDTO)
        {
            var existingMovie = await _context.Movies.FindAsync(id);

            if (existingMovie != null)
            {
                existingMovie.Duration = movieDTO.Duration;
                existingMovie.Name = movieDTO.Name;
                existingMovie.Description = movieDTO.Description;

                _context.Entry(existingMovie).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteMovie(int id)
        {
            var movie = await _context.Movies.FindAsync(id);
            if (movie != null)
            {
                _context.Movies.Remove(movie);
                await _context.SaveChangesAsync();
            }
        }
    }
}
