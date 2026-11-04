using System.ComponentModel.DataAnnotations;

namespace Prestamos_Backend.Module.Auth.Dtos;
public class RegisterRequestDtos
{

    [Required(ErrorMessage = "El Nombre es requerido")]
    [MinLength(3, ErrorMessage = "El campo debe tener al menos 3 caracteres")]
    public required string Nombre { get; set; }  = string.Empty;


    [Required(ErrorMessage = "El apellido es obligatorio")]
    [MinLength(2, ErrorMessage = "El campo debe tener al menos 2 caracteres")]
    public required string Apellido { get; set; }  = string.Empty;

        
    [Required(ErrorMessage = "La cédula es obligatoria")]
    [MinLength(11, ErrorMessage = "La cédula debe tener al menos 11 caracteres")]
    public required string Cedula { get; set; }  = string.Empty;


    [Required(ErrorMessage = "El teléfono es obligatorio")]
    [MinLength(9, ErrorMessage = "El teléfono debe tener al menos 9 caracteres")]
    public required string Telefono { get; set; }  = string.Empty;

    [Required(ErrorMessage = "El email es obligatorio")]
    [EmailAddress(ErrorMessage = "El email no es válido")]
    public required string Email { get; set; }  = string.Empty;

    [Required(ErrorMessage = "La contraseña es obligatoria")]
    [MinLength(8, ErrorMessage = "La contraseña debe tener al menos 8 caracteres")]
    public required string Password { get; set; }  = string.Empty;

    [Required(ErrorMessage = "La confirmación de contraseña es obligatoria")]
    [Compare(nameof(Password), ErrorMessage = "Los campos Password y ConfirmPassword no coinciden.")]
    public required string ConfirmPassword { get; set; }  = string.Empty;
}