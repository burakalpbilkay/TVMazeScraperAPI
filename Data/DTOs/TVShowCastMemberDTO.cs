namespace TVMazeScrapperAPI.Data.DTOs
{
    using TVMazeScrapperAPI.Models;

    public class TVShowCastMemberDTO
    {
        public int TVShowId { get; set; }
        public TVShowDTO TvShow { get; set; }
        public int CastMemberId { get; set; }
        public CastMemberDTO CastMember { get; set; }

        public TVShowCastMemberDTO(int tvShowId, TVShowDTO tvShow, int castMemberId, CastMemberDTO castMember)
        {
            this.TVShowId = tvShowId;
            this.TvShow = tvShow;
            this.CastMemberId = castMemberId;
            this.CastMember = castMember;
        }

        public TVShowCastMemberDTO(int tvShowId, int castMemberId)
        {
            this.TVShowId = tvShowId;            
            this.CastMemberId = castMemberId;            
        }
        
        public TVShowCastMember ToModel()
        {
            return new TVShowCastMember(
                this.TVShowId,                
                this.CastMemberId
                );
        }
    }
}