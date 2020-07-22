using Microsoft.EntityFrameworkCore;
using TimeManager.Domain.Mapping;

namespace TimeManager.Domain.Context
{
    public class TimeManagerContext : DbContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<Activity> Activity { get; set; }

        public TimeManagerContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMapping());
            modelBuilder.ApplyConfiguration(new ActivityMapping());
        }
    }
}
