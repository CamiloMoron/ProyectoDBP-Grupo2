using System;
using System.Collections.Generic;

namespace ProyectoDesarrollo.Models;

public partial class TbVentum
{
    public int IdVenta { get; set; }

    public int IdCliente { get; set; }

    public float TotalVenta { get; set; }

    public string EstadoVenta { get; set; } = null!;

    public virtual TbPersona IdClienteNavigation { get; set; } = null!;

    public virtual ICollection<TbDetalleVentum> TbDetalleVenta { get; set; } = new List<TbDetalleVentum>();
}
