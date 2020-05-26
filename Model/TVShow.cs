
namespace TVMazeScrapperAPI.Models
{    
    using System.Collections.Generic;   

    
    public class TVShow
    {
        
        public TVShow(int id, string name, ICollection<TVShowCastMember> tvShowCastMember)
        {
            this.Id = id;
            this.Name = name;
            this.TVShowCastMember = tvShowCastMember;
        }

        public TVShow(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        public TVShow()
        {
        }

        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public virtual ICollection<TVShowCastMember> TVShowCastMember { get; set; }
    }
}
