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

    }
    
}