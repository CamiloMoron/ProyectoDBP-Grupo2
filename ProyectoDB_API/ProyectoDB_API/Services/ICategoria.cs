using ProyectoDB_API.Models;

namespace ProyectoDB_API.Services
{
    public interface ICategoria
    {
        IEnumerable<TbCategorium> GetAllCategorias();
        TbCategorium GetCategorium(int id);
    }
}
