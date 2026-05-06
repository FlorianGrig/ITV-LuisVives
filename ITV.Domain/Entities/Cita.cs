namespace ITV.Domain.Entities;

public class Cita {
    public int Id { get; set; }
    public DateTime FechaInspeccion { get; set; }
    public bool ResultadoInspeccion { get; set; }
    public int CocheId { get; set; }
    public Coche Coche { get; set; }
}