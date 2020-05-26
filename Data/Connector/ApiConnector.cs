namespace TVMazeScrapperAPI.Data.Connector
{
    using System.Net.Http;   
    using System.Threading.Tasks;
    

    public class ApiConnector : IConnector
    {       
        public async Task<HttpResponseMessage> GetAsync(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                return await client.GetAsync(url);
            }
        }
    }
}
