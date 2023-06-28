using ProyectoDB_API.Models;
using ProyectoDB_API.Services;

namespace ProyectoDB_API.Repositories
{
    public class VentaRepository : IVenta
    {
        private readonly APIContext conexion = new APIContext();
        public void add(TbVentum venta)
        {
            conexion.TbVenta.Add(venta);
            conexion.SaveChanges();
        }

        public IEnumerable<TbVentum> GetAllVentas()
        {
            if(conexion != null)
            {
                return conexion.TbVenta.ToList();
            }
            else
            {
                return Enumerable.Empty<TbVentum>();
            }
        }

        public TbVentum GetVenta(int id)
        {
            var obj = conexion.TbVenta.Where(tventa =>
                      tventa.IdVenta == id).FirstOrDefault();
            return obj;
        }
    }
}
