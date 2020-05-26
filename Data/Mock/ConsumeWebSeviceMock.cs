using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TVMazeScrapperAPI.Data.Consumer;
using TVMazeScrapperAPI.Data.DTOs;

namespace TVMazeScrapperAPI.Data.Mock
{
    public class ConsumeWebSeviceMock :IConsumeWebService
    {
       

        public ConsumeWebSeviceMock()
        {
        }

        public async Task AddCast(List<TVShowDTO> shows)
        {
            await Task.CompletedTask;

        }

        public async Task<IEnumerable<TVShowDTO>> GetTVShows()
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
            await Task.CompletedTask;
            return mockTvShows;
        }
    }
}
