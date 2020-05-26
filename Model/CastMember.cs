namespace TVMazeScrapperAPI.Models
{
    using System;
    using System.Collections.Generic;
    public class CastMember
    {        
        public CastMember(int id, ICollection<TVShowCastMember> tvShowCastMember, string name, DateTimeOffset birthday)
        {
            this.Id = id;
            this.Name = name;
            this.Birthday = birthday;
            this.TVShowCastMember = tvShowCastMember;
        }

        
        public CastMember()
        {
        }

        public CastMember(int id, string name, DateTimeOffset birthday)
        {
            Id = id;
            Name = name;
            Birthday = birthday;
        }

        
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public DateTimeOffset? Birthday { get; set; }

        public virtual ICollection<TVShowCastMember> TVShowCastMember { get; set; }
    }
}