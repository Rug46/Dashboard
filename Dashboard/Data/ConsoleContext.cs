using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Dashboard.Models;

namespace Dashboard.Data
{
    public class ConsoleContext : DbContext
    {
        public ConsoleContext()
        {
        }

        public ConsoleContext(DbContextOptions<ConsoleContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=Dashboard-User;Trusted_Connection=True;");
        }

        public DbSet<ConsoleModel> ConsoleRecords { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ConsoleModel>().ToTable("Console");
        }
    }
}
