using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;
using Test_jvarg361.Commons;

namespace Test_jvarg361.Validations
{
    //se crea una validación de atributo para validar que las categorías indicadas en el objeto ProductBulk si existan
    public class CheckCategories: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null || string.IsNullOrEmpty(value.ToString()))
            {
                return new ValidationResult("Categorías no definidas");
            }

            //Se extraen las categorías recibidas en el body
            IEnumerable<string> categories = (IEnumerable<string>)value;
            //Se validan que los nombres de las categorías sean correctos y todas existan
            if (!ToolBox.checkCategories(categories))
            {
                return new ValidationResult($"Categorías no válidas o inexistentes");
            }
            return ValidationResult.Success;
        }
    }
}
