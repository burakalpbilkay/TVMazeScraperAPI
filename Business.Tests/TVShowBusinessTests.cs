namespace TVMazeScrapperAPI.Business.Tests
{
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TVMazeScrapperAPI.Business;
    using TVMazeScrapperAPI.Data.Consumer;
    using TVMazeScrapperAPI.Data.Mock;
    using TVMazeScrapperAPI.Data.Repository;
    [TestClass]
    public class TVShowBusinessTests
    {
        ITVShowRepository repo;
        IConsumeWebService service;    

        TVShowBusiness business;
        [TestInitialize]
        public void testInit()
        {
             repo = new TVShowRepositoryMock();
             service = new ConsumeWebSeviceMock();  
             business = new TVShowBusiness(repo,service);
        }  
        
        [TestMethod]
        public void TestGetTVShows_returnTVShowsSuccesfully()
        {
            
            var value = business.GetAllTVShows();
            Assert.IsTrue(value.Count() == 2);
           
        }
        
        [TestMethod]
        public void TestTVShows_returnTVShowsSuccesfully()
        {
            Task.Run(async () =>
            {
                Assert.IsTrue((await business.GetTVShows(1)).Count() == 2);
            }).GetAwaiter().GetResult();            
        }
        
        [TestMethod]
        public void TestTVShows_DoesNotFailWhenReturnValueQqualsToNull()
        {
            Task.Run(async () =>
            {
                var value = await business.GetTVShows(0);
                Assert.IsTrue(value == null);
            }).GetAwaiter().GetResult();
        }
    }
}
