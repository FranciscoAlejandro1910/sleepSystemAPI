using System;
using System.Collections.Generic;

namespace sleepSystemAPI.Models;

public partial class Pregunta
{
    public int IdPregunta { get; set; }

    public string Texto { get; set; } = null!;

    public string? Tipo { get; set; }

    public int? ItemPsqi { get; set; }

    public virtual ICollection<Respuesta> Respuesta { get; set; } = new List<Respuesta>();
}
