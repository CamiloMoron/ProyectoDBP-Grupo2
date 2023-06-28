using ProyectoDesarrollo.Models;

namespace ProyectoDesarrollo.Servicios
{
    public class VentaRepository : IVenta
    {
        private readonly ProyectoContext _conexion = new ProyectoContext();
        public void addVenta(TbVentum venta)
        {
            //venta.IdVenta = getAllVentas().Count() + 1;
            try
            {
                _conexion.TbVenta.Add(venta);
                _conexion.SaveChanges();

            }catch(Exception e) 
            {
                Console.WriteLine(e.ToString());
            }
        }

        public IEnumerable<TbVentum> getAllVentas()
        {
            return _conexion.TbVenta;
        }

        IEnumerable<TbVentum> IVenta.getAllVentas(int idCliente)
        {
            IEnumerable<TbVentum> lista = (from venta in getAllVentas()
                                           where venta.IdCliente == idCliente
                                           select venta);
            return lista;
        }

        public TbVentum getVenta(int id)
        {
            var obj = (from tVenta in _conexion.TbVenta
                       where tVenta.IdVenta == id
                       select tVenta).Single();
            return obj;
        }

        public TbVentum getLastVenta() 
        {
            var obj = (from venta in getAllVentas()
                       select venta).LastOrDefault();
            return obj;
        }
    }
}
