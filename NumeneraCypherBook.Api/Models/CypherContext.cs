using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace NumeneraCypherBookAPI.Models
{
    public class CypherContext : DbContext
    {
        public CypherContext(DbContextOptions<CypherContext> options)
            :base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cypher>()
                .ToTable("cyphers")
                .Property(c => c.ID)
                .IsRequired();
        }

        public virtual DbSet<Cypher> Cyphers { get; set; }
    }
}
