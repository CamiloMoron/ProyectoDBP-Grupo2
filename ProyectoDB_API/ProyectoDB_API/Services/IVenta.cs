using ProyectoDB_API.Models;

namespace ProyectoDB_API.Services
{
    public interface IVenta
    {
        IEnumerable<TbVentum> GetAllVentas();
        TbVentum GetVenta(int id);
        void add(TbVentum venta);
    }
}
