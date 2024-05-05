using Test.Data.Request;


namespace Test.Data.Response;

public class ClienteResponse
{
    public int Id { get; set; }
    public string Cedula { get; set; } = null!;
    public string Nombre { get; set; } = null!;
    public string Apellidos { get; set; } = null!;
    public string? Direccion { get; set; }
    public string? Telefono { get; set; }

    public ClienteRequest ToRequest()
    {

        return new ClienteRequest()
        {
            Id = Id,
            Nombre = Nombre,
            Apellidos = Apellidos,
            Direccion = Direccion,
            Telefono = Telefono,
            Cedula = Cedula
        };
    }

}