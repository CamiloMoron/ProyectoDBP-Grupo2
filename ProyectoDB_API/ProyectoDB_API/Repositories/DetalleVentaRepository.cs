using ProyectoDB_API.Models;
using ProyectoDB_API.Services;

namespace ProyectoDB_API.Repositories
{
    public class DetalleVentaRepository : IDetalleVenta
    {
        private readonly APIContext conexion = new APIContext();
        public void add(TbDetalleVentum detalleVenta)
        {
            conexion.TbDetalleVenta.Add(detalleVenta);
            conexion.SaveChanges();
        }

        public IEnumerable<TbDetalleVentum> GetAllDetalleVenta()
        {
            return conexion.TbDetalleVenta.ToList();
        }

        public TbDetalleVentum GetDetalleVentum(int id)
        {
            var obj = conexion.TbDetalleVenta.Where(tdetails =>
                      tdetails.IdDetalleVenta == id).SingleOrDefault();
            return obj;
        }
    }
}
