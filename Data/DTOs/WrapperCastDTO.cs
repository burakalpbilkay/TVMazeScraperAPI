namespace TVMazeScrapperAPI.Data.DTOs
{
    using Newtonsoft.Json;   

    public class WrapperCastDTO
    {
        [JsonProperty("person")]
        public CastMemberDTO cast { get; set; }
    }
}
