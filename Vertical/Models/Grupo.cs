using System;
using System.Collections.Generic;

namespace Vertical.Models;

public partial class Grupo
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public DateTime DataRegistro { get; set; }

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
