namespace ProyectoDesarrollo.Servicios
{
    public class TempPersona
    {
        public string usuario { get; set; }
        public string clave { get; set; }
        public string tipo { get; set; }
        
        public TempPersona() 
        {
            usuario = "";
            clave = "";
            tipo = "";
        }

        public bool isValid()
        {
            if (usuario != "" && clave != "" && tipo != "") { return true; }
            else { return false; }
        }

        public int getTipoAsInt() 
        {
            if(tipo == "Cliente") { return 1; }
            else if(tipo == "Administrador") { return 2; }
            else { return 0; }
        }

    }
}
