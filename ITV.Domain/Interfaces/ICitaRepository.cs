using ITV.Domain.Entities;

namespace ITV.Domain.Interfaces;

public interface ICitaRepository {
    void CrearCita(Cita cita);
    Cita BuscarPorId(int id);
    List<Cita> ListarTodo();
    void ActualizarCita(Cita cita);
    void BorrarCita(int id);
}