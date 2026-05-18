using ITV.Domain.Entities;
using ITV.Domain.Interfaces;
using ITV.Infrastructure.EFCore.Context;
using Microsoft.EntityFrameworkCore;

namespace ITV.Infrastructure.EFCore;

public class CItaRepositoryEfCore : ICitaRepository
{
    private readonly AppDbContext _context;

    public CItaRepositoryEfCore(AppDbContext context)
    {
        _context = context;
    }

    public void CrearCita(Cita cita)
    {
        _context.Citas.Add(cita);
        _context.SaveChanges();
    }

    public Cita BuscarPorId(int id)
    {
        return _context.Citas.Find(id) ??
               throw new Exception("Cita no encontrada.");
    }
    
    public List<Cita> ListarTodo()
    {
        return _context.Citas.ToList();
    }

    public void ActualizarCita(Cita cita)
    {
        _context.Citas.Update(cita);
        _context.SaveChanges();
    }

    public void BorrarCita(int id)
    {
        var cita = BuscarPorId(id);
        if (cita != null)
        {
            _context.Citas.Remove(cita);
            _context.SaveChanges();
        }
    }

    public List<Cita> BuscarPorMatriculaYFecha(string matricula, DateTime fecha)
    {
        return _context.Citas
            .Include(c => c.Coche)
            .Where(c => c.Coche.Matricula == matricula
                        && c.FechaInspeccion == fecha)
            .ToList();

    }

    public List<Cita> BuscarPorDniYFecha(string dni, DateTime fecha)
    {
        return _context.Citas
            .Include(c =>c.Coche)
            .ThenInclude(co => co.Propietario)
            .Where(c=>c.Coche.Propietario.DNI == dni 
                      && c.FechaInspeccion == fecha)
            .ToList();
    }
}