using ProyectoDesarrollo.Models;

namespace ProyectoDesarrollo.Servicios
{
    public interface IProducto
    {
        IEnumerable<TbProducto> GetAllProductos();

        IEnumerable<TbProducto> GetAllProductos(int idCategoria);
        void removeProducto(int IdProducto);
        TbProducto getProducto(int IdProducto);
        void editProducto(TbProducto producto);
        void addProducto(TbMultipleTables producto);
        void alterStockProducto(int id, int cantidad);
    }
}
