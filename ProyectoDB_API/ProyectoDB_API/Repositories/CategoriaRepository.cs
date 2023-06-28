using ProyectoDB_API.Models;
using ProyectoDB_API.Services;

namespace ProyectoDB_API.Repositories
{
    public class CategoriaRepository : ICategoria
    {
        private readonly APIContext conexion = new APIContext();
        public IEnumerable<TbCategorium> GetAllCategorias()
        {
            return conexion.TbCategoria.ToList();
        }

        public TbCategorium GetCategorium(int id)
        {
            var obj = conexion.TbCategoria.Where(tcat =>
                      tcat.IdCategoria == id).SingleOrDefault();
            return obj;
        }
    }
}
