using Test.Data.Request;

namespace Test.Data.Response;

public class UsuarioResponse
{
    public int Id { get; set; }
    public string Nombre { get; set; } = null!;
    public string Apellidos { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string? Role { get; set; }

    public UsuarioRequest ToRequest()
    {
        return new UsuarioRequest
        {
            Id = Id,
            Nombre = Nombre,
            Apellidos = Apellidos,
            Email = Email,
            Password = Password,
            Role = Role
        };
    }

}