using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Dashboard.Models;
using Microsoft.EntityFrameworkCore;

namespace Dashboard.Data
{
    public class Database : DbContext
    {
        public Database()
        {
        }

        public Database(DbContextOptions<Database> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=Dashboard;Trusted_Connection=True;");
        }

        public DbSet<ActivityModel> Activity { get; set; }
        public DbSet<BudgetModel> Budgets { get; set; }
        public DbSet<ConsoleModel> Consoles { get; set; }
        public DbSet<FavouriteModel> Favourites { get; set; }
        public DbSet<GameModel> Games { get; set; }
        public DbSet<ModeModel> Modes { get; set; }
        public DbSet<RatingModel> Ratings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ActivityModel>().ToTable("Activity");
            modelBuilder.Entity<BudgetModel>().ToTable("Budget");
            modelBuilder.Entity<ConsoleModel>().ToTable("Console");
            modelBuilder.Entity<FavouriteModel>().ToTable("Favourite");
            modelBuilder.Entity<GameModel>().ToTable("Game");
            modelBuilder.Entity<ModeModel>().ToTable("Mode");
            modelBuilder.Entity<RatingModel>().ToTable("Rating");
        }
    }
}
