using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ProyectoDB_API.Models;

public partial class TbVentum
{
    public int IdVenta { get; set; }

    public int IdCliente { get; set; }

    public float TotalVenta { get; set; }

    public string EstadoVenta { get; set; } = null!;

    [JsonIgnore]
    public virtual TbPersona IdClienteNavigation { get; set; } = null!;

    [JsonIgnore]
    public virtual ICollection<TbDetalleVentum> TbDetalleVenta { get; set; } = new List<TbDetalleVentum>();
}
