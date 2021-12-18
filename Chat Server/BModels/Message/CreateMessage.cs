using Newtonsoft.Json;

namespace Chat_Server.BModels
{
    public class CreateMessage
    {
        [JsonRequired]
        public string token { get; set; }
        [JsonRequired]
        public long toid { get; set; }
        [JsonRequired]
        public string text { get; set; }
        public string? reply { get; set; }
    }
}
