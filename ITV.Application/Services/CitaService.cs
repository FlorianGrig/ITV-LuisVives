using ITV.Application.DTOs;
using ITV.Domain.Entities;
using ITV.Domain.Interfaces;
using ITV.Domain.Validators;

namespace ITV.Application.Services;

public class CitaService
{
    private readonly ICitaRepository _citaRepository;
    private readonly ICocheRepository _cocheRepository;
    private readonly IPropietarioRepository _propietarioRepository;

    public CitaService(ICitaRepository citaRepository, 
        ICocheRepository cocheRepository,
        IPropietarioRepository propietarioRepository)
    {
        _citaRepository = citaRepository;
        _cocheRepository = cocheRepository;
        _propietarioRepository = propietarioRepository;
    }

    public void CrearCita(CrearCitaDTO dto)
    {
        var dniValidator = new DniValidator();
        var matriculaValidator = new MatriculaValidator();
        var fechaValidator = new FechaValidator();

        if (!dniValidator.EsValido(dto.DNI))
            throw new Exception("El DNI no es valido.");
        if (!matriculaValidator.EsValida(dto.Matricula))
            throw new Exception("La matricula no es valida.");
        if (!fechaValidator.FechaMatriculacionValida(dto.FechaMatriculacion))
            throw new Exception("La fecha de matriculacion no es valida");
        if (!fechaValidator.FechaInspeccionValida(dto.FechaInspeccion))
            throw new Exception("La fecha de inspeccion no es valida.");
        
        
        var citaExistente = _citaRepository
            .BuscarPorMatriculaYFecha(dto.Matricula, dto.FechaInspeccion);
        var maximoVehiculos = _citaRepository
            .BuscarPorDniYFecha(dto.DNI, dto.FechaInspeccion);
        var propietario = _propietarioRepository.BuscarPorDni(dto.DNI);
        var coche = _cocheRepository.BuscarPorMatricula(dto.Matricula);

        if (citaExistente.Count != 0)
            throw new Exception("Este vehiculo ya tiene cita para ese dia.");
        if (maximoVehiculos.Count >= 3)
            throw new Exception("Hay mas de 3 vehiculos con cita el mismo dia.");
        if (propietario == null)
        {
            propietario = new Propietario
            {
                Nombre = dto.Nombre,
                Apellido = dto.Apellidos,
                DNI = dto.DNI };
            _propietarioRepository.CrearPropietario(propietario);
        }

        if (coche == null)
        {
            coche = new Coche
            {
                Matricula = dto.Matricula,
                Marca = dto.Marca,
                Modelo = dto.Modelo,
                FechaMatriculacion = dto.FechaMatriculacion,
                TipoMotor = dto.TipoMotor,
                Propietario = propietario.Id};
            _cocheRepository.CrearCoche(coche);
        }

        var cita = new Cita
        {
            FechaInspeccion = dto.FechaInspeccion,
            CocheId = coche.Id,
            Coche = null
        };
        _citaRepository.CrearCita(cita);
    }
}