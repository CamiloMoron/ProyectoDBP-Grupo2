using Microsoft.AspNetCore.Mvc;
using ProyectoDesarrollo.Models;
using ProyectoDesarrollo.Servicios;

namespace ProyectoDesarrollo.Controllers
{
    public class AdminMenuController : Controller
    {
        private readonly IPersona _persona;
        private readonly IProducto _producto;
        private readonly ICategoria _categoria;

        public AdminMenuController(IPersona persona, IProducto producto, ICategoria categoria)
        {
            this._persona = persona;
            this._producto = producto;
            this._categoria = categoria;
        }

        public IActionResult Index()
        {
            return View();
        }

        //LLAMADA SOLO PARA VER LA LISTA DE PRODUCTOS
        [Route("AdminMenu/verProductos")]
        public IActionResult verProductos()
        {
            ViewData["searchData"] = null;
            return View(_producto.GetAllProductos());
        }
        public IActionResult verPersonas()
        {
            return View(_persona.GetAllPersona());
        }
        public IActionResult verCategorias()
        {
            return View(_categoria.GetAllCategorias());
        }
        //PANTALLA DE AGREGACION PARA CLIENTE, PRODUCTO O CATEGORIA, sera llamado desde su "ver" respectivo
        [Route("AdminMenu/verAgregacion/{tipo}")]
        public IActionResult verAgregacion(int tipo) // 1--> cliente, 2 --> producto, 3 --> categoria 
        {
            //No permitas que se creen productos si aun no hay categorias disponibles
            if(tipo == 2 && _categoria.GetAllCategorias().Count() == 0) { return RedirectToAction("verProductos"); }
            ViewData["tipo"] = tipo;
            return View();
        }
        public IActionResult agregarPersona(TbMultipleTables persona)
        {
            _persona.addPersonaAdmin(persona);
            return RedirectToAction("verPersonas");
        }

        public IActionResult agregarProducto(TbMultipleTables producto)
        {
            _producto.addProducto(producto);
            return RedirectToAction("verProductos");
        }
        public IActionResult agregarCategoria(TbMultipleTables categoria)
        {
            _categoria.addCategoria(categoria);
            return RedirectToAction("verCategorias");
        }

        [Route("AdminMenu/pickPersona/{IdPersona}")]
        public IActionResult pickPersona(int IdPersona)
        {
            return View(_persona.getPersona(IdPersona));
        }
        [Route("AdminMenu/pickProducto/{IdProducto}")]
        public IActionResult pickProducto(int IdProducto)
        {
            return View(_producto.getProducto(IdProducto));
        }
        [Route("AdminMenu/pickCategoria/{IdCategoria}")]
        public IActionResult pickCategoria(int IdCategoria)
        {
            return View(_categoria.getCategoria(IdCategoria));
        }
        public IActionResult editarPersona(TbPersona persona)
        {
            _persona.editPersona(persona);
            return RedirectToAction("verPersonas");
        }
        public IActionResult editarProducto(TbProducto producto)
        {
            _producto.editProducto(producto);
            return RedirectToAction("verProductos");
        }
        public IActionResult editarCategoria(TbCategorium categoria)
        {
            _categoria.editCategoria(categoria);
            return RedirectToAction("verCategorias");
        }
        [Route("AdminMenu/eliminarPersona/{IdPersona}")]
        public IActionResult eliminarPersona(int IdPersona)
        {
            _persona.removePersona(IdPersona);
            return RedirectToAction("verPersonas");
        }
        [Route("AdminMenu/eliminarProducto/{IdProducto}")]
        public IActionResult eliminarProducto(int IdProducto)
        {
            _producto.removeProducto(IdProducto);
            return RedirectToAction("verProductos");
        }
        [Route("AdminMenu/eliminarCategoria/{IdCategoria}")]
        public IActionResult eliminarCategoria(int IdCategoria)
        {
            //Eliminamos los productos que hubieran tenido esa categoria
            List<TbProducto> pCongruents = _producto.GetAllProductos(IdCategoria).ToList();
            int size = pCongruents.Count();
            for (int i = 0; i < size; i++)
            {
                _producto.removeProducto(pCongruents[i].IdProducto);
            }

            _categoria.removeCategoria(IdCategoria);

            return RedirectToAction("verCategorias");
        }
    }
    }
