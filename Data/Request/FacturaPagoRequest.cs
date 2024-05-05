using Test.Data.Response;

namespace Test.Data.Request;

public class FacturaPagoRequest
{
    public int Id { get; set; }
    public int FacturaID { get; set; }
    public DateTime Fecha { get; set; } = DateTime.Now;
    public double MontoPagado { get; set; }
    public string Observacion { get; set; } = null!;
    public decimal Pendiente { get; set; }
    public virtual ICollection<FacturaRequest> Facturas { get; set; } 
        = new List<FacturaRequest>();
}