using Dashboard.Models;
using Microsoft.EntityFrameworkCore;

namespace Dashboard.Data
{
    public class ActivityContext : DbContext
    {
        public ActivityContext()
        {
        }

        public ActivityContext(DbContextOptions<ActivityContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=dbo.PlayTime;Trusted_Connection=True;");
        }

        public DbSet<ActivityModel> ActivityRecords { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ActivityModel>().ToTable("dbo.PlayTime");
        }
    }
}