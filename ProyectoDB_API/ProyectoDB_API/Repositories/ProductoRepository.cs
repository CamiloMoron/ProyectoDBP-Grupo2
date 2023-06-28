using Microsoft.AspNetCore.Mvc;
using ProyectoDB_API.Models;
using ProyectoDB_API.Services;

namespace ProyectoDB_API.Repositories
{
    public class ProductoRepository : IProducto
    {
        private readonly APIContext conexion = new APIContext();
        

        public IEnumerable<TbProducto> GetAllProductos()
        {
            if(conexion != null) 
            {
                return conexion.TbProductos.ToList();
            }
            else { return Enumerable.Empty<TbProducto>();}
        }

        public TbProducto GetProducto(int id)
        {
                var obj = conexion.TbProductos.Where(tpro =>
                      tpro.IdProducto == id).FirstOrDefault();
                return obj;
            
        }

        public void ModifyProducto([FromBody]TbProducto producto)
        {
            var obj = conexion.TbProductos.Where(tpro => tpro.IdProducto == producto.IdProducto).SingleOrDefault();
            obj.NombreProducto = producto.NombreProducto;
            obj.Descripcion = producto.Descripcion;
            obj.Stock = producto.Stock;
            obj.IdCategoria = producto.IdCategoria;
            conexion.SaveChanges();
        }
    }
}
