using System.Text;

namespace Chat_Server.Service
{
    public static class Generator
    {
        public static string GenerateToken()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(Guid.NewGuid().ToString());
            builder.Append(Guid.NewGuid().ToString());
            builder.Append(Guid.NewGuid().ToString());
            return builder.ToString();
        }
    }
}
