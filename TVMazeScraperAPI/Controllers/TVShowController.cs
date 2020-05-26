using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TVMazeScrapperAPI.Business;
using TVMazeScrapperAPI.Data.DTOs;

namespace TVMazeScraperAPI.Controllers
{
    [Produces("application/json")]
    [Route("Home")]
    [ApiController]
    public class TVShowController : ControllerBase
    {
        /// <summary>
        /// The business logic that handles <see cref="Definition"/> entities.
        /// </summary>
        private readonly ITVShowBusiness tvShowBusiness;

        /// <summary>
        /// Initializes a new instance of the <see cref="DefinitionsController"/> class.
        /// </summary>
        /// <param name="definitionBusiness">The business logic that handles <see cref="Definition"/> entities.</param>
        public TVShowController(ITVShowBusiness tvShowBusiness)
        {
            this.tvShowBusiness = tvShowBusiness;
           
        }

        [HttpGet("Index")]
        public ContentResult Index()
        {
            return new ContentResult
            {
                ContentType = "text/html",
                Content = @"<p> Home Page </p>
                            <p> Usage:</p>
                            <p> &nbsp; &nbsp; home/ShowAll : Returns all tv shows.&nbsp;</p >  
                            <p><br/> &nbsp; &nbsp; home/Shows/{id} : Returns paginated list of tv shows with its cast.</p>
                            <p> &nbsp;</p> "
            };
            
        }

        [HttpGet("ShowAll")]
        public JsonResult AllShows()
        {
            var shows = tvShowBusiness.GetAllTVShows();
            if (shows != null && shows.Count() > 0)
                return new JsonResult(JsonConvert.SerializeObject(shows));
                
            return new JsonResult("Database is not initialized");
        }

        [HttpGet("Shows/{page}")]
        public async Task<JsonResult> Shows(int page = 1)
        {
            var shows = await tvShowBusiness.GetTVShows(page: page);
            if (shows != null && shows.Count() > 0)
            {
                return new JsonResult(JsonConvert.SerializeObject(shows));
            }
            return new JsonResult("No data exists on this page");
        }
    }
}
