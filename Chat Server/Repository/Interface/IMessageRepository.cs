﻿using ChatRepository;

namespace Chat_Server.Repository.Interface
{
    public interface IMessageRepository
    {
        public Task SendMessage(int fromid, int toid, string text, string? reply = null);
        public Task<long> CreatePrivateChat(int userid, int friendid);
        public Task<long> CreateChat(int userid);
        public Task<List<Message>> GetPrivateMessages(int userid, int friendid, int skip=0,int take=25);
        public Task<List<Message>> GetChatMessages(int userid, int chatid, int skip = 0, int take = 25);
        public Task<List<Chat>> GetChats(int userid);

    }
}
