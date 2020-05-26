
namespace TVMazeScrapperAPI.Data.Repository
{    
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using TVMazeScrapperAPI.Data.DTOs;
    

    
    public interface ITVShowRepository
    {        
        void Create();

        void Drop();
        
        Task AddTVShows(TVShowDTO tvShows);

        Task AddCasts(CastMemberDTO castMembers);
        
        Task AddRelation(TVShowCastMemberDTO tVShowCastMembers);
    
        IEnumerable<TVShowDTO> GetAllTVShows();

        IEnumerable<CastMemberDTO> GetAllTCast();

        Task<IEnumerable<TVShowDTO>> GetTVShows(int page = 1);
    }
}

