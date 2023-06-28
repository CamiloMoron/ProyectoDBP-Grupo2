using ProyectoDesarrollo.Models;

namespace ProyectoDesarrollo.Servicios
{
    public interface ICategoria
    {
        void addCategoria(TbMultipleTables categoria);
        IEnumerable<TbCategorium> GetAllCategorias();
        void removeCategoria(int IdCategoria);
        TbCategorium getCategoria(int IdCategoria);
        void editCategoria(TbCategorium categoria);
    }
}
