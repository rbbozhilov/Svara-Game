using Microsoft.EntityFrameworkCore;
using Svara_Game.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Svara_Game.Data
{
    public class SvaraDbContext : DbContext
    {

        public SvaraDbContext()
        {

        }

        public SvaraDbContext( DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=SvaraDataBase;Integrated Security=true");
            }

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }



    }
}
