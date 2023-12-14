using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Runtime.Remoting;
using System.Text.Json.Nodes;
using Test_jvarg361.Controllers;
using Test_jvarg361.DBContext;
using Test_jvarg361.Entitys;
using Test_jvarg361.Services;
using Xunit.Abstractions;


namespace XUnitTestJvarg
{
    public class CategoryTest
    {
        private readonly IApplicationContextDB contextoDB;
        private readonly ICategoryService categoryService;
        private readonly CategoryController categoryController;
        private readonly ITestOutputHelper _output;

        //la inyección permite imprimir en consola de ser necesario
        public CategoryTest(ITestOutputHelper output)
        {
            contextoDB = new ApplicationDbContext();
            categoryService = new CategoryService(contextoDB);
            categoryController = new CategoryController(categoryService);
            _output = output;
        }

        [Fact]
        public async void getCategories()
        {
            var result = await categoryController.GetCategory();
            Assert.IsType<OkObjectResult>(result);
            var obj = (OkObjectResult)result;
            Assert.NotNull(obj);
            var JRes = JArray.FromObject(obj.Value);
            //Se valida que la respuesta traiga varios objeto
            Assert.True(JRes.Count > 0);
        }

        [Fact]
        public async void createCategory()
        {
            //asegurarse que no exista ya una categoría con este nombre o la prueba fallará ya que no es posible repetir categorías
            string nombre = "test8";
            //se crea un body para enviar 
            Category body = new Category{
                Name = nombre,
                Description = "categoria test",
                Picture = "https://www.google.com"
            };

            var result = await categoryController.CreateCategory(body);
            Assert.IsType<OkObjectResult>(result);
            var obj = (OkObjectResult)result;
            Assert.NotNull(obj);
            //se parsea el objeto como json object y se extraen sus propiedades
            JObject JRes = JObject.FromObject(obj.Value);
            string name = (string)JRes.GetValue("Name");
            Assert.True(name == nombre);
            Assert.True((int)JRes["Id"] > 0);
        }
    }
}