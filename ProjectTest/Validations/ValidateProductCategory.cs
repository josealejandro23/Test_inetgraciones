using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;
using Test_jvarg361.Commons;

namespace Test_jvarg361.Validations
{
    //Validación para verificar que el id indicado de una categoría sí exista
    public class ValidateProductCategory: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null || string.IsNullOrEmpty(value.ToString()))
            {
                return new ValidationResult("Categoría no definida.");
            }

            //se valida que la categoría indicada para crear un producto sí exista
            int id = int.Parse(value.ToString());
            if (!ToolBox.checkCategorie(id))
            {
                return new ValidationResult($"Categoría no válida");
            }
            return ValidationResult.Success;
        }
    }
}
