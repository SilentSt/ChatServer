using Newtonsoft.Json;

namespace Chat_Server.BModels
{
    [Serializable]
    public class Auth
    {
        [JsonRequired]
        public string login { get; set; }
        [JsonRequired]
        public string password { get; set; }
    }
}
