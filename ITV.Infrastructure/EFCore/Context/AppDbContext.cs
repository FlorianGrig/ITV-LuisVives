using Microsoft.EntityFrameworkCore;
using ITV.Domain.Entities;

namespace ITV.Infrastructure.EFCore.Context;

public class AppDbContext : DbContext
{
    public DbSet<Propietario> Propietarios { get; set; }
    public DbSet<Coche> Coches { get; set; }
    public DbSet<Cita> Citas { get; set; }
    
    public AppDbContext(DbContextOptions<AppDbContext>options) :base(options){}
}