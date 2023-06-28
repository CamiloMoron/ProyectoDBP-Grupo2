using ProyectoDesarrollo.Models;

namespace ProyectoDesarrollo.Servicios
{
    public class ProductoRepository : IProducto
    {
        private readonly ProyectoContext conexion = new ProyectoContext();


        //PROPUESTA
        private readonly ICategoria _categoria = new CategoriaRepository();

        public void addProducto(TbMultipleTables producto)
        {
            //producto.TbProducto.IdProducto = GetAllProductos().Count() + 1;
            try
            {
                conexion.TbProductos.Add(producto.TbProducto);
                conexion.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }


        public void editProducto(TbProducto producto)
        {
            var objModificable = getProducto(producto.IdProducto);
            objModificable.NombreProducto = producto.NombreProducto;
            objModificable.Descripcion = producto.Descripcion;
            objModificable.Precio = producto.Precio;
            objModificable.Stock = producto.Stock;
            objModificable.IdCategoria = producto.IdCategoria;
            conexion.SaveChanges();

        }

        public IEnumerable<TbProducto> GetAllProductos()
        {
            return conexion.TbProductos;
        }

        public TbProducto getProducto(int IdProducto)
        {
            var obj = (from tproduct in conexion.TbProductos
                       where tproduct.IdProducto == IdProducto
                       select tproduct).Single();
            return obj;
        }

        public void removeProducto(int IdProducto)
        {
            var obj = getProducto(IdProducto);
            conexion.Remove(obj);
            conexion.SaveChanges();
        }

        public void alterStockProducto(int id, int cantidad) 
        {
            TbProducto producto = this.getProducto(id);
            int stock = producto.Stock;
            stock += cantidad;
            if (stock > 0)//Restale a su stock
            {
                producto.Stock = stock;
            }
            else { producto.Stock = 0; }
            this.editProducto(producto);
        }

        public IEnumerable<TbProducto> GetAllProductos(int idCategoria)
        {
            var obj = (from tproduct in conexion.TbProductos
                       where tproduct.IdCategoria == idCategoria
                       select tproduct);
            return obj;
        }
    }
}
