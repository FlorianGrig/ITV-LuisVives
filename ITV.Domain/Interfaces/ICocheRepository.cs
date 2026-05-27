using ITV.Domain.Entities;

namespace ITV.Domain.Interfaces;

public interface ICocheRepository {
    void CrearCoche(Coche coche);
    Coche BuscarPorId(int id);
    List<Coche> ListarTodo();
    void ActualizarCoche(Coche coche);
    void BorrarCoche(int id);
    Coche BuscarPorMatricula(string matricula);
}