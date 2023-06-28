using ProyectoDesarrollo.Models;

namespace ProyectoDesarrollo.Servicios
{
    public class SearchData
    {
        private readonly ProyectoContext conexion = new ProyectoContext();
        public string busqueda { get; set; }
        public string filtro { get; set; } 
        //esto lo leeran las condiciones de la vista que le corresponda
        //puede ser "menor a mayor", "precio < 500", etc

        public SearchData() 
        {
            busqueda = "";
            filtro = "";
        }

        public bool isNull() 
        {
            if (busqueda == "" || filtro == "" || busqueda == null || filtro == null) { return true; }
            else return false;
        }
        public TbProducto searchProducto(String searchdata)
        {
            var objBuscable = (from tproduct in conexion.TbProductos
                               where tproduct.NombreProducto.Contains(searchdata)
                               select tproduct);
            conexion.SaveChanges();
            return (TbProducto)objBuscable;

        }
    }
}
