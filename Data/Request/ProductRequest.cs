using Test.Data.Model;
using System.ComponentModel.DataAnnotations.Schema;
using Test.Data.Response;


namespace Test.Data.Request;

public class ProductoRequest
{
    public int Id { get; set; }
    public string? Codigo { get; set; }
    public string Descripcion { get; set; } = null!;
    public string Categoria { get; set; } = null!;
    public int Stock { get; set; }
    public decimal Precio { get; set; }
    
}