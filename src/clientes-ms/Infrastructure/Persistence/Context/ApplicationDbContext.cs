using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using clientes_ms.Domain.Entities;

namespace clientes_ms.Infrastructure.Persistence.Context;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Apisexternas> Apisexternas { get; set; }

    public virtual DbSet<AuditoriaTransferencia> AuditoriaTransferencia { get; set; }

    public virtual DbSet<Cantones> Cantones { get; set; }

    public virtual DbSet<Ciudades> Ciudades { get; set; }

    public virtual DbSet<ClienteObservacion> ClienteObservacion { get; set; }

    public virtual DbSet<Clientes> Clientes { get; set; }

    public virtual DbSet<Codigos14> Codigos14 { get; set; }

    public virtual DbSet<ContactosClientes> ContactosClientes { get; set; }

    public virtual DbSet<Contadores> Contadores { get; set; }

    public virtual DbSet<Correos> Correos { get; set; }

    public virtual DbSet<DatosAdicionales> DatosAdicionales { get; set; }

    public virtual DbSet<Departamentos> Departamentos { get; set; }

    public virtual DbSet<Direcciones> Direcciones { get; set; }

    public virtual DbSet<Empresas> Empresas { get; set; }

    public virtual DbSet<EstadoCivil> EstadoCivil { get; set; }

    public virtual DbSet<EstadoEmpresa> EstadoEmpresa { get; set; }

    public virtual DbSet<Genero> Genero { get; set; }

    public virtual DbSet<Gerentes> Gerentes { get; set; }

    public virtual DbSet<Gln> Gln { get; set; }

    public virtual DbSet<GrupoEmpresa> GrupoEmpresa { get; set; }

    public virtual DbSet<GrupoProducto> GrupoProducto { get; set; }

    public virtual DbSet<HistorialCliente> HistorialCliente { get; set; }

    public virtual DbSet<Menus> Menus { get; set; }

    public virtual DbSet<Modulos> Modulos { get; set; }

    public virtual DbSet<NumeroControl> NumeroControl { get; set; }

    public virtual DbSet<Opciones> Opciones { get; set; }

    public virtual DbSet<Paises> Paises { get; set; }

    public virtual DbSet<Parametros> Parametros { get; set; }

    public virtual DbSet<Perfiles> Perfiles { get; set; }

    public virtual DbSet<PerfilesMenus> PerfilesMenus { get; set; }

    public virtual DbSet<PerfilesModulos> PerfilesModulos { get; set; }

    public virtual DbSet<PerfilesOpciones> PerfilesOpciones { get; set; }

    public virtual DbSet<PerfilesSistemas> PerfilesSistemas { get; set; }

    public virtual DbSet<Personas> Personas { get; set; }

    public virtual DbSet<Prefijos> Prefijos { get; set; }

    public virtual DbSet<Producto> Producto { get; set; }

    public virtual DbSet<ProductoDatosAdicionales> ProductoDatosAdicionales { get; set; }

    public virtual DbSet<ProductoDepartamento> ProductoDepartamento { get; set; }

    public virtual DbSet<ProductoDivision> ProductoDivision { get; set; }

    public virtual DbSet<ProductoGrupo> ProductoGrupo { get; set; }

    public virtual DbSet<ProductoSubDivision> ProductoSubDivision { get; set; }

    public virtual DbSet<Provincia> Provincia { get; set; }

    public virtual DbSet<Roles> Roles { get; set; }

    public virtual DbSet<Seccion> Seccion { get; set; }

    public virtual DbSet<Sector> Sector { get; set; }

    public virtual DbSet<Sistemas> Sistemas { get; set; }

    public virtual DbSet<Telefonos> Telefonos { get; set; }

    public virtual DbSet<TipoCliente> TipoCliente { get; set; }

    public virtual DbSet<TipoCodigoGs1> TipoCodigoGs1 { get; set; }

    public virtual DbSet<TipoDocumento> TipoDocumento { get; set; }

    public virtual DbSet<TipoEmpresaLocalizacion> TipoEmpresaLocalizacion { get; set; }

    public virtual DbSet<TipoLocalizacion> TipoLocalizacion { get; set; }

    public virtual DbSet<TipoOrigenIngresos> TipoOrigenIngresos { get; set; }

    public virtual DbSet<Usuarios> Usuarios { get; set; }

    public virtual DbSet<UsuariosPerfiles> UsuariosPerfiles { get; set; }

    public virtual DbSet<UsuariosRoles> UsuariosRoles { get; set; }

    public virtual DbSet<Vendedor> Vendedor { get; set; }

    public virtual DbSet<Zona> Zona { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Apisexternas>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__apisexte__3213E83F3755BE14");

            entity.ToTable("apisexternas", "seguridades");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ApiKey)
                .HasMaxLength(200)
                .HasColumnName("api_key");
            entity.Property(e => e.Estado)
                .HasDefaultValue(true)
                .HasColumnName("estado");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
            entity.Property(e => e.Ruta)
                .HasMaxLength(500)
                .HasColumnName("ruta");
            entity.Property(e => e.Urlbase)
                .HasMaxLength(500)
                .HasColumnName("urlbase");
        });

        modelBuilder.Entity<AuditoriaTransferencia>(entity =>
        {
            entity.HasKey(e => e.IdTransferenciaPrefijo);

            entity.ToTable("auditoria_transferencia", "sic");

            entity.Property(e => e.IdTransferenciaPrefijo).HasColumnName("id_transferencia_prefijo");
            entity.Property(e => e.ClientesCodigoDestino).HasColumnName("clientes_codigo_destino");
            entity.Property(e => e.ClientesCodigoOrigen).HasColumnName("clientes_codigo_origen");
            entity.Property(e => e.Fecha)
                .HasColumnType("datetime")
                .HasColumnName("fecha");
            entity.Property(e => e.IdPrefijos).HasColumnName("id_prefijos");
            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");
            entity.Property(e => e.Tipo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("tipo");

            entity.HasOne(d => d.ClientesCodigoDestinoNavigation).WithMany(p => p.AuditoriaTransferenciaClientesCodigoDestinoNavigation)
                .HasForeignKey(d => d.ClientesCodigoDestino)
                .HasConstraintName("FK_AuditoriaTransferencia_ClienteDestino");

            entity.HasOne(d => d.ClientesCodigoOrigenNavigation).WithMany(p => p.AuditoriaTransferenciaClientesCodigoOrigenNavigation)
                .HasForeignKey(d => d.ClientesCodigoOrigen)
                .HasConstraintName("FK_AuditoriaTransferencia_ClienteOrigen");

            entity.HasOne(d => d.IdPrefijosNavigation).WithMany(p => p.AuditoriaTransferencia)
                .HasForeignKey(d => d.IdPrefijos)
                .HasConstraintName("FK_AuditoriaTransferencia_Prefijo");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.AuditoriaTransferencia)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK_AuditoriaTransferencia_Usuario");
        });

        modelBuilder.Entity<Cantones>(entity =>
        {
            entity.HasKey(e => e.IdCanton).HasName("pk_sic_canton");

            entity.ToTable("cantones", "seguridades");

            entity.Property(e => e.IdCanton).HasColumnName("id_canton");
            entity.Property(e => e.IdProvincia).HasColumnName("id_provincia");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Referencia)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("referencia");

            entity.HasOne(d => d.IdProvinciaNavigation).WithMany(p => p.Cantones)
                .HasForeignKey(d => d.IdProvincia)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_canton_provincia");
        });

        modelBuilder.Entity<Ciudades>(entity =>
        {
            entity.HasKey(e => e.IdCiudad).HasName("pk_sic_ciudad");

            entity.ToTable("ciudades", "seguridades");

            entity.Property(e => e.IdCiudad).HasColumnName("id_ciudad");
            entity.Property(e => e.Area)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("area");
            entity.Property(e => e.IdCanton).HasColumnName("id_canton");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Referencia)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("referencia");

            entity.HasOne(d => d.IdCantonNavigation).WithMany(p => p.Ciudades)
                .HasForeignKey(d => d.IdCanton)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ciudad_canton");
        });

        modelBuilder.Entity<ClienteObservacion>(entity =>
        {
            entity.HasKey(e => e.IdClienteObservacion).HasName("PK_sic_cliente_observacion");

            entity.ToTable("cliente_observacion", "sic");

            entity.Property(e => e.IdClienteObservacion).HasColumnName("id_cliente_observacion");
            entity.Property(e => e.ClientesCodigo).HasColumnName("clientes_codigo");
            entity.Property(e => e.Detalle)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("detalle");
            entity.Property(e => e.Fecha)
                .HasColumnType("datetime")
                .HasColumnName("fecha");
            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");
        });

        modelBuilder.Entity<Clientes>(entity =>
        {
            entity.HasKey(e => e.ClientesCodigo).HasName("pk_sic_clientes");

            entity.ToTable("clientes", "sic");

            entity.Property(e => e.ClientesCodigo).HasColumnName("clientes_codigo");
            entity.Property(e => e.Ciudad)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("ciudad");
            entity.Property(e => e.Codcue)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("codcue");
            entity.Property(e => e.CodigoPostal)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("codigo_postal");
            entity.Property(e => e.CodigoPostal2)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("codigo_postal2");
            entity.Property(e => e.Concli)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("concli");
            entity.Property(e => e.Delestado).HasColumnName("delestado");
            entity.Property(e => e.Desde).HasColumnName("desde");
            entity.Property(e => e.Dircli)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("dircli");
            entity.Property(e => e.Email)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.EmpresaCodigo).HasColumnName("empresa_codigo");
            entity.Property(e => e.Fax)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("fax");
            entity.Property(e => e.Fecfac)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("fecfac");
            entity.Property(e => e.Fecfac1).HasColumnName("fecfac1");
            entity.Property(e => e.Fecfac2).HasColumnName("fecfac2");
            entity.Property(e => e.Fecfac3).HasColumnName("fecfac3");
            entity.Property(e => e.Fecfac4).HasColumnName("fecfac4");
            entity.Property(e => e.Fecfac5).HasColumnName("fecfac5");
            entity.Property(e => e.FechaCeseAct).HasColumnName("fecha_cese_act");
            entity.Property(e => e.Fechaactinact).HasColumnName("fechaactinact");
            entity.Property(e => e.Fechtre)
                .HasColumnType("datetime")
                .HasColumnName("fechtre");
            entity.Property(e => e.Fecing).HasColumnName("fecing");
            entity.Property(e => e.Fecmod).HasColumnName("fecmod");
            entity.Property(e => e.Fecnac).HasColumnName("fecnac");
            entity.Property(e => e.Formatodocumento).HasColumnName("formatodocumento");
            entity.Property(e => e.Genero)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("genero");
            entity.Property(e => e.Hello)
                .HasMaxLength(77)
                .IsUnicode(false)
                .HasColumnName("hello");
            entity.Property(e => e.IdCiudad).HasColumnName("id_ciudad");
            entity.Property(e => e.IdEstadoEmpresa).HasColumnName("id_estado_empresa");
            entity.Property(e => e.IdGrupoEmpresa).HasColumnName("id_grupo_empresa");
            entity.Property(e => e.IdGrupoProducto).HasColumnName("id_grupo_producto");
            entity.Property(e => e.IdPersona).HasColumnName("id_persona");
            entity.Property(e => e.IdTipoCliente).HasColumnName("id_tipo_cliente");
            entity.Property(e => e.IdVendedor).HasColumnName("id_vendedor");
            entity.Property(e => e.IdZona).HasColumnName("id_zona");
            entity.Property(e => e.Imprimeobstramite).HasColumnName("imprimeobstramite");
            entity.Property(e => e.Infcamahabitacion)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("infcamahabitacion");
            entity.Property(e => e.Marca1)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("marca1");
            entity.Property(e => e.Marca2)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("marca2");
            entity.Property(e => e.Marca3)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("marca3");
            entity.Property(e => e.Marca4)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("marca4");
            entity.Property(e => e.Marca5)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("marca5");
            entity.Property(e => e.MotivoCeseAct)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("motivo_cese_act");
            entity.Property(e => e.Nomcli)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("nomcli");
            entity.Property(e => e.Obs)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("obs");
            entity.Property(e => e.RazonSocial)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("razon_social");
            entity.Property(e => e.Representante)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("representante");
            entity.Property(e => e.Ruc)
                .HasMaxLength(13)
                .IsUnicode(false)
                .HasColumnName("ruc");
            entity.Property(e => e.Saldo)
                .HasColumnType("numeric(8, 2)")
                .HasColumnName("saldo");
            entity.Property(e => e.Seguimiento).HasColumnName("seguimiento");
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("telefono");
            entity.Property(e => e.Telefono1)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("telefono1");
            entity.Property(e => e.Usumod)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("usumod");
            entity.Property(e => e.Web)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("web");

            entity.HasOne(d => d.EmpresaCodigoNavigation).WithMany(p => p.Clientes)
                .HasForeignKey(d => d.EmpresaCodigo)
                .HasConstraintName("FK_sic_clientes_empresa");

            entity.HasOne(d => d.IdCiudadNavigation).WithMany(p => p.Clientes)
                .HasForeignKey(d => d.IdCiudad)
                .HasConstraintName("FK_sic_clientes_sic_ciudad");

            entity.HasOne(d => d.IdEstadoEmpresaNavigation).WithMany(p => p.Clientes)
                .HasForeignKey(d => d.IdEstadoEmpresa)
                .HasConstraintName("FK_sic_clientes_sic_estado_empresa");

            entity.HasOne(d => d.IdGrupoEmpresaNavigation).WithMany(p => p.Clientes)
                .HasForeignKey(d => d.IdGrupoEmpresa)
                .HasConstraintName("FK_sic_clientes_sic_grupo_empresa");

            entity.HasOne(d => d.IdGrupoProductoNavigation).WithMany(p => p.Clientes)
                .HasForeignKey(d => d.IdGrupoProducto)
                .HasConstraintName("FK_sic_clientes_sic_grupo_producto");

            entity.HasOne(d => d.IdTipoClienteNavigation).WithMany(p => p.Clientes)
                .HasForeignKey(d => d.IdTipoCliente)
                .HasConstraintName("FK_sic_clientes_sic_tipo_cliente");

            entity.HasOne(d => d.IdVendedorNavigation).WithMany(p => p.Clientes)
                .HasForeignKey(d => d.IdVendedor)
                .HasConstraintName("FK_sic_clientes_sic_vendedor");

            entity.HasOne(d => d.IdZonaNavigation).WithMany(p => p.Clientes)
                .HasForeignKey(d => d.IdZona)
                .HasConstraintName("FK_sic_clientes_sic_zona");
        });

        modelBuilder.Entity<Codigos14>(entity =>
        {
            entity.HasKey(e => e.IdCodigos14).HasName("PK_sic_codigos14");

            entity.ToTable("codigos14", "sic");

            entity.Property(e => e.IdCodigos14).HasColumnName("id_codigos14");
            entity.Property(e => e.Abrevia)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("abrevia");
            entity.Property(e => e.Activo).HasColumnName("activo");
            entity.Property(e => e.Ancho).HasColumnName("ancho");
            entity.Property(e => e.Codbar)
                .HasMaxLength(28)
                .IsUnicode(false)
                .HasColumnName("codbar");
            entity.Property(e => e.Codpro)
                .HasMaxLength(13)
                .IsUnicode(false)
                .HasColumnName("codpro");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.Facturar)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("facturar");
            entity.Property(e => e.Fecha).HasColumnName("fecha");
            entity.Property(e => e.Foto)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("foto");
            entity.Property(e => e.G14)
                .HasMaxLength(28)
                .IsUnicode(false)
                .HasColumnName("g14");
            entity.Property(e => e.Gtin)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("gtin");
            entity.Property(e => e.IdCliente).HasColumnName("id_cliente");
            entity.Property(e => e.IdPrefijos).HasColumnName("id_prefijos");
            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");
            entity.Property(e => e.Largo).HasColumnName("largo");
            entity.Property(e => e.Marca)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("marca");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Peso).HasColumnName("peso");
            entity.Property(e => e.Presentacion).HasColumnName("presentacion");
            entity.Property(e => e.Profundidad).HasColumnName("profundidad");
            entity.Property(e => e.Referencia)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("referencia");
            entity.Property(e => e.Sector)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("sector");
            entity.Property(e => e.Target)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("target");
            entity.Property(e => e.Unidad).HasColumnName("unidad");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Codigos14)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK_sic_codigos14_usuarios");
        });

        modelBuilder.Entity<ContactosClientes>(entity =>
        {
            entity.HasKey(e => e.IdContactosClientes).HasName("pk_sic_contactos_clientes");

            entity.ToTable("contactos_clientes", "sic");

            entity.Property(e => e.IdContactosClientes).HasColumnName("id_contactos_clientes");
            entity.Property(e => e.Cargo)
                .HasMaxLength(70)
                .IsUnicode(false)
                .HasColumnName("cargo");
            entity.Property(e => e.ClientesCodigo).HasColumnName("clientes_codigo");
            entity.Property(e => e.Email)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Nombre)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("telefono");
        });

        modelBuilder.Entity<Contadores>(entity =>
        {
            entity.HasKey(e => e.IdContador).HasName("PK__contador__085A4520BCB0E4BC");

            entity.ToTable("contadores", "seguridades");

            entity.Property(e => e.IdContador).HasColumnName("id_contador");
            entity.Property(e => e.EmpresaCodigo).HasColumnName("empresa_codigo");
            entity.Property(e => e.FechaFin).HasColumnName("fecha_fin");
            entity.Property(e => e.FechaInicio)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("fecha_inicio");
            entity.Property(e => e.IdPersona).HasColumnName("id_persona");
            entity.Property(e => e.Status)
                .HasDefaultValue(true)
                .HasColumnName("status");

            entity.HasOne(d => d.EmpresaCodigoNavigation).WithMany(p => p.Contadores)
                .HasForeignKey(d => d.EmpresaCodigo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_contador_empresa");

            entity.HasOne(d => d.IdPersonaNavigation).WithMany(p => p.Contadores)
                .HasForeignKey(d => d.IdPersona)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_contador_persona");
        });

        modelBuilder.Entity<Correos>(entity =>
        {
            entity.HasKey(e => e.IdCorreo).HasName("PK__correos__D5CABEB30471CA5E");

            entity.ToTable("correos", "seguridades");

            entity.HasIndex(e => e.Email, "UQ__correos__AB6E616414E86034").IsUnique();

            entity.Property(e => e.IdCorreo).HasColumnName("id_correo");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.IdPersona).HasColumnName("id_persona");
            entity.Property(e => e.Tipo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("tipo");

            entity.HasOne(d => d.IdPersonaNavigation).WithMany(p => p.Correos)
                .HasForeignKey(d => d.IdPersona)
                .HasConstraintName("FK__correos__id_pers__44952D46");
        });

        modelBuilder.Entity<DatosAdicionales>(entity =>
        {
            entity.HasKey(e => e.IdDatosAdicionales).HasName("pk_sic_datos_adicionales");

            entity.ToTable("datos_adicionales", "sic");

            entity.Property(e => e.IdDatosAdicionales).HasColumnName("id_datos_adicionales");
            entity.Property(e => e.ClientesCodigo).HasColumnName("clientes_codigo");
            entity.Property(e => e.Expprod).HasColumnName("expprod");
            entity.Property(e => e.Facebook).HasColumnName("facebook");
            entity.Property(e => e.Gs1ec).HasColumnName("gs1ec");
            entity.Property(e => e.Instagram).HasColumnName("instagram");
            entity.Property(e => e.Medico).HasColumnName("medico");
            entity.Property(e => e.Vendeus).HasColumnName("vendeus");
            entity.Property(e => e.Web)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("web");
        });

        modelBuilder.Entity<Departamentos>(entity =>
        {
            entity.HasKey(e => e.IdDepartamento);

            entity.ToTable("departamentos", "seguridades");

            entity.Property(e => e.IdDepartamento).HasColumnName("id_departamento");
            entity.Property(e => e.Cuenta)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("cuenta");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.IdEmpresa).HasColumnName("id_empresa");
            entity.Property(e => e.Nombre)
                .HasMaxLength(80)
                .IsUnicode(false)
                .HasColumnName("nombre");

            entity.HasOne(d => d.IdEmpresaNavigation).WithMany(p => p.Departamentos)
                .HasForeignKey(d => d.IdEmpresa)
                .HasConstraintName("FK_departamentos_empresas");
        });

        modelBuilder.Entity<Direcciones>(entity =>
        {
            entity.HasKey(e => e.IdDireccion).HasName("PK__direccio__25C35D07009A2750");

            entity.ToTable("direcciones", "seguridades");

            entity.Property(e => e.IdDireccion).HasColumnName("id_direccion");
            entity.Property(e => e.Calle)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("calle");
            entity.Property(e => e.Ciudad)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("ciudad");
            entity.Property(e => e.CodigoPostal)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("codigo_postal");
            entity.Property(e => e.Estado)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("estado");
            entity.Property(e => e.IdPersona).HasColumnName("id_persona");
            entity.Property(e => e.Pais)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("pais");
            entity.Property(e => e.Tipo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("tipo");

            entity.HasOne(d => d.IdPersonaNavigation).WithMany(p => p.Direcciones)
                .HasForeignKey(d => d.IdPersona)
                .HasConstraintName("FK__direccion__id_pe__4865BE2A");
        });

        modelBuilder.Entity<Empresas>(entity =>
        {
            entity.HasKey(e => e.IdEmpresa).HasName("pk_empresa");

            entity.ToTable("empresas", "seguridades");

            entity.Property(e => e.IdEmpresa).HasColumnName("id_empresa");
            entity.Property(e => e.CodigoEntidad)
                .HasMaxLength(7)
                .IsUnicode(false)
                .HasColumnName("codigo_entidad");
            entity.Property(e => e.ContribuyenteEspecial)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("contribuyente_especial");
            entity.Property(e => e.Direccion)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("direccion");
            entity.Property(e => e.Directorio)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("directorio");
            entity.Property(e => e.Email)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Establecimiento)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("establecimiento");
            entity.Property(e => e.Fax)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("fax");
            entity.Property(e => e.IdCiudad).HasColumnName("id_ciudad");
            entity.Property(e => e.Logo)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("logo");
            entity.Property(e => e.Moneda)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("moneda");
            entity.Property(e => e.Nombre)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.ObligadoContabilidad)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("obligado_contabilidad");
            entity.Property(e => e.Ruc)
                .HasMaxLength(13)
                .IsUnicode(false)
                .HasColumnName("ruc");
            entity.Property(e => e.Sistema)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("sistema");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.Telefono1)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("telefono1");
            entity.Property(e => e.Telefono2)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("telefono2");
            entity.Property(e => e.TipoCambio)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("tipo_cambio");
            entity.Property(e => e.TipoFacturacion)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("tipo_facturacion");

            entity.HasOne(d => d.IdCiudadNavigation).WithMany(p => p.Empresas)
                .HasForeignKey(d => d.IdCiudad)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_empresa_ciudad");
        });

        modelBuilder.Entity<EstadoCivil>(entity =>
        {
            entity.HasKey(e => e.EstadoCivilCodigo).HasName("pk_sic_estado_civil");

            entity.ToTable("estado_civil", "seguridades");

            entity.Property(e => e.EstadoCivilCodigo).HasColumnName("estado_civil_codigo");
            entity.Property(e => e.EstadoCivilNombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("estado_civil_nombre");
            entity.Property(e => e.EstadoCivilReferencia)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("estado_civil_referencia");
        });

        modelBuilder.Entity<EstadoEmpresa>(entity =>
        {
            entity.HasKey(e => e.IdEstadoEmpresa).HasName("pk_sic_estado_empresa");

            entity.ToTable("estado_empresa", "seguridades");

            entity.Property(e => e.IdEstadoEmpresa).HasColumnName("id_estado_empresa");
            entity.Property(e => e.EmpresaCodigo).HasColumnName("empresa_codigo");
            entity.Property(e => e.Fecha).HasColumnName("fecha");
            entity.Property(e => e.Nombre)
                .HasMaxLength(70)
                .IsUnicode(false)
                .HasColumnName("nombre");

            entity.HasOne(d => d.EmpresaCodigoNavigation).WithMany(p => p.EstadoEmpresa)
                .HasForeignKey(d => d.EmpresaCodigo)
                .HasConstraintName("FK_estado_empresa_empresa");
        });

        modelBuilder.Entity<Genero>(entity =>
        {
            entity.HasKey(e => e.GeneroCodigo).HasName("pk_sic_tipo_sexo");

            entity.ToTable("genero", "seguridades");

            entity.Property(e => e.GeneroCodigo).HasColumnName("genero_codigo");
            entity.Property(e => e.GeneroDescripcion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("genero_descripcion");
            entity.Property(e => e.GeneroReferencia)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("genero_referencia");
            entity.Property(e => e.Status).HasColumnName("status");
        });

        modelBuilder.Entity<Gerentes>(entity =>
        {
            entity.HasKey(e => e.IdGerente).HasName("PK__gerentes__0A301510DEE95B7A");

            entity.ToTable("gerentes", "seguridades");

            entity.Property(e => e.IdGerente).HasColumnName("id_gerente");
            entity.Property(e => e.EmpresaCodigo).HasColumnName("empresa_codigo");
            entity.Property(e => e.FechaFin).HasColumnName("fecha_fin");
            entity.Property(e => e.FechaInicio)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("fecha_inicio");
            entity.Property(e => e.IdPersona).HasColumnName("id_persona");
            entity.Property(e => e.Status)
                .HasDefaultValue(true)
                .HasColumnName("status");

            entity.HasOne(d => d.EmpresaCodigoNavigation).WithMany(p => p.Gerentes)
                .HasForeignKey(d => d.EmpresaCodigo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_gerente_empresa");

            entity.HasOne(d => d.IdPersonaNavigation).WithMany(p => p.Gerentes)
                .HasForeignKey(d => d.IdPersona)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_gerente_persona");
        });

        modelBuilder.Entity<Gln>(entity =>
        {
            entity.HasKey(e => e.IdGln).HasName("PK_sic_gln");

            entity.ToTable("gln", "sic");

            entity.Property(e => e.IdGln).HasColumnName("id_gln");
            entity.Property(e => e.ClientesCodigo).HasColumnName("clientes_codigo");
            entity.Property(e => e.Contacto)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("contacto");
            entity.Property(e => e.ContactoTel)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("contacto_tel");
            entity.Property(e => e.Direccion)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("direccion");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Europa)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("europa");
            entity.Property(e => e.Expprod).HasColumnName("expprod");
            entity.Property(e => e.Fax)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("fax");
            entity.Property(e => e.Fda)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("fda");
            entity.Property(e => e.Gas1org).HasColumnName("gas1org");
            entity.Property(e => e.Gln1)
                .HasMaxLength(14)
                .IsUnicode(false)
                .HasColumnName("gln");
            entity.Property(e => e.GlnCelular)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("gln_celular");
            entity.Property(e => e.GlnCodigopostal)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("gln_codigopostal");
            entity.Property(e => e.GlnCodpro)
                .HasMaxLength(13)
                .IsUnicode(false)
                .HasColumnName("gln_codpro");
            entity.Property(e => e.GlnContacto2)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("gln_contacto2");
            entity.Property(e => e.GlnContacto3)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("gln_contacto3");
            entity.Property(e => e.GlnEmail2)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("gln_email2");
            entity.Property(e => e.GlnEmail3)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("gln_email3");
            entity.Property(e => e.GlnFacturar)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("gln_facturar");
            entity.Property(e => e.GlnFecha).HasColumnName("gln_fecha");
            entity.Property(e => e.GlnGlne)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("gln_glne");
            entity.Property(e => e.GlnGlnp)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("gln_glnp");
            entity.Property(e => e.GlnGlobal)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("gln_global");
            entity.Property(e => e.GlnLatitud)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("gln_latitud");
            entity.Property(e => e.GlnLongitud)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("gln_longitud");
            entity.Property(e => e.GlnNombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("gln_nombre");
            entity.Property(e => e.GlnObs1)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("gln_obs1");
            entity.Property(e => e.GlnObs2)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("gln_obs2");
            entity.Property(e => e.GlnOrigenprefijo)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("gln_origenprefijo");
            entity.Property(e => e.GlnOtro1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("gln_otro1");
            entity.Property(e => e.GlnOtro2)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("gln_otro2");
            entity.Property(e => e.GlnPrefijogs1)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("gln_prefijogs1");
            entity.Property(e => e.GlnTel2)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("gln_tel2");
            entity.Property(e => e.GlnTel3)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("gln_tel3");
            entity.Property(e => e.Google).HasColumnName("google");
            entity.Property(e => e.Gs1ec).HasColumnName("gs1ec");
            entity.Property(e => e.Gs1latam).HasColumnName("gs1latam");
            entity.Property(e => e.Gs1otros)
                .HasMaxLength(500)
                .HasColumnName("gs1otros");
            entity.Property(e => e.IdCiudad).HasColumnName("id_ciudad");
            entity.Property(e => e.IdPais).HasColumnName("id_pais");
            entity.Property(e => e.IdPrefijos).HasColumnName("id_prefijos");
            entity.Property(e => e.IdTipoLocalizacion).HasColumnName("id_tipo_localizacion");
            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");
            entity.Property(e => e.LatiE).HasMaxLength(5);
            entity.Property(e => e.LatiG).HasMaxLength(5);
            entity.Property(e => e.LatiM).HasMaxLength(5);
            entity.Property(e => e.LatiS).HasMaxLength(8);
            entity.Property(e => e.LongE).HasMaxLength(5);
            entity.Property(e => e.LongG).HasMaxLength(5);
            entity.Property(e => e.LongM).HasMaxLength(5);
            entity.Property(e => e.LongS).HasMaxLength(8);
            entity.Property(e => e.NombreLocalizacion)
                .HasMaxLength(200)
                .HasColumnName("nombre_localizacion");
            entity.Property(e => e.Observ)
                .HasMaxLength(500)
                .HasColumnName("observ");
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("telefono");
            entity.Property(e => e.Web)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("web");

            entity.HasOne(d => d.ClientesCodigoNavigation).WithMany(p => p.Gln)
                .HasForeignKey(d => d.ClientesCodigo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Gln_Clientes");

            entity.HasOne(d => d.IdCiudadNavigation).WithMany(p => p.Gln)
                .HasForeignKey(d => d.IdCiudad)
                .HasConstraintName("FK_sic_gln_sic_ciudad");

            entity.HasOne(d => d.IdPaisNavigation).WithMany(p => p.Gln)
                .HasForeignKey(d => d.IdPais)
                .HasConstraintName("FK_sic_gln_sic_pais");

            entity.HasOne(d => d.IdPrefijosNavigation).WithMany(p => p.Gln)
                .HasForeignKey(d => d.IdPrefijos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Gln_Prefijos");

            entity.HasOne(d => d.IdTipoLocalizacionNavigation).WithMany(p => p.Gln)
                .HasForeignKey(d => d.IdTipoLocalizacion)
                .HasConstraintName("FK_sic_gln_sic_tipo_localizacion");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Gln)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK_sic_gln_usuarios");
        });

        modelBuilder.Entity<GrupoEmpresa>(entity =>
        {
            entity.HasKey(e => e.IdGrupoEmpresa).HasName("pk_sic_grupo_empresa");

            entity.ToTable("grupo_empresa", "sic");

            entity.Property(e => e.IdGrupoEmpresa).HasColumnName("id_grupo_empresa");
            entity.Property(e => e.Asignacion).HasColumnName("asignacion");
            entity.Property(e => e.AsignacionDolar).HasColumnName("asignacion_dolar");
            entity.Property(e => e.Codigo)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("codigo");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.Fecha).HasColumnName("fecha");
            entity.Property(e => e.Inscripcion).HasColumnName("inscripcion");
            entity.Property(e => e.InscripcionDolar).HasColumnName("inscripcion_dolar");
            entity.Property(e => e.Mantenimiento).HasColumnName("mantenimiento");
            entity.Property(e => e.MantenimientoDolar).HasColumnName("mantenimiento_dolar");
            entity.Property(e => e.Nombre)
                .HasMaxLength(70)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.ProductoAsignacion)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("producto_asignacion");
            entity.Property(e => e.ProductoInscripcion)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("producto_inscripcion");
            entity.Property(e => e.ProductoMantenimiento)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("producto_mantenimiento");
            entity.Property(e => e.ValorAnual).HasColumnName("valor_anual");
        });

        modelBuilder.Entity<GrupoProducto>(entity =>
        {
            entity.HasKey(e => e.IdGrupoProducto).HasName("pk_sic_grupo_producto");

            entity.ToTable("grupo_producto", "sic");

            entity.Property(e => e.IdGrupoProducto).HasColumnName("id_grupo_producto");
            entity.Property(e => e.Brick)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("brick");
            entity.Property(e => e.Clase)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("clase");
            entity.Property(e => e.Codigo)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("codigo");
            entity.Property(e => e.DesBrick)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("des_brick");
            entity.Property(e => e.DesBricking)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("des_bricking");
            entity.Property(e => e.DesClase)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("des_clase");
            entity.Property(e => e.DesClaseing)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("des_claseing");
            entity.Property(e => e.DesFamilia)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("des_familia");
            entity.Property(e => e.DesFamiliaing)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("des_familiaing");
            entity.Property(e => e.DesSegmento)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("des_segmento");
            entity.Property(e => e.DesSegmentoing)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("des_segmentoing");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.Familia)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("familia");
            entity.Property(e => e.Segmento)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("segmento");
        });

        modelBuilder.Entity<HistorialCliente>(entity =>
        {
            entity.HasKey(e => e.IdHistorialCliente);

            entity.ToTable("historial_cliente", "sic");

            entity.Property(e => e.IdHistorialCliente).HasColumnName("id_historial_cliente");
            entity.Property(e => e.ClientesCodigo).HasColumnName("clientes_codigo");
            entity.Property(e => e.Descripcion)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.Fecha)
                .HasColumnType("datetime")
                .HasColumnName("fecha");
            entity.Property(e => e.IdEmpresa).HasColumnName("id_empresa");
            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");
            entity.Property(e => e.NombreUsuario)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("nombre_usuario");
            entity.Property(e => e.Tabla)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("tabla");
            entity.Property(e => e.TipoAccion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("tipo_accion");

            entity.HasOne(d => d.ClientesCodigoNavigation).WithMany(p => p.HistorialCliente)
                .HasForeignKey(d => d.ClientesCodigo)
                .HasConstraintName("FK_Historial_Clientes");

            entity.HasOne(d => d.IdEmpresaNavigation).WithMany(p => p.HistorialCliente)
                .HasForeignKey(d => d.IdEmpresa)
                .HasConstraintName("FK_Historial_empresa");
        });

        modelBuilder.Entity<Menus>(entity =>
        {
            entity.HasKey(e => e.IdMenu).HasName("PK__menus__68A1D9DB5E611002");

            entity.ToTable("menus", "seguridades");

            entity.Property(e => e.IdMenu).HasColumnName("id_menu");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.IdModulo).HasColumnName("id_modulo");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Status).HasColumnName("status");

            entity.HasOne(d => d.IdModuloNavigation).WithMany(p => p.Menus)
                .HasForeignKey(d => d.IdModulo)
                .HasConstraintName("FK__menus__id_modulo__25518C17");
        });

        modelBuilder.Entity<Modulos>(entity =>
        {
            entity.HasKey(e => e.IdModulo).HasName("PK__modulos__B2584DFC402C2407");

            entity.ToTable("modulos", "seguridades");

            entity.Property(e => e.IdModulo).HasColumnName("id_modulo");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.IdSistema).HasColumnName("id_sistema");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Status).HasColumnName("status");

            entity.HasOne(d => d.IdSistemaNavigation).WithMany(p => p.Modulos)
                .HasForeignKey(d => d.IdSistema)
                .HasConstraintName("FK__modulos__id_sist__2645B050");
        });

        modelBuilder.Entity<NumeroControl>(entity =>
        {
            entity.HasKey(e => e.IdNumeroControl).HasName("PK_sic_numero_control");

            entity.ToTable("numero_control", "sic");

            entity.Property(e => e.IdNumeroControl).HasColumnName("id_numero_control");
            entity.Property(e => e.Codcon).HasColumnName("codcon");
            entity.Property(e => e.EmpresaCodigo).HasColumnName("empresa_codigo");
            entity.Property(e => e.Modcon)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("modcon");
            entity.Property(e => e.Numcon)
                .HasMaxLength(14)
                .IsUnicode(false)
                .HasColumnName("numcon");
            entity.Property(e => e.Ocupado).HasColumnName("ocupado");
            entity.Property(e => e.Tipcon)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("tipcon");
        });

        modelBuilder.Entity<Opciones>(entity =>
        {
            entity.HasKey(e => e.IdOpcion).HasName("PK__opciones__A41C30186FE59AD8");

            entity.ToTable("opciones", "seguridades");

            entity.Property(e => e.IdOpcion).HasColumnName("id_opcion");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.IdMenu).HasColumnName("id_menu");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Status).HasColumnName("status");

            entity.HasOne(d => d.IdMenuNavigation).WithMany(p => p.Opciones)
                .HasForeignKey(d => d.IdMenu)
                .HasConstraintName("FK__opciones__id_men__18EBB532");
        });

        modelBuilder.Entity<Paises>(entity =>
        {
            entity.HasKey(e => e.IdPais).HasName("pk_sic_pais");

            entity.ToTable("paises", "seguridades");

            entity.Property(e => e.IdPais).HasColumnName("id_pais");
            entity.Property(e => e.CodigoArea).HasColumnName("codigo_area");
            entity.Property(e => e.Codzona)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("codzona");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Parametros>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__parametr__326FD81AA2AC7927");

            entity.ToTable("parametros", "seguridades");

            entity.HasIndex(e => e.Clave, "UQ__parametr__71DCA3DB71E21189").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Clave)
                .HasMaxLength(100)
                .HasColumnName("clave");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .HasColumnName("descripcion");
            entity.Property(e => e.Estado)
                .HasDefaultValue(true)
                .HasColumnName("estado");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fecha_creacion");
            entity.Property(e => e.Valor)
                .HasMaxLength(500)
                .HasColumnName("valor");
        });

        modelBuilder.Entity<Perfiles>(entity =>
        {
            entity.HasKey(e => e.IdPerfil).HasName("PK__perfiles__1D1C87684BC4CDA1");

            entity.ToTable("perfiles", "seguridades");

            entity.HasIndex(e => e.Nombre, "UQ__perfiles__72AFBCC61AE3324A").IsUnique();

            entity.Property(e => e.IdPerfil).HasColumnName("id_perfil");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fecha_creacion");
            entity.Property(e => e.IdEmpresa).HasColumnName("id_empresa");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre");

            entity.HasOne(d => d.IdEmpresaNavigation).WithMany(p => p.Perfiles)
                .HasForeignKey(d => d.IdEmpresa)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_perfiles_empresa");
        });

        modelBuilder.Entity<PerfilesMenus>(entity =>
        {
            entity.HasKey(e => e.IdPerfilMenu);

            entity.ToTable("perfiles_menus", "seguridades");

            entity.Property(e => e.IdPerfilMenu).HasColumnName("id_perfil_menu");
            entity.Property(e => e.FechaCreacion)
                .HasColumnType("datetime")
                .HasColumnName("fecha_creacion");
            entity.Property(e => e.IdMenu).HasColumnName("id_menu");
            entity.Property(e => e.IdPerfil).HasColumnName("id_perfil");
            entity.Property(e => e.Status).HasColumnName("status");

            entity.HasOne(d => d.IdMenuNavigation).WithMany(p => p.PerfilesMenus)
                .HasForeignKey(d => d.IdMenu)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_perfiles_menus_menus");

            entity.HasOne(d => d.IdPerfilNavigation).WithMany(p => p.PerfilesMenus)
                .HasForeignKey(d => d.IdPerfil)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_perfiles_menus_perfiles");
        });

        modelBuilder.Entity<PerfilesModulos>(entity =>
        {
            entity.HasKey(e => e.IdPerfilModulo);

            entity.ToTable("perfiles_modulos", "seguridades");

            entity.Property(e => e.IdPerfilModulo).HasColumnName("id_perfil_modulo");
            entity.Property(e => e.FechaCreacion)
                .HasColumnType("datetime")
                .HasColumnName("fecha_creacion");
            entity.Property(e => e.IdModulo).HasColumnName("id_modulo");
            entity.Property(e => e.IdPerfil).HasColumnName("id_perfil");
            entity.Property(e => e.Status).HasColumnName("status");

            entity.HasOne(d => d.IdModuloNavigation).WithMany(p => p.PerfilesModulos)
                .HasForeignKey(d => d.IdModulo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_perfiles_modulos_modulos");

            entity.HasOne(d => d.IdPerfilNavigation).WithMany(p => p.PerfilesModulos)
                .HasForeignKey(d => d.IdPerfil)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_perfiles_modulos_perfiles");
        });

        modelBuilder.Entity<PerfilesOpciones>(entity =>
        {
            entity.HasKey(e => e.IdPerfilOpcion);

            entity.ToTable("perfiles_opciones", "seguridades");

            entity.Property(e => e.IdPerfilOpcion).HasColumnName("id_perfil_opcion");
            entity.Property(e => e.FechaCreacion)
                .HasColumnType("datetime")
                .HasColumnName("fecha_creacion");
            entity.Property(e => e.IdOpcion).HasColumnName("id_opcion");
            entity.Property(e => e.IdPerfil).HasColumnName("id_perfil");
            entity.Property(e => e.Status).HasColumnName("status");

            entity.HasOne(d => d.IdOpcionNavigation).WithMany(p => p.PerfilesOpciones)
                .HasForeignKey(d => d.IdOpcion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_perfiles_opciones_opciones");

            entity.HasOne(d => d.IdPerfilNavigation).WithMany(p => p.PerfilesOpciones)
                .HasForeignKey(d => d.IdPerfil)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_perfiles_opciones_perfiles");
        });

        modelBuilder.Entity<PerfilesSistemas>(entity =>
        {
            entity.HasKey(e => e.IdPerfilSistema);

            entity.ToTable("perfiles_sistemas", "seguridades");

            entity.Property(e => e.IdPerfilSistema).HasColumnName("id_perfil_sistema");
            entity.Property(e => e.FechaCreacion)
                .HasColumnType("datetime")
                .HasColumnName("fecha_creacion");
            entity.Property(e => e.IdPerfil).HasColumnName("id_perfil");
            entity.Property(e => e.IdSistema).HasColumnName("id_sistema");
            entity.Property(e => e.Status).HasColumnName("status");

            entity.HasOne(d => d.IdPerfilNavigation).WithMany(p => p.PerfilesSistemas)
                .HasForeignKey(d => d.IdPerfil)
                .HasConstraintName("FK_perfiles_sistemas_perfiles");

            entity.HasOne(d => d.IdSistemaNavigation).WithMany(p => p.PerfilesSistemas)
                .HasForeignKey(d => d.IdSistema)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_perfiles_sistemas_sistemas");
        });

        modelBuilder.Entity<Personas>(entity =>
        {
            entity.HasKey(e => e.IdPersona).HasName("PK__personas__228148B0A81EA645");

            entity.ToTable("personas", "seguridades");

            entity.HasIndex(e => e.Documento, "UQ__personas__A25B3E617942C33D").IsUnique();

            entity.Property(e => e.IdPersona).HasColumnName("id_persona");
            entity.Property(e => e.Apellido1)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("apellido1");
            entity.Property(e => e.Apellido2)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("apellido2");
            entity.Property(e => e.Documento)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("documento");
            entity.Property(e => e.FechaNacimiento).HasColumnName("fecha_nacimiento");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fecha_registro");
            entity.Property(e => e.IdCiudad).HasColumnName("id_ciudad");
            entity.Property(e => e.IdEstadoCivil).HasColumnName("id_estado_civil");
            entity.Property(e => e.IdGenero).HasColumnName("id_genero");
            entity.Property(e => e.IdTipoDocumento).HasColumnName("id_tipo_documento");
            entity.Property(e => e.Nombre1)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("nombre1");
            entity.Property(e => e.Nombre2)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("nombre2");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.TipoPersona)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("tipo_persona");

            entity.HasOne(d => d.IdCiudadNavigation).WithMany(p => p.Personas)
                .HasForeignKey(d => d.IdCiudad)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_personas_ciudad");

            entity.HasOne(d => d.IdEstadoCivilNavigation).WithMany(p => p.Personas)
                .HasForeignKey(d => d.IdEstadoCivil)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_personas_estado_civil");

            entity.HasOne(d => d.IdGeneroNavigation).WithMany(p => p.Personas)
                .HasForeignKey(d => d.IdGenero)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_personas_genero");

            entity.HasOne(d => d.IdTipoDocumentoNavigation).WithMany(p => p.Personas)
                .HasForeignKey(d => d.IdTipoDocumento)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_personas_tipo_documento2");
        });

        modelBuilder.Entity<Prefijos>(entity =>
        {
            entity.HasKey(e => e.IdPrefijos).HasName("pk_sic_prefijos");

            entity.ToTable("prefijos", "sic");

            entity.Property(e => e.IdPrefijos).HasColumnName("id_prefijos");
            entity.Property(e => e.Bandera).HasColumnName("bandera");
            entity.Property(e => e.ClientesCodigo).HasColumnName("clientes_codigo");
            entity.Property(e => e.Codpre)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("codpre");
            entity.Property(e => e.Codpro)
                .HasMaxLength(13)
                .IsUnicode(false)
                .HasColumnName("codpro");
            entity.Property(e => e.Control).HasColumnName("control");
            entity.Property(e => e.Digitos)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("digitos");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.Facturar)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("facturar");
            entity.Property(e => e.Fecfac)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("fecfac");
            entity.Property(e => e.Fecha).HasColumnName("fecha");
            entity.Property(e => e.FechaCierre)
                .HasColumnType("datetime")
                .HasColumnName("fecha_cierre");
            entity.Property(e => e.Ngln).HasColumnName("ngln");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Observacion)
                .HasMaxLength(225)
                .IsUnicode(false)
                .HasColumnName("observacion");
            entity.Property(e => e.Orden).HasColumnName("orden");
            entity.Property(e => e.OrigenPrefijo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("origen_prefijo");
            entity.Property(e => e.Prefijosgs1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("prefijosgs1");
            entity.Property(e => e.ReferenciaInterna)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("referencia_interna");

            entity.HasOne(d => d.ClientesCodigoNavigation).WithMany(p => p.Prefijos)
                .HasForeignKey(d => d.ClientesCodigo)
                .HasConstraintName("FK_prefijos_clientes");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.IdProducto).HasName("PK_sic_producto");

            entity.ToTable("producto", "sic");

            entity.Property(e => e.IdProducto)
                .ValueGeneratedNever()
                .HasColumnName("id_producto");
            entity.Property(e => e.Abrevia)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("abrevia");
            entity.Property(e => e.Activo).HasColumnName("activo");
            entity.Property(e => e.AltoRiesgo).HasColumnName("alto_riesgo");
            entity.Property(e => e.Ancho).HasColumnName("ancho");
            entity.Property(e => e.CantConv).HasColumnName("cant_conv");
            entity.Property(e => e.CantDecimal).HasColumnName("cant_decimal");
            entity.Property(e => e.ClasProd)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("clas_prod");
            entity.Property(e => e.CodColUbi)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("cod_col_ubi");
            entity.Property(e => e.CodNiv)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("cod_niv");
            entity.Property(e => e.Codcol).HasColumnName("codcol");
            entity.Property(e => e.Codcuedeb)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("codcuedeb");
            entity.Property(e => e.Codcuedes)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("codcuedes");
            entity.Property(e => e.Codcuedev)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("codcuedev");
            entity.Property(e => e.Codcuehab)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("codcuehab");
            entity.Property(e => e.Codorigen)
                .HasMaxLength(13)
                .IsUnicode(false)
                .HasColumnName("codorigen");
            entity.Property(e => e.Codpro)
                .HasMaxLength(13)
                .IsUnicode(false)
                .HasColumnName("codpro");
            entity.Property(e => e.Codsab)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("codsab");
            entity.Property(e => e.Codubi)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("codubi");
            entity.Property(e => e.Coleccion)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("coleccion");
            entity.Property(e => e.Colsab)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("colsab");
            entity.Property(e => e.CosAnterior).HasColumnName("cos_anterior");
            entity.Property(e => e.Cospro).HasColumnName("cospro");
            entity.Property(e => e.CostHelado).HasColumnName("cost_helado");
            entity.Property(e => e.CostSuminis).HasColumnName("cost_suminis");
            entity.Property(e => e.CtaProdGasto)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("cta_prod_gasto");
            entity.Property(e => e.DescCosto1).HasColumnName("desc_costo1");
            entity.Property(e => e.DescCosto2).HasColumnName("desc_costo2");
            entity.Property(e => e.DescCosto3).HasColumnName("desc_costo3");
            entity.Property(e => e.DescCosto4).HasColumnName("desc_costo4");
            entity.Property(e => e.Descuentos).HasColumnName("descuentos");
            entity.Property(e => e.Desind)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("desind");
            entity.Property(e => e.Despro)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("despro");
            entity.Property(e => e.Despro2)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("despro2");
            entity.Property(e => e.EmpresaCodigo).HasColumnName("empresa_codigo");
            entity.Property(e => e.Espesor).HasColumnName("espesor");
            entity.Property(e => e.Exipdc).HasColumnName("exipdc");
            entity.Property(e => e.Exipdv).HasColumnName("exipdv");
            entity.Property(e => e.Exiqty).HasColumnName("exiqty");
            entity.Property(e => e.Exisic).HasColumnName("exisic");
            entity.Property(e => e.Fabricante).HasColumnName("fabricante");
            entity.Property(e => e.FecCosAct)
                .HasColumnType("datetime")
                .HasColumnName("fec_cos_act");
            entity.Property(e => e.FecCosMod)
                .HasColumnType("datetime")
                .HasColumnName("fec_cos_mod");
            entity.Property(e => e.FecFinPro)
                .HasColumnType("datetime")
                .HasColumnName("fec_fin_pro");
            entity.Property(e => e.FecFinPro1)
                .HasColumnType("datetime")
                .HasColumnName("fec_fin_pro1");
            entity.Property(e => e.FecIniPro)
                .HasColumnType("datetime")
                .HasColumnName("fec_ini_pro");
            entity.Property(e => e.FecIniPro1)
                .HasColumnType("datetime")
                .HasColumnName("fec_ini_pro1");
            entity.Property(e => e.FecMarAntes)
                .HasColumnType("datetime")
                .HasColumnName("fec_mar_antes");
            entity.Property(e => e.FecPreAct)
                .HasColumnType("datetime")
                .HasColumnName("fec_pre_act");
            entity.Property(e => e.FecPreAnt)
                .HasColumnType("datetime")
                .HasColumnName("fec_pre_ant");
            entity.Property(e => e.FecPreMod)
                .HasColumnType("datetime")
                .HasColumnName("fec_pre_mod");
            entity.Property(e => e.Feccre)
                .HasColumnType("datetime")
                .HasColumnName("feccre");
            entity.Property(e => e.Fechacad)
                .HasMaxLength(7)
                .IsUnicode(false)
                .HasColumnName("fechacad");
            entity.Property(e => e.Fechacad1).HasColumnName("fechacad1");
            entity.Property(e => e.Fechamod)
                .HasColumnType("datetime")
                .HasColumnName("fechamod");
            entity.Property(e => e.Fecing)
                .HasColumnType("datetime")
                .HasColumnName("fecing");
            entity.Property(e => e.Fecsic)
                .HasColumnType("datetime")
                .HasColumnName("fecsic");
            entity.Property(e => e.Foto)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("foto");
            entity.Property(e => e.GrupoCodigo).HasColumnName("grupo_codigo");
            entity.Property(e => e.IdDatosAdicionales).HasColumnName("id_datos_adicionales");
            entity.Property(e => e.IdDepartamento).HasColumnName("id_departamento");
            entity.Property(e => e.IdDivision).HasColumnName("id_division");
            entity.Property(e => e.IdSeccion).HasColumnName("id_seccion");
            entity.Property(e => e.IdSubDivision).HasColumnName("id_sub_division");
            entity.Property(e => e.Iva)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("iva");
            entity.Property(e => e.Largo).HasColumnName("largo");
            entity.Property(e => e.Marca).HasColumnName("marca");
            entity.Property(e => e.MargenAntes).HasColumnName("margen_antes");
            entity.Property(e => e.MargenUtilidad).HasColumnName("margen_utilidad");
            entity.Property(e => e.Modelo)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasColumnName("modelo");
            entity.Property(e => e.Numserie)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("numserie");
            entity.Property(e => e.Obs)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("obs");
            entity.Property(e => e.PGasto).HasColumnName("p_gasto");
            entity.Property(e => e.PagaRegalia).HasColumnName("paga_regalia");
            entity.Property(e => e.Peso).HasColumnName("peso");
            entity.Property(e => e.PorcenRecepcion).HasColumnName("porcen_recepcion");
            entity.Property(e => e.PreAnterior).HasColumnName("pre_anterior");
            entity.Property(e => e.PreRebaja).HasColumnName("pre_rebaja");
            entity.Property(e => e.PreRebajaAntes).HasColumnName("pre_rebaja_antes");
            entity.Property(e => e.Precos).HasColumnName("precos");
            entity.Property(e => e.Prepormayor).HasColumnName("prepormayor");
            entity.Property(e => e.Preven).HasColumnName("preven");
            entity.Property(e => e.Preven2).HasColumnName("preven2");
            entity.Property(e => e.PvpSinIva).HasColumnName("pvp_sin_iva");
            entity.Property(e => e.Receta).HasColumnName("receta");
            entity.Property(e => e.Refer)
                .HasMaxLength(15)
                .HasColumnName("refer");
            entity.Property(e => e.Referencia)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("referencia");
            entity.Property(e => e.RegSanitario)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("reg_sanitario");
            entity.Property(e => e.StockMax).HasColumnName("stock_max");
            entity.Property(e => e.StockMin).HasColumnName("stock_min");
            entity.Property(e => e.Stocks).HasColumnName("stocks");
            entity.Property(e => e.Talla)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("talla");
            entity.Property(e => e.Tamanio)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("tamanio");
            entity.Property(e => e.Temporada)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("temporada");
            entity.Property(e => e.Tippro)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("tippro");
            entity.Property(e => e.Uniman)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("uniman");
            entity.Property(e => e.ValorUnidad).HasColumnName("valor_unidad");

            entity.HasOne(d => d.EmpresaCodigoNavigation).WithMany(p => p.Producto)
                .HasForeignKey(d => d.EmpresaCodigo)
                .HasConstraintName("FK_sic_producto_empresa");

            entity.HasOne(d => d.GrupoCodigoNavigation).WithMany(p => p.Producto)
                .HasForeignKey(d => d.GrupoCodigo)
                .HasConstraintName("FK_sic_producto_sic_producto_grupo");

            entity.HasOne(d => d.IdDivisionNavigation).WithMany(p => p.Producto)
                .HasForeignKey(d => d.IdDivision)
                .HasConstraintName("FK_sic_producto_sic_producto_division");

            entity.HasOne(d => d.IdSeccionNavigation).WithMany(p => p.Producto)
                .HasForeignKey(d => d.IdSeccion)
                .HasConstraintName("FK_sic_producto_sic_seccion");

            entity.HasOne(d => d.IdSubDivisionNavigation).WithMany(p => p.Producto)
                .HasForeignKey(d => d.IdSubDivision)
                .HasConstraintName("FK_sic_producto_sic_producto_sub_division");
        });

        modelBuilder.Entity<ProductoDatosAdicionales>(entity =>
        {
            entity.HasKey(e => e.ClientesCodigo).HasName("PK_sic_producto_datos_adicionales");

            entity.ToTable("producto_datos_adicionales", "sic");

            entity.Property(e => e.ClientesCodigo)
                .ValueGeneratedNever()
                .HasColumnName("clientes_codigo");
            entity.Property(e => e.Aum)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("aum");
            entity.Property(e => e.Autfuncion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("autfuncion");
            entity.Property(e => e.Brick)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("brick");
            entity.Property(e => e.Codint)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("codint");
            entity.Property(e => e.Contenido)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("contenido");
            entity.Property(e => e.Facturar)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("facturar");
            entity.Property(e => e.Gtin)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("gtin");
            entity.Property(e => e.IdPrefijos).HasColumnName("id_prefijos");
            entity.Property(e => e.IdProductoDatosAdicionales)
                .ValueGeneratedOnAdd()
                .HasColumnName("id__producto_datos_adicionales");
            entity.Property(e => e.IdProductoGrupo)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("id_producto_grupo");
            entity.Property(e => e.IdSector).HasColumnName("id_sector");
            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");
            entity.Property(e => e.Lum)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("lum");
            entity.Property(e => e.Marca)
                .HasMaxLength(190)
                .IsUnicode(false)
                .HasColumnName("marca");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Obsc)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("obsc");
            entity.Property(e => e.Pais)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("pais");
            entity.Property(e => e.Pais2)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("pais2");
            entity.Property(e => e.Pais3)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("pais3");
            entity.Property(e => e.Peso1).HasColumnName("peso1");
            entity.Property(e => e.Pum)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("pum");
            entity.Property(e => e.Registros)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("registros");
            entity.Property(e => e.Secto2)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("secto2");
            entity.Property(e => e.Sector3)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("sector3");
            entity.Property(e => e.SolAmazon).HasColumnName("sol_amazon");
            entity.Property(e => e.SolEbay).HasColumnName("sol_ebay");
            entity.Property(e => e.SolFavorita).HasColumnName("sol_favorita");
            entity.Property(e => e.SolGoogle).HasColumnName("sol_google");
            entity.Property(e => e.SolOtros)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("sol_otros");
            entity.Property(e => e.SolRosado).HasColumnName("sol_rosado");
            entity.Property(e => e.SolSantamaria).HasColumnName("sol_santamaria");
            entity.Property(e => e.SolTia).HasColumnName("sol_tia");
            entity.Property(e => e.Target)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("target");
            entity.Property(e => e.TipoCodigoGs1Codigo).HasColumnName("tipo_codigo_gs1_codigo");
            entity.Property(e => e.Um)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("um");
            entity.Property(e => e.Url)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("url");
            entity.Property(e => e.Url2)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("url2");

            entity.HasOne(d => d.ClientesCodigoNavigation).WithOne(p => p.ProductoDatosAdicionales)
                .HasForeignKey<ProductoDatosAdicionales>(d => d.ClientesCodigo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_sic_producto_datos_adicionales_sic_producto");

            entity.HasOne(d => d.IdSectorNavigation).WithMany(p => p.ProductoDatosAdicionales)
                .HasForeignKey(d => d.IdSector)
                .HasConstraintName("FK_sic_producto_datos_adicionales_sic_sector");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.ProductoDatosAdicionales)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK_sic_producto_datos_adicionales_usuarios");

            entity.HasOne(d => d.TipoCodigoGs1CodigoNavigation).WithMany(p => p.ProductoDatosAdicionales)
                .HasForeignKey(d => d.TipoCodigoGs1Codigo)
                .HasConstraintName("FK_sic_producto_datos_adicionales_sic_tipo_codigo_gs1");
        });

        modelBuilder.Entity<ProductoDepartamento>(entity =>
        {
            entity.HasKey(e => e.IdProductoDepartamento).HasName("PK_sic_producto_departamento");

            entity.ToTable("producto_departamento", "sic");

            entity.Property(e => e.IdProductoDepartamento).HasColumnName("id_producto_departamento");
            entity.Property(e => e.Coddep).HasColumnName("coddep");
            entity.Property(e => e.Desdep)
                .HasMaxLength(80)
                .IsUnicode(false)
                .HasColumnName("desdep");
            entity.Property(e => e.IdProductoDivision).HasColumnName("id_producto_division");

            entity.HasOne(d => d.IdProductoDivisionNavigation).WithMany(p => p.ProductoDepartamento)
                .HasForeignKey(d => d.IdProductoDivision)
                .HasConstraintName("FK_sic_producto_departamento_sic_producto_division");
        });

        modelBuilder.Entity<ProductoDivision>(entity =>
        {
            entity.HasKey(e => e.IdProductoDivision).HasName("PK_sic_producto_division");

            entity.ToTable("producto_division", "sic");

            entity.Property(e => e.IdProductoDivision).HasColumnName("id_producto_division");
            entity.Property(e => e.Coddiv).HasColumnName("coddiv");
            entity.Property(e => e.Desdiv)
                .HasMaxLength(80)
                .IsUnicode(false)
                .HasColumnName("desdiv");
        });

        modelBuilder.Entity<ProductoGrupo>(entity =>
        {
            entity.HasKey(e => e.IdProductoGrupo).HasName("PK_sic_producto_grupo");

            entity.ToTable("producto_grupo", "sic");

            entity.Property(e => e.IdProductoGrupo).HasColumnName("id_producto_grupo");
            entity.Property(e => e.Codgru).HasColumnName("codgru");
            entity.Property(e => e.Desgru)
                .HasMaxLength(80)
                .IsUnicode(false)
                .HasColumnName("desgru");
            entity.Property(e => e.Sec)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("sec");
        });

        modelBuilder.Entity<ProductoSubDivision>(entity =>
        {
            entity.HasKey(e => e.IdProductoSubDivision).HasName("PK_sic_producto_sub_division");

            entity.ToTable("producto_sub_division", "sic");

            entity.Property(e => e.IdProductoSubDivision).HasColumnName("id_producto_sub_division");
            entity.Property(e => e.Dessub)
                .HasMaxLength(80)
                .IsUnicode(false)
                .HasColumnName("dessub");
            entity.Property(e => e.IdProductoDivision).HasColumnName("id_producto_division");
            entity.Property(e => e.PeaCodigoHis).HasColumnName("pea_codigo_his");

            entity.HasOne(d => d.IdProductoDivisionNavigation).WithMany(p => p.ProductoSubDivision)
                .HasForeignKey(d => d.IdProductoDivision)
                .HasConstraintName("FK_sic_producto_sub_division_sic_producto_division");
        });

        modelBuilder.Entity<Provincia>(entity =>
        {
            entity.HasKey(e => e.IdProvincia).HasName("pk_sic_provincia");

            entity.ToTable("provincia", "seguridades");

            entity.Property(e => e.IdProvincia).HasColumnName("id_provincia");
            entity.Property(e => e.IdPais).HasColumnName("id_pais");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Referencia)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("referencia");

            entity.HasOne(d => d.IdPaisNavigation).WithMany(p => p.Provincia)
                .HasForeignKey(d => d.IdPais)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_provincia_pais");
        });

        modelBuilder.Entity<Roles>(entity =>
        {
            entity.HasKey(e => e.IdRol).HasName("PK__roles__6ABCB5E01BCBE04C");

            entity.ToTable("roles", "seguridades");

            entity.HasIndex(e => e.NombreRol, "UQ__roles__673CB4356160CEAA").IsUnique();

            entity.Property(e => e.IdRol).HasColumnName("id_rol");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fecha_creacion");
            entity.Property(e => e.NombreRol)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre_rol");
        });

        modelBuilder.Entity<Seccion>(entity =>
        {
            entity.HasKey(e => e.IdProductoSeccion).HasName("PK_sic_seccion");

            entity.ToTable("seccion", "sic");

            entity.Property(e => e.IdProductoSeccion).HasColumnName("id_producto_seccion");
            entity.Property(e => e.Codsec).HasColumnName("codsec");
            entity.Property(e => e.IdProductoDepartamento).HasColumnName("id_producto_departamento");

            entity.HasOne(d => d.IdProductoDepartamentoNavigation).WithMany(p => p.Seccion)
                .HasForeignKey(d => d.IdProductoDepartamento)
                .HasConstraintName("FK_sic_seccion_sic_producto_departamento");
        });

        modelBuilder.Entity<Sector>(entity =>
        {
            entity.HasKey(e => e.IdSector).HasName("PK_sic_sector");

            entity.ToTable("sector", "sic");

            entity.Property(e => e.IdSector).HasColumnName("id_sector");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("descripcion");
        });

        modelBuilder.Entity<Sistemas>(entity =>
        {
            entity.HasKey(e => e.IdSistema).HasName("PK__sistemas__A0747B268DA0C9CE");

            entity.ToTable("sistemas", "seguridades");

            entity.HasIndex(e => e.Nombre, "UQ__sistemas__72AFBCC6BF17E340").IsUnique();

            entity.Property(e => e.IdSistema).HasColumnName("id_sistema");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fecha_creacion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Status).HasColumnName("status");
        });

        modelBuilder.Entity<Telefonos>(entity =>
        {
            entity.HasKey(e => e.IdTelefono).HasName("PK__telefono__28CD6802043990A9");

            entity.ToTable("telefonos", "seguridades");

            entity.Property(e => e.IdTelefono).HasColumnName("id_telefono");
            entity.Property(e => e.IdPersona).HasColumnName("id_persona");
            entity.Property(e => e.Numero)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("numero");
            entity.Property(e => e.Tipo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("tipo");

            entity.HasOne(d => d.IdPersonaNavigation).WithMany(p => p.Telefonos)
                .HasForeignKey(d => d.IdPersona)
                .HasConstraintName("FK__telefonos__id_pe__3EDC53F0");
        });

        modelBuilder.Entity<TipoCliente>(entity =>
        {
            entity.HasKey(e => e.IdTipoCliente).HasName("pk_sic_tipo_cliente");

            entity.ToTable("tipo_cliente", "sic");

            entity.Property(e => e.IdTipoCliente).HasColumnName("id_tipo_cliente");
            entity.Property(e => e.Cuenta)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("cuenta");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.IdEmpresa).HasColumnName("id_empresa");

            entity.HasOne(d => d.IdEmpresaNavigation).WithMany(p => p.TipoCliente)
                .HasForeignKey(d => d.IdEmpresa)
                .HasConstraintName("FK_tipo_cliente_nueva_empresa");
        });

        modelBuilder.Entity<TipoCodigoGs1>(entity =>
        {
            entity.HasKey(e => e.IdTipoCodigoGs1).HasName("PK_sic_tipo_codigo_gs1");

            entity.ToTable("tipo_codigo_gs1", "sic");

            entity.Property(e => e.IdTipoCodigoGs1).HasColumnName("id_tipo_codigo_gs1");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("descripcion");
        });

        modelBuilder.Entity<TipoDocumento>(entity =>
        {
            entity.HasKey(e => e.IdTipoDocumento).HasName("PK__tipo_doc__9F38507C97957934");

            entity.ToTable("tipo_documento", "seguridades");

            entity.Property(e => e.IdTipoDocumento).HasColumnName("id_tipo_documento");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.Referencia)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("referencia");
            entity.Property(e => e.Status).HasColumnName("status");
        });

        modelBuilder.Entity<TipoEmpresaLocalizacion>(entity =>
        {
            entity.HasKey(e => e.IdTipoEmpresaLocalizacion).HasName("pk_sic_tipo_empresa_localizaci");

            entity.ToTable("tipo_empresa_localizacion", "sic");

            entity.Property(e => e.IdTipoEmpresaLocalizacion).HasColumnName("id_tipo_empresa_localizacion");
            entity.Property(e => e.ClientesCodigo).HasColumnName("clientes_codigo");
            entity.Property(e => e.CodigoPostal)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("codigo_postal");
            entity.Property(e => e.Direccion)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("direccion");
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("telefono");

            entity.HasOne(d => d.ClientesCodigoNavigation).WithMany(p => p.TipoEmpresaLocalizacion)
                .HasForeignKey(d => d.ClientesCodigo)
                .HasConstraintName("FK_sic_tipo_empresa_localizacion_sic_clientes");
        });

        modelBuilder.Entity<TipoLocalizacion>(entity =>
        {
            entity.HasKey(e => e.IdTipoLocalizacion).HasName("PK_sic_tipo_localizacion");

            entity.ToTable("tipo_localizacion", "sic");

            entity.Property(e => e.IdTipoLocalizacion).HasColumnName("id_tipo_localizacion");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.Estado).HasColumnName("estado");
        });

        modelBuilder.Entity<TipoOrigenIngresos>(entity =>
        {
            entity.HasKey(e => e.SicTipoOrigenIngresosCodigo).HasName("pk_sic_tipo_origen_ingresos");

            entity.ToTable("tipo_origen_ingresos", "sic");

            entity.Property(e => e.SicTipoOrigenIngresosCodigo).HasColumnName("sic_tipo_origen_ingresos_codigo");
            entity.Property(e => e.SicTipoOrigenIngresosNombre)
                .HasMaxLength(70)
                .IsUnicode(false)
                .HasColumnName("sic_tipo_origen_ingresos_nombre");
        });

        modelBuilder.Entity<Usuarios>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__usuarios__4E3E04AD6281436A");

            entity.ToTable("usuarios", "seguridades");

            entity.HasIndex(e => e.IdPersona, "UQ__usuarios__228148B1D8113A34").IsUnique();

            entity.HasIndex(e => e.NombreUsuario, "UQ__usuarios__D4D22D747DE859FB").IsUnique();

            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");
            entity.Property(e => e.ContraseniaHash)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("contrasenia_hash");
            entity.Property(e => e.Correo)
                .HasMaxLength(100)
                .HasColumnName("correo");
            entity.Property(e => e.Estado)
                .HasDefaultValue(true)
                .HasColumnName("estado");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fecha_creacion");
            entity.Property(e => e.IdDepartamento).HasColumnName("id_departamento");
            entity.Property(e => e.IdEmpresa).HasColumnName("id_empresa");
            entity.Property(e => e.IdPersona).HasColumnName("id_persona");
            entity.Property(e => e.NombreUsuario)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("nombre_usuario");

            entity.HasOne(d => d.IdDepartamentoNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdDepartamento)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_usuarios_departamentos");

            entity.HasOne(d => d.IdEmpresaNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdEmpresa)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_usuarios_empresa");

            entity.HasOne(d => d.IdPersonaNavigation).WithOne(p => p.Usuarios)
                .HasForeignKey<Usuarios>(d => d.IdPersona)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_usuarios_personas");
        });

        modelBuilder.Entity<UsuariosPerfiles>(entity =>
        {
            entity.HasKey(e => e.IdUsuarioPerfiles).HasName("PK__usuarios__B584416B6924F8DE");

            entity.ToTable("usuarios_perfiles", "seguridades");

            entity.Property(e => e.IdUsuarioPerfiles).HasColumnName("id_usuario_perfiles");
            entity.Property(e => e.FechaAsignacion)
                .HasColumnType("datetime")
                .HasColumnName("fecha_asignacion");
            entity.Property(e => e.IdPerfil).HasColumnName("id_perfil");
            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

            entity.HasOne(d => d.IdPerfilNavigation).WithMany(p => p.UsuariosPerfiles)
                .HasForeignKey(d => d.IdPerfil)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__usuarios___id_pe__719CDDE7");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.UsuariosPerfiles)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__usuarios___id_us__70A8B9AE");
        });

        modelBuilder.Entity<UsuariosRoles>(entity =>
        {
            entity.HasKey(e => new { e.IdUsuario, e.IdRol }).HasName("PK__usuarios__5895CFF39DFA106F");

            entity.ToTable("usuarios_roles", "seguridades");

            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");
            entity.Property(e => e.IdRol).HasColumnName("id_rol");
            entity.Property(e => e.FechaAsignacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fecha_asignacion");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.UsuariosRoles)
                .HasForeignKey(d => d.IdRol)
                .HasConstraintName("FK__usuarios___id_ro__3A179ED3");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.UsuariosRoles)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__usuarios___id_us__39237A9A");
        });

        modelBuilder.Entity<Vendedor>(entity =>
        {
            entity.HasKey(e => e.IdVendedor).HasName("pk_sic_vendedor");

            entity.ToTable("vendedor", "sic");

            entity.Property(e => e.IdVendedor).HasColumnName("id_vendedor");
            entity.Property(e => e.EmpresaCodigo).HasColumnName("empresa_codigo");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.Fecing).HasColumnName("fecing");
            entity.Property(e => e.Fecsal).HasColumnName("fecsal");
            entity.Property(e => e.Nombre)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.PorVendedor)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("por_vendedor");
            entity.Property(e => e.Ruc)
                .HasMaxLength(13)
                .IsUnicode(false)
                .HasColumnName("ruc");

            entity.HasOne(d => d.EmpresaCodigoNavigation).WithMany(p => p.Vendedor)
                .HasForeignKey(d => d.EmpresaCodigo)
                .HasConstraintName("FK_sic_vendedor_empresa");
        });

        modelBuilder.Entity<Zona>(entity =>
        {
            entity.HasKey(e => e.IdZona).HasName("pk_sic_zona");

            entity.ToTable("zona", "seguridades");

            entity.Property(e => e.IdZona).HasColumnName("id_zona");
            entity.Property(e => e.EmpresaCodigo).HasColumnName("empresa_codigo");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Numero)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("numero");
            entity.Property(e => e.Referencia)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("referencia");

            entity.HasOne(d => d.EmpresaCodigoNavigation).WithMany(p => p.Zona)
                .HasForeignKey(d => d.EmpresaCodigo)
                .HasConstraintName("FK_zona_empresa");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
