namespace TVMazeScrapperAPI.Data.Consumer
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using TVMazeScrapperAPI.Data.DTOs;
    
    public interface IConsumeWebService
    {
        Task<IEnumerable<TVShowDTO>> GetTVShows();
        Task AddCast(List<TVShowDTO> shows);
    }
}
