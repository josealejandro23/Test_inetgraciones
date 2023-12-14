using Test_jvarg361.Entitys;

namespace Test_jvarg361.Services
{
    //Se define una interfaz para separar la capa de aplicación de la capa de servicios y de acceso a datos
    public interface IProducService
    {
        Task<int> CheckProductByIdAsync(int id);
        Task<Product> GetProductAsync(int id);
        Task<IEnumerable<Product>> getProductsByPagination(int pagina, int pageSize);
        Task<Product> SaveProductAsync(Product product);
        Task<int> SaveProductBulk(IEnumerable<Product> products);
    }
}
