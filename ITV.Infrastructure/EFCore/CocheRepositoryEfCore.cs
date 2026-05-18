using ITV.Domain.Entities;
using ITV.Domain.Interfaces;
using ITV.Infrastructure.EFCore.Context;

namespace ITV.Infrastructure.EFCore;

public class CocheRepositoryEfCore : ICocheRepository
{
    private readonly AppDbContext _context;

    public CocheRepositoryEfCore(AppDbContext context)
    {
        _context = context;
    }
    public void CrearCoche(Coche coche)
    {
        _context.Coches.Add(coche);
        _context.SaveChanges();
    }

    public Coche BuscarPorId(int id)
    {
        return _context.Coches.Find(id) ?? 
               throw new Exception("Coche no encontrado");
    }

    public List<Coche> ListarTodo()
    {
        return _context.Coches.ToList();
    }

    public void ActualizarCoche(Coche coche)
    {
        _context.Coches.Update(coche);
        _context.SaveChanges();
    }

    public void BorrarCoche(int id)
    {
        var coche = BuscarPorId(id);
        if (coche != null)
        {
            _context.Coches.Remove(coche);
            _context.SaveChanges();
        }
    }

    public Coche BuscarPorMatricula(string matricula)
    {
        return _context.Coches
            .FirstOrDefault(c => c.Matricula == matricula) ?? throw new Exception("Matricula no encontrada.");
    }
}