using System;
using System.Collections.Generic;

namespace ProyectoDesarrollo.Models;

public partial class TbCategorium
{
    public int IdCategoria { get; set; }

    public string NombreCategoria { get; set; } = null!;

    public virtual ICollection<TbProducto> TbProductos { get; set; } = new List<TbProducto>();
}
