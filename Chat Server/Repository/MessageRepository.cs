using Chat_Server.BModels;
using Chat_Server.BModels.Boards;
using Chat_Server.Repository.Interface;
using Chat_Server.Service;
using ChatRepository;
using Microsoft.EntityFrameworkCore;

using System.Linq;

namespace Chat_Server.Repository
{
    public class MessageRepository : IMessageRepository
    {
        ChatContext chatContext;

        public MessageRepository(ChatContext chat)
        {
            chatContext = chat;
        }

        public async Task<long> CreateChat(int userid, string name)
        {
            var chatid = Generator.Generate64Id();
            await chatContext.Chats.AddAsync(new Chat() {ChatId = chatid,UserId = userid,Name = name,Private = false});
            await chatContext.SaveChangesAsync();
            return chatid;
        }

        public async Task<long> CreatePrivateChat(int userid, int friendid)
        {
            var chatid = Generator.Generate64Id();
            await chatContext.Chats.AddAsync(new Chat() { ChatId = chatid, UserId = userid, Private = true });
            await chatContext.Chats.AddAsync(new Chat() { ChatId = chatid, UserId = friendid, Private = true });
            await chatContext.SaveChangesAsync();
            return chatid;
        }

        public async Task<List<Message>> GetChatMessages(int userid, int chatid, int skip = 0, int take = 25)
        {
            if (chatContext.Chats.Any(c => c.UserId == userid && c.ChatId == chatid))
            {
                var messages = await chatContext.History.Where(c => c.ChatId == chatid).OrderBy(f=>f.UtcTime).ToListAsync();
                return messages;
            }
            throw new Exception("403");
        }

        public async Task<List<UserChats>> GetChats(int userid)
        {
            var chats = await chatContext.Chats.Where(c => c.UserId == userid).ToListAsync();
            List<UserChats> rchats = new List<UserChats>();
            foreach (var chat in chats)
            {
                rchats.Add(
                    new UserChats(){chatid = chat.ChatId,name = chat.Name,users = chatContext.Chats.Where(g=>g.ChatId==chat.ChatId).Select(x=> new ComUser()
                    {
                        nick = chatContext.Users.First(t => t.Id == x.UserId).NickName,
                        id = x.UserId
                    }).ToList(),priv = chat.Private});
            }
            return rchats;
        }

        public async Task<List<Message>> GetPrivateMessages(int userid, int friendid, int skip = 0, int take = 25)
        {
            var id = chatContext.Chats.Where(ch => ch.UserId == userid && ch.Private);

            var chats = chatContext.Chats.Where(x => id.Any(f=>f.ChatId==x.ChatId));
            var chat =(await chats.FirstOrDefaultAsync(x => x.UserId == friendid)).ChatId;
                //(await chatContext.Chats.FirstOrDefaultAsync(c => id.Any(x => x.ChatId == c.ChatId) && c.UserId == friendid)).ChatId;
            var messages = chatContext.History.Where(y => y.ChatId == chat).Skip(skip).Take(take);
            return await messages.ToListAsync();
        }

        public async Task AddUserToChat(int userid, long chatid)
        {
            var chatname = await GetChatName(chatid);
            await chatContext.Chats.AddAsync(new Chat() { ChatId = chatid, UserId = userid, Private = false, Name = chatname});
        }

        public async Task<int> SendMessage(int fromid, int toid, string text, string? reply = null)
        {
            var message = await chatContext.History.AddAsync(new Message()
                { FromId = fromid, ChatId = toid, UtcTime = DateTime.UtcNow, Reply = reply });
            await chatContext.SaveChangesAsync();
            return message.Entity.Id;
        }

        private async Task<string?> GetChatName(long id)
        {
            return (await chatContext.Chats.FirstOrDefaultAsync(x => x.ChatId == id)).Name;
        }
    }
}
