namespace Data.DTOs.Extensions
{
    using TVMazeScrapperAPI.Data.DTOs;
    using TVMazeScrapperAPI.Models;

    public static class TVShowCastMemberExtension
    {       
        public static TVShowCastMemberDTO ToDto(this TVShowCastMember model)
        {
            return new TVShowCastMemberDTO(
                model.TVShowId,
                model.TvShow?.ToDto(),
                model.CastMemberId,
                model.CastMember?.ToDto());
        }
    }
}
