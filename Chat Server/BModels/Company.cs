namespace Chat_Server.BModels
{
    public class Company
    {
        public string name { get; set; }
        public List<ComUser> users { get; set; }
    }

    public class ComUser
    {
        public int id { get; set; }
        public string nick { get; set; }
    }
}
