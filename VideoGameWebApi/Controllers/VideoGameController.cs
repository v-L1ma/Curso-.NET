using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using VideoGameWebApi.Data;

namespace VideoGameWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoGameController(VideoGameDbContext context) : ControllerBase
    {

        private readonly VideoGameDbContext _context = context;

        [HttpGet]
        public async Task<ActionResult<List<VideoGame>>> GetVideoGames()
        {
            return Ok(await _context.VideoGames.ToListAsync());
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<VideoGame>> GetVideoGameById(int Id)
        {
            var game = await _context.VideoGames.FindAsync(Id);
            if (game is null)
            {
                return NotFound();
            }
        
            return Ok(game);
        }
        
        [HttpPost]
        public async Task<ActionResult<VideoGame>> addVideoGame(VideoGame newGame)
        {
            if (newGame is null)
            {
                return BadRequest();
            }

            _context.VideoGames.Add(newGame);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetVideoGameById), new { Id = newGame.Id }, newGame);
        }
        
        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdateVideoGame(int Id, VideoGame updatesGame)
        {
            var game = await _context.VideoGames.FindAsync(Id);
            if (game is null)
            {
                return NotFound();
            }
            
            game.Title = updatesGame.Title;
            game.Platform = updatesGame.Platform;
            game.Developer = updatesGame.Developer;
            game.Publisher = updatesGame.Publisher;

            await _context.SaveChangesAsync();
        
            return NoContent();
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVideoGame(int Id)
        {
            var game = await _context.VideoGames.FindAsync(Id);
            if(game is null){
                return NotFound();
            }
            
            _context.VideoGames.Remove(game);
            await _context.SaveChangesAsync();
            return NoContent();
        }


    }
    
}