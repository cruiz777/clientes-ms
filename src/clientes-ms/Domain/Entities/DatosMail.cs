using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class DatosMail
{
    public long IdDatosMail { get; set; }

    public string? UsuarioMail { get; set; }

    public string? ClaveMail { get; set; }

    public string? ServidorSmtp { get; set; }

    public string? PuertoMail { get; set; }

    public string? MailSalida { get; set; }

    public string? Subject { get; set; }

    public string? Body { get; set; }

    public string? BodyResponsable { get; set; }

    public string? BodyCargo { get; set; }

    public string? BodyWebSite { get; set; }

    public string? BodyEmail { get; set; }

    public string? BodyCelular { get; set; }

    public string? PathLogo { get; set; }

    public string? PathArchivoPdf { get; set; }

    public long? IdEmpresa { get; set; }
}
