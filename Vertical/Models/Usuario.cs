using System;
using System.Collections.Generic;

namespace Vertical.Models;

public partial class Usuario
{
    public int Id { get; set; }

    public string Login { get; set; } = null!;

    public string Nome { get; set; } = null!;

    public string Senha { get; set; } = null!;

    public DateTime DataRegistro { get; set; }

    public int IdGrupo { get; set; }

    public virtual Grupo IdGrupoNavigation { get; set; } = null!;
}
