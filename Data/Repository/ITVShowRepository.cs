
namespace TVMazeScrapperAPI.Data.Repository
{    
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using TVMazeScrapperAPI.Data.DTOs;
    

    
    public interface ITVShowRepository
    {        
        void Create();        
        
        Task AddTVShows(TVShowDTO tvShows);

        Task AddCasts(CastMemberDTO castMembers);
        
        Task AddRelation(TVShowCastMemberDTO tVShowCastMembers);
    
        IEnumerable<TVShowDTO> GetAllTVShows();
            
        Task<IEnumerable<TVShowDTO>> GetTVShows(int page = 1);
    }
}

