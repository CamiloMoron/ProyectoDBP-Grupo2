using ProyectoDesarrollo.Models;

namespace ProyectoDesarrollo.Servicios
{
    public class CategoriaRepository: ICategoria
    {
        private readonly ProyectoContext conexion = new ProyectoContext();

        public void addCategoria(TbMultipleTables categoria) 
        {
            //categoria.TbCategoria.IdCategoria = GetAllCategorias().Count() + 1;
            try
            {
                conexion.TbCategoria.Add(categoria.TbCategoria);
                conexion.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public IEnumerable<TbCategorium> GetAllCategorias() 
        {
            return conexion.TbCategoria;
        }
        public void removeCategoria(int IdCategoria) 
        {
            var obj = getCategoria(IdCategoria);
            conexion.Remove(obj);
            conexion.SaveChanges();
        }
        public TbCategorium getCategoria(int IdCategoria) 
        {
            var obj = (from tcategory in conexion.TbCategoria
                       where tcategory.IdCategoria == IdCategoria
                       select tcategory).Single();
            return obj;
        }
        public void editCategoria(TbCategorium categoria) 
        {
            var objModificable = getCategoria(categoria.IdCategoria);

            objModificable.NombreCategoria = categoria.NombreCategoria;
            conexion.SaveChanges();
        }
    }
}
