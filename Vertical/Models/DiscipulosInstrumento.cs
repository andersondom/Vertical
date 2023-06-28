using System;
using System.Collections.Generic;

namespace Vertical.Models;

public partial class DiscipulosInstrumento
{
    public int Id { get; set; }

    public int IdDiscipulo { get; set; }

    public int IdInstrumento { get; set; }

    public virtual Discipulo IdDiscipuloNavigation { get; set; } = null!;

    public virtual Instrumento IdInstrumentoNavigation { get; set; } = null!;
}
