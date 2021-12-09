namespace Chat_Server.BModels.Boards
{
    public class UpCard
    {
        public string token { get; set; }
        public ulong cardid { get; set; }
        public string? title { get; set; }
        public string? description { get; set; }
        public string? state { get; set; }
        public DateTime? deadline { get; set; }
    }
}
