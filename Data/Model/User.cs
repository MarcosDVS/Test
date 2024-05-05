using System.ComponentModel.DataAnnotations;
using Test.Data.Request;
using Test.Data.Response;

namespace Test.Data.Model;

public class Usuario
{
    [Key]
    public int Id { get; set; }
    public string Nombre { get; set; } = null!;
    public string Apellidos { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string? Role { get; set; }

    public static Usuario Crear(UsuarioRequest user) => new()
    {
        Nombre = user.Nombre,
        Apellidos = user.Apellidos,
        Email = user.Email,
        Password = user.Password,
        Role = user.Role
    };
    public bool Modificar(UsuarioRequest item)
    {
        var cambio = false;
        if (Nombre != item.Nombre) Nombre = item.Nombre; cambio = true;
        if (Apellidos != item.Apellidos) Apellidos = item.Apellidos; cambio = true;
        if (Email != item.Email) Email = item.Email; cambio = true;
        if (Password != item.Password) Password = item.Password; cambio = true;
        if (Role != item.Role) Role = item.Role; cambio = true;

        return cambio;
    }
    public UsuarioResponse ToResponse() => new()
    {
        Id = Id,
        Nombre = Nombre,
        Apellidos = Apellidos,
        Email = Email,
        Password = Password,
        Role = Role
    };
}