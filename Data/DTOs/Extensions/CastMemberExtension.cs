namespace TVMazeScrapperAPI.Data.DTOs.Extensions
{
    using System;   
    using TVMazeScrapperAPI.Data.DTOs;
    using TVMazeScrapperAPI.Models;
    
    public static class CastMemberExtension
    {
        public static CastMemberDTO ToDto(this CastMember model)
        {
            return new CastMemberDTO(
                model.Id,
                model.Name,
                model.Birthday.GetValueOrDefault().Date.ToString("dd-MM-yyyy"));
        }
    }
}
