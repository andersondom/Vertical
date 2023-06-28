using System;
using System.Collections.Generic;

namespace Vertical.Models;

public partial class Instrumento
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public virtual ICollection<DiscipulosInstrumento> DiscipulosInstrumentos { get; set; } = new List<DiscipulosInstrumento>();
}
