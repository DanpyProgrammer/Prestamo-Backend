

namespace Prestamos_Backend.Module.Auth.Dtos;

public class LoginRequestDtos
{
    public required string Email { get; set; } = string.Empty;
    public required string Password { get; set; } = string.Empty;
}