using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ProyectoDB_API.Models;

public partial class TbDetalleVentum
{
    public int IdDetalleVenta { get; set; }

    public int IdVenta { get; set; }

    public int IdProducto { get; set; }

    public int Cantidad { get; set; }

    public float Precio { get; set; }

    [JsonIgnore]
    public virtual TbProducto IdProductoNavigation { get; set; } = null!;

    [JsonIgnore]
    public virtual TbVentum IdVentaNavigation { get; set; } = null!;
}
