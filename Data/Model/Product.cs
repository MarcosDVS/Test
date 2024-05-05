using Test.Data.Request;
using Test.Data.Response;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;

namespace Test.Data.Model;

public class Producto
{
    [Key]
    public int Id { get; set; }
    public string? Codigo { get; set; }
    public string Descripcion { get; set; } = null!;
    public string Categoria { get; set; } = null!;
    public int Stock { get; set; } 
    [Column(TypeName = "decimal(18,2)")]
    public decimal Precio { get; set; }

    public static Producto Crear(ProductoRequest item)
        => new()
        {
            Codigo = item.Codigo,
            Descripcion = item.Descripcion,
            Categoria = item.Categoria,
            Stock = item.Stock,
            Precio = item.Precio
        };

    public bool Mofidicar(ProductoRequest item)
    {
        var cambio = false;
        if (Codigo != item.Codigo)
        {
            Codigo = item.Codigo;
            cambio = true;
        }
        if (Stock != item.Stock)
        {
            Stock = item.Stock;
            cambio = true;
        }
        if (Descripcion != item.Descripcion)
        {
            Descripcion = item.Descripcion;
            cambio = true;
        }
        if (Categoria != item.Categoria)
        {
            Categoria = item.Categoria;
            cambio = true;
        }
        if (Precio != item.Precio)
        {
            Precio = item.Precio;
            cambio = true;
        }
        return cambio;
    }

    public ProductoResponse ToResponse()
        => new()
        {
            Id = Id,
            Codigo = Codigo,
            Descripcion = Descripcion,
            Categoria = Categoria,
            Stock = Stock,
            Precio = Precio
        };
}