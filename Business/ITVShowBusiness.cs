namespace TVMazeScrapperAPI.Business
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using TVMazeScrapperAPI.Data.DTOs;

    public interface ITVShowBusiness
    {        
        Task<IEnumerable<TVShowDTO>> GetTVShows(int page = 1);

        IEnumerable<TVShowDTO> GetAllTVShows();
        
        Task CreateAndPopulateDatabase();

        void DropDatabase();

        Task AddTVShows(IEnumerable<TVShowDTO> tvShows);
    }
}
