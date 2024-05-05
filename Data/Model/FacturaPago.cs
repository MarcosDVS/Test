using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Test.Data.Request;
using Test.Data.Response;

namespace Test.Data.Model;

public class FacturaPago
{
    [Key]
    public int Id { get; set; }
    [ForeignKey(nameof(FacturaID))]
    public virtual Factura Factura { get; set; }
    public int FacturaID { get; set; }
    public DateTime Fecha { get; set; }
    public double MontoPagado { get; set; }
    public string Observacion { get; set; } = null!;

    public FacturaPagoResponse? ToResponse() => new()
    {
        Id = Id,
        FacturaID = FacturaID,
        //Factura = Factura.ToResponse(),
        MontoPagado = MontoPagado,
        Observacion = Observacion,
        Fecha = Fecha
    };

    public static FacturaPago Crear(FacturaPagoRequest item)
    => new()
    {
        FacturaID = item.FacturaID,
        MontoPagado = item.MontoPagado,
        Observacion = item.Observacion,
        Fecha = item.Fecha
    };
    public bool Mofidicar(FacturaPagoRequest item)
    {
        var cambio = false;
        if(FacturaID != item.FacturaID)
        {
            FacturaID = item.FacturaID;
            cambio = true;
        }
        if(MontoPagado != item.MontoPagado)
        {
            MontoPagado = item.MontoPagado;
            cambio = true;
        }
        if(Observacion != item.Observacion)
        {
            Observacion = item.Observacion;
            cambio = true;
        }
        if(Fecha != item.Fecha)
        {
            Fecha = item.Fecha;
            cambio = true;
        }
        return cambio;
    }
}