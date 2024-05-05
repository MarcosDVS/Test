using Test.Data.Response;

namespace Test.Data.Request;

public class FacturaRequest
{
    public int Id { get; set; }
    public int ClienteId { get; set; }
    public DateTime Fecha { get; set; } = DateTime.Now;
    public virtual ICollection<FacturaDetalleRequest> Detalles { get; set; }
        = new List<FacturaDetalleRequest>();
    public virtual ICollection<FacturaRequest> Facturas { get; set; }
        = new List<FacturaRequest>();
    
    public decimal SubTotal =>
        Detalles != null ?
        Detalles.Sum(d => d.SubTotal)
        :
        0;

    public decimal TotalDesc =>
        Detalles != null ? //IF
        Detalles.Sum(d => d.TotalDesc) //Verdadero
        :
        0;//Falso

    public decimal ITBIS => SubTotal * 0.18m;

    public string TypePayment  { get; set; } = null!;
    public decimal SaldoPagado { get; set; }
    public virtual ICollection<FacturaPagoResponse> Pagos { get; set; } = new List<FacturaPagoResponse>(); // Inicializamos la colección aquí
    public decimal SaldoPendiente => SubTotal - DineroPagado - TotalDesc;
    public decimal Cambio => SaldoPagado - SubTotal - TotalDesc;
    public decimal DineroPagado { get; set; }
}