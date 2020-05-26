namespace Data.DTOs.Extensions
{
    using System;
    using System.Linq;
    using TVMazeScrapperAPI.Data.DTOs; 
    using TVMazeScrapperAPI.Models;
    
    public static class TVShowExtension
    {
        
        public static TVShowDTO ToDto(this TVShow model)
        {
            return new TVShowDTO(
                model.Id,
                model.Name,
                model.TVShowCastMember?.Select(x => x.CastMember.ToDto()).ToList());
        }

        public static TVShowDTO ToDtoWithoutCast(this TVShow model)
        {
            return new TVShowDTO(
                model.Id,
                model.Name);
        }
    }
}
