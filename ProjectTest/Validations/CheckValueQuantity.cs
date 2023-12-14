using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;
using Test_jvarg361.Commons;

namespace Test_jvarg361.Validations
{
    //Validación para constatar que el quantity ingresado en el objeto product bulk sea mayor a cero
    public class CheckValueQuantity: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            try
            {
                //Se valida que el valor sea un número mayor a cero
                int cantidad = (int)value;
                if (cantidad <= 0)
                {
                    return new ValidationResult($"Debe indicar un quantity mayor a cero.");
                }
                return ValidationResult.Success;
            }
            catch (Exception e)
            {
                return new ValidationResult($"Error en la definición del objeto {e.Message}");
            }
        }
    }
}
