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
        public DbSet<BacklogModel> Backlog { get; set; }
        public DbSet<BudgetModel> Budgets { get; set; }
        public DbSet<GameModel> Games { get; set; }
        public DbSet<ModeModel> Modes { get; set; }
        public DbSet<SecurityQuestionModel> SecurityQuestions { get; set; }
        public DbSet<SettingModel> Settings { get; set; }
        public DbSet<UserModel> Users { get; set; }
        public DbSet<UserResetTokenModel> UserResetTokens { get; set; }
        public DbSet<UserBudgetModel> UserBudgets { get; set; }
        public DbSet<UserSettingModel> UserSettings { get; set; }
        public DbSet<WishlistModel> Wishlist { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ActivityModel>().ToTable("Activity");
            modelBuilder.Entity<BacklogModel>().ToTable("Backlog");
            modelBuilder.Entity<BudgetModel>().ToTable("Budget");
            modelBuilder.Entity<GameModel>().ToTable("Game");
            modelBuilder.Entity<ModeModel>().ToTable("Mode");
            modelBuilder.Entity<SecurityQuestionModel>().ToTable("SecurityQuestion");
            modelBuilder.Entity<SettingModel>().ToTable("Setting");
            modelBuilder.Entity<UserModel>().ToTable("User");
            modelBuilder.Entity<UserResetTokenModel>().ToTable("UserResetToken");
            modelBuilder.Entity<UserBudgetModel>().ToTable("UserBudget");
            modelBuilder.Entity<UserSettingModel>().ToTable("UserSetting");
            modelBuilder.Entity<WishlistModel>().ToTable("Wishlist");
        }
    }
}
