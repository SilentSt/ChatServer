using Microsoft.EntityFrameworkCore;

namespace ChatRepository
{
    public class ChatContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;database=drag;user=sDether;password=1namQfeg1_;");
            //optionsBuilder.UseMySQL("server=217.25.89.68;database=drag;user=sDether;password=1namQfeg1_;");
            base.OnConfiguring(optionsBuilder);
        }

        public async Task Reload()
        {
            await Entry(Chats.EntityType).ReloadAsync();
            await Entry(History.EntityType).ReloadAsync();
            await Entry(Companys.EntityType).ReloadAsync();
            await Entry(Boards.EntityType).ReloadAsync();
            await Entry(Cards.EntityType).ReloadAsync();
            await Entry(Users.EntityType).ReloadAsync();
            await Entry(Tokens.EntityType).ReloadAsync();
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Message> History { get; set; }
        public DbSet<Tokens> Tokens { get; set; }
        public DbSet<Company> Companys { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<Board> Boards { get; set; }
        public DbSet<Card> Cards { get; set; }

    }
}