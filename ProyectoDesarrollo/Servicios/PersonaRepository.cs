using ProyectoDesarrollo.Models;

namespace ProyectoDesarrollo.Servicios
{
    public class PersonaRepository : IPersona
    {
        private readonly ProyectoContext conexion = new ProyectoContext();
        public void addPersonaAdmin(TbMultipleTables persona)
        {
            //persona.TbPersona.IdPersona = GetAllPersona().Count() + 1;
            try
            {
                conexion.TbPersonas.Add(persona.TbPersona);
                conexion.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public TbPersona getPersona(int IdPersona)
        {
            var obj = (from tperson in conexion.TbPersonas
                       where tperson.IdPersona == IdPersona
                       select tperson).Single();
            return obj;
        }

        public void editPersona(TbPersona persona)
        {
            var objModificable = getPersona(persona.IdPersona);

            objModificable.NombrePersona = persona.NombrePersona;
            objModificable.TipoPersona = persona.TipoPersona;
            objModificable.Apellidos = persona.Apellidos;
            objModificable.Usuario = persona.Usuario;
            objModificable.Clave = persona.Clave;
            conexion.SaveChanges();
        }

        public IEnumerable<TbPersona> GetAllPersona()
        {
            return conexion.TbPersonas;
        }

        public void removePersona(int IdPersona)
        {
            var obj = getPersona(IdPersona);
            conexion.Remove(obj);
            conexion.SaveChanges();
        }

        public TbPersona getLoggedPersona(string Usuario, string Clave, string TipoPersona)
        {
            var obj = (from tperson in conexion.TbPersonas
                       where
                       tperson.Usuario == Usuario
                       && tperson.Clave == Clave
                       && tperson.TipoPersona == TipoPersona
                       select tperson).SingleOrDefault(); //esto retornara null cuando haya excepciones
            return obj;
        }

        public bool personaExists(string Usuario, string Clave, string TipoPersona)
        {
            var obj = getLoggedPersona(Usuario, Clave, TipoPersona);
            if (obj == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void addPersonaUsuario(TbPersona persona)
        {
            //persona.IdPersona = GetAllPersona().Count() + 1;

            try
            {
                conexion.TbPersonas.Add(persona);
                conexion.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public IEnumerable<TbPersona> getAllClientes()
        {
            var lst = (from tperson in conexion.TbPersonas
                       where
                       tperson.TipoPersona == "Cliente"
                       select tperson); //esto retornara null cuando haya excepciones
            return lst;
        }
    }
}
