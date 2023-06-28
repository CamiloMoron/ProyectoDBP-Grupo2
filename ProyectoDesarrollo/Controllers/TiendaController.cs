using Microsoft.AspNetCore.DataProtection.KeyManagement.Internal;
using Microsoft.AspNetCore.Mvc;
using ProyectoDesarrollo.Models;
using ProyectoDesarrollo.Servicios;
using Newtonsoft.Json;

namespace ProyectoDesarrollo.Controllers
{
    public class TiendaController : Controller
    {
        public List<TbProducto> carrito;
        public int idCliente; //-1 = invitado

        private readonly IProducto _producto;
        private readonly IDetalleVenta _detalleVenta;
        private readonly IVenta _venta;
        
        public TiendaController(IProducto producto, IDetalleVenta detalleVenta, IVenta venta)
        {
            _producto = producto;
            _detalleVenta = detalleVenta;
            _venta = venta;
            idCliente = -1;
            carrito = new List<TbProducto>();
        }

        //Cuando entramos, dejamos constancia de quien ha entrado
        [Route("Tienda/Ingresar/{idCliente}")]
        public IActionResult Ingresar(int idCliente) 
        {
            if(idCliente > 0) this.saveIdClienteCookies(idCliente);
            return RedirectToAction("Index");
        }

        [Route("Tienda/CerrarSesion")]
        public IActionResult CerrarSesion() 
        {
            carrito = this.getCarritoCookies();
            if(carrito.Count > 0) { this.clearCarrito(); }
            this.saveIdClienteCookies(-1);
            return RedirectToAction("Index", "Logueo");
        }

        [Route("Tienda/Index")]
        public IActionResult Index()// EL CATALAGO
        {
            idCliente = getIdClienteCookies();
            if(idCliente > 0) 
            {
                return View(_producto.GetAllProductos());
            }
            else { return RedirectToAction("limitedIndex"); }
        }

        public IActionResult limitedIndex() 
        {
            return View(_producto.GetAllProductos());
        }

        [Route("Tienda/verProducto/{idProducto}")]
        public IActionResult verProducto(int idProducto)
        {
            idCliente = getIdClienteCookies();
            if (_producto.getProducto(idProducto).Stock > 0 && idCliente > 0)
            {
                var product = _producto.getProducto(idProducto);
                return View(product);
            }
            else { return RedirectToAction("Index"); }
        }

        [Route("Tienda/verCarrito")]
        public IActionResult verCarrito()
        {
            //Refrescamos el carrito
            idCliente = getIdClienteCookies();
            
            carrito = this.getCarritoCookies();
            return View(carrito);
        }

        [Route("Tienda/comprarCarrito")]
        public IActionResult comprarCarrito()
        {
            generarVenta();
            return RedirectToAction("verCarrito");
        }

        [Route("Tienda/verVentas")]
        public IActionResult verVentas() 
        {
            //Refrescar idCliente 
            idCliente = getIdClienteCookies();

            if (idCliente > 0) { return View(_venta.getAllVentas(idCliente)); }
            else { return RedirectToAction("Index"); }
        }

        [Route("Tienda/verDetallesVenta/{idVenta}")]
        public IActionResult verDetallesVenta(int idVenta) 
        {
            return View(_detalleVenta.getAllDetalleVenta(idVenta));
        }

        private void generarVenta()
        {
            //Refrescando idCliente y Carrito
            idCliente = getIdClienteCookies();
            carrito = getCarritoCookies();

            int size = carrito.Count();
            if (size > 0 && idCliente > 0) //si mi carrito no esta vacio y no soy invitado
            {
                //Creando y agregando la venta...
                TbVentum venta = new TbVentum();
                venta.IdCliente = idCliente;
                venta.TotalVenta = getMontoCarrito();
                venta.EstadoVenta = "Pagada";
                _venta.addVenta(venta);

                //Creando y agregando detalles por cada producto en el carrito...
                int idVenta = _venta.getLastVenta().IdVenta;
                for (int i = 0; i < size; i++)
                {
                    TbDetalleVentum detalleVenta = new TbDetalleVentum();
                    detalleVenta.IdVenta = idVenta;
                    detalleVenta.IdProducto = carrito[i].IdProducto;
                    detalleVenta.Cantidad = carrito[i].Stock;
                    detalleVenta.Precio = (carrito[i].Precio * carrito[i].Stock);
                    _detalleVenta.addDetalleVenta(detalleVenta);
                }

                //Vaciando y guardando el carrito...
                carrito.Clear();
                this.saveCarritoCookies(carrito);
            }
        }

        // *****- FUNCIONES DE MANEJO DEL CARRITO DE COMPRAS -********************************
        private List<TbProducto> getCarritoCookies()
        {
            var cartJson = Request.Cookies["Carrito"];
            if (string.IsNullOrEmpty(cartJson))
            {
                return new List<TbProducto>();
            }
            return JsonConvert.DeserializeObject<List<TbProducto>>(cartJson);
        }

        private void saveCarritoCookies(List<TbProducto> carrito) 
        {
            var cartJson = JsonConvert.SerializeObject(carrito);
            Response.Cookies.Append("Carrito", cartJson);
        }

        [Route("Tienda/quitarProducto/{idProducto}")]
        public IActionResult quitarProducto(int idProducto)//quitar del carrito
        {
            //Refrescamos el carrito
            carrito = this.getCarritoCookies();

            int posicion = getCarritoPosition(idProducto);
            if (posicion >= 0)
            {
                int cantidad = carrito[posicion].Stock;
                carrito.Remove(carrito[posicion]);
                _producto.alterStockProducto(idProducto, cantidad);

                //Guardamos los cambios en el carrito
                this.saveCarritoCookies(carrito);
            }
            return RedirectToAction("verCarrito");
        }

        //Pasamos el perfil del producto con la cantidad solicitada
        public IActionResult agregarProducto(TbProducto producto) //su stock es la cantidad solicitada
        {
            //Refrescamos el carrito
            carrito = this.getCarritoCookies();

            //Comprobando que no es un producto ya agregado...
            int posicion = this.getCarritoPosition(producto.IdProducto);

            if (posicion < 0) //si es un producto nuevo...lo agregamos al carrito
            { carrito.Add(producto); }
            else //si es un producto ya agregado al carrito, aumentamos su cantidad
            { carrito[posicion].Stock += producto.Stock; }

            //Restamos al stock de la tienda lo agregado en el carrito
            _producto.alterStockProducto(producto.IdProducto, (producto.Stock * -1));

            //Guardamos los cambios en el carrito
            this.saveCarritoCookies(carrito);

            return RedirectToAction("Index");
        }

        [Route("Tienda/vaciarCarrito")]
        public IActionResult vaciarCarrito() 
        {
            clearCarrito();

            return RedirectToAction("verCarrito");
        }

        private void clearCarrito() 
        {
            //Refrescamos el carrito
            carrito = this.getCarritoCookies();

            //Vamos retornar el stock de cada producto
            int size = carrito.Count();
            for (int i = 0; i < size; i++)
            {
                TbProducto producto = carrito[i];
                _producto.alterStockProducto(producto.IdProducto, producto.Stock);
            }

            //Vaciamos la lista por completo
            carrito.Clear();

            //Guardamos los cambios en el carrito
            this.saveCarritoCookies(carrito);
        }

        private int getCarritoPosition(int idProducto)
        {
            //Refrescamos el carrito
            carrito = this.getCarritoCookies();
            int size = carrito.Count;
            int posicion = -1;
            for (int i = 0; i < size; i++)
            {
                if (carrito[i].IdProducto == idProducto) { posicion = i; }
            }
            return posicion;
        }

        private float getMontoCarrito()
        {
            float monto = 0;
            int size = carrito.Count;
            for (int i = 0; i < size; i++) { monto += (carrito[i].Precio * carrito[i].Stock); }
            return monto;
        }


// *****- FUNCIONES DE MANEJO DEL ID DEL CLIENTE -************************************
        private void saveIdClienteCookies(int idCliente) 
        {
            var idJson = JsonConvert.SerializeObject(idCliente);
            Response.Cookies.Append("idCliente", idJson);
        }

        private int getIdClienteCookies() 
        {
            var idJson = Request.Cookies["idCliente"];
            if (string.IsNullOrEmpty(idJson))
            {
                return -1;
            }
            return JsonConvert.DeserializeObject<int>(idJson);
        }
    }
}