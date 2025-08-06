using System;
using System.Collections.Generic;

namespace sleepSystemAPI.Models;

public partial class Respuesta
{
    public int IdRespuesta { get; set; }

    public int UsuarioId { get; set; }

    public int PreguntaId { get; set; }

    public string Respuesta1 { get; set; } = null!;

    public virtual Pregunta Pregunta { get; set; } = null!;

    public virtual Usuario Usuario { get; set; } = null!;
}
