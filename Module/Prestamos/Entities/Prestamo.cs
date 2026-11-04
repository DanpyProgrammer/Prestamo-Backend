
namespace Prestamos_Backend.Module.Prestamos.Entities;

    public class PrestamosEntity
    {
        public int Id { get; set; }

        public Guid Uuid { get; set; }

        public required decimal Monto { get; set; }
        public required int Plazo { get; set; }
        public required decimal Interes { get; set; }
        public required decimal CuotaMensual { get; set; }
    }
