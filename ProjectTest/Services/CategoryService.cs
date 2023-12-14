using Microsoft.EntityFrameworkCore;
using Test_jvarg361.DBContext;
using Test_jvarg361.Entitys;
using Test_jvarg361.Exceptions;

namespace Test_jvarg361.Services
{
    public class CategoryService: ICategoryService
    {
        //se define el objeto de base de datos
        private readonly IApplicationContextDB _ContextDB;

        //Se obtiene por inyección de dependencias el contexto de DB
        public CategoryService(IApplicationContextDB applicationContextDB)
        {
            _ContextDB = applicationContextDB;
        }

        /*-----------------------------------------------------------------------------------------------------------*/

        //Función para guardar una categoría
        public async Task<Category> SaveCategoryAsync(Category category)
        {
            //se valida si no existe ya la categoría, de ser así se lanza una excepción personalizada
            var categories = await _ContextDB.Categories.Where(x => x.Name == category.Name).ToListAsync();
            if(categories.Any())
            {
                throw new CategoryException("La categoría a crear ya existe");
            }
            //se almacena la categoría
            await _ContextDB.Categories.AddAsync(category);
            await _ContextDB.SaveChangesAsync(true);
            return category;
        }

        /*-----------------------------------------------------------------------------------------------------------*/

        //función para obtener el listado de categorías
        public async Task<List<Category>> GetCategoriesAsync()
        {
            //se obtienen todas las categorías y se retornan
            var categories = await _ContextDB.Categories.ToListAsync();
            return categories;
        }

        /*-----------------------------------------------------------------------------------------------------------*/

        //Función para obtener las categorías a partir de sus nombres
        public async Task<IEnumerable<int>> getCategoriesIds(IEnumerable<string> categorias)
        {
            //se pasan los nombres a minúsculas
            List<string> lista = categorias.Select(x => x.ToLower()).ToList();
            //se obtienen todas las categorías que coinciden con los nombres recibidos
            var categoriesDB = await _ContextDB.Categories.Where(x => lista.Contains(x.Name)).ToListAsync();
            //se retornan solamente los ids de las categorías correspondientes
            return categoriesDB.Select(x => x.Id).ToList();
        }
    }
}
