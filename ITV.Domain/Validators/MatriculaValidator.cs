using System.Text.RegularExpressions;

namespace ITV.Domain.Validators;

public class MatriculaValidator{
    public bool EsValida(string Matricula)
    {
        return Regex.IsMatch(Matricula, @"^\d{4}[A-Z]{3}$");
    }
}