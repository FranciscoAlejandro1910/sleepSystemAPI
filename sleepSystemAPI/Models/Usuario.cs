using System;
using System.Collections.Generic;

namespace sleepSystemAPI.Models;

public partial class Usuario
{
    public int IdUser { get; set; }

    public string Genero { get; set; } = null!;

    public int Edad { get; set; }

    public string Oficio { get; set; } = null!;

    public virtual ICollection<Evaluacione> Evaluaciones { get; set; } = new List<Evaluacione>();

    public virtual ICollection<Respuesta> Respuesta { get; set; } = new List<Respuesta>();
}
