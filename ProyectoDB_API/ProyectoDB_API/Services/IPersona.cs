using ProyectoDB_API.Models;

namespace ProyectoDB_API.Services
{
    public interface IPersona
    {
        IEnumerable<TbPersona> GetAllPersonas();
        TbPersona GetPersona(int id);
    }
}
