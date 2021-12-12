using Chat_Server.Repository.Interface;

using ChatRepository;
using Microsoft.EntityFrameworkCore;

namespace Chat_Server.Repository
{
    public class UserRepository : IUserRepository
    {
        ChatContext chatContext = new ();
        public UserRepository()
        {
            chatContext.Database.EnsureCreated();
        }

        public async Task AddToken(User user, string token)
        {
            chatContext.Tokens.Add(new Tokens() { Token = token,UserId=user.Id });
            await chatContext.SaveChangesAsync();
        }

        public async Task AddToken(int userid, string token)
        {
            var user = await GetUser(userid);
            chatContext.Tokens.Add(new Tokens() { Token = token, UserId = user.Id });
            await chatContext.SaveChangesAsync();
        }

        public async Task<User> FindUser(string nickname)
        {
            var user = chatContext.Users.FirstOrDefault(u => u.NickName.Contains(nickname));
            return user ?? new User() { Id=0};
        }

        public async Task<List<User>> FindUsers(string nickname)
        {
            var users = chatContext.Users.Where(u=>u.NickName.Contains(nickname)).ToList();
            return users;
        }

        public async Task<List<User>> GetCompanyUsers(long id)
        {
            if (id < 0)
            {
                var users = chatContext.Users.Where(c => c.CompanyId == id).ToList();
                return users;
            }
            return new();
        }

        public async Task<Company> GetFullCompany(long id)
        {
            if (id > 0) throw new Exception("403");
            var company = await chatContext.Companys.FirstOrDefaultAsync(c=>c.Id==id);
            return company;
        }

        public async Task<User> GetUser(int id)
        {
            var user = chatContext.Users.FirstOrDefault(u => u.Id == id);
            return user ?? new User() { Id = 0 };
        }
        public async Task<User> GetUser(string token)
        {
            var user = chatContext.Users.FirstOrDefault(x => x.Tokens.Any(y => y.Token == token));
            return user ?? new User() { Id = 0 };
        }

        public async Task<User> Login(string username, string password)
        {
            var user = chatContext.Users.FirstOrDefault(u => u.Login == username&& u.CompanyId<0 && u.Password == password);
            return user ?? new User() { Id = 0 };
        }
    }
}
