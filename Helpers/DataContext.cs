using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TwoFactorAuthenticationApi.Entities;

namespace TwoFactorAuthenticationApi.Helpers
{
    public class DataContext:DbContext
    {
        protected readonly IConfiguration Configuration;

        public DataContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to sql server with connection string from app settings
            options.UseSqlServer(Configuration.GetConnectionString("TwoFactorAuthenticationApiDatabase"));
        }

        public DbSet<User> Users { get; set; }
    }
}
