﻿namespace Chat_Server.BModels.Boards
{
    public class RChat
    {
        public long ChatId { get; set; }
        public string? Name { get; set; }
        public List<ComUser> UsersId { get; set; }
        public bool Private { get; set; }
    }
}
