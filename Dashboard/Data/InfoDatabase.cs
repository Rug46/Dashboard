using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Dashboard.Models.Info;
using Microsoft.EntityFrameworkCore;

namespace Dashboard.Data
{
    public class InfoDatabase : DbContext
    {
        public InfoDatabase()
        {
        }

        public InfoDatabase(DbContextOptions<InfoDatabase> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=Dashboard-Info;Trusted_Connection=True;");
        }

        public DbSet<GamesModel> Games { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GamesModel>().ToTable("Games");
        }

    }
}
