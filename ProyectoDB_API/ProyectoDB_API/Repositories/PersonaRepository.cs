using ProyectoDB_API.Models;
using ProyectoDB_API.Services;

namespace ProyectoDB_API.Repositories
{
    public class PersonaRepository : IPersona
    {
        private readonly APIContext conexion = new APIContext();
        public IEnumerable<TbPersona> GetAllPersonas()
        {
            if(conexion != null)
            {
                return conexion.TbPersonas.ToList();
            }
            else
            {
                return Enumerable.Empty<TbPersona>();
            }
        }

        public TbPersona GetPersona(int id)
        {
            var obj = conexion.TbPersonas.Where(tperson =>
                      tperson.IdPersona == id).FirstOrDefault();
            return obj;
        }
    }
}
