using Microsoft.AspNetCore.Mvc;
using ProyectoDB_API.Models;
using ProyectoDB_API.Services;

namespace ProyectoDB_API.Controllers
{
    [Route("Api/[Controller]")]
    [ApiController]
    public class DetalleVentaController : Controller
    {
        private readonly IDetalleVenta _detalle;
        
        public DetalleVentaController(IDetalleVenta detalle)
        {
            _detalle = detalle;
        }
        public IActionResult Get()
        {
            return Ok(_detalle.GetAllDetalleVenta());
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var obj = _detalle.GetDetalleVentum(id);
            if(obj == null)
            {
                return NotFound("AYUDAAAAA ME PERDIIIIIII");
            }
            else
            {
                return Ok(obj);
            }
        }
        [HttpPost("add")]
        public IActionResult Agregar(TbDetalleVentum detalleVenta)
        {
            _detalle.add(detalleVenta);
            return CreatedAtAction(nameof(Agregar), detalleVenta);
        }
    }
}
