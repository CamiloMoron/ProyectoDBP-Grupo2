using Microsoft.AspNetCore.Mvc;
using ProyectoDB_API.Services;

namespace ProyectoDB_API.Controllers
{
    [Route("Api/[Controller]")]
    [ApiController]
    public class CategoriaController : Controller
    {
        private readonly ICategoria _categoria;

        public CategoriaController(ICategoria categoria)
        {
            _categoria = categoria;
        }
        public IActionResult Get()
        {
            return Ok(_categoria.GetAllCategorias());
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var obj = _categoria.GetCategorium(id);
            if(obj == null)
            {
                return NotFound("AAAAAAAAAAA AYUDAAAAAAA ME PERDIIIIIII");
            }
            else
            {
                return Ok(obj);
            }
        }

    }
}
