using Microsoft.AspNetCore.Mvc;
using ProyectoDB_API.Models;
using ProyectoDB_API.Services;

namespace ProyectoDB_API.Controllers
{
    [Route("Api/[Controller]")]
    [ApiController]
    public class ProductoController : Controller
    {
        private readonly IProducto _producto;

        public ProductoController(IProducto producto)
        {
            _producto = producto;
        }
        public IActionResult Get()
        {
            return Ok(_producto.GetAllProductos());
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var obj = _producto.GetProducto(id);
            if(obj == null)
            {
                return NotFound("ME PERDIIIII AYUDAAAAAAAAAAA");
            }
            else
            {
                return Ok(obj);
            }
        }
        [HttpPut("modificar")]
        public IActionResult Put(TbProducto producto)
        {
            _producto.ModifyProducto(producto);
            return Ok(producto);
        }
    }
}
