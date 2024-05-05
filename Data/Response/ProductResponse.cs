using Test.Data.Model;
using Test.Data.Request;

namespace Test.Data.Response;

public class ProductoResponse
{
    public int Id { get; set; }
    public string? Codigo { get; set; }
    public string Descripcion { get; set; } = null!;
    public string Categoria { get; set; } = null!;
    public int Stock { get; set; }
    public decimal Precio { get; set; }

    public string CodigoDescripcion => $"({Codigo}) {Descripcion}";

    public ProductoRequest ToRequest() 
    {
        return new ProductoRequest
        {
            Id = Id,
            Codigo = Codigo,
            Descripcion = Descripcion,
            Categoria = Categoria,
            Stock = Stock,
            Precio = Precio,
        };
    }
}