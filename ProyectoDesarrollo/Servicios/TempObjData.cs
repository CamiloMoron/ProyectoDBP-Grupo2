using ProyectoDesarrollo.Models;

namespace ProyectoDesarrollo.Servicios
{
    public class TempObjData
    {
        public IPersona _persona { get; set; }
        public IProducto _producto { get; set; }

        public ICategoria _categoria { get; set; }

        public int id { get; set; }
        public string tipo { get; set; }

        public TempObjData(IPersona persona, IProducto producto, ICategoria categoria)
        {
            id = 0;
            tipo = "";
            this._persona = persona;
            this._producto = producto;
            this._categoria = categoria;
        }
        public bool isValid() 
        {
            if (id == 0 || tipo == "") { return false; }
            else { return true; }
        }
    }
}
