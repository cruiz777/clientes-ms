using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class AuditoriaTransferencia
{
    public long IdTransferenciaPrefijo { get; set; }

    public long? ClientesCodigoOrigen { get; set; }

    public long? ClientesCodigoDestino { get; set; }

    public DateTime? Fecha { get; set; }

    public long? IdPrefijos { get; set; }

    public string? Tipo { get; set; }

    public long? IdUsuario { get; set; }

    public virtual Clientes? ClientesCodigoDestinoNavigation { get; set; }

    public virtual Clientes? ClientesCodigoOrigenNavigation { get; set; }

    public virtual Prefijos? IdPrefijosNavigation { get; set; }

    public virtual Usuarios? IdUsuarioNavigation { get; set; }
}
