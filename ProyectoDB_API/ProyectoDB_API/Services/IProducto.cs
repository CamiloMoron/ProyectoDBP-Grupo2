using ProyectoDB_API.Models;

namespace ProyectoDB_API.Services
{
    public interface IProducto
    {
        IEnumerable<TbProducto> GetAllProductos();
        TbProducto GetProducto(int id);
        void ModifyProducto(TbProducto producto);
    }
}
