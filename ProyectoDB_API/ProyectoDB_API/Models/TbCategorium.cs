using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ProyectoDB_API.Models;

public partial class TbCategorium
{
    public int IdCategoria { get; set; }

    public string NombreCategoria { get; set; } = null!;

    [JsonIgnore]
    public virtual ICollection<TbProducto> TbProductos { get; set; } = new List<TbProducto>();
}
