using ITV.Domain.Entities;
using ITV.Domain.Interfaces;
using ITV.Infrastructure.EFCore.Context;


namespace ITV.Infrastructure.EFCore;

public class PropietarioRepositoryEfCore : IPropietarioRepository
{
    private readonly AppDbContext _context;

    public PropietarioRepositoryEfCore(AppDbContext context)
    {
        _context = context;
    }

    public void CrearPropietario(Propietario propietario)
    {
        _context.Propietarios.Add(propietario);
        _context.SaveChanges();
    }

    public Propietario BuscarPorId(int id)
    {
        return _context.Propietarios.Find(id) ?? 
               throw new Exception("Propietario no encontrado");
    }

    public List<Propietario> ListarTodo()
    {
        return _context.Propietarios.ToList();
    }

    public void ActualizarPropietario(Propietario propietario)
    {
        _context.Propietarios.Update(propietario);
        _context.SaveChanges();
    }

    public void BorrarPropietario(int id)
    {
        var propietario = BuscarPorId(id);
        if (propietario != null)
        {
            _context.Propietarios.Remove(propietario);
            _context.SaveChanges();
        }
    }

    public Propietario BuscarPorDni(string dni)
    {
        return _context.Propietarios
            .FirstOrDefault(p => p.DNI == dni) ?? throw new Exception("Propietario no encontrado.");
    }

}