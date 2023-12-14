using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Test_jvarg361.Commons;
using Test_jvarg361.Entitys;
using Test_jvarg361.Exceptions;
using Test_jvarg361.Models;
using Test_jvarg361.Services;
using Test_jvarg361.Validations;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Test_jvarg361.Controllers
{
    [Route("api")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProducService producService;
        private readonly ICategoryService categoryService;
        private readonly ISupplierService supplierService;

        //Cargamos los servicios que estarán disponibles para el controlador
        public ProductController(IProducService producService, ICategoryService categoryService, ISupplierService supplierService)
        {
            this.producService = producService;
            this.categoryService = categoryService;
            this.supplierService = supplierService;
        }

        //Permite obtener productos por paginación
        [HttpGet]
        [Route("Products")]
        public async Task<IActionResult> GetProductPagination(int page, int pageSize)
        {
            //se validan que los valores de paginación sean correctos
            if(page <= 0 || pageSize <= 0) return BadRequest(new { message = "La paginación debe ser mayor a cero." });
            try
            {
                //consultamos los productos
                var products = await producService.getProductsByPagination(page, pageSize);
                return Ok(products);
            }
            //Se capturan las excepciones si suceden
            catch (ProductException ex)
            {
                return StatusCode(404, new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        /*-----------------------------------------------------------------------------------------------------------*/

        //Permite obtener un producto indicando su id mediante un identificador de recursos
        [Route("Products/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetProductById(int id)
        {
            try
            {
                //se consulta el producto correspondiente por id
                var product = await producService.GetProductAsync(id);
                return Ok(product);
            }
            catch (ProductException ex)
            {
                return StatusCode(404, new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        /*-----------------------------------------------------------------------------------------------------------*/

        // POST api/<Product>
        //permite crear un producto a partir de un body de producto
        [HttpPost]
        [Route("Product")]
        public async Task<IActionResult> createProductAsync([FromBody] Product product)
        {
            try
            {
                //se almacena el producto recibido
                var response = await producService.SaveProductAsync(product);
                return Ok(response);
            }
            catch (ProductException ex)
            {
                return StatusCode(400, new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message, innerException = ex.InnerException});
            }
        }

        /*-----------------------------------------------------------------------------------------------------------*/

        // POST api/<Products>
        //permite crear N productos mediante la definición de categorías y cantidades en el body request
        [Route("Products")]
        [HttpPost]
        public async Task<IActionResult> createProductBulkAsync([FromBody] ProductsBulk requestedData)
        {
            try
            {
                //se obtienen los ids de las categorías mencionadas en el body request
                IEnumerable<int> categoriesIds = await categoryService.getCategoriesIds(requestedData.Categories);
                //se obtienen todos los id de la tabla suppliers
                IEnumerable<int> suppliersIds = await supplierService.getSuppliersIds();
                //Se crean los productos aleatoriamente
                IEnumerable<Product> products = await ToolBox.GenerateRandomProducts(requestedData.Quantity, categoriesIds, suppliersIds);
                //se almacenan los productos en la db y se responde con la cantidad de productos creados
                int quantityCreated = await producService.SaveProductBulk(products);
                return Ok(new { message = $"Productos creados correctamente: {quantityCreated}", quantity = quantityCreated });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message, innerException = ex.InnerException });
            }
        }
    }
}
