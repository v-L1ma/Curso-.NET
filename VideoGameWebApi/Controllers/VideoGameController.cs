using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace VideoGameWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoGameController : ControllerBase
    {

        static private List<VideoGame> videoGames = new List<VideoGame>
        {
            new VideoGame
            {
                Id = 1,
                Title = "Spider-Man ",
                Platform = "PS5",
                Developer = "Insomaniac Games",
                Publisher = "Sony",
            },
            new VideoGame
            {
                Id = 2,
                Title = "Black 2",
                Platform = "PS5",
                Developer = "Seila",
                Publisher = "Feira",
            },
            new VideoGame
            {
                Id = 3,
                Title = "CS2",
                Platform = "PC",
                Developer = "Valve",
                Publisher = "Steam"
            }
        };

        [HttpGet]
        public ActionResult<List<VideoGame>> GetVideoGames()
        {
            return Ok(videoGames);
        }

        [HttpGet("{Id}")]
        public ActionResult<VideoGame> GetVideoGameById(int Id)
        {
            var game = videoGames.FirstOrDefault(g => g.Id == Id);
            if (game is null)
            {
                return NotFound();
            }

            return Ok(game);
        }

        [HttpPost]
        public ActionResult<VideoGame> addVideoGame(VideoGame newGame)
        {
            if (newGame is null)
            {
                return BadRequest();
            }

            newGame.Id = videoGames.Max(g => g.Id) + 1;
            videoGames.Add((newGame));
            return CreatedAtAction(nameof(GetVideoGameById), new { Id = newGame.Id }, newGame);
        }

        [HttpPut("{Id}")]
        public IActionResult UpdateVideoGame(int Id, VideoGame updatesGame)
        {
            var game = videoGames.FirstOrDefault(g => g.Id == Id);
            if (game is null)
            {
                return NotFound();
            }
            
            game.Title = updatesGame.Title;
            game.Platform = updatesGame.Platform;
            game.Developer = updatesGame.Developer;
            game.Publisher = updatesGame.Publisher;

            return NoContent();
        }
    }
    
}