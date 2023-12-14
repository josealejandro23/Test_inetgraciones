using System.ComponentModel.DataAnnotations;
using Test_jvarg361.Validations;

namespace Test_jvarg361.Models
{
    //Definición de una clase que se utilizará para crear productos en masa
    public class ProductsBulk
    {
        //se aplican validaciones personalizadas para garantizar los datos recibidos
        [Required]
        [CheckValueQuantity] //validar que el quantity sea positivo
        public int Quantity { get; set; }
        [Required]
        [CheckCategories] //validar que las categorías sí existan
        public IEnumerable<string> Categories { get; set; }
    }
}
