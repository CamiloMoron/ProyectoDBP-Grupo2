using ProyectoDesarrollo.Models;

namespace ProyectoDesarrollo.Servicios
{
    public class DetalleVentaRepository : IDetalleVenta
    {
        private readonly ProyectoContext _conexion = new ProyectoContext();
        public void addDetalleVenta(TbDetalleVentum details)
        {
            try
            {
                _conexion.TbDetalleVenta.Add(details);
                _conexion.SaveChanges();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public IEnumerable<TbDetalleVentum> getAllDetalleVenta()
        {
            return _conexion.TbDetalleVenta;
        }

        public IEnumerable<TbDetalleVentum> getAllDetalleVenta(int idVenta)
        {
            var lista = (from tbDetails in _conexion.TbDetalleVenta
                         where tbDetails.IdVenta == idVenta
                         select tbDetails).ToList();
            return lista;
        }

        public TbDetalleVentum getDetalleVenta(int id)
        {
            var obj = (from tbDetails in _conexion.TbDetalleVenta
                       where tbDetails.IdVenta == id
                       select tbDetails).Single();
            return obj;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
