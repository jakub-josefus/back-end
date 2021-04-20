using Microsoft.EntityFrameworkCore;

namespace back_end
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {
        }
        public DbSet<Client> Clients { get; set; }
    }
}