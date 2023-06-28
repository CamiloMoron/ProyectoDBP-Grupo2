using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ProyectoDB_API.Models;

public partial class TbPersona
{
    public int IdPersona { get; set; }

    public string NombrePersona { get; set; } = null!;

    public string Apellidos { get; set; } = null!;

    public string Usuario { get; set; } = null!;

    public string Clave { get; set; } = null!;

    public string TipoPersona { get; set; } = null!;

    [JsonIgnore]
    public virtual ICollection<TbVentum> TbVenta { get; set; } = new List<TbVentum>();
}
