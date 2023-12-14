using Test_jvarg361.Entitys;

namespace Test_jvarg361.Services
{
    //Se define una interfaz para separar la capa de aplicación de la capa de servicios y de acceso a datos
    public interface ICategoryService
    {
        Task<List<Category>> GetCategoriesAsync();
        Task<IEnumerable<int>> getCategoriesIds(IEnumerable<string> categorias);
        Task<Category> SaveCategoryAsync(Category category);
    }
}
