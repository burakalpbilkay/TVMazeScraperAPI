namespace TVMazeScrapperAPI.Business
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;    
    using TVMazeScrapperAPI.Data.DTOs;
    using TVMazeScrapperAPI.Data.Repository;    
    using System.Linq;
    using Data.Consumer;

    public class TVShowBusiness : ITVShowBusiness
    {        
        private readonly ITVShowRepository tvShowRepository;
        
        private readonly IConsumeWebService consumerWebService;

        
        public TVShowBusiness(ITVShowRepository tvShowRepository, IConsumeWebService consumerWebService)
        {
            this.tvShowRepository = tvShowRepository;
            this.consumerWebService = consumerWebService;
        }

        public async Task AddTVShows(IEnumerable<TVShowDTO> tvShows)
        {            
            foreach (var tvShow in tvShows)
            {
                await tvShowRepository.AddTVShows(tvShow);
                foreach (var item in tvShow.Cast)
                {
                    await tvShowRepository.AddCasts(item);
                    TVShowCastMemberDTO relation = new TVShowCastMemberDTO(tvShow.Id, item.Id);
                    await tvShowRepository.AddRelation(relation);
                }
                                
            }
        }

        public async Task CreateAndPopulateDatabase()
        {
            this.tvShowRepository.Create();
            var tvShows = await consumerWebService.GetTVShows();          
            await consumerWebService.AddCast(tvShows.ToList());
            await AddTVShows(tvShows);

        }

        public IEnumerable<TVShowDTO> GetAllTVShows()
        {
            return this.tvShowRepository
                  .GetAllTVShows();
        }

        public async Task<IEnumerable<TVShowDTO>> GetTVShows(int page = 1 )
        {
            var shows = this.tvShowRepository
                   .GetTVShows(page);
                    
            return await shows;
        }
    }
}
