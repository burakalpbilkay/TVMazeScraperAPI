
namespace TVMazeScrapperAPI.Data.DTOs
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Models;
    
    public class TVShowDTO
    {        
        public TVShowDTO(int id, string name, ICollection<CastMemberDTO> cast)
        {
            this.Id = id;
            this.Name = name;
            this.Cast = cast;

        }

        public TVShowDTO(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        
        public TVShowDTO()
        {
        }
                
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public ICollection<CastMemberDTO> Cast { get; set; }
        
        public TVShow ToModel()
        {
            return new TVShow(
                this.Id,
                this.Name                
                );
        }
    }}
