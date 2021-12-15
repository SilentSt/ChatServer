namespace Chat_Server.BModels.Message
{
    public class AddUserToChat
    {
        public string token { get; set; }
        public int userid { get; set; }
        public long chatid { get; set; }

    }
}
