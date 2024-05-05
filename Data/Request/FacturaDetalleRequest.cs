using Test.Data.Response;

namespace Test.Data.Request;


public class FacturaDetalleRequest
{
    public int Id { get; set; }
    public int ProductoId { get; set; }
    public string? Descripcion { get; set; }
    public int Cantidad { get; set; } = 1;
    public decimal Precio { get; set; }
    public decimal Descuento { get; set; }
    public decimal SubTotal => Cantidad * Precio;
    public decimal TotalDesc => SubTotal * (Descuento / 100 );
    public decimal ITBIS => SubTotal * 0.18m;
}