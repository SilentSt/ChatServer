using Chat_Server.Repository.Interface;
using Chat_Server.Service;
using ChatRepository;
using Microsoft.EntityFrameworkCore;

namespace Chat_Server.Repository
{
    public class MessageRepository : IMessageRepository
    {
        ChatContext chatContext = new ();

        public async Task<long> CreateChat(int userid)
        {
            var chatid = Generator.Generate64Id();
            await chatContext.Chats.AddAsync(new Chat() {ChatId = chatid,UserId = userid, Private = false});
            return chatid;
        }

        public async Task<long> CreatePrivateChat(int userid, int friendid)
        {
            var chatid = Generator.Generate64Id();
            await chatContext.Chats.AddAsync(new Chat() { ChatId = chatid, UserId = userid, Private = true });
            await chatContext.Chats.AddAsync(new Chat() { ChatId = chatid, UserId = friendid, Private = true });
            return chatid;
        }

        public async Task<List<Message>> GetChatMessages(int userid, int chatid, int skip = 0, int take = 25)
        {
            if (chatContext.Chats.Any(c => c.UserId == userid && c.ChatId == chatid))
            {
                var messages = await chatContext.History.Where(c => c.ChatId == chatid).ToListAsync();
                return messages;
            }
            throw new Exception("403");
        }

        public async Task<List<Chat>> GetChats(int userid)
        {
            var chats = await chatContext.Chats.Where(c => c.UserId == userid).ToListAsync();
            return chats;
        }

        public async Task<List<Message>> GetPrivateMessages(int userid, int friendid, int skip = 0, int take = 25)
        {
            var id = chatContext.Chats.Where(ch => ch.UserId == userid && ch.Private);
            var chatid =
                (await chatContext.Chats.FirstOrDefaultAsync(c => id.Any(x => x.ChatId == c.ChatId) && c.UserId == friendid)).ChatId;
            var messages = chatContext.History.Where(y => y.ChatId == chatid).Skip(skip).Take(take);
            return await messages.ToListAsync();
        }

        public async Task SendMessage(int fromid, int toid, string text, string? reply = null)
        {
            await chatContext.History.AddAsync(new Message()
                { FromId = fromid, ChatId = toid, UtcTime = DateTime.UtcNow, Reply = reply });
            await chatContext.SaveChangesAsync();
        }
    }
}
