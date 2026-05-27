using ITV.Domain.Entities;

namespace ITV.Domain.Interfaces;

public interface IPropietarioRepository {
    void CrearPropietario(Propietario propietario);
    Propietario BuscarPorId(int id);
    List<Propietario> ListarTodo();
    void ActualizarPropietario(Propietario propietario);
    void BorrarPropietario(int id);
    Propietario BuscarPorDni(string dni);
}