

namespace Prestamos_Backend.Module.Prestamos.Dtos;

public class PrestamosCreate
{
    public required string Nombre { get; set; }
    public required string Apellido { get; set; }
    public required string Cedula { get; set; }
    public required int Monto { get; set; }
}
