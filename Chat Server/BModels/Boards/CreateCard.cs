namespace Chat_Server.BModels.Boards
{
    public class CreateCard
    {
        public string token { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string state { get; set; }
        public long boardid { get; set; }
        public DateTime deadline { get; set; }
    }
}
