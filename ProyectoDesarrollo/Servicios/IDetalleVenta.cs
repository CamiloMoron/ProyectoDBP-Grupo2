using ProyectoDesarrollo.Models;

namespace ProyectoDesarrollo.Servicios
{
    public interface IDetalleVenta
     {
        void addDetalleVenta(TbDetalleVentum details);
        IEnumerable<TbDetalleVentum> getAllDetalleVenta();

        IEnumerable<TbDetalleVentum> getAllDetalleVenta(int idVenta);
        TbDetalleVentum getDetalleVenta(int id);
    }
}
