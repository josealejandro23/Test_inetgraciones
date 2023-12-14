using System.ComponentModel.DataAnnotations;
using Test_jvarg361.Validations;

namespace Test_jvarg361.Entitys
{
    //Definición del objeto Product que derivará en una tabla mediante Entity Framework Core
    public class Product
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        private string CreationDate = DateTime.Now.ToString();
        [Required]
        [ValidateProductSupplier]
        public int SupplierId { get; set; }
        private Supplier Supplier { get; set; } //propiedad de navegación
        [Required]
        [ValidateProductCategory]
        public int CategoryId { get; set; }
        private Category Category { get; set; }
        [Required]
        public int QuantityPerUnit { get; set; }
        [Required]
        public int UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
    }
}
