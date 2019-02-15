﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dashboard.Models;
using Microsoft.EntityFrameworkCore;

namespace Dashboard.Data
{
    public class GameContext : DbContext
    {
        public GameContext()
        {
        }

        public GameContext(DbContextOptions<ActivityContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=Dashboard;Trusted_Connection=True;");
        }

        public DbSet<GameModel> GameRecords { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GameModel>().ToTable("Games");
        }
    }
}