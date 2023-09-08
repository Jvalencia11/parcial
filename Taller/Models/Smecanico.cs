using System;
using System.Collections.Generic;

namespace Taller.Models;

public partial class Smecanico
{
    public int IdMecanico { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public int? IdCarro { get; set; }

    public string? Herramientas { get; set; }
}
