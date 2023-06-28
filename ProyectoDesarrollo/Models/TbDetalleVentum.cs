using System;
using System.Collections.Generic;

namespace ProyectoDesarrollo.Models;

public partial class TbDetalleVentum
{
    public int IdDetalleVenta { get; set; }

    public int IdVenta { get; set; }

    public int IdProducto { get; set; }

    public int Cantidad { get; set; }

    public float Precio { get; set; }

    public virtual TbProducto IdProductoNavigation { get; set; } = null!;

    public virtual TbVentum IdVentaNavigation { get; set; } = null!;
}
