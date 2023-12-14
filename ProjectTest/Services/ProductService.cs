using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Data;
using Test_jvarg361.Commons;
using Test_jvarg361.DBContext;
using Test_jvarg361.Entitys;
using Test_jvarg361.Exceptions;

namespace Test_jvarg361.Services
{
    public class ProductService:IProducService
    {
        private readonly IApplicationContextDB _ContextDB;

        //se recibe por inyección de dependencias el contexto de DB
        public ProductService(IApplicationContextDB applicationContextDB)
        {
            _ContextDB = applicationContextDB;
        }

        /*-----------------------------------------------------------------------------------------------------------*/

        //función para almacenar un producto
        public async Task<Product> SaveProductAsync(Product product)
        {
            try
            {
                //se almacena el producto en db y se asientan los cambios
                await _ContextDB.Products.AddAsync(product);
                await _ContextDB.SaveChangesAsync(true);
            }
            catch (Exception)
            {
                throw;
            }
            return product;
        }

        /*-----------------------------------------------------------------------------------------------------------*/

        //función para obtener un producto mediante su id
        public async Task<Product> GetProductAsync(int id)
        {
            //se obtiene el producto coincidente al id recibido sino se lanza un error
            var product = await _ContextDB.Products.Where(x => x.Id == id).FirstOrDefaultAsync();
            if(product == null)
            {
                throw new ProductException("El producto no existe");
            }
            return product;
        }

        /*-----------------------------------------------------------------------------------------------------------*/

        //Función para retornar productos mediante variables de paginación
        public async Task<IEnumerable<Product>> getProductsByPagination(int page, int pageSize)
        {
            // Calcular el índice inicial para saber desde dónde tomar los datos
            int indiceInicio = (page - 1) * pageSize;

            //se toman tantos registros como se indique desde el índice calculado antes y se convierten en lista
            var datosPaginados = await _ContextDB.Products
                .Skip(indiceInicio)
                .Take(pageSize)
                .ToListAsync();

            //si no hay registros se lanza un error de lo contrario se retorna el resultado
            if(datosPaginados.Count == 0)
            {
                throw new ProductException("No existen productos almacenados.");
            }

            return datosPaginados;
        }

        /*-----------------------------------------------------------------------------------------------------------*/

        //Función que valida si el producto con X id ya existe
        public async Task<int> CheckProductByIdAsync(int id)
        {
            var productCheck = await _ContextDB.Products.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (productCheck != null)
            {
                throw new ProductException($"El producto ya existe en el sistema con id {productCheck.Id}");
            }
            return id;
        }

        /*-----------------------------------------------------------------------------------------------------------*/

        //Función para almacenar productos en masa
        public async Task<int> SaveProductBulk(IEnumerable<Product> products)
        {
            //variable auxiliar
            int productsInserted = 0;
            //se convierte el listado de productos en un dataset para ser pasado como un parámetro TVP a la DB
            DataTable productsTable = ToolBox.FormatDataTable(products);
            //Se establece una conexión con la db mediante using para eliminarla automáticamente al finalizar la consulta
            using (SqlConnection connection = _ContextDB.getDBConnection())
            {
                //se abre la conexión
                connection.Open();
                //se define el uso de un comando de Store procedure
                using (SqlCommand command = new SqlCommand("BulkProducts", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    //Se crea un objeto de parámetros que tendrá el datatable a insertar
                    SqlParameter parameter = new SqlParameter
                    {
                        ParameterName = "@Products",
                        Value = productsTable
                    };

                    //se añaden los parámetros a la consulta y se establece un timeout
                    command.Parameters.Add(parameter);
                    command.CommandTimeout = 1000;
                    //se ejecuta la sentencia de inserción de productos
                    productsInserted = await command.ExecuteNonQueryAsync();
                }
            }
            //Se retorna la cantidad de productos insertados en la DB
            return productsInserted;
        }
    }
}
