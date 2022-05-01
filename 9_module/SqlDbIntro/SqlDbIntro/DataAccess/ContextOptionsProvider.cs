using Microsoft.EntityFrameworkCore;

namespace SqlDbIntro.DataAccess
{
    public static class ContextOptionsProvider
    {
        public static string ConnectionString { get => "Server = localhost\\SQLEXPRESS; Database = master; Integrated Security = True;"; }

        public static DbContextOptions GetDbContextOptions()
        {
            var builder = new DbContextOptionsBuilder();
            return builder.UseSqlServer(ConnectionString).Options;
        }
    }
}
