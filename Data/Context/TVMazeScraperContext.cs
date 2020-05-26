namespace TVMazeScrapperAPI.Data.Context
{
    using System;
    using TVMazeScrapperAPI.Models;
    using Microsoft.EntityFrameworkCore;
    
    public class TVMazeScraperContext : DbContext
    {
        public TVMazeScraperContext(DbContextOptions<TVMazeScraperContext> options)
                : base(options)
            {
            }
       
        public DbSet<TVShow> TVShows { get; set; }
       
        public DbSet<CastMember> Cast { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TVShowCastMember>()
         .HasKey(bc => new { bc.TVShowId, bc.CastMemberId });
            modelBuilder.Entity<TVShowCastMember>()
             .HasOne(pt => pt.TvShow)
             .WithMany(p => p.TVShowCastMember)
             .HasForeignKey(pt => pt.TVShowId);

            modelBuilder.Entity<TVShowCastMember>()
                .HasOne(pt => pt.CastMember)
                .WithMany(t => t.TVShowCastMember)
                .HasForeignKey(pt => pt.CastMemberId);
        }
    }
}

