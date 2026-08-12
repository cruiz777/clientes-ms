using System;
using System.Collections.Generic;

namespace clientes_ms.Domain.Entities;

public partial class Cargas
{
    public long IdCarga { get; set; }

    public int IdEmpresa { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public string? Identificacion { get; set; }

    public string? Direccion { get; set; }

    public string? Telefono { get; set; }

    public DateOnly? FechaNacimiento { get; set; }

    public long? IdGenero { get; set; }

    public string? Parentesco { get; set; }

    public bool? Estado { get; set; }

    public bool? Utilidad { get; set; }

    public bool? Imprenta { get; set; }

    public long? IdEmpleado { get; set; }

    public long? IdTipoDiscapacidad { get; set; }

    public virtual RpMaeEmp? IdEmpleadoNavigation { get; set; }

    public virtual Genero? IdGeneroNavigation { get; set; }

    public virtual RpTipoDiscapacidad? IdTipoDiscapacidadNavigation { get; set; }
}
