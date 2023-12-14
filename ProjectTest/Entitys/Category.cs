using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Test_jvarg361.Entitys
{
    //Definición del objeto category que derivará en una tabla mediante Entity Framework Core
    public class Category
    {
        public int Id { get; set; }
        //mediante anotaciones de datos definimos atributos de los campos
        //Preferible sobre api fluence porque nos permite validaciones en tiempo de ejecución sobre la data y no al momento de insertar
        [StringLength(50)]
        [Required]
        public string Name { get; set; }
        [StringLength(250)]
        [Required]
        public string Description { get; set; }
        [Unicode]//para almacenar la url de una imágen representativa de la categoría
        public string Picture { get; set; }
        //cargamos los productos de la categoría
        private List<Product> Products { get; set; }
    }
}
