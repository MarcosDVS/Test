using Microsoft.EntityFrameworkCore;
using Test.Data.Model;

namespace Test.Data.Context
{
    public interface IMyDbContext
    {
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Factura> Facturas { get; set; }
        public DbSet<FacturaDetalle> FacturaDetalles { get; set; }
        public DbSet<FacturaPago> FacturaPagos { get; set; }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}