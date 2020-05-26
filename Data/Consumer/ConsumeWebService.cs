namespace TVMazeScrapperAPI.Data.Consumer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;
    using Data.DTOs;
    using Newtonsoft.Json;
    using TVMazeScrapperAPI.Data.Connector;   
    using TVMazeScrapperAPI.Models.Exceptions;

    public class ConsumeWebService : IConsumeWebService
    {        
        private readonly string tvMazeApiUrl = "http://api.tvmaze.com/shows";
        
        private readonly string tvMazeApiUrlforCast = "http://api.tvmaze.com/shows";
        
        private readonly int partitionSize = 20;
        
        private readonly IConnector connector;

        public ConsumeWebService( IConnector connector)
        {
            this.connector = connector;
        }

        public async Task AddCast(List<TVShowDTO> shows)
        {

            var partitition = shows.Zip(Enumerable.Range(0, shows.Count()),
                 (s, r) => new { Group = r / partitionSize, Item = s })
            .GroupBy(i => i.Group, g => g.Item)
            .ToList();


            foreach (var tvShows in partitition)
            {
                foreach (var show in tvShows.ToList())
                {                    
                    var response = await this.connector.GetAsync(
                    $"{this.tvMazeApiUrlforCast}/{show.Id}/cast");
                    switch (response.StatusCode)
                    {
                        case HttpStatusCode.OK:
                            string body =
                                await response.Content.ReadAsStringAsync();

                            var wrapper = JsonConvert.DeserializeObject<List<WrapperCastDTO>>(body);                                                       
                            show.Cast = wrapper.Select(x => x.cast).ToList();
                            break;

                        case HttpStatusCode.NotFound:
                            throw new NotFoundException(
                                $"No tv shows are found.");
                        default:
                            throw new ConnectionException(
                                $"Retrieving a tv show resulted in an unexpected response.");
                    }
                   
                }
                await Task.Delay(10000); //rate limited to allow at  20 calls every 10 seconds
            }
            await Task.Yield();
        }

        
        public async Task<IEnumerable<TVShowDTO>> GetTVShows()
        {
            var response = await this.connector.GetAsync(
                $"{this.tvMazeApiUrl}");

            switch (response.StatusCode)
            {
                case HttpStatusCode.OK:
                    string body =
                        await response.Content.ReadAsStringAsync();
                   
                    return JsonConvert.DeserializeObject<IEnumerable<TVShowDTO>>(body);


                case HttpStatusCode.NotFound:
                    throw new NotFoundException(
                        $"No tv shows are found.");
                default:
                    throw new ConnectionException(
                        $"Retrieving a tv show resulted in an unexpected response.");
            }
        }
    }
}
