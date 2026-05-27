using ITV.Application.Services;
using ITV.Domain.Validators;

namespace ITV.Tests;

public class ValidatorsTests
{
    // Test 1 - Matrícula válida
    [Test]
    public void MatriculaValida_DebeRetornarTrue()
    {
        var validator = new MatriculaValidator();
        var resultado = validator.EsValida("1234ABC");
        Assert.That(resultado, Is.True);
    }

    // Test 2 - Matrícula inválida
    [Test]
    public void MatriculaInvalida_DebeRetornarFalse()
    {
        var validator = new MatriculaValidator();
        var resultado = validator.EsValida("ABC1234");
        Assert.That(resultado, Is.False);
    }
    
    // Test 3 - Dni válido
    [Test]
    public void DNIValido_DebeRetornarTrue()
    {
        var validator = new DniValidator();
        var resultado = validator.EsValido("35976169Y");
        Assert.That(resultado, Is.True);
    }
    
    // Test 4 - Dni inválido
    [Test]
    public void DniInvalido_DebeRetornarFalse()
    {
        var validator = new DniValidator();
        var resultado = validator.EsValido("383576469Z");
        Assert.That(resultado, Is.False);
    }
    
    // Test 5 - Fecha Inspeccion valida
    [Test]
    public void FechaInspeccionValida_DebeRetornarTrue()
    {
        var validator = new FechaValidator();
        var resultado = validator.FechaInspeccionValida(DateTime.Today.AddDays(10));
        Assert.That(resultado, Is.True);
    }
    
    // Test 6 - Fecha Inspeccion inválida
    [Test]
    public void FechaInspeccionInvalida_DebeRetornarFalse()
    {
        var validator = new FechaValidator();
        var resultado = validator.FechaInspeccionValida(new DateTime(2026, 05, 26));
        Assert.That(resultado, Is.False);
    }
    
    // Test 7 - Fehca Matriculacion valida
    [Test]
    public void FechaMatriculacionValida_DebeRetornarTrue()
    {
        var validator = new FechaValidator();
        var resultado = validator.FechaMatriculacionValida(new DateTime(2026, 05, 25));
        Assert.That(resultado, Is.True);
    }
    
    // Test 8 - Fecha Matriculacion Invalida
    [Test]
    public void FechaMatriculacionInvalida_DebeRetornarFalse()
    {
        var validator = new FechaValidator();
        var resultado = validator.FechaMatriculacionValida(new DateTime(2027, 07, 13));
        Assert.That(resultado, Is.False);
    }
    
    
}