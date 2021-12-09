using Newtonsoft.Json;

namespace Chat_Server.BModels
{
    public class GetHistory
    {
        [JsonRequired]
        public string token { get; set; }
        [JsonRequired]
        public int id { get; set; }
        public int? skip { get; set; }
        public int? take { get; set; }
    }
}
