using Moq;
using ITV.Application.Services;
using ITV.Application.DTOs;
using ITV.Domain.Interfaces;
using ITV.Domain.Entities;

public class CitaServiceTests
{
    private Mock<ICitaRepository> _citaRepositoryMock;
    private Mock<ICocheRepository> _cocheRepositoryMock;
    private Mock<IPropietarioRepository> _propietarioRepositoryMock;
    private CitaService _citaService;
    

    [SetUp]
    public void Setup()
    {
        _citaRepositoryMock = new Mock<ICitaRepository>();
        _cocheRepositoryMock = new Mock<ICocheRepository>();
        _propietarioRepositoryMock = new Mock<IPropietarioRepository>();
        

        _citaService = new CitaService(
            _citaRepositoryMock.Object,
            _cocheRepositoryMock.Object,
            _propietarioRepositoryMock.Object
        );
        
    }
    
    [Test]
    public void CrearCita_MatriculaInvalida_LanzaExcepcion()
    {
        var dto = new CrearCitaDTO
        {
            DNI = "35976169Y",
            Matricula = "A123BC4",
            FechaMatriculacion = new DateTime(2020, 1, 1),
            FechaInspeccion = DateTime.Today.AddDays(5)
        };
        Assert.Throws<Exception>(() => _citaService.CrearCita(dto));
    }

    [Test]
    public void CrearCita_DNIInvalido_LanzaExcepcion()
    {
        var dto = new CrearCitaDTO
        {
            DNI = "383576469Z",
            Matricula = "1234ABC",
            FechaMatriculacion = new DateTime(2024, 05, 12),
            FechaInspeccion = DateTime.Today.AddDays(7)
        };
        Assert.Throws<Exception>(() => _citaService.CrearCita(dto));
    }

    [Test]
    public void CrearCita_FechaInspeccionInvalida_LanzaExcepcion()
    {
        var dto = new CrearCitaDTO
        {
            DNI = "35976169Y",
            Matricula = "1234ABC",
            FechaMatriculacion = new DateTime(2025, 03, 23),
            FechaInspeccion = new DateTime(2024, 04, 14)
        };
        Assert.Throws<Exception>(() => _citaService.CrearCita(dto));
    }

    [Test]
    public void CrearCia_VehiculoYaTieneCitaEseDia()
    {_citaRepositoryMock
            .Setup(r => r.BuscarPorMatriculaYFecha(It.IsAny<string>(), It.IsAny<DateTime>()))
            .Returns( new List<Cita> { new Cita { Coche = new Coche { Propietario = new Propietario() } } } );
        var dto = new CrearCitaDTO
        {
            DNI = "35976169Y",
            Matricula = "1234ABC",
            FechaMatriculacion = new DateTime(2017, 05, 12),
            FechaInspeccion = DateTime.Today
        };
        Assert.Throws<Exception>(() => _citaService.CrearCita(dto));
    }
}