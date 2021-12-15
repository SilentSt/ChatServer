namespace Chat_Server.BModels.Boards
{
    public class CreateBoard
    {
        public string token { get; set; }
        public string title { get; set; }
        public bool priv { get; set; }
    }
}
