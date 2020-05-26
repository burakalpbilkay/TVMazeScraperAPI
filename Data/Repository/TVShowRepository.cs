using System;
using Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using TVMazeScrapperAPI.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using Data.DTOs.Extensions;
using TVMazeScrapperAPI.Data.DTOs;

namespace TVMazeScrapperAPI.Data.Repository
{

    public class TVShowRepository : ITVShowRepository
    {
        private readonly TVMazeScraperContext context;
        
        public TVShowRepository(TVMazeScraperContext context)
        {
            this.context = context;
        }

        public async Task AddTVShow(TVShow tvShow)
        {
            try
            {
                await context.TVShows.AddAsync(tvShow);
                context.SaveChanges(); 
            }
            catch
            {
                //TODO log                
            }
        }

        public async Task AddTVShows(TVShowDTO tvShows)
        {
            try
            {
                if (context.TVShows.Where(x => x.Id == tvShows.Id).Count() <= 0)
                    await context.TVShows.AddAsync(tvShows.ToModel());
                    context.SaveChanges();
            }
            catch
            {
                //TODO log
            }
        }

        public async Task AddCasts(CastMemberDTO castMembers)
        {          
            try
            {   if (context.Cast.Where(x => x.Id == castMembers.Id).Count() <= 0)                   
                    await context.Cast.AddAsync(castMembers.ToModel());
                    context.SaveChanges();
            }
            catch
            {
                //TODO log
            }
        }

        public void Create()
        {
            context.Database.EnsureCreatedAsync();
        }        

        public async Task<IEnumerable<TVShowDTO>> GetTVShows(int page = 1)
        {
            var pageSize = 10;
            if (page < 1)
                return GetAllTVShows();

            var tvShows = context.TVShows
                               .Skip(pageSize * (page - 1))
                               .Take(pageSize)
                               .Include(tvShow => tvShow.TVShowCastMember)
                               .ThenInclude(x => x.CastMember);
            await tvShows.ForEachAsync(x => x.TVShowCastMember = x.TVShowCastMember.OrderByDescending(c => c.CastMember.Birthday).ToList());            
           
            return tvShows.Select(x => x.ToDto());
        }
        public async Task Drop()
        {
            await context.Database.EnsureDeletedAsync();
        }

        public IEnumerable<TVShowDTO> GetAllTVShows()
        {
            return context.TVShows.Select(x => x.ToDtoWithoutCast());
        }

        public async Task AddRelation(TVShowCastMemberDTO tVShowCastMembers)
        {
            try
            {
                if (context.Find(tVShowCastMembers.ToModel().GetType(),new object[] { tVShowCastMembers.TVShowId, tVShowCastMembers.CastMemberId} ) == null)
                    await context.AddAsync(tVShowCastMembers.ToModel());
                    context.SaveChanges();
            }
            catch
            {
                //TODO log
            }
        }
    }
}
