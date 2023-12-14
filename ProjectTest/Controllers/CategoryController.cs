using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using Test_jvarg361.Entitys;
using Test_jvarg361.Commons;
using Test_jvarg361.Services;
using Newtonsoft.Json.Linq;
using Test_jvarg361.Exceptions;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Test_jvarg361.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        // GET: api/<Category>
        //retorna las categorías creadas
        [HttpGet]
        public async Task<IActionResult> GetCategory()
        {
            try
            {
                //consultar las categorias y retornarlas
                var JResult = await categoryService.GetCategoriesAsync();
                return Ok(JResult);
            }
            catch (Exception e)
            {
                return StatusCode(500, new { Message = e.Message });
            }
        }

        /*-----------------------------------------------------------------------------------------------------------*/

        // POST api/<Category>
        //crea una categoría
        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] Category requestedData)
        {
            //Se valida si el objeto recibido es válido con el modelo declarado
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            try
            {
                //se crea la categoría
                var Response = await categoryService.SaveCategoryAsync(requestedData);
                return Ok(Response);
            }
            catch (CategoryException e)
            {
                //en caso de error del tipo categoría se captura
                return StatusCode(400, new {Message = e.Message});
            }
            catch (Exception e)
            {
                return StatusCode(500, new { Message  = e.Message });
            }
        }
    }
}
