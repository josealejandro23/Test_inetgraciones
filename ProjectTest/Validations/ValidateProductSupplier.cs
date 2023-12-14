using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;
using Test_jvarg361.Commons;

namespace Test_jvarg361.Validations
{
    //Validar si un supplier id indicado existe o no
    public class ValidateProductSupplier: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null || string.IsNullOrEmpty(value.ToString()))
            {
                return new ValidationResult("Supplier no definido");
            }

            try
            {
                //Se obtiene el id provisto y se valida que sí exista.
                int id = int.Parse(value.ToString());
                if (!ToolBox.checkSupplier(id))
                {
                    return new ValidationResult($"Supplier no válido");
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
