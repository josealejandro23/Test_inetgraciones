using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Test_jvarg361.Controllers;
using Test_jvarg361.DBContext;
using Test_jvarg361.Entitys;
using Test_jvarg361.Models;
using Test_jvarg361.Services;
using Xunit.Abstractions;

namespace XUnitTestJvarg
{
    public class ProductTest
    {
        private readonly IApplicationContextDB contextoDB;
        private readonly IProducService ProductService;
        private readonly ICategoryService categoryService;
        private readonly ISupplierService supplierService;
        private readonly ProductController ProductController;
        private readonly ITestOutputHelper _output;

        public ProductTest(ITestOutputHelper output)
        {
            contextoDB = new ApplicationDbContext();
            ProductService = new ProductService(contextoDB);
            categoryService = new CategoryService(contextoDB);
            supplierService = new SupplierService(contextoDB);
            ProductController = new ProductController(ProductService, categoryService, supplierService);
        }

        //validar la creaci�n de productos en masa
        [Fact]
        public async void CreateProductsBulk()
        {
            //definimos las categorias y cantidad de productos a crear
            string[] categories = { "servers", "cloud" };
            int quantityToCreate = 100;
            //creamos el body a enviar
            ProductsBulk body = new ProductsBulk
            {
                Quantity = quantityToCreate,
                Categories = categories
            };
            //ejecutamos la acci�n
            var result = await ProductController.createProductBulkAsync(body);
            //validamos que sea un resultado exitoso
            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
            var obj = (OkObjectResult)result;
            Assert.NotNull(obj);
            //convertimos la respuesta a un JSONObject
            var JRes = JObject.FromObject(obj.Value);
            //la cantidad retornada debe ser igual a la enviada, lo que indica que la transacci�n fue exitosa
            int quantityCreated = (int)JRes["quantity"];
            Assert.True(quantityCreated == quantityToCreate);
        }

        //validar la paginaci�n de productos, debe ejecutarse despu�s de la prueba CreateProductsBulk
        [Fact]
        public async void getProductsPagination()
        {
            //definimos tama�os de p�ginas
            var page = 1;
            var pageSize = 10;
            //ejecutamos la acci�n
            var result = await ProductController.GetProductPagination(page, pageSize);
            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
            var obj = (OkObjectResult)result;
            Assert.NotNull(obj);
            //convertimos la respuesta a un Array
            var JRes = JArray.FromObject(obj.Value);
            //validamos que el conteo de productos sea igual al solicitado
            //esto solo es v�lido si el pagesize es menor a la cantidad de productos creados
            //por lo que se recomienda ejecutar primero la prueva previa
            Assert.True(JRes.Count == pageSize);
            var JItem = (JObject)JRes.First();
            int productId = (int)JItem.GetValue("Id");
            Assert.True(productId > 0);
        }

        //validar la obtenci�n de un �nico producto, se debe ejecutar despu�s de getProductsPagination
        [Fact]
        public async void ValidateOneProduct()
        {
            //se debe obtener un id de la base de datos
            int productId = 611530;
            var result = await ProductController.GetProductById(productId);
            //validamos que sea un resultado exitoso
            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
            var obj = (OkObjectResult)result;
            Assert.NotNull(obj);
            //convertimos la respuesta a un JSONObject
            var JRes = JObject.FromObject(obj.Value);
            //el id recibido debe ser igual al enviado
            int idReturned = (int)JRes.GetValue("Id");
            Assert.True(idReturned == productId);
        }
    }
}