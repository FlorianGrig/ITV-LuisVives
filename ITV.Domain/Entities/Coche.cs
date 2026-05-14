using ITV.Domain.Enums;

namespace ITV.Domain.Entities;

public class Coche {
    public int Id { get; set; }
    public int PropietarioId { get; set; }
    public int Propietario { get; set; }
    public string Matricula { get; set; }
    public string Marca { get; set; }
    public string Modelo { get; set; }
    public DateTime FechaMatriculacion { get; set; }
    public TipoMotor TipoMotor {get; set; }
}