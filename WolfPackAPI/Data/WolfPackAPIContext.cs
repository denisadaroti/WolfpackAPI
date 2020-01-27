using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WolfPackAPI.Models;

namespace WolfPackAPI.Data
{
    public class WolfPackAPIContext : DbContext
    {
        public WolfPackAPIContext (DbContextOptions<WolfPackAPIContext> options)
            : base(options)
        {
        }

        public DbSet<WolfPackAPI.Models.Wolf> Wolf { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Wolf>()
                .HasOne(l => l.Location)
                .WithOne(b => b.Wolf)
                .HasForeignKey<Location>(b => b.WolfId);
        }
    }
}
