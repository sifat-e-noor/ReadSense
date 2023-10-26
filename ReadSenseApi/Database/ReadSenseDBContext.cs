using Microsoft.EntityFrameworkCore;

namespace ReadSenseApi.Database
{
    public class ReadSenseDBContext : DbContext
    {
        public ReadSenseDBContext(DbContextOptions<ReadSenseDBContext> options) : base(options)
        {
        }

        public DbSet<Entities.User> Users { get; set; }
        public DbSet<Entities.Device> Devices { get; set; }
    }
}
