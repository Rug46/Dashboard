using Dashboard.Models;
using Microsoft.EntityFrameworkCore;

namespace Dashboard.Data
{
    public class PlaytimeContext : DbContext
    {
        public PlaytimeContext()
        {
        }

        public PlaytimeContext(DbContextOptions<PlaytimeContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=dbo.PlayTime;Trusted_Connection=True;");
        }

        public DbSet<PlaytimeModel> PlaytimeRecords { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlaytimeModel>().ToTable("dbo.PlayTime");
        }
    }
}