using Test.Data.Request;

namespace Test.Data.Response;

public class FacturaPagoResponse
{
    public int Id { get; set; }
    public int FacturaID { get; set; }
    public FacturaResponse Factura { get; set; } = null!;
    public DateTime Fecha { get; set; } = DateTime.Today;
    public double MontoPagado { get; set; }
    public string Observacion { get; set; } = null!;

    public FacturaPagoRequest ToRequest() 
    {
        return new FacturaPagoRequest
        {
            Id = Id,
            FacturaID = FacturaID,
            MontoPagado = MontoPagado,
            Observacion = Observacion,
            Fecha = Fecha
        };
    }
}