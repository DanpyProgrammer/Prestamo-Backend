
namespace Prestamos_Backend.Module.Auth.Entities;

public class User
{
    public int Id { get; set; }

    public Guid Uuid { get; set; }

    public required string Nombre { get; set; } = string.Empty;

    public required string Apellido { get; set; } = string.Empty;
    
    public required string Cedula { get; set; } = string.Empty;

    public required string Telefono { get; set; } = string.Empty;

    public required string Email { get; set; } = string.Empty;

    public required string Password { get; set; } = string.Empty;
}