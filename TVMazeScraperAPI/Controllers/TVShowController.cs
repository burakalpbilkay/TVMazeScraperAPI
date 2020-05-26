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
        public string Index()
        {
            return "Home Page";
        }

        [HttpGet("AllShows")]
        public string AllShows()
        {
            var shows = tvShowBusiness.GetAllTVShows();
            if (shows != null && shows.Count() > 0)
                return JsonConvert.SerializeObject(shows);
            return "Database is not initialized";
        }

        [HttpGet("Shows/{page}")]
        public async Task<string> Shows(int page = 1)
        {
            var shows = await tvShowBusiness.GetTVShows(page: page);
            if (shows != null && shows.Count() > 0)
            {
                return JsonConvert.SerializeObject(shows);
            }
            return "Database is not initialized";
        }
    }
}
