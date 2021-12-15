namespace Chat_Server.BModels.Boards
{
    public class UserChats
    {
        public long chatid { get; set; }
        public string? name { get; set; }
        public List<ComUser> users { get; set; }
        public bool priv { get; set; }
    }
}
