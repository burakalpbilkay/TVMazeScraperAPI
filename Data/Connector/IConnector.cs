namespace TVMazeScrapperAPI.Data.Connector
{
    using System.Net.Http;
    using System.Threading.Tasks;
    
    public interface IConnector
    {        
        Task<HttpResponseMessage> GetAsync(string url);
    }
}
