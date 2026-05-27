using ITV.Domain.Enums;
namespace ITV.Application.DTOs;

public class CrearCitaDTO {
    public string DNI { get; set; }
    public string Nombre { get; set; }
    public string Apellidos { get; set; }
    public string Matricula { get; set; }
    public string Marca { get; set; }
    public string Modelo { get; set; }
    public TipoMotor TipoMotor { get; set; }
    public DateTime FechaMatriculacion { get; set; }
    public DateTime FechaInspeccion { get; set; }
}