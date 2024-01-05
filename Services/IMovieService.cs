// Services/IMovieService.cs
using DotNetMinimalAPI.DTOs;

namespace DotNetMinimalAPI.Services
{
    public interface IMovieService
    {
        Task<IEnumerable<MovieDTO>> GetAllMovies();
        Task<MovieDTO> GetMovieById(int id);
        Task CreateMovie(MovieDTO movieDTO);
        Task UpdateMovie(int id, MovieDTO movieDTO);
        Task DeleteMovie(int id);
    }
}
