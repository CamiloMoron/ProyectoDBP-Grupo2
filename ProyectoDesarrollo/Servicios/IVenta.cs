using ProyectoDesarrollo.Models;

namespace ProyectoDesarrollo.Servicios
{
    public interface IVenta
    {
        void addVenta(TbVentum venta);
        IEnumerable<TbVentum> getAllVentas();
        IEnumerable<TbVentum> getAllVentas(int idCliente);
        TbVentum getVenta(int id);
        public TbVentum getLastVenta();
    }
}
