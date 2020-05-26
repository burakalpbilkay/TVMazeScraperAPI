namespace TVMazeScrapperAPI.Data.DTOs
{
    using System;    
    using TVMazeScrapperAPI.Models;

    public class CastMemberDTO
    {                       

        public CastMemberDTO()
        {
        }

        public CastMemberDTO(int id, string name, string birthday)
        {
            Id = id;
            Name = name;
            Birthday = birthday;
        }

        
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public string Birthday { get; set; }
       
        public CastMember ToModel()
        {
            return new CastMember(
                this.Id,             
                this.Name,
                DateTimeOffset.Parse(this.Birthday));
        }
    }
}