namespace Chat_Server.BModels.Message
{
    public class CreatePrivateChat
    {
        public string token { get; set; }
        public int friend { get; set; }
    }
}
