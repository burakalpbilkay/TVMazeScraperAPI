namespace TVMazeScrapperAPI.Models
{
    public class TVShowCastMember
    {
        public int TVShowId { get; set; }
        public TVShow TvShow { get; set; }
        public int CastMemberId { get; set; }
        public CastMember CastMember { get; set; }

        public TVShowCastMember()
        {

        }

        public TVShowCastMember(int tvShowId, TVShow tvShow, int castMemberId, CastMember castMember)
        {
            this.TVShowId = tvShowId;
            this.TvShow = tvShow;
            this.CastMemberId = castMemberId;
            this.CastMember = castMember;
       }

        public TVShowCastMember(int tVShowId, int castMemberId)
        {
            TVShowId = tVShowId;
            CastMemberId = castMemberId;
        }
    }
   
}
