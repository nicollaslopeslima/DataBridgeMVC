using DataBridge.Models;
using Microsoft.EntityFrameworkCore;

namespace DataBridge.Data
{
    public class SqlServerContext : DbContext
    {
        public SqlServerContext(DbContextOptions<SqlServerContext> options)
            : base(options) { }

        public DbSet<ClienteAntigo> Clientes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ClienteAntigo>(entity =>
            {
                entity.ToTable("Clientes");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.DataCadastro).
                                HasDefaultValueSql("GETDATE()");
                    
            });
        }
    }
}
