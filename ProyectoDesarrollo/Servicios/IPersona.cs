using ProyectoDesarrollo.Models;

namespace ProyectoDesarrollo.Servicios
{
    public interface IPersona
    {
        void addPersonaAdmin(TbMultipleTables persona);
        void addPersonaUsuario(TbPersona persona);
        IEnumerable<TbPersona> GetAllPersona();

        IEnumerable<TbPersona> getAllClientes();
        void removePersona(int IdPersona);
        TbPersona getPersona(int IdPersona);
        void editPersona(TbPersona persona);
        public TbPersona getLoggedPersona(string Usuario, string Clave, string TipoPersona);
        bool personaExists(string Usuario, string Clave, string TipoPersona);
    }
}
