using DataBridge.Models;
using Microsoft.EntityFrameworkCore;

namespace DataBridge.Data
{
    public class MySqlContext : DbContext
    {
        public MySqlContext(DbContextOptions<MySqlContext> options) : base(options) { }

        public DbSet<ClienteNovo> Clientes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClienteNovo>(entity =>
            {
                entity.ToTable("clientes");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.DataAlteracao)
                      .HasDefaultValueSql("CURRENT_TIMESTAMP");
            });
        }
    }
}
