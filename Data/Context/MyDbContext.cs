using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Test.Data.Model;

namespace Test.Data.Context;

    public class MyDbContext : DbContext, IMyDbContext
    {
        public MyDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Factura> Facturas { get; set; }
        public DbSet<FacturaDetalle> FacturaDetalles { get; set; }
        public DbSet<FacturaPago> FacturaPagos { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(cancellationToken);
        }
    }