namespace TVMazeScrapperAPI.Data.Tests
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using TVMazeScrapperAPI.Data.Context;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TVMazeScrapperAPI.Data.DTOs;
    using TVMazeScrapperAPI.Data.Repository;

    [TestClass]
    public class DataTests
    {
        ITVShowRepository repo;
        TVMazeScraperContext context;
        [TestInitialize]
        public void testInit()
        {
            var optionsBuilder = new DbContextOptionsBuilder<TVMazeScraperContext>();
            optionsBuilder.UseSqlite("Data Source = tvmazescrapertest.db");
            context = new TVMazeScraperContext(optionsBuilder.Options);
            repo = new TVShowRepository(context);
            repo.Create();            
        }
        
        [TestCleanup]
        public void testCleanup()
        {
            repo.Drop();
        }

        [TestMethod]
        public void AddTVShows_Succesfully()
        {
            Task.Run(async () =>
            {
                CastMemberDTO mockCasMember_1 = new CastMemberDTO(1, "mockMember_1", "12-07-1989");              

                TVShowDTO mockTvShow_1 = new TVShowDTO(1, "mockTvShow_1", new List<CastMemberDTO> { mockCasMember_1 });

                await repo.AddTVShows(mockTvShow_1);
                var tvShows = await repo.GetTVShows();
                Assert.IsTrue(tvShows.First().Id == mockTvShow_1.Id);
            }).GetAwaiter().GetResult();
        }

        [TestMethod]
        public void AddCastMember_Succesfully()
        {
            Task.Run(async () =>
            {
                CastMemberDTO mockCasMember_2 = new CastMemberDTO(2, "mockMember_2", "12-07-1989");

                await repo.AddCasts(mockCasMember_2);
                var cast = repo.GetAllTCast();
                Assert.IsTrue(cast.First().Id == mockCasMember_2.Id);
            }).GetAwaiter().GetResult();
        }

        
        [TestMethod]
        public void GetTVShows_Succesfully()
        {
            Task.Run(async () =>
            {
                CastMemberDTO mockCasMember_3 = new CastMemberDTO(3, "mockMember_3", "12-07-1989");

                TVShowDTO mockTvShow_3 = new TVShowDTO(3, "mockTvShow_3", new List<CastMemberDTO> { mockCasMember_3 });

                await repo.AddTVShows(mockTvShow_3);
                var tvShows = await repo.GetTVShows();
                Assert.IsTrue(tvShows.First().Id == mockTvShow_3.Id);
            }).GetAwaiter().GetResult();

        }

        [TestMethod]
        public void GetAllTVShows_Succesfully()        
        {
            Task.Run(async () =>
            {

                CastMemberDTO mockCasMember_4 = new CastMemberDTO(4, "mockMember_4", "12-07-1989");

                TVShowDTO mockTvShow_4 = new TVShowDTO(4, "mockTvShow_4", new List<CastMemberDTO> { mockCasMember_4 });

                await repo.AddTVShows(mockTvShow_4);
                var tvShows = repo.GetAllTVShows();              
                Assert.IsTrue(tvShows.First().Id == mockTvShow_4.Id);                
            }).GetAwaiter().GetResult();
            
        }

        [TestMethod]
        public void AddRelation_Succesfully()        
        {
            Task.Run(async () =>
            {

                CastMemberDTO mockCasMember_5 = new CastMemberDTO(5, "mockMember_5", "12-07-1989");

                TVShowDTO mockTvShow_5 = new TVShowDTO(5, "mockTvShow_4", new List<CastMemberDTO> { mockCasMember_5 });
                TVShowCastMemberDTO relation = new TVShowCastMemberDTO ( mockTvShow_5.Id, mockCasMember_5.Id );
                await repo.AddTVShows(mockTvShow_5);
                await repo.AddCasts(mockCasMember_5);
                await repo.AddRelation(relation);
                var tvShows = await repo.GetTVShows();
                var castId = tvShows.Where(x => x.Id == mockCasMember_5.Id).First().Id;
               Assert.AreEqual(mockTvShow_5.Id, castId);
            }).GetAwaiter().GetResult();
        }
    }
}
