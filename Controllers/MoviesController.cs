using Microsoft.AspNetCore.Mvc;
using DotNetMinimalAPI.DTOs;
using DotNetMinimalAPI.Services;

namespace DotNetMinimalAPI.Controllers
{
    [ApiController]
    [Route("api/movies")]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        public async Task<IEnumerable<MovieDTO>> Get()
        {
            return await _movieService.GetAllMovies();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MovieDTO>> GetById(int id)
        {
            var movie = await _movieService.GetMovieById(id);

            if (movie == null)
            {
                return NotFound();
            }

            return movie;
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] MovieDTO movieDTO)
        {
            await _movieService.CreateMovie(movieDTO);
            return CreatedAtAction(nameof(GetById), new { id = movieDTO.MovieId }, movieDTO);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] MovieDTO movieDTO)
        {
            await _movieService.UpdateMovie(id, movieDTO);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _movieService.DeleteMovie(id);
            return NoContent();
        }
    }
}
