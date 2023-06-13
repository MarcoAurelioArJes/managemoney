using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace ManageMoney.Helpers
{
    public class CustomValidate
    {
        public static ValidationResult ValidaData(DateTime data)
        {
            return (data == DateTime.MinValue || data == null)
                ? new ValidationResult("Informe uma data válida!")
                : ValidationResult.Success;
        }

        public static ValidationResult ValidaValor(decimal valor)
        {
            return (valor == decimal.Zero)
                ? new ValidationResult("Informe um valor maior que zero!")
                : ValidationResult.Success;
        }

        public static ValidationResult ValidaCpf(string cpf)
        {
            var regex = new Regex(@"([0-9]{2}[\.]?[0-9]{3}[\.]?[0-9]{3}[\/]?[0-9]{4}[-]?[0-9]{2})|([0-9]{3}[\.]?[0-9]{3}[\.]?[0-9]{3}[-]?[0-9]{2})");
            if (string.IsNullOrWhiteSpace(cpf))
                return new ValidationResult("É necessário informar um CPF");

            return !regex.IsMatch(cpf)
                ? new ValidationResult("Por favor informe um CPF válido")
                : ValidationResult.Success;
        }
    }
}
