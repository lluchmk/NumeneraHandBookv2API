using Microsoft.EntityFrameworkCore;
using NumeneraCypherBook.Core.Models;

namespace NumeneraCypherBook.Core.Data
{
    public class NumeneraContext : DbContext
    {
        public NumeneraContext(DbContextOptions options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cypher>()
                .ToTable("cyphers")
                .Property(c => c.Id)
                .IsRequired();
        }

        public DbSet<Cypher> Cyphers { get; set; }
    }
}
