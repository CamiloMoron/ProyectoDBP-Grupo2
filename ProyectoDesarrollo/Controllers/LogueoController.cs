using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using ProyectoDesarrollo.Models;
using ProyectoDesarrollo.Servicios;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ProyectoDesarrollo.Controllers
{
    public class LogueoController : Controller
    {
        private readonly IPersona _persona;

        public LogueoController(IPersona persona) 
        {
            _persona = persona;
        }
        public IActionResult Index()
        {
            return View();
        }

        //El parametro tipo es enviado por el index
        [Route("Logueo/Ingresar/{tipo}")]
        public IActionResult Ingresar(int tipo) //Cuando ya tienes una cuenta
        {
            ViewData["tipo"] = tipo;
            return View();
        }

        public IActionResult Registrar() //Para crear una nueva cuenta
        {
            return View();
        }

        //Debe ser llamada desde el Registrar
        public IActionResult Agregar(TbPersona persona) //Para agregar una persona a la base de datos
        {
            _persona.addPersonaUsuario(persona);
            return RedirectToAction("Index");
        }

        [Route("Tienda/entrarComoInvitado")]
        public IActionResult entrarComoInvitado() 
        {
            return RedirectToAction("Ingresar", "Tienda", new { @idCliente = -1 });
        }

        //Debe ser llamada desde Ingresar
        public IActionResult Login(TempPersona tempPersona) //Para validar las credenciales e ir al menu correspondiente   
        {
            if (tempPersona.isValid())
            {
                string usuario = tempPersona.usuario,
                    clave = tempPersona.clave,
                    tipo = tempPersona.tipo;

                if (_persona.personaExists(usuario, clave, tipo))
                {
                    if (tipo == "Administrador")
                    {
                        return RedirectToAction("Index", "AdminMenu"); //index del admin
                    }
                    else if (tipo == "Cliente") 
                    {
                        //return RedirectToAction("Index", "Tienda"); //index del admin
                        return RedirectToAction("Ingresar", "Tienda", new { @idCliente = _persona.getLoggedPersona(usuario, clave, tipo).IdPersona });
                    }
                    else
                    {
                        return RedirectToAction("Index", "Logueo"); //index de logueo
                    }

                }
                else
                {
                    return RedirectToAction("Ingresar", "Logueo", new { @tipo = tempPersona.getTipoAsInt() });
                }
            }
            else 
            {
                return RedirectToAction("Ingresar", "Logueo", new { @tipo = tempPersona.getTipoAsInt() });
            }
        }
    }
    /*
    public IActionResult EvaluacionPractica()
    {
        return View(_persona.getAllClientes());
    }
    */
}