using Microsoft.AspNetCore.Mvc;
using ProyectoDB_API.Services;

namespace ProyectoDB_API.Controllers
{
    [Route("Api/[Controller]")]
    [ApiController]
    public class PersonaController : Controller
    {
        private readonly IPersona _persona;

        public PersonaController(IPersona persona)
        {
            _persona = persona;
        }

        public IActionResult Get()
        {
            return Ok(_persona.GetAllPersonas());
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var obj = _persona.GetPersona(id);
            if(obj == null)
            {
                return NotFound("AYUDAAAAA ME PERDIIII");
            }
            else
            {
                return Ok(obj);
            }
        }
    }
}
