namespace TVMazeScrapperAPI.Data.Mock
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using TVMazeScrapperAPI.Data.DTOs;
    using TVMazeScrapperAPI.Data.Repository;

    public class TVShowRepositoryMock : ITVShowRepository
    {
      
        public TVShowRepositoryMock()
        {
           
        }

        public async Task AddCasts(CastMemberDTO castMembers)
        {
            await Task.CompletedTask;
        }

        public async Task AddRelation(TVShowCastMemberDTO tVShowCastMembers)
        {
            await Task.CompletedTask;
        }

        public async Task AddTVShows(TVShowDTO tvShows)
        {
            await Task.CompletedTask;
        }

        public void Create()
        {
            return;
        }

        public void Drop()
        {
            return;
        }

        public IEnumerable<CastMemberDTO> GetAllTCast()
        {
            return null;
        }

        public IEnumerable<TVShowDTO> GetAllTVShows()
        {
            CastMemberDTO mockCasMember_1 = new CastMemberDTO(1, "mockMember_1", null);
            CastMemberDTO mockCasMember_2 = new CastMemberDTO(2, "mockMember_2", "12-07-1999");
            CastMemberDTO mockCasMember_3 = new CastMemberDTO(3, "mockMember_3", "");
            CastMemberDTO mockCasMember_4 = new CastMemberDTO(4, "mockMember_2", "12-07-2020");

            TVShowDTO mockTvShow_1 = new TVShowDTO(1, "mockTvShow_1", new List<CastMemberDTO> { mockCasMember_1, mockCasMember_2 });
            TVShowDTO mockTvShow_2 = new TVShowDTO(2, "mockTvShow_2", new List<CastMemberDTO> { mockCasMember_3, mockCasMember_4 });


            List<TVShowDTO> mockTvShows = new List<TVShowDTO>();
            mockTvShows.Add(mockTvShow_1);
            mockTvShows.Add(mockTvShow_2);
            return mockTvShows;
        }

        public async Task<IEnumerable<TVShowDTO>> GetTVShows(int page = 1)
        {
            if (page == 0)
                return null;
            CastMemberDTO mockCasMember_1 = new CastMemberDTO(1, "mockMember_1", null);
            CastMemberDTO mockCasMember_2 = new CastMemberDTO(2, "mockMember_2", "12-07-1999");
            CastMemberDTO mockCasMember_3 = new CastMemberDTO(3, "mockMember_3", "");
            CastMemberDTO mockCasMember_4 = new CastMemberDTO(4, "mockMember_2", "12-07-2020");

            TVShowDTO mockTvShow_1 = new TVShowDTO(1, "mockTvShow_1", new List<CastMemberDTO> { mockCasMember_1, mockCasMember_2 });
            TVShowDTO mockTvShow_2 = new TVShowDTO(2, "mockTvShow_2", new List<CastMemberDTO> { mockCasMember_3, mockCasMember_4 });


            List<TVShowDTO> mockTvShows = new List<TVShowDTO>();
            mockTvShows.Add(mockTvShow_1);
            mockTvShows.Add(mockTvShow_2);
            await Task.CompletedTask;
            return mockTvShows;
        }
    }
}
