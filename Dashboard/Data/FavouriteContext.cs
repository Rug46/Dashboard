using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Dashboard.Models;
using Microsoft.EntityFrameworkCore;

namespace Dashboard.Data
{
    public class FavouriteContext : DbContext
    {
        public FavouriteContext()
        {
        }

        public FavouriteContext(DbContextOptions<FavouriteContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=Dashboard-User;Trusted_Connection=True;");
        }

        public DbSet<FavouriteModel> FavouriteRecords { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FavouriteModel>().ToTable("Favourites");
        }
    }
}
