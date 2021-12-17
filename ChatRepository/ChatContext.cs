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
            foreach (var entityEntry in ChangeTracker.Entries())
            {
                await entityEntry.ReloadAsync();
            }
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