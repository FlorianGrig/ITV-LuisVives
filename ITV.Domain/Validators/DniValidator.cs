using System.Text.RegularExpressions;

namespace ITV.Domain.Validators;

public class DniValidator {
    public bool EsValido(string dni)
    {
        string letras = "TRWAGMYFPDXBNJZSQVHLCUE";
        int numero = int.Parse(dni.Substring(0, 8));
        char letraDni = char.ToUpper(dni[^1]);
        return Regex.IsMatch(dni, @"^((\d{8})([a-z]|[A-Z]{1}))") && letras[numero%23] == letraDni;
    }
}