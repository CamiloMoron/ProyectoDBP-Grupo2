using ProyectoDesarrollo.Servicios;

namespace ProyectoDesarrollo.Models
{
    public class TbMultipleTables //IPersona,IProducto,ICategoria
    {
        public TbPersona TbPersona { get; set; } = null!;
        public TbProducto TbProducto { get; set; } = null!;
        public TbCategorium TbCategoria { get; set; } = null!;

        /*
        private readonly ProyectoContext conexion = new ProyectoContext();

        public void addCategoria(TbCategorium categoria)
        {
            categoria.IdCategoria = GetAllCategorias().Count() + 1;

            try
            {
                conexion.TbCategoria.Add(categoria);
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
        public void addPersona(TbMultipleTables persona)
        {
            persona.TbPersona.IdPersona = GetAllPersona().Count() + 1;

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
        public void addProducto(TbMultipleTables producto)
        {
            producto.TbProducto.IdProducto = GetAllProductos().Count() + 1;
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
        */
    }
}

