using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;

namespace Vertical.Models;

public partial class DiscipulosInstrumento
{
    public int Id { get; set; }

    public int IdDiscipulo { get; set; }

    public int IdInstrumento { get; set; }

    [Display(Description = "Lista de Discípulos")]
    public virtual Discipulo Discipulo { get; set; } = null!;

    [Display(Description = "Lista de Instrumentos")]
    public virtual Instrumento Instrumento { get; set; } = null!;
}