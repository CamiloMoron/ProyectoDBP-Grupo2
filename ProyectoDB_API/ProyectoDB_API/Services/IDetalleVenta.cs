using ProyectoDB_API.Models;

namespace ProyectoDB_API.Services
{
    public interface IDetalleVenta
    {
        IEnumerable<TbDetalleVentum> GetAllDetalleVenta();
        TbDetalleVentum GetDetalleVentum(int id);
        void add(TbDetalleVentum detalleVenta);
    }
}
