using System.Data;
using Dapper;
using ITV.Domain.Entities;
using ITV.Domain.Interfaces;


namespace ITV.Infrastructure.Dapper;

public class CitaRepositoryDapper : ICitaRepository
{
    private readonly IDbConnection _connection;
    public CitaRepositoryDapper(IDbConnection connection)
    {
        _connection = connection;
    }
    public void CrearCita(Cita cita)
    {
        _connection.Execute("INSERT INTO Citas(FechaInspeccion, ResultadoInspeccion, CocheId) " +
                            "VALUES (@FechaInspeccion, @ResultadoInspeccion, @CocheId)" ,cita);
    }
    
    public Cita BuscarPorId(int id)
    {
        
       return _connection.QueryFirstOrDefault<Cita>("Select * FROM Citas where Id=@Id", new{Id=id}) ??
              throw new Exception("Cita no encontrada.");
    }

    public List<Cita> ListarTodo()
    {
       return _connection.Query<Cita>("SELECT * FROM Citas").ToList();
    }

    public void ActualizarCita(Cita cita)
    {
        _connection.Execute(
            "UPDATE Citas SET FechaInspeccion = @FechaInspeccion, " +
            "ResultadoInspeccion= @ResultadoInspeccion, " +
            "CocheId=@CocheId WHERE Id=@Id",
            cita);
    }

    public void BorrarCita(int id)
    {
        _connection.Execute("DELETE FROM Citas WHERE Id=@Id", new {Id=id});
    }

    public List<Cita> BuscarPorMatriculaYFecha(string matricula, DateTime fecha)
    {
        return _connection.Query<Cita>(
            "SELECT Citas.* From Citas JOIN Coches ON Citas.CocheId = Coches.Id " +
            "WHERE Coches.Matricula = @Matricula " +
            "AND Citas.FechaInspeccion = @Fecha", new{Matricula = matricula, Fecha= fecha}
            ).ToList();
    }

    public List<Cita> BuscarPorDniYFecha(string dni, DateTime fecha)
    {
        return _connection.Query<Cita>(
            "SELECT Citas.* FROM Citas JOIN Coches ON Citas.CocheId= Coches.Id " +
            "JOIN Propietarios ON Coches.PropietarioId = Propietarios.Id " +
            "WHERE Propietarios.Dni = @Dni " +
            "AND Citas.FechaInspeccion = @Fecha", new { Dni = dni, Fecha = fecha }
        ).ToList();
    }
}