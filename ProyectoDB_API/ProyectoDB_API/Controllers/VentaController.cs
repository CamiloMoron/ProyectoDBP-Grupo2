using Microsoft.AspNetCore.Mvc;
using ProyectoDB_API.Models;
using ProyectoDB_API.Services;

namespace ProyectoDB_API.Controllers
{
    [Route("Api/[Controller]")]
    [ApiController]
    public class VentaController : Controller
    {
        private readonly IVenta _venta;

        public VentaController(IVenta venta)
        {
            _venta = venta;
        }

        public IActionResult Get()
        {
            return Ok(_venta.GetAllVentas());
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var obj = _venta.GetVenta(id);
            if(obj == null)
            {
                return NotFound("ME PERDIIIIII AYUDAMEE AAAA");
            }
            else
            {
                return Ok(obj);
            }
        }
        [HttpPost("add")]
        public IActionResult Agregar(TbVentum venta)
        {
            _venta.add(venta);
            return CreatedAtAction(nameof(Agregar), venta);
        }
    }
}
