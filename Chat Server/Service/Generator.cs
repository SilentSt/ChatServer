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

        public static long GenerateCompanyId()
        {
            return new Random().NextInt64(long.MinValue, -10000000)-((long)DateTime.Now.Millisecond*900754);
        }

        public static long Generate64Id()
        {
            return new Random().NextInt64(100000000, long.MaxValue)+((long)DateTime.Now.Millisecond*909909);
        }
        public static ulong GenerateU64Id()
        {
            return (ulong)new Random().NextInt64(100000000, long.MaxValue) + ((ulong)DateTime.Now.Millisecond * 9409079);
        }
    }
}
