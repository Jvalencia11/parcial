using System;
using System.Collections.Generic;

namespace Taller.Models;

public partial class Cliente
{
    public int IdCliente { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public int? IdCarro { get; set; }
}
