using System;
using System.Collections.Generic;

namespace sleepSystemAPI.Models;

public partial class Evaluacione
{
    public int IdEvaluaciones { get; set; }

    public int UsuarioId { get; set; }

    public int Componente1 { get; set; }

    public int Componente2 { get; set; }

    public int Componente3 { get; set; }

    public int Componente4 { get; set; }

    public int Componente5 { get; set; }

    public int Componente6 { get; set; }

    public int Componente7 { get; set; }

    public int PuntajeTotal { get; set; }

    public virtual Usuario Usuario { get; set; } = null!;
}
