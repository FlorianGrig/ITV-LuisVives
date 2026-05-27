namespace ITV.Domain.Validators;

public class FechaValidator {
    public bool FechaMatriculacionValida(DateTime fechaMatriculacion)
    {
        return fechaMatriculacion < DateTime.Today;
    }

    public bool FechaInspeccionValida(DateTime fechaInspeccion) {
        return fechaInspeccion > DateTime.Today && fechaInspeccion <= DateTime.Today.AddDays(30);
    }
}