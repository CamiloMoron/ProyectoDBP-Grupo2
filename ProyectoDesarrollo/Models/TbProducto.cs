using System;
using System.Collections.Generic;

namespace ProyectoDesarrollo.Models;

public partial class TbProducto
{
    public int IdProducto { get; set; }

    public string NombreProducto { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public float Precio { get; set; }

    public int Stock { get; set; }

    public int IdCategoria { get; set; }

    public virtual TbCategorium IdCategoriaNavigation { get; set; } = null!;

    public virtual ICollection<TbDetalleVentum> TbDetalleVenta { get; set; } = new List<TbDetalleVentum>();
}
