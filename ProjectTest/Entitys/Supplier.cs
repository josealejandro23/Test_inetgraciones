using System.ComponentModel.DataAnnotations;

namespace Test_jvarg361.Entitys
{
    //Definición del objeto Supplier que derivará en una tabla mediante Entity Framework Core
    public class Supplier
    {
        public int Id { get; set; }
        [StringLength(100)]
        [Required]
        public string CompanyName { get; set; }
        [StringLength(100)]
        [Required]
        public string Country { get; set; }
        public List<Product> Products { get; set; }
    }
}
