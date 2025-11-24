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

    public virtual DbSet<AuditoriaPrefijos> AuditoriaPrefijos { get; set; }

    public virtual DbSet<AuditoriaTransferencia> AuditoriaTransferencia { get; set; }

    public virtual DbSet<AutorizacionCaja> AutorizacionCaja { get; set; }

    public virtual DbSet<AutorizacionCajaUsuario> AutorizacionCajaUsuario { get; set; }

    public virtual DbSet<Bodega> Bodega { get; set; }

    public virtual DbSet<Cantones> Cantones { get; set; }

    public virtual DbSet<CentroCostos> CentroCostos { get; set; }

    public virtual DbSet<Ciudades> Ciudades { get; set; }

    public virtual DbSet<Clasificacion> Clasificacion { get; set; }

    public virtual DbSet<ClienteDatosAdicionales> ClienteDatosAdicionales { get; set; }

    public virtual DbSet<ClienteObservacion> ClienteObservacion { get; set; }

    public virtual DbSet<Clientes> Clientes { get; set; }

    public virtual DbSet<Codigos14> Codigos14 { get; set; }

    public virtual DbSet<Colores> Colores { get; set; }

    public virtual DbSet<ContactosClientes> ContactosClientes { get; set; }

    public virtual DbSet<Contadores> Contadores { get; set; }

    public virtual DbSet<Correos> Correos { get; set; }

    public virtual DbSet<Cupones> Cupones { get; set; }

    public virtual DbSet<Cxc> Cxc { get; set; }

    public virtual DbSet<Departamento> Departamento { get; set; }

    public virtual DbSet<Departamentos> Departamentos { get; set; }

    public virtual DbSet<Descuento> Descuento { get; set; }

    public virtual DbSet<DetalleNotaCredito> DetalleNotaCredito { get; set; }

    public virtual DbSet<DetallePagos> DetallePagos { get; set; }

    public virtual DbSet<Direcciones> Direcciones { get; set; }

    public virtual DbSet<Division> Division { get; set; }

    public virtual DbSet<Empresas> Empresas { get; set; }

    public virtual DbSet<EstadoCivil> EstadoCivil { get; set; }

    public virtual DbSet<EstadoCuentas> EstadoCuentas { get; set; }

    public virtual DbSet<EstadoEmpresa> EstadoEmpresa { get; set; }

    public virtual DbSet<EstructuraComercial> EstructuraComercial { get; set; }

    public virtual DbSet<Fabricantes> Fabricantes { get; set; }

    public virtual DbSet<FacturaDetalle> FacturaDetalle { get; set; }

    public virtual DbSet<FacturaDetallePrefijos> FacturaDetallePrefijos { get; set; }

    public virtual DbSet<FacturaPago> FacturaPago { get; set; }

    public virtual DbSet<FormaPago> FormaPago { get; set; }

    public virtual DbSet<FormaPagoSri> FormaPagoSri { get; set; }

    public virtual DbSet<Genero> Genero { get; set; }

    public virtual DbSet<Gerentes> Gerentes { get; set; }

    public virtual DbSet<Gln> Gln { get; set; }

    public virtual DbSet<Grupo> Grupo { get; set; }

    public virtual DbSet<GrupoEmpresa> GrupoEmpresa { get; set; }

    public virtual DbSet<GrupoProducto> GrupoProducto { get; set; }

    public virtual DbSet<HistorialCliente> HistorialCliente { get; set; }

    public virtual DbSet<HistorialContrasenias> HistorialContrasenias { get; set; }

    public virtual DbSet<Iva> Iva { get; set; }

    public virtual DbSet<Kardex> Kardex { get; set; }

    public virtual DbSet<Locales> Locales { get; set; }

    public virtual DbSet<Menus> Menus { get; set; }

    public virtual DbSet<Modulos> Modulos { get; set; }

    public virtual DbSet<Nota> Nota { get; set; }

    public virtual DbSet<NotaCredito> NotaCredito { get; set; }

    public virtual DbSet<NumeroControl> NumeroControl { get; set; }

    public virtual DbSet<Opciones> Opciones { get; set; }

    public virtual DbSet<Pagos> Pagos { get; set; }

    public virtual DbSet<PagosNotaCredito> PagosNotaCredito { get; set; }

    public virtual DbSet<Paises> Paises { get; set; }

    public virtual DbSet<Parametros> Parametros { get; set; }

    public virtual DbSet<ParametrosDetalle> ParametrosDetalle { get; set; }

    public virtual DbSet<ParametrosFactura> ParametrosFactura { get; set; }

    public virtual DbSet<Perfiles> Perfiles { get; set; }

    public virtual DbSet<PerfilesMenus> PerfilesMenus { get; set; }

    public virtual DbSet<PerfilesModulos> PerfilesModulos { get; set; }

    public virtual DbSet<PerfilesOpciones> PerfilesOpciones { get; set; }

    public virtual DbSet<PerfilesSistemas> PerfilesSistemas { get; set; }

    public virtual DbSet<PerfilesSubMenus> PerfilesSubMenus { get; set; }

    public virtual DbSet<Personas> Personas { get; set; }

    public virtual DbSet<Prefijos> Prefijos { get; set; }

    public virtual DbSet<Presentacion> Presentacion { get; set; }

    public virtual DbSet<Producto> Producto { get; set; }

    public virtual DbSet<ProductoDatosAdicionales> ProductoDatosAdicionales { get; set; }

    public virtual DbSet<ProductoEstructuraComercial> ProductoEstructuraComercial { get; set; }

    public virtual DbSet<ProductoUbicacionBodega> ProductoUbicacionBodega { get; set; }

    public virtual DbSet<ProductosProveedores> ProductosProveedores { get; set; }

    public virtual DbSet<Proveedores> Proveedores { get; set; }

    public virtual DbSet<Provincia> Provincia { get; set; }

    public virtual DbSet<Proyectos> Proyectos { get; set; }

    public virtual DbSet<RecuperacionClave> RecuperacionClave { get; set; }

    public virtual DbSet<Roles> Roles { get; set; }

    public virtual DbSet<Sabores> Sabores { get; set; }

    public virtual DbSet<Seccion> Seccion { get; set; }

    public virtual DbSet<Sector> Sector { get; set; }

    public virtual DbSet<Sistemas> Sistemas { get; set; }

    public virtual DbSet<Sscc> Sscc { get; set; }

    public virtual DbSet<Stocks> Stocks { get; set; }

    public virtual DbSet<SubDivision> SubDivision { get; set; }

    public virtual DbSet<SubMenus> SubMenus { get; set; }

    public virtual DbSet<TablaPrueba> TablaPrueba { get; set; }

    public virtual DbSet<Telefonos> Telefonos { get; set; }

    public virtual DbSet<TipoCliente> TipoCliente { get; set; }

    public virtual DbSet<TipoCodigoGs1> TipoCodigoGs1 { get; set; }

    public virtual DbSet<TipoDocumento> TipoDocumento { get; set; }

    public virtual DbSet<TipoDocumentoSri> TipoDocumentoSri { get; set; }

    public virtual DbSet<TipoEmpresaLocalizacion> TipoEmpresaLocalizacion { get; set; }

    public virtual DbSet<TipoIdentificacionSri> TipoIdentificacionSri { get; set; }

    public virtual DbSet<TipoLocalizacion> TipoLocalizacion { get; set; }

    public virtual DbSet<TipoMovimiento> TipoMovimiento { get; set; }

    public virtual DbSet<TipoMovimientoEstadoCuenta> TipoMovimientoEstadoCuenta { get; set; }

    public virtual DbSet<TipoNegocio> TipoNegocio { get; set; }

    public virtual DbSet<TipoOrigenIngresos> TipoOrigenIngresos { get; set; }

    public virtual DbSet<UbicacionArea> UbicacionArea { get; set; }

    public virtual DbSet<UbicacionColumna> UbicacionColumna { get; set; }

    public virtual DbSet<UbicacionNivel> UbicacionNivel { get; set; }

    public virtual DbSet<UnidadVenta> UnidadVenta { get; set; }

    public virtual DbSet<Unidadmedida> Unidadmedida { get; set; }

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

        modelBuilder.Entity<AuditoriaPrefijos>(entity =>
        {
            entity.ToTable("auditoria_prefijos", "sic");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Codpre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("codpre");
            entity.Property(e => e.Empresa)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("empresa");
            entity.Property(e => e.Fecha)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("fecha");
            entity.Property(e => e.Ruc)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ruc");
            entity.Property(e => e.Usuario)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("usuario");
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

        modelBuilder.Entity<AutorizacionCaja>(entity =>
        {
            entity.HasKey(e => e.IdAutorizacionCaja);

            entity.ToTable("autorizacion_caja", "sic");

            entity.Property(e => e.IdAutorizacionCaja).HasColumnName("id_autorizacion_caja");
            entity.Property(e => e.Caja)
                .HasMaxLength(10)
                .HasColumnName("caja");
            entity.Property(e => e.Direccion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("direccion");
            entity.Property(e => e.DocSri).HasColumnName("doc_sri");
            entity.Property(e => e.Docfin).HasColumnName("docfin");
            entity.Property(e => e.Docini).HasColumnName("docini");
            entity.Property(e => e.EstadoFactura)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("estado_factura");
            entity.Property(e => e.EstadoNcredito)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("estado_ncredito");
            entity.Property(e => e.Fecfin)
                .HasColumnType("datetime")
                .HasColumnName("fecfin");
            entity.Property(e => e.Fecini)
                .HasColumnType("datetime")
                .HasColumnName("fecini");
            entity.Property(e => e.GenerarXml).HasColumnName("generar_xml");
            entity.Property(e => e.IdEmpresa).HasColumnName("id_empresa");
            entity.Property(e => e.IdLocal).HasColumnName("id_local");
            entity.Property(e => e.IdTipoDocumento).HasColumnName("id_tipo_documento");
            entity.Property(e => e.NombreComercial)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre_comercial");
            entity.Property(e => e.NumEstablecimiento)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("num_establecimiento");
            entity.Property(e => e.NumeroAutorizacion)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("numero_autorizacion");
            entity.Property(e => e.NumeroFactura)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("numero_factura");
            entity.Property(e => e.NumeroNcredito)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("numero_ncredito");
            entity.Property(e => e.Ruc)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ruc");

            entity.HasOne(d => d.IdLocalNavigation).WithMany(p => p.AutorizacionCaja)
                .HasForeignKey(d => d.IdLocal)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_autorizacion_caja_locales");

            entity.HasOne(d => d.IdTipoDocumentoNavigation).WithMany(p => p.AutorizacionCaja)
                .HasForeignKey(d => d.IdTipoDocumento)
                .HasConstraintName("FK_autorizacion_caja_tipo_documento");
        });

        modelBuilder.Entity<AutorizacionCajaUsuario>(entity =>
        {
            entity.HasKey(e => e.IdAutorizacionUsuario).HasName("PK__autoriza__03CFB86AC1A24C04");

            entity.ToTable("autorizacion_caja_usuario", "sic");

            entity.Property(e => e.IdAutorizacionUsuario).HasColumnName("id_autorizacion_usuario");
            entity.Property(e => e.Activa).HasColumnName("activa");
            entity.Property(e => e.IdAutorizacionCaja).HasColumnName("id_autorizacion_caja");
            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

            entity.HasOne(d => d.IdAutorizacionCajaNavigation).WithMany(p => p.AutorizacionCajaUsuario)
                .HasForeignKey(d => d.IdAutorizacionCaja)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_autorizacion_caja_usuario_autorizacion_caja");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.AutorizacionCajaUsuario)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_autorizacion_caja_usuario_usuarios");
        });

        modelBuilder.Entity<Bodega>(entity =>
        {
            entity.HasKey(e => e.IdBodega).HasName("PK__bodega__6B4E4970A1AF5A66");

            entity.ToTable("bodega", "sic");

            entity.HasIndex(e => e.IdProducto, "UQ__bodega__FF341C0CBD6F5BF8").IsUnique();

            entity.Property(e => e.IdBodega).HasColumnName("id_bodega");
            entity.Property(e => e.ClasProducto)
                .HasMaxLength(50)
                .HasColumnName("clas_producto");
            entity.Property(e => e.Existencia).HasColumnName("existencia");
            entity.Property(e => e.IdLocal).HasColumnName("id_local");
            entity.Property(e => e.IdProducto).HasColumnName("id_producto");
            entity.Property(e => e.Reservado).HasColumnName("reservado");

            entity.HasOne(d => d.IdLocalNavigation).WithMany(p => p.Bodega)
                .HasForeignKey(d => d.IdLocal)
                .HasConstraintName("FK_bodega_locales");

            entity.HasOne(d => d.IdProductoNavigation).WithOne(p => p.Bodega)
                .HasForeignKey<Bodega>(d => d.IdProducto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_bodega_producto");
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

        modelBuilder.Entity<CentroCostos>(entity =>
        {
            entity.HasKey(e => e.IdCentroCostos).HasName("PK__centro_c__2C18650350FF6B81");

            entity.ToTable("centro_costos", "seguridades");

            entity.Property(e => e.IdCentroCostos).HasColumnName("id_centro_costos");
            entity.Property(e => e.Cuenta)
                .HasMaxLength(10)
                .HasColumnName("cuenta");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.IdEmpresa).HasColumnName("id_empresa");

            entity.HasOne(d => d.IdEmpresaNavigation).WithMany(p => p.CentroCostos)
                .HasForeignKey(d => d.IdEmpresa)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_centro_costos_empresas");
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
            entity.Property(e => e.IdZona).HasColumnName("id_zona");
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

        modelBuilder.Entity<Clasificacion>(entity =>
        {
            entity.HasKey(e => e.IdClasificacion);

            entity.ToTable("clasificacion", "sic");

            entity.Property(e => e.IdClasificacion).HasColumnName("id_clasificacion");
            entity.Property(e => e.CodigoCuenta)
                .HasMaxLength(10)
                .HasColumnName("codigo_cuenta");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(30)
                .HasColumnName("descripcion");
            entity.Property(e => e.Estado).HasColumnName("estado");
        });

        modelBuilder.Entity<ClienteDatosAdicionales>(entity =>
        {
            entity.HasKey(e => e.IdDatosAdicionales).HasName("pk_sic_datos_adicionales");

            entity.ToTable("cliente_datos_adicionales", "sic");

            entity.Property(e => e.IdDatosAdicionales).HasColumnName("id_datos_adicionales");
            entity.Property(e => e.ClientesCodigo).HasColumnName("clientes_codigo");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.Expprod).HasColumnName("expprod");
            entity.Property(e => e.Facebook).HasColumnName("facebook");
            entity.Property(e => e.Gs1ec).HasColumnName("gs1ec");
            entity.Property(e => e.Guia).HasColumnName("guia");
            entity.Property(e => e.Instagram).HasColumnName("instagram");
            entity.Property(e => e.Medico).HasColumnName("medico");
            entity.Property(e => e.Prefijo).HasColumnName("prefijo");
            entity.Property(e => e.Vendeus).HasColumnName("vendeus");
            entity.Property(e => e.Web).HasColumnName("web");

            entity.HasOne(d => d.ClientesCodigoNavigation).WithMany(p => p.ClienteDatosAdicionales)
                .HasForeignKey(d => d.ClientesCodigo)
                .HasConstraintName("FK_cliente_datos_adicionales");
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
            entity.Property(e => e.Linea).HasColumnName("linea");
            entity.Property(e => e.NombreUsuario)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre_usuario");

            entity.HasOne(d => d.ClientesCodigoNavigation).WithMany(p => p.ClienteObservacion)
                .HasForeignKey(d => d.ClientesCodigo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_clienteobservcli");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.ClienteObservacion)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_clienteobservacionclientes");
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
            entity.Property(e => e.ClientesCodigo).HasColumnName("clientes_codigo");
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
            entity.Property(e => e.IdPrefijos).HasColumnName("id_prefijos");
            entity.Property(e => e.IdProducto).HasColumnName("id_producto");
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

            entity.HasOne(d => d.IdPrefijosNavigation).WithMany(p => p.Codigos14)
                .HasForeignKey(d => d.IdPrefijos)
                .HasConstraintName("FK_codigo14_prefijos");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.Codigos14)
                .HasForeignKey(d => d.IdProducto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_codigo14_producto");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Codigos14)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK_sic_codigos14_usuarios");
        });

        modelBuilder.Entity<Colores>(entity =>
        {
            entity.HasKey(e => e.IdColor);

            entity.ToTable("colores", "sic");

            entity.Property(e => e.IdColor).HasColumnName("id_color");
            entity.Property(e => e.Activo)
                .HasDefaultValue(true)
                .HasColumnName("activo");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(20)
                .HasColumnName("descripcion");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fecha_creacion");
            entity.Property(e => e.FechaModificacion)
                .HasColumnType("datetime")
                .HasColumnName("fecha_modificacion");
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
            entity.Property(e => e.Linea).HasColumnName("linea");
            entity.Property(e => e.Nombre)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("telefono");

            entity.HasOne(d => d.ClientesCodigoNavigation).WithMany(p => p.ContactosClientes)
                .HasForeignKey(d => d.ClientesCodigo)
                .HasConstraintName("FK_contactos_Clientes");
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

        modelBuilder.Entity<Cupones>(entity =>
        {
            entity.HasKey(e => e.IdCupon).HasName("PK__cupones__5EA30214EF45EE56");

            entity.ToTable("cupones", "sic");

            entity.HasIndex(e => e.CodigoCupon, "UQ__cupones__96C7773BBA3E5922").IsUnique();

            entity.Property(e => e.IdCupon).HasColumnName("id_cupon");
            entity.Property(e => e.CodigoCupon)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("codigo_cupon");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.Estado)
                .HasDefaultValue(true)
                .HasColumnName("estado");
            entity.Property(e => e.FechaCaducidad).HasColumnName("fecha_caducidad");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fecha_creacion");
            entity.Property(e => e.FechaInicio).HasColumnName("fecha_inicio");
            entity.Property(e => e.IdCliente).HasColumnName("id_cliente");
            entity.Property(e => e.IdGrupoProducto).HasColumnName("id_grupo_producto");
            entity.Property(e => e.IdPrefijo).HasColumnName("id_prefijo");
            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");
            entity.Property(e => e.Serial).HasColumnName("serial");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Cupones)
                .HasForeignKey(d => d.IdCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__cupones__id_clie__58BC2184");

            entity.HasOne(d => d.IdGrupoProductoNavigation).WithMany(p => p.Cupones)
                .HasForeignKey(d => d.IdGrupoProducto)
                .HasConstraintName("fk_cupones_grupo_producto");

            entity.HasOne(d => d.IdPrefijoNavigation).WithMany(p => p.Cupones)
                .HasForeignKey(d => d.IdPrefijo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__cupones__id_pref__59B045BD");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Cupones)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("fk_cupones_usuario");
        });

        modelBuilder.Entity<Cxc>(entity =>
        {
            entity.HasKey(e => new { e.Codcli, e.Numdoc, e.Fecha, e.Tipo, e.Forpag, e.Fila }).HasName("PK_CxC");

            entity.ToTable("cxc", "sic");

            entity.Property(e => e.Codcli)
                .HasMaxLength(10)
                .HasColumnName("codcli");
            entity.Property(e => e.Numdoc)
                .HasMaxLength(20)
                .HasColumnName("numdoc");
            entity.Property(e => e.Fecha)
                .HasColumnType("datetime")
                .HasColumnName("fecha");
            entity.Property(e => e.Tipo)
                .HasMaxLength(1)
                .HasColumnName("tipo");
            entity.Property(e => e.Forpag)
                .HasMaxLength(10)
                .HasColumnName("forpag");
            entity.Property(e => e.Fila).HasColumnName("fila");
            entity.Property(e => e.Claspag)
                .HasMaxLength(10)
                .HasColumnName("claspag");
            entity.Property(e => e.Debe)
                .HasMaxLength(20)
                .HasColumnName("debe");
            entity.Property(e => e.Fecha1)
                .HasMaxLength(8)
                .HasColumnName("fecha1");
            entity.Property(e => e.Fechapago)
                .HasColumnType("datetime")
                .HasColumnName("fechapago");
            entity.Property(e => e.Fecven)
                .HasColumnType("datetime")
                .HasColumnName("fecven");
            entity.Property(e => e.Fecven1)
                .HasMaxLength(8)
                .HasColumnName("fecven1");
            entity.Property(e => e.Haber)
                .HasMaxLength(20)
                .HasColumnName("haber");
            entity.Property(e => e.Marca).HasMaxLength(1);
            entity.Property(e => e.Saldo)
                .HasMaxLength(20)
                .HasColumnName("saldo");
            entity.Property(e => e.Tipest)
                .HasMaxLength(1)
                .HasColumnName("tipest");
        });

        modelBuilder.Entity<Departamento>(entity =>
        {
            entity.HasKey(e => e.IdDepartamento).HasName("PK__departam__64F37A16194DFEBC");

            entity.ToTable("departamento", "sic");

            entity.Property(e => e.IdDepartamento).HasColumnName("id_departamento");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.IdSubDivision).HasColumnName("id_sub_division");

            entity.HasOne(d => d.IdSubDivisionNavigation).WithMany(p => p.Departamento)
                .HasForeignKey(d => d.IdSubDivision)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_departamento_subdivision");
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

        modelBuilder.Entity<Descuento>(entity =>
        {
            entity.HasKey(e => e.IdDescuento).HasName("PK__descuent__4F9A1A8040EA3FEF");

            entity.ToTable("descuento", "sic");

            entity.Property(e => e.IdDescuento).HasColumnName("id_descuento");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .HasColumnName("descripcion");
            entity.Property(e => e.Valor).HasColumnName("valor");
        });

        modelBuilder.Entity<DetalleNotaCredito>(entity =>
        {
            entity.HasKey(e => e.IdDetNotaCredito).HasName("PK_DetalleNotaCredito");

            entity.ToTable("detalle_nota_credito", "sic");

            entity.Property(e => e.IdDetNotaCredito).HasColumnName("idDetNotaCredito");
            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.CantidadAnterior).HasColumnName("cantidadAnterior");
            entity.Property(e => e.Codpro)
                .HasMaxLength(13)
                .HasColumnName("codpro");
            entity.Property(e => e.Costo).HasColumnName("costo");
            entity.Property(e => e.CueCodigo).HasColumnName("cue_codigo");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.Descuento).HasColumnName("descuento");
            entity.Property(e => e.Estado)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValue("A")
                .HasColumnName("estado");
            entity.Property(e => e.Fila).HasColumnName("fila");
            entity.Property(e => e.IdNotaCredito).HasColumnName("idNotaCredito");
            entity.Property(e => e.Iva).HasColumnName("iva");
            entity.Property(e => e.Precio).HasColumnName("precio");
            entity.Property(e => e.TipoIva)
                .HasMaxLength(1)
                .HasColumnName("tipoIva");

            entity.HasOne(d => d.IdNotaCreditoNavigation).WithMany(p => p.DetalleNotaCredito)
                .HasForeignKey(d => d.IdNotaCredito)
                .HasConstraintName("FK_detalle_nota_credito_nota_credito");
        });

        modelBuilder.Entity<DetallePagos>(entity =>
        {
            entity.HasKey(e => e.IdDetallePago);

            entity.ToTable("detalle_pagos", "sic");

            entity.HasIndex(e => e.FormaPago, "IX_detalle_pagos_forma_pago");

            entity.HasIndex(e => e.NumeroPago, "IX_detalle_pagos_numero");

            entity.HasIndex(e => e.IdPago, "IX_detalle_pagos_pago");

            entity.HasIndex(e => new { e.NumeroPago, e.FormaPago, e.Secuencia }, "UK_detalle_pagos_compuesta").IsUnique();

            entity.Property(e => e.IdDetallePago).HasColumnName("id_detalle_pago");
            entity.Property(e => e.Autorizacion)
                .HasMaxLength(50)
                .HasColumnName("autorizacion");
            entity.Property(e => e.AuxiliarContable)
                .HasDefaultValue(0.0)
                .HasColumnName("auxiliar_contable");
            entity.Property(e => e.Banco)
                .HasMaxLength(100)
                .HasColumnName("banco");
            entity.Property(e => e.DescripcionPago)
                .HasMaxLength(255)
                .HasColumnName("descripcion_pago");
            entity.Property(e => e.FacturaProveedor)
                .HasMaxLength(50)
                .HasColumnName("factura_proveedor");
            entity.Property(e => e.FechaAutorizacion)
                .HasMaxLength(50)
                .HasColumnName("fecha_autorizacion");
            entity.Property(e => e.FechaEmision).HasColumnName("fecha_emision");
            entity.Property(e => e.FormaPago)
                .HasMaxLength(10)
                .HasColumnName("forma_pago");
            entity.Property(e => e.IdPago).HasColumnName("id_pago");
            entity.Property(e => e.LoteRecapitulacion)
                .HasMaxLength(50)
                .HasColumnName("lote_recapitulacion");
            entity.Property(e => e.Monto).HasColumnName("monto");
            entity.Property(e => e.NumeroCuenta)
                .HasMaxLength(50)
                .HasColumnName("numero_cuenta");
            entity.Property(e => e.NumeroDocumento)
                .HasMaxLength(50)
                .HasColumnName("numero_documento");
            entity.Property(e => e.NumeroPago)
                .HasMaxLength(20)
                .HasColumnName("numero_pago");
            entity.Property(e => e.Observaciones).HasColumnName("observaciones");
            entity.Property(e => e.Propietario)
                .HasMaxLength(150)
                .HasColumnName("propietario");
            entity.Property(e => e.Secuencia)
                .HasMaxLength(3)
                .HasColumnName("secuencia");

            entity.HasOne(d => d.IdPagoNavigation).WithMany(p => p.DetallePagos)
                .HasForeignKey(d => d.IdPago)
                .HasConstraintName("FK_detalle_pagos_pago");
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

        modelBuilder.Entity<Division>(entity =>
        {
            entity.HasKey(e => e.IdDivision).HasName("PK__division__52AEDB0EA8F6115D");

            entity.ToTable("division", "sic");

            entity.Property(e => e.IdDivision).HasColumnName("id_division");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.IdEstructuraComercial).HasColumnName("id_estructura_comercial");

            entity.HasOne(d => d.IdEstructuraComercialNavigation).WithMany(p => p.Division)
                .HasForeignKey(d => d.IdEstructuraComercial)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_division_estructura");
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
            entity.Property(e => e.Firma)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("firma");
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

        modelBuilder.Entity<EstadoCuentas>(entity =>
        {
            entity.HasKey(e => new { e.Id, e.Numfac, e.Tipodoc, e.TipDoc, e.Numdoc, e.ClienteCodigo, e.Fecha }).HasName("PK_EstadoCuentas");

            entity.ToTable("estado_cuentas", "sic");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.Numfac)
                .HasMaxLength(20)
                .HasColumnName("numfac");
            entity.Property(e => e.Tipodoc)
                .HasMaxLength(20)
                .HasColumnName("tipodoc");
            entity.Property(e => e.TipDoc)
                .HasMaxLength(5)
                .HasColumnName("tip_doc");
            entity.Property(e => e.Numdoc)
                .HasMaxLength(15)
                .HasColumnName("numdoc");
            entity.Property(e => e.ClienteCodigo).HasColumnName("cliente_codigo");
            entity.Property(e => e.Fecha)
                .HasMaxLength(10)
                .HasColumnName("fecha");
            entity.Property(e => e.AteCodigo)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("ate_codigo");
            entity.Property(e => e.Caja)
                .HasMaxLength(3)
                .HasColumnName("caja");
            entity.Property(e => e.ClasPago)
                .HasMaxLength(10)
                .HasColumnName("clas_pago");
            entity.Property(e => e.Debe).HasColumnName("debe");
            entity.Property(e => e.FormaPago)
                .HasMaxLength(10)
                .HasColumnName("forma_pago");
            entity.Property(e => e.Haber).HasColumnName("haber");
            entity.Property(e => e.HistoriaClinica)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("historia_clinica");
            entity.Property(e => e.Observacion)
                .HasMaxLength(200)
                .HasColumnName("observacion");
            entity.Property(e => e.PagoAnulado).HasColumnName("pago_anulado");
            entity.Property(e => e.Responsable).HasColumnName("responsable");
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

        modelBuilder.Entity<EstructuraComercial>(entity =>
        {
            entity.HasKey(e => e.IdEstructuraComercial).HasName("PK_estructura_comercial_1");

            entity.ToTable("estructura_comercial", "sic");

            entity.Property(e => e.IdEstructuraComercial).HasColumnName("id_estructura_comercial");
            entity.Property(e => e.Descri)
                .HasMaxLength(50)
                .HasColumnName("descri");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.IdEmpresa).HasColumnName("id_empresa");
            entity.Property(e => e.Numnodos).HasColumnName("numnodos");

            entity.HasOne(d => d.IdEmpresaNavigation).WithMany(p => p.EstructuraComercial)
                .HasForeignKey(d => d.IdEmpresa)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_estructura_comercial_empresas");
        });

        modelBuilder.Entity<Fabricantes>(entity =>
        {
            entity.HasKey(e => e.IdFabricante);

            entity.ToTable("fabricantes", "sic");

            entity.Property(e => e.IdFabricante).HasColumnName("id_fabricante");
            entity.Property(e => e.Activo)
                .HasDefaultValue(true)
                .HasColumnName("activo");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fecha_creacion");
            entity.Property(e => e.FechaModificacion)
                .HasColumnType("datetime")
                .HasColumnName("fecha_modificacion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(35)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<FacturaDetalle>(entity =>
        {
            entity.HasKey(e => e.IdFacturaDet);

            entity.ToTable("factura_detalle", "sic");

            entity.Property(e => e.IdFacturaDet).HasColumnName("id_factura_det");
            entity.Property(e => e.Caja)
                .HasMaxLength(10)
                .HasColumnName("caja");
            entity.Property(e => e.Candev).HasColumnName("candev");
            entity.Property(e => e.Cantid)
                .HasMaxLength(10)
                .HasColumnName("cantid");
            entity.Property(e => e.Codbar)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("codbar");
            entity.Property(e => e.Coddep).HasColumnName("coddep");
            entity.Property(e => e.Coddiv).HasColumnName("coddiv");
            entity.Property(e => e.Codloc)
                .HasMaxLength(10)
                .HasColumnName("codloc");
            entity.Property(e => e.Codsec).HasColumnName("codsec");
            entity.Property(e => e.Costo)
                .HasMaxLength(20)
                .HasColumnName("costo");
            entity.Property(e => e.Desind)
                .HasMaxLength(20)
                .HasColumnName("desind");
            entity.Property(e => e.Encero)
                .HasMaxLength(80)
                .HasColumnName("encero");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdDescuento).HasColumnName("id_descuento");
            entity.Property(e => e.IdProducto).HasColumnName("id_producto");
            entity.Property(e => e.Iva).HasMaxLength(1);
            entity.Property(e => e.Numnota)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("numnota");
            entity.Property(e => e.Obs2)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("obs2");
            entity.Property(e => e.Precio)
                .HasColumnType("decimal(18, 3)")
                .HasColumnName("precio");
            entity.Property(e => e.Tipdoc).HasColumnName("tipdoc");
            entity.Property(e => e.Uniman)
                .HasMaxLength(10)
                .HasColumnName("uniman");

            entity.HasOne(d => d.IdDescuentoNavigation).WithMany(p => p.FacturaDetalle)
                .HasForeignKey(d => d.IdDescuento)
                .HasConstraintName("FK_factura_detalle_descuento");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.FacturaDetalle)
                .HasForeignKey(d => d.IdProducto)
                .HasConstraintName("FK_factura_detalle_producto");

            entity.HasOne(d => d.NumnotaNavigation).WithMany(p => p.FacturaDetalle)
                .HasPrincipalKey(p => p.Numnota)
                .HasForeignKey(d => d.Numnota)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_factura_detalle_nota");
        });

        modelBuilder.Entity<FacturaDetallePrefijos>(entity =>
        {
            entity.HasKey(e => e.IdPagosPrefijo).HasName("PK__factura___62D1E41C350FF2AA");

            entity.ToTable("factura_detalle_prefijos", "sic");

            entity.Property(e => e.IdPagosPrefijo).HasColumnName("id_pagos_prefijo");
            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.ClientesCodigo).HasColumnName("clientes_codigo");
            entity.Property(e => e.CodigoPrefijo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("codigo_prefijo");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.FechaFactura).HasColumnName("fecha_factura");
            entity.Property(e => e.Numnota)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("numnota");
            entity.Property(e => e.PeriodoDesde).HasColumnName("periodo_desde");
            entity.Property(e => e.PeriodoHasta).HasColumnName("periodo_hasta");
        });

        modelBuilder.Entity<FacturaPago>(entity =>
        {
            entity.HasKey(e => e.IdFacturaPago);

            entity.ToTable("factura_pago", "sic");

            entity.Property(e => e.IdFacturaPago).HasColumnName("id_factura_pago");
            entity.Property(e => e.Arqueada).HasColumnName("arqueada");
            entity.Property(e => e.AsientoContable).HasColumnName("asientoContable");
            entity.Property(e => e.Autoriza)
                .HasMaxLength(100)
                .HasColumnName("autoriza");
            entity.Property(e => e.Banco)
                .HasMaxLength(20)
                .HasColumnName("banco");
            entity.Property(e => e.Caja)
                .HasMaxLength(10)
                .HasColumnName("caja");
            entity.Property(e => e.Cajero)
                .HasMaxLength(10)
                .HasColumnName("cajero");
            entity.Property(e => e.ChequeCaduca)
                .HasMaxLength(20)
                .HasColumnName("cheque_caduca");
            entity.Property(e => e.Claspag)
                .HasMaxLength(2)
                .HasColumnName("claspag");
            entity.Property(e => e.CodPlazo)
                .HasMaxLength(100)
                .IsFixedLength()
                .HasColumnName("cod_plazo");
            entity.Property(e => e.Codcli)
                .HasMaxLength(10)
                .HasColumnName("codcli");
            entity.Property(e => e.Consec)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("consec");
            entity.Property(e => e.Detalle).HasColumnName("detalle");
            entity.Property(e => e.Duenio)
                .HasMaxLength(30)
                .HasColumnName("duenio");
            entity.Property(e => e.Fecha)
                .HasColumnType("datetime")
                .HasColumnName("fecha");
            entity.Property(e => e.Fecha1)
                .HasMaxLength(8)
                .HasColumnName("fecha1");
            entity.Property(e => e.Fila).HasColumnName("fila");
            entity.Property(e => e.IdFormaPago).HasColumnName("id_forma_pago");
            entity.Property(e => e.Imprime).HasColumnName("imprime");
            entity.Property(e => e.Local)
                .HasMaxLength(10)
                .HasColumnName("local");
            entity.Property(e => e.NumcuentaTarj)
                .HasMaxLength(20)
                .HasColumnName("numcuenta_tarj");
            entity.Property(e => e.Numnota)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("numnota");
            entity.Property(e => e.Obs)
                .HasColumnType("ntext")
                .HasColumnName("obs");
            entity.Property(e => e.Parcial)
                .HasMaxLength(20)
                .HasColumnName("parcial");
            entity.Property(e => e.Parcial1)
                .HasMaxLength(20)
                .HasColumnName("parcial1");
            entity.Property(e => e.Tipdoc).HasColumnName("tipdoc");
            entity.Property(e => e.TipoAsiento)
                .HasMaxLength(3)
                .IsFixedLength()
                .HasColumnName("tipoAsiento");
            entity.Property(e => e.Tipomov)
                .HasMaxLength(2)
                .HasColumnName("tipomov");
            entity.Property(e => e.Vendedor)
                .HasMaxLength(10)
                .HasColumnName("vendedor");

            entity.HasOne(d => d.IdFormaPagoNavigation).WithMany(p => p.FacturaPago)
                .HasForeignKey(d => d.IdFormaPago)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_factura_pago_forma_pago");

            entity.HasOne(d => d.NumnotaNavigation).WithMany(p => p.FacturaPago)
                .HasPrincipalKey(p => p.Numnota)
                .HasForeignKey(d => d.Numnota)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_factura_pago_nota");
        });

        modelBuilder.Entity<FormaPago>(entity =>
        {
            entity.HasKey(e => e.IdFormaPago);

            entity.ToTable("forma_pago", "sic");

            entity.Property(e => e.IdFormaPago).HasColumnName("id_forma_pago");
            entity.Property(e => e.ActivarAnticipo).HasColumnName("activar_anticipo");
            entity.Property(e => e.ActivarCuentas).HasColumnName("activar_cuentas");
            entity.Property(e => e.ActivarFactura).HasColumnName("activar_factura");
            entity.Property(e => e.ActivarFacturaHis).HasColumnName("activar_factura_his");
            entity.Property(e => e.ActivarLiqTarjeta).HasColumnName("activar_liq_tarjeta");
            entity.Property(e => e.ActivarPagParjeta).HasColumnName("activar_pag_parjeta");
            entity.Property(e => e.CodigoCuenta)
                .HasMaxLength(10)
                .HasColumnName("codigo_cuenta");
            entity.Property(e => e.Codigocg)
                .HasMaxLength(50)
                .HasColumnName("codigocg");
            entity.Property(e => e.Codigosic)
                .HasMaxLength(50)
                .HasColumnName("codigosic");
            entity.Property(e => e.Cxc).HasColumnName("CXC");
            entity.Property(e => e.DescripcionPago)
                .HasMaxLength(30)
                .HasColumnName("descripcion_pago");
            entity.Property(e => e.IdClasificacion).HasColumnName("id_clasificacion");
            entity.Property(e => e.IdEmpresa).HasColumnName("id_empresa");
            entity.Property(e => e.IdFormaPagoSri).HasColumnName("id_forma_pago_sri");

            entity.HasOne(d => d.IdClasificacionNavigation).WithMany(p => p.FormaPago)
                .HasForeignKey(d => d.IdClasificacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_forma_pago_clasificacion");

            entity.HasOne(d => d.IdEmpresaNavigation).WithMany(p => p.FormaPago)
                .HasForeignKey(d => d.IdEmpresa)
                .HasConstraintName("FK_forma_pago_empresas");

            entity.HasOne(d => d.IdFormaPagoSriNavigation).WithMany(p => p.FormaPago)
                .HasForeignKey(d => d.IdFormaPagoSri)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_forma_pago_forma_pago_sri");
        });

        modelBuilder.Entity<FormaPagoSri>(entity =>
        {
            entity.HasKey(e => e.IdFormaPagoSri).HasName("PK_Forma_PagoSRI");

            entity.ToTable("forma_pago_sri", "sic");

            entity.Property(e => e.IdFormaPagoSri).HasColumnName("id_forma_pago_sri");
            entity.Property(e => e.CodigoSri)
                .HasMaxLength(2)
                .IsFixedLength()
                .HasColumnName("codigo_sri");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .HasColumnName("descripcion");
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

        modelBuilder.Entity<Grupo>(entity =>
        {
            entity.HasKey(e => e.IdGrupo).HasName("PK__grupo__8B68D688ECA49C89");

            entity.ToTable("grupo", "sic");

            entity.Property(e => e.IdGrupo).HasColumnName("id_grupo");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.IdSeccion).HasColumnName("id_seccion");

            entity.HasOne(d => d.IdSeccionNavigation).WithMany(p => p.Grupo)
                .HasForeignKey(d => d.IdSeccion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_grupo_seccion");
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
            entity.Property(e => e.BrickExcludes)
                .IsUnicode(false)
                .HasColumnName("brick_excludes");
            entity.Property(e => e.BrickIncludes)
                .IsUnicode(false)
                .HasColumnName("brick_includes");
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
            entity.Property(e => e.Estado).HasColumnName("estado");
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

        modelBuilder.Entity<HistorialContrasenias>(entity =>
        {
            entity.HasKey(e => e.IdHistorial).HasName("PK__historia__76E6C502835F37C8");

            entity.ToTable("historial_contrasenias", "seguridades");

            entity.Property(e => e.IdHistorial).HasColumnName("id_historial");
            entity.Property(e => e.ContraseniaHash)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("contrasenia_hash");
            entity.Property(e => e.FechaCambio)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fecha_cambio");
            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.HistorialContrasenias)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__historial__id_us__253C7D7E");
        });

        modelBuilder.Entity<Iva>(entity =>
        {
            entity.HasKey(e => e.IdIva).HasName("PK__iva__D62AEEC2E4123B06");

            entity.ToTable("iva", "seguridades");

            entity.Property(e => e.IdIva).HasColumnName("id_iva");
            entity.Property(e => e.CodigoIva).HasColumnName("codigo_iva");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(150)
                .HasColumnName("descripcion");
            entity.Property(e => e.FechaFin)
                .HasColumnType("datetime")
                .HasColumnName("fecha_fin");
            entity.Property(e => e.FechaInicio)
                .HasColumnType("datetime")
                .HasColumnName("fecha_inicio");
            entity.Property(e => e.Porcentaje).HasColumnName("porcentaje");
            entity.Property(e => e.Principal).HasColumnName("principal");
        });

        modelBuilder.Entity<Kardex>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("kardex", "sic");

            entity.Property(e => e.AsientoContable)
                .HasDefaultValue(0.0)
                .HasColumnName("asiento_contable");
            entity.Property(e => e.AtencionCodigo).HasColumnName("atencion_codigo");
            entity.Property(e => e.AuxFecha).HasColumnName("aux_fecha");
            entity.Property(e => e.Costo).HasColumnName("costo");
            entity.Property(e => e.Costo2).HasColumnName("costo2");
            entity.Property(e => e.CostoTotal).HasColumnName("costo_total");
            entity.Property(e => e.CostoTotal2).HasColumnName("costo_total2");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(250)
                .HasColumnName("descripcion");
            entity.Property(e => e.Egreso)
                .HasMaxLength(100)
                .HasColumnName("egreso");
            entity.Property(e => e.Factura).HasMaxLength(40);
            entity.Property(e => e.Fecha)
                .HasColumnType("datetime")
                .HasColumnName("fecha");
            entity.Property(e => e.FechaAux)
                .HasMaxLength(15)
                .HasColumnName("fecha_aux");
            entity.Property(e => e.HistoriaClinica).HasColumnName("historia_clinica");
            entity.Property(e => e.IdDepartamento).HasColumnName("id_departamento");
            entity.Property(e => e.IdDivision).HasColumnName("id_division");
            entity.Property(e => e.IdGrupo).HasColumnName("id_grupo");
            entity.Property(e => e.IdKardex)
                .ValueGeneratedOnAdd()
                .HasColumnName("id_kardex");
            entity.Property(e => e.IdLocal).HasColumnName("id_local");
            entity.Property(e => e.IdProducto).HasColumnName("id_producto");
            entity.Property(e => e.IdProveedor).HasColumnName("id_proveedor");
            entity.Property(e => e.IdSeccion).HasColumnName("id_seccion");
            entity.Property(e => e.IdSubdivision).HasColumnName("id_subdivision");
            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");
            entity.Property(e => e.Ingreso)
                .HasMaxLength(100)
                .HasColumnName("ingreso");
            entity.Property(e => e.IpMaquina)
                .HasMaxLength(50)
                .HasColumnName("ip_maquina");
            entity.Property(e => e.Numdoc)
                .HasMaxLength(20)
                .HasColumnName("numdoc");
            entity.Property(e => e.Saldo)
                .HasMaxLength(100)
                .HasColumnName("saldo");
            entity.Property(e => e.Signo)
                .HasMaxLength(5)
                .HasColumnName("signo");
            entity.Property(e => e.Tipdoc)
                .HasMaxLength(10)
                .HasColumnName("tipdoc");
            entity.Property(e => e.TipoAsiento)
                .HasMaxLength(3)
                .IsFixedLength()
                .HasColumnName("tipo_asiento");
            entity.Property(e => e.Venta).HasColumnName("venta");

            entity.HasOne(d => d.IdLocalNavigation).WithMany()
                .HasForeignKey(d => d.IdLocal)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_kardex_locales");

            entity.HasOne(d => d.IdProductoNavigation).WithMany()
                .HasForeignKey(d => d.IdProducto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_kardex_producto");

            entity.HasOne(d => d.TipdocNavigation).WithMany()
                .HasForeignKey(d => d.Tipdoc)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_kardex_tipo_movimiento");
        });

        modelBuilder.Entity<Locales>(entity =>
        {
            entity.HasKey(e => e.IdLocal).HasName("PK__locales__1ECD0210B1B66169");

            entity.ToTable("locales", "seguridades");

            entity.Property(e => e.IdLocal).HasColumnName("id_local");
            entity.Property(e => e.AplicaPedido).HasColumnName("aplica_pedido");
            entity.Property(e => e.Area).HasColumnName("area");
            entity.Property(e => e.BodDespachoP).HasColumnName("bod_despacho_p");
            entity.Property(e => e.BodPedidoP).HasColumnName("bod_pedido_p");
            entity.Property(e => e.BodUbicacion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("bod_ubicacion");
            entity.Property(e => e.Bstock).HasColumnName("bstock");
            entity.Property(e => e.DirIpBodega)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("dir_ip_bodega");
            entity.Property(e => e.Direccion)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("direccion");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.IdCentroCostos).HasColumnName("id_centro_costos");
            entity.Property(e => e.IdCiudad).HasColumnName("id_ciudad");
            entity.Property(e => e.IdEmpresa).HasColumnName("id_empresa");
            entity.Property(e => e.IdTipoNegocio).HasColumnName("id_tipo_negocio");
            entity.Property(e => e.IdZona).HasColumnName("id_zona");
            entity.Property(e => e.LocalBodega).HasColumnName("local_bodega");
            entity.Property(e => e.LocalHis).HasColumnName("local_his");
            entity.Property(e => e.LocalRuc)
                .HasMaxLength(13)
                .HasColumnName("local_ruc");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Principal).HasColumnName("principal");
            entity.Property(e => e.Priopridad).HasColumnName("priopridad");
            entity.Property(e => e.Telefono1)
                .HasMaxLength(15)
                .HasColumnName("telefono1");

            entity.HasOne(d => d.IdCentroCostosNavigation).WithMany(p => p.Locales)
                .HasForeignKey(d => d.IdCentroCostos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_locales_centro_costos");

            entity.HasOne(d => d.IdCiudadNavigation).WithMany(p => p.Locales)
                .HasForeignKey(d => d.IdCiudad)
                .HasConstraintName("FK_locales_ciudades");

            entity.HasOne(d => d.IdEmpresaNavigation).WithMany(p => p.Locales)
                .HasForeignKey(d => d.IdEmpresa)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_locales_empresas");

            entity.HasOne(d => d.IdTipoNegocioNavigation).WithMany(p => p.Locales)
                .HasForeignKey(d => d.IdTipoNegocio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_locales_tipo_negocio");
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
            entity.Property(e => e.Url)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("url");

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
            entity.Property(e => e.Url)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("url");

            entity.HasOne(d => d.IdSistemaNavigation).WithMany(p => p.Modulos)
                .HasForeignKey(d => d.IdSistema)
                .HasConstraintName("FK__modulos__id_sist__2645B050");
        });

        modelBuilder.Entity<Nota>(entity =>
        {
            entity.HasKey(e => e.IdNota).HasName("PK_Nota");

            entity.ToTable("nota", "sic");

            entity.HasIndex(e => e.Numnota, "UK_nota_numnota").IsUnique();

            entity.Property(e => e.IdNota).HasColumnName("id_nota");
            entity.Property(e => e.AnioFactura).HasColumnName("anioFactura");
            entity.Property(e => e.AsientoContable)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("asiento_contable");
            entity.Property(e => e.Autorizacion)
                .HasMaxLength(16)
                .HasColumnName("autorizacion");
            entity.Property(e => e.Cajero).HasColumnName("cajero");
            entity.Property(e => e.Cancelado)
                .HasMaxLength(20)
                .HasColumnName("cancelado");
            entity.Property(e => e.ClaveAcceso)
                .HasMaxLength(50)
                .HasColumnName("claveAcceso");
            entity.Property(e => e.Coniva).HasColumnName("coniva");
            entity.Property(e => e.ConivaDev).HasColumnName("coniva_Dev");
            entity.Property(e => e.Correo)
                .IsUnicode(false)
                .HasColumnName("correo");
            entity.Property(e => e.DesctDev).HasColumnName("desct_Dev");
            entity.Property(e => e.Desctot).HasColumnName("desctot");
            entity.Property(e => e.Dircli)
                .HasMaxLength(200)
                .HasColumnName("dircli");
            entity.Property(e => e.FacBloque).HasColumnName("fac_bloque");
            entity.Property(e => e.Facturada).HasColumnName("facturada");
            entity.Property(e => e.Fecha)
                .HasColumnType("datetime")
                .HasColumnName("fecha");
            entity.Property(e => e.Fecha1)
                .HasMaxLength(8)
                .HasColumnName("fecha1");
            entity.Property(e => e.Fecven)
                .HasColumnType("datetime")
                .HasColumnName("fecven");
            entity.Property(e => e.GrupoCliente)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("grupo_cliente");
            entity.Property(e => e.Hora)
                .HasMaxLength(50)
                .HasColumnName("hora");
            entity.Property(e => e.IdAutorizacionCaja).HasColumnName("id_autorizacion_caja");
            entity.Property(e => e.IdCliente).HasColumnName("id_cliente");
            entity.Property(e => e.IdDescuento).HasColumnName("id_descuento");
            entity.Property(e => e.IdEmpresa).HasColumnName("id_empresa");
            entity.Property(e => e.IdGrupoEmpresa).HasColumnName("id_grupo_empresa");
            entity.Property(e => e.IdLocal).HasColumnName("id_local");
            entity.Property(e => e.IdTipoCliente).HasColumnName("id_tipo_cliente");
            entity.Property(e => e.ImprimeDesct).HasColumnName("imprime_desct");
            entity.Property(e => e.Items).HasColumnName("items");
            entity.Property(e => e.Iva).HasColumnName("iva");
            entity.Property(e => e.IvaDev).HasColumnName("iva_Dev");
            entity.Property(e => e.Motivo)
                .HasMaxLength(50)
                .HasColumnName("motivo");
            entity.Property(e => e.Nomcli)
                .HasMaxLength(200)
                .HasColumnName("nomcli");
            entity.Property(e => e.Numguirem)
                .HasMaxLength(10)
                .HasColumnName("numguirem");
            entity.Property(e => e.Numnota)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("numnota");
            entity.Property(e => e.Numorden)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("numorden");
            entity.Property(e => e.Obs)
                .HasMaxLength(250)
                .HasColumnName("obs");
            entity.Property(e => e.PorfectajeIva).HasColumnName("porfectaje_iva");
            entity.Property(e => e.Pormayor).HasColumnName("pormayor");
            entity.Property(e => e.Prefijo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("prefijo");
            entity.Property(e => e.Ruc)
                .HasMaxLength(20)
                .HasColumnName("ruc");
            entity.Property(e => e.Ruccli)
                .HasMaxLength(13)
                .HasColumnName("ruccli");
            entity.Property(e => e.SinivaDev).HasColumnName("siniva_Dev");
            entity.Property(e => e.SubtDev).HasColumnName("subt_Dev");
            entity.Property(e => e.Subtotal).HasColumnName("subtotal");
            entity.Property(e => e.Telcli)
                .HasMaxLength(20)
                .HasColumnName("telcli");
            entity.Property(e => e.Tiempoentrega)
                .HasMaxLength(50)
                .HasColumnName("tiempoentrega");
            entity.Property(e => e.Tipdoc).HasColumnName("tipdoc");
            entity.Property(e => e.TotDev).HasColumnName("Tot_Dev");
            entity.Property(e => e.Total).HasColumnName("total");
            entity.Property(e => e.Totciva).HasColumnName("totciva");
            entity.Property(e => e.Totsiva).HasColumnName("totsiva");

            entity.HasOne(d => d.IdAutorizacionCajaNavigation).WithMany(p => p.Nota)
                .HasForeignKey(d => d.IdAutorizacionCaja)
                .HasConstraintName("FK_nota_autorizacion_caja");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Nota)
                .HasForeignKey(d => d.IdCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_nota_clientes");

            entity.HasOne(d => d.IdDescuentoNavigation).WithMany(p => p.Nota)
                .HasForeignKey(d => d.IdDescuento)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_nota_descuento");

            entity.HasOne(d => d.IdEmpresaNavigation).WithMany(p => p.Nota)
                .HasForeignKey(d => d.IdEmpresa)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_nota_empresas");
        });

        modelBuilder.Entity<NotaCredito>(entity =>
        {
            entity.HasKey(e => e.IdNotaCredito).HasName("PK__nota_cre__119FFC7E36B671F1");

            entity.ToTable("nota_credito", "sic");

            entity.Property(e => e.IdNotaCredito).HasColumnName("idNotaCredito");
            entity.Property(e => e.Asicon)
                .HasMaxLength(10)
                .HasColumnName("asicon");
            entity.Property(e => e.AteCodigo).HasColumnName("ate_codigo");
            entity.Property(e => e.Caja)
                .HasMaxLength(10)
                .HasColumnName("caja");
            entity.Property(e => e.Cancelado).HasColumnName("cancelado");
            entity.Property(e => e.ClaveAcceso)
                .HasMaxLength(50)
                .HasColumnName("claveAcceso");
            entity.Property(e => e.ClientesCodigo).HasColumnName("clientes_codigo");
            entity.Property(e => e.Codcue)
                .HasMaxLength(10)
                .HasColumnName("codcue");
            entity.Property(e => e.Codcuehaber)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("codcuehaber");
            entity.Property(e => e.Codusu)
                .HasMaxLength(10)
                .HasColumnName("codusu");
            entity.Property(e => e.Consec)
                .HasMaxLength(10)
                .HasColumnName("consec");
            entity.Property(e => e.Descuento).HasColumnName("descuento");
            entity.Property(e => e.Establecimiento)
                .HasMaxLength(3)
                .IsFixedLength()
                .HasColumnName("establecimiento");
            entity.Property(e => e.Estado)
                .HasMaxLength(1)
                .HasDefaultValue("A")
                .IsFixedLength()
                .HasColumnName("estado");
            entity.Property(e => e.Fecha)
                .HasColumnType("datetime")
                .HasColumnName("fecha");
            entity.Property(e => e.FechaAnula)
                .HasColumnType("datetime")
                .HasColumnName("fechaAnula");
            entity.Property(e => e.FechaIngreso)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fechaIngreso");
            entity.Property(e => e.Fechafac)
                .HasColumnType("datetime")
                .HasColumnName("fechafac");
            entity.Property(e => e.Fecmod)
                .HasColumnType("datetime")
                .HasColumnName("fecmod");
            entity.Property(e => e.HistoriaClinica)
                .HasMaxLength(10)
                .HasColumnName("historia_clinica");
            entity.Property(e => e.Id)
                .HasMaxLength(5)
                .HasColumnName("id");
            entity.Property(e => e.IdEmpresa).HasColumnName("id_empresa");
            entity.Property(e => e.Iva).HasColumnName("iva");
            entity.Property(e => e.Numdoc)
                .HasMaxLength(15)
                .HasColumnName("numdoc");
            entity.Property(e => e.Numnota)
                .HasMaxLength(15)
                .HasColumnName("numnota");
            entity.Property(e => e.Obs)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("obs");
            entity.Property(e => e.Proveedor).HasMaxLength(100);
            entity.Property(e => e.Rucproveedor).HasMaxLength(13);
            entity.Property(e => e.Subtotal).HasColumnName("subtotal");
            entity.Property(e => e.Tipond).HasColumnName("TIPOND");
            entity.Property(e => e.Total).HasColumnName("total");
            entity.Property(e => e.Totciva).HasColumnName("totciva");
            entity.Property(e => e.Totsiva).HasColumnName("totsiva");
            entity.Property(e => e.UsuarioAnula)
                .HasMaxLength(50)
                .HasColumnName("usuarioAnula");
            entity.Property(e => e.UsuarioIngreso)
                .HasMaxLength(50)
                .HasColumnName("usuarioIngreso");
            entity.Property(e => e.Valor).HasColumnName("valor");
            entity.Property(e => e.Valoranterior).HasColumnName("valoranterior");
            entity.Property(e => e.Valoriva).HasColumnName("valoriva");

            entity.HasOne(d => d.ClientesCodigoNavigation).WithMany(p => p.NotaCredito)
                .HasForeignKey(d => d.ClientesCodigo)
                .HasConstraintName("FK_nota_credito_clientes");

            entity.HasOne(d => d.IdEmpresaNavigation).WithMany(p => p.NotaCredito)
                .HasForeignKey(d => d.IdEmpresa)
                .HasConstraintName("FK_nota_credito_empresas");
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
            entity.HasKey(e => e.IdOpcion).HasName("PK__opciones__EFAF4258039A2B11");

            entity.ToTable("opciones", "seguridades");

            entity.Property(e => e.IdOpcion).HasColumnName("id_opcion");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.IdSub).HasColumnName("id_sub");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Status).HasColumnName("status");

            entity.HasOne(d => d.IdSubNavigation).WithMany(p => p.Opciones)
                .HasForeignKey(d => d.IdSub)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__opciones__id_sub__2F4FF79D");
        });

        modelBuilder.Entity<Pagos>(entity =>
        {
            entity.HasKey(e => e.IdPago);

            entity.ToTable("pagos", "sic");

            entity.HasIndex(e => new { e.ClienteCodigo, e.Fecha }, "IX_pagos_cliente_fecha").IsDescending(false, true);

            entity.HasIndex(e => e.Fecha, "IX_pagos_fecha").IsDescending();

            entity.HasIndex(e => e.NumeroPago, "IX_pagos_numero");

            entity.HasIndex(e => e.NumeroDocumento, "IX_pagos_numero_documento");

            entity.Property(e => e.IdPago).HasColumnName("id_pago");
            entity.Property(e => e.Arqueada)
                .HasDefaultValue(false)
                .HasColumnName("arqueada");
            entity.Property(e => e.AsientoContable)
                .HasMaxLength(15)
                .HasColumnName("asiento_contable");
            entity.Property(e => e.Caja)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("caja");
            entity.Property(e => e.ClienteCodigo).HasColumnName("cliente_codigo");
            entity.Property(e => e.CodigoResponsable).HasColumnName("codigo_responsable");
            entity.Property(e => e.Comentario)
                .HasMaxLength(250)
                .HasColumnName("comentario");
            entity.Property(e => e.Consecutivo)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("consecutivo");
            entity.Property(e => e.Fecha)
                .HasColumnType("datetime")
                .HasColumnName("fecha");
            entity.Property(e => e.FechaAnulacion)
                .HasMaxLength(30)
                .HasColumnName("fecha_anulacion");
            entity.Property(e => e.FechaSecundaria)
                .HasMaxLength(8)
                .HasColumnName("fecha_secundaria");
            entity.Property(e => e.FilaCuentasPorCobrar)
                .HasDefaultValue(0.0)
                .HasColumnName("fila_cuentas_por_cobrar");
            entity.Property(e => e.FormaPagoPrincipal)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("forma_pago_principal");
            entity.Property(e => e.NumeroDocumento)
                .HasMaxLength(20)
                .HasColumnName("numero_documento");
            entity.Property(e => e.NumeroLiquidacion).HasColumnName("numero_liquidacion");
            entity.Property(e => e.NumeroPago)
                .HasMaxLength(20)
                .HasColumnName("numero_pago");
            entity.Property(e => e.Observaciones)
                .HasMaxLength(1)
                .HasColumnName("observaciones");
            entity.Property(e => e.Pagado)
                .HasMaxLength(20)
                .HasColumnName("pagado");
            entity.Property(e => e.PagoAnulado).HasColumnName("pago_anulado");
            entity.Property(e => e.PagosTexto)
                .HasColumnType("ntext")
                .HasColumnName("pagos_texto");
            entity.Property(e => e.TieneRetencionFuente).HasColumnName("tiene_retencion_fuente");
            entity.Property(e => e.TieneRetencionIva).HasColumnName("tiene_retencion_iva");
            entity.Property(e => e.Tipo)
                .HasMaxLength(1)
                .HasColumnName("tipo");
            entity.Property(e => e.TotalPago).HasColumnName("total_pago");
            entity.Property(e => e.ValorRetencionFuente)
                .HasMaxLength(20)
                .HasColumnName("valor_retencion_fuente");
            entity.Property(e => e.ValorRetencionIva)
                .HasMaxLength(20)
                .HasColumnName("valor_retencion_iva");

            entity.HasOne(d => d.ClienteCodigoNavigation).WithMany(p => p.Pagos)
                .HasForeignKey(d => d.ClienteCodigo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_pagos_clientes");
        });

        modelBuilder.Entity<PagosNotaCredito>(entity =>
        {
            entity.HasKey(e => e.IdPagosNc).HasName("PK__pagos_no__6FC2182882DB79C9");

            entity.ToTable("pagos_nota_credito", "sic");

            entity.Property(e => e.IdPagosNc).HasColumnName("idPagosNc");
            entity.Property(e => e.ClientesCodigo).HasColumnName("clientes_codigo");
            entity.Property(e => e.CuentaContable)
                .HasMaxLength(10)
                .HasColumnName("cuentaContable");
            entity.Property(e => e.Estado)
                .HasMaxLength(1)
                .HasDefaultValue("A")
                .IsFixedLength()
                .HasColumnName("estado");
            entity.Property(e => e.Fecha)
                .HasColumnType("datetime")
                .HasColumnName("fecha");
            entity.Property(e => e.Fila).HasColumnName("fila");
            entity.Property(e => e.Forpag)
                .HasMaxLength(10)
                .HasColumnName("forpag");
            entity.Property(e => e.Id)
                .HasMaxLength(5)
                .IsFixedLength()
                .HasColumnName("id");
            entity.Property(e => e.IdNotaCredito).HasColumnName("idNotaCredito");
            entity.Property(e => e.Numdoc)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("numdoc");
            entity.Property(e => e.Numnota)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("numnota");
            entity.Property(e => e.Valor).HasColumnName("valor");

            entity.HasOne(d => d.ClientesCodigoNavigation).WithMany(p => p.PagosNotaCredito)
                .HasForeignKey(d => d.ClientesCodigo)
                .HasConstraintName("FK_pagos_nota_credito_clientes");

            entity.HasOne(d => d.IdNotaCreditoNavigation).WithMany(p => p.PagosNotaCredito)
                .HasForeignKey(d => d.IdNotaCredito)
                .HasConstraintName("FK_pagos_nota_credito_nota_credito");
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
            entity.HasKey(e => e.Id).HasName("PK__parametr__3213E83F9F10F2E1");

            entity.ToTable("parametros", "seguridades");

            entity.HasIndex(e => e.Clave, "UQ__parametr__71DCA3DBA6C574A0").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Activo)
                .HasDefaultValue(true)
                .HasColumnName("activo");
            entity.Property(e => e.Clave)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("clave");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fecha_creacion");
            entity.Property(e => e.Multiple)
                .HasDefaultValue(false)
                .HasColumnName("multiple");
            entity.Property(e => e.Requerido)
                .HasDefaultValue(false)
                .HasColumnName("requerido");
            entity.Property(e => e.Tipo)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("tipo");
        });

        modelBuilder.Entity<ParametrosDetalle>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__parametr__3213E83F28B670FB");

            entity.ToTable("parametros_detalle", "seguridades");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Activo)
                .HasDefaultValue(true)
                .HasColumnName("activo");
            entity.Property(e => e.Ambiente)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("prod")
                .HasColumnName("ambiente");
            entity.Property(e => e.Contexto)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("contexto");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fecha_creacion");
            entity.Property(e => e.IdEmpresa).HasColumnName("id_empresa");
            entity.Property(e => e.IdParametro).HasColumnName("id_parametro");
            entity.Property(e => e.UsuarioModifica)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("usuario_modifica");
            entity.Property(e => e.Valor)
                .IsUnicode(false)
                .HasColumnName("valor");

            entity.HasOne(d => d.IdParametroNavigation).WithMany(p => p.ParametrosDetalle)
                .HasForeignKey(d => d.IdParametro)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__parametro__id_pa__3B2BBE9D");
        });

        modelBuilder.Entity<ParametrosFactura>(entity =>
        {
            entity.HasKey(e => e.IdParametrosFactura);

            entity.ToTable("parametros_factura", "sic");

            entity.Property(e => e.IdParametrosFactura).HasColumnName("id_parametros_factura");
            entity.Property(e => e.Activado).HasColumnName("activado");
            entity.Property(e => e.Codpar)
                .HasMaxLength(10)
                .HasColumnName("codpar");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(150)
                .HasColumnName("descripcion");
            entity.Property(e => e.Fecmod)
                .HasColumnType("datetime")
                .HasColumnName("fecmod");
            entity.Property(e => e.Obs)
                .HasMaxLength(255)
                .HasColumnName("obs");
            entity.Property(e => e.Texto)
                .HasMaxLength(255)
                .HasColumnName("texto");
            entity.Property(e => e.Valor).HasColumnName("valor");
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
            entity.Property(e => e.Estado)
                .HasDefaultValue(true)
                .HasColumnName("estado");
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
            entity.HasKey(e => e.IdPerfilOpcion).HasName("PK__perfiles__9990C2953C17600B");

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
                .HasConstraintName("FK__perfiles___id_op__35FCF52C");

            entity.HasOne(d => d.IdPerfilNavigation).WithMany(p => p.PerfilesOpciones)
                .HasForeignKey(d => d.IdPerfil)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__perfiles___id_pe__3508D0F3");
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

        modelBuilder.Entity<PerfilesSubMenus>(entity =>
        {
            entity.HasKey(e => e.IdPerfilSubMenu).HasName("PK__perfiles__2133A4DD1327DD0F");

            entity.ToTable("perfiles_sub_menus", "seguridades");

            entity.Property(e => e.IdPerfilSubMenu).HasColumnName("id_perfil_sub_menu");
            entity.Property(e => e.FechaCreacion)
                .HasColumnType("datetime")
                .HasColumnName("fecha_creacion");
            entity.Property(e => e.IdPerfil).HasColumnName("id_perfil");
            entity.Property(e => e.IdSub).HasColumnName("id_sub");
            entity.Property(e => e.Status).HasColumnName("status");

            entity.HasOne(d => d.IdPerfilNavigation).WithMany(p => p.PerfilesSubMenus)
                .HasForeignKey(d => d.IdPerfil)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__perfiles___id_pe__697C9932");

            entity.HasOne(d => d.IdSubNavigation).WithMany(p => p.PerfilesSubMenus)
                .HasForeignKey(d => d.IdSub)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__perfiles___id_su__6A70BD6B");
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

        modelBuilder.Entity<Presentacion>(entity =>
        {
            entity.HasKey(e => e.IdPresentacion).HasName("PK__presenta__5F94E0EDC4FDCC7D");

            entity.ToTable("presentacion", "sic");

            entity.Property(e => e.IdPresentacion).HasColumnName("id_presentacion");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.Status)
                .HasDefaultValue(true)
                .HasColumnName("status");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.IdProducto).HasName("PK_sic_producto");

            entity.ToTable("producto", "sic");

            entity.Property(e => e.IdProducto).HasColumnName("id_producto");
            entity.Property(e => e.Abrevia)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("abrevia");
            entity.Property(e => e.Activo).HasColumnName("activo");
            entity.Property(e => e.AltoRiesgo).HasColumnName("alto_riesgo");
            entity.Property(e => e.Ancho).HasColumnName("ancho");
            entity.Property(e => e.CantConv)
                .HasComment("Cantidad de conversión entre unidades")
                .HasColumnName("cant_conv");
            entity.Property(e => e.CantDecimal).HasColumnName("cant_decimal");
            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.ClasProd)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("clas_prod");
            entity.Property(e => e.CodColUbi)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasComment("Código de columna ubicación")
                .HasColumnName("cod_col_ubi");
            entity.Property(e => e.CodNiv)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasComment("Código de nivel")
                .HasColumnName("cod_niv");
            entity.Property(e => e.Codbar)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("codbar");
            entity.Property(e => e.Codcol)
                .HasComment("Color del producto (ID referencia futura tabla colores)")
                .HasColumnName("codcol");
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
            entity.Property(e => e.Coddep).HasColumnName("coddep");
            entity.Property(e => e.Coddiv).HasColumnName("coddiv");
            entity.Property(e => e.Codgru).HasColumnName("codgru");
            entity.Property(e => e.Codmar).HasColumnName("codmar");
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
                .HasComment("Código sabor (varchar temporal, futuro ID tabla sabores)")
                .HasColumnName("codsab");
            entity.Property(e => e.Codsec).HasColumnName("codsec");
            entity.Property(e => e.Codsub).HasColumnName("codsub");
            entity.Property(e => e.Codubi)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasComment("Código de ubicación - Pasillo")
                .HasColumnName("codubi");
            entity.Property(e => e.Coleccion)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("coleccion");
            entity.Property(e => e.Colsab)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("colsab");
            entity.Property(e => e.ConsumoInterno)
                .HasDefaultValue(false)
                .HasColumnName("consumo_interno");
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
            entity.Property(e => e.Descuento).HasColumnName("descuento");
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
            entity.Property(e => e.Espesor).HasColumnName("espesor");
            entity.Property(e => e.Estupefaciente)
                .HasDefaultValue(false)
                .HasColumnName("estupefaciente");
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
            entity.Property(e => e.IdColor).HasColumnName("id_color");
            entity.Property(e => e.IdEmpresa).HasColumnName("id_empresa");
            entity.Property(e => e.IdFabricante).HasColumnName("id_fabricante");
            entity.Property(e => e.IdIva).HasColumnName("id_iva");
            entity.Property(e => e.IdPresentacion).HasColumnName("id_presentacion");
            entity.Property(e => e.IdSabor).HasColumnName("id_sabor");
            entity.Property(e => e.Inv).HasColumnName("inv");
            entity.Property(e => e.Iva)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("iva");
            entity.Property(e => e.Largo).HasColumnName("largo");
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
            entity.Property(e => e.PagaIva).HasColumnName("paga_iva");
            entity.Property(e => e.PagaRegalia).HasColumnName("paga_regalia");
            entity.Property(e => e.Peso).HasColumnName("peso");
            entity.Property(e => e.PorcenRecepcion).HasColumnName("porcen_recepcion");
            entity.Property(e => e.PreAnterior).HasColumnName("pre_anterior");
            entity.Property(e => e.PreRebaja).HasColumnName("pre_rebaja");
            entity.Property(e => e.PreRebajaAntes).HasColumnName("pre_rebaja_antes");
            entity.Property(e => e.Precos).HasColumnName("precos");
            entity.Property(e => e.Prepormayor).HasColumnName("prepormayor");
            entity.Property(e => e.Preuni)
                .HasMaxLength(20)
                .HasColumnName("preuni");
            entity.Property(e => e.Preven).HasColumnName("preven");
            entity.Property(e => e.Preven2).HasColumnName("preven2");
            entity.Property(e => e.PrevenSinIva).HasColumnName("preven_sin_iva");
            entity.Property(e => e.ProductoEnVenta)
                .HasDefaultValue(false)
                .HasColumnName("producto_en_venta");
            entity.Property(e => e.Psicotropico)
                .HasDefaultValue(false)
                .HasColumnName("psicotropico");
            entity.Property(e => e.PvpSinIva).HasColumnName("pvp_sin_iva");
            entity.Property(e => e.Receta).HasColumnName("receta");
            entity.Property(e => e.Refer)
                .HasMaxLength(15)
                .HasColumnName("refer");
            entity.Property(e => e.Referencia)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("referencia");
            entity.Property(e => e.RegSanitario)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("reg_sanitario");
            entity.Property(e => e.Regalia)
                .HasMaxLength(15)
                .HasColumnName("regalia");
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
            entity.Property(e => e.Tipo)
                .HasMaxLength(1)
                .HasColumnName("tipo");
            entity.Property(e => e.Tippro)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("tippro");
            entity.Property(e => e.Uniman)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("uniman");
            entity.Property(e => e.ValorUnidad).HasColumnName("valor_unidad");

            entity.HasOne(d => d.IdColorNavigation).WithMany(p => p.Producto)
                .HasForeignKey(d => d.IdColor)
                .HasConstraintName("FK_producto_color");

            entity.HasOne(d => d.IdEmpresaNavigation).WithMany(p => p.Producto)
                .HasForeignKey(d => d.IdEmpresa)
                .HasConstraintName("FK_sic_producto_empresa");

            entity.HasOne(d => d.IdFabricanteNavigation).WithMany(p => p.Producto)
                .HasForeignKey(d => d.IdFabricante)
                .HasConstraintName("FK_producto_fabricante");

            entity.HasOne(d => d.IdIvaNavigation).WithMany(p => p.Producto)
                .HasForeignKey(d => d.IdIva)
                .HasConstraintName("FK_producto_iva");

            entity.HasOne(d => d.IdPresentacionNavigation).WithMany(p => p.Producto)
                .HasForeignKey(d => d.IdPresentacion)
                .HasConstraintName("FK_producto_presentacion");

            entity.HasOne(d => d.IdSaborNavigation).WithMany(p => p.Producto)
                .HasForeignKey(d => d.IdSabor)
                .HasConstraintName("FK_producto_sabor");
        });

        modelBuilder.Entity<ProductoDatosAdicionales>(entity =>
        {
            entity.HasKey(e => e.IdProductoDatosAdicionales).HasName("PK_sic_producto_datos_adicionales");

            entity.ToTable("producto_datos_adicionales", "sic");

            entity.HasIndex(e => e.IdProducto, "UQ_producto_datos_adicionales_idproducto").IsUnique();

            entity.Property(e => e.IdProductoDatosAdicionales).HasColumnName("id__producto_datos_adicionales");
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
            entity.Property(e => e.ClientesCodigo).HasColumnName("clientes_codigo");
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
            entity.Property(e => e.IdGrupoProducto).HasColumnName("id_grupo_producto");
            entity.Property(e => e.IdPrefijos).HasColumnName("id_prefijos");
            entity.Property(e => e.IdProducto).HasColumnName("id_producto");
            entity.Property(e => e.IdSector).HasColumnName("id_sector");
            entity.Property(e => e.IdTipoCodigoGs1).HasColumnName("id_tipo_codigo_gs1");
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

            entity.HasOne(d => d.ClientesCodigoNavigation).WithMany(p => p.ProductoDatosAdicionales)
                .HasForeignKey(d => d.ClientesCodigo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_prodcu_datos_clientes");

            entity.HasOne(d => d.IdGrupoProductoNavigation).WithMany(p => p.ProductoDatosAdicionales)
                .HasForeignKey(d => d.IdGrupoProducto)
                .HasConstraintName("FK_prodcu_datos_grupo_producto");

            entity.HasOne(d => d.IdPrefijosNavigation).WithMany(p => p.ProductoDatosAdicionales)
                .HasForeignKey(d => d.IdPrefijos)
                .HasConstraintName("FK_prodcu_datos_prefijos");

            entity.HasOne(d => d.IdProductoNavigation).WithOne(p => p.ProductoDatosAdicionales)
                .HasForeignKey<ProductoDatosAdicionales>(d => d.IdProducto)
                .HasConstraintName("FK_prodcu_datos_adicionales");

            entity.HasOne(d => d.IdSectorNavigation).WithMany(p => p.ProductoDatosAdicionales)
                .HasForeignKey(d => d.IdSector)
                .HasConstraintName("FK_sic_producto_datos_adicionales_sic_sector");

            entity.HasOne(d => d.IdTipoCodigoGs1Navigation).WithMany(p => p.ProductoDatosAdicionales)
                .HasForeignKey(d => d.IdTipoCodigoGs1)
                .HasConstraintName("FK_sic_producto_datos_adicionales_sic_tipo_codigo_gs1");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.ProductoDatosAdicionales)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK_sic_producto_datos_adicionales_usuarios");
        });

        modelBuilder.Entity<ProductoEstructuraComercial>(entity =>
        {
            entity.HasKey(e => e.IdProducto);

            entity.ToTable("producto_estructura_comercial", "sic");

            entity.Property(e => e.IdProducto)
                .ValueGeneratedNever()
                .HasColumnName("id_producto");
            entity.Property(e => e.IdDepartamento).HasColumnName("id_departamento");
            entity.Property(e => e.IdDivision).HasColumnName("id_division");
            entity.Property(e => e.IdGrupo).HasColumnName("id_grupo");
            entity.Property(e => e.IdSeccion).HasColumnName("id_seccion");
            entity.Property(e => e.IdSubDivision).HasColumnName("id_sub_division");

            entity.HasOne(d => d.IdDepartamentoNavigation).WithMany(p => p.ProductoEstructuraComercial)
                .HasForeignKey(d => d.IdDepartamento)
                .HasConstraintName("FK_pe_departamento");

            entity.HasOne(d => d.IdDivisionNavigation).WithMany(p => p.ProductoEstructuraComercial)
                .HasForeignKey(d => d.IdDivision)
                .HasConstraintName("FK_pe_division");

            entity.HasOne(d => d.IdGrupoNavigation).WithMany(p => p.ProductoEstructuraComercial)
                .HasForeignKey(d => d.IdGrupo)
                .HasConstraintName("FK_pe_grupo");

            entity.HasOne(d => d.IdProductoNavigation).WithOne(p => p.ProductoEstructuraComercial)
                .HasForeignKey<ProductoEstructuraComercial>(d => d.IdProducto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_pe_producto");

            entity.HasOne(d => d.IdSeccionNavigation).WithMany(p => p.ProductoEstructuraComercial)
                .HasForeignKey(d => d.IdSeccion)
                .HasConstraintName("FK_pe_seccion");

            entity.HasOne(d => d.IdSubDivisionNavigation).WithMany(p => p.ProductoEstructuraComercial)
                .HasForeignKey(d => d.IdSubDivision)
                .HasConstraintName("FK_pe_subdivision");
        });

        modelBuilder.Entity<ProductoUbicacionBodega>(entity =>
        {
            entity.HasKey(e => e.IdProductoUbicacion);

            entity.ToTable("producto_ubicacion_bodega", "sic");

            entity.HasIndex(e => e.IdLocal, "IX_producto_ubicacion_bodega_local");

            entity.HasIndex(e => e.IdProducto, "IX_producto_ubicacion_bodega_producto");

            entity.Property(e => e.IdProductoUbicacion).HasColumnName("id_producto_ubicacion");
            entity.Property(e => e.IdArea).HasColumnName("id_area");
            entity.Property(e => e.IdColumna).HasColumnName("id_columna");
            entity.Property(e => e.IdLocal).HasColumnName("id_local");
            entity.Property(e => e.IdNivel).HasColumnName("id_nivel");
            entity.Property(e => e.IdProducto).HasColumnName("id_producto");

            entity.HasOne(d => d.IdAreaNavigation).WithMany(p => p.ProductoUbicacionBodega)
                .HasForeignKey(d => d.IdArea)
                .HasConstraintName("FK_producto_ubicacion_bodega_ubicacion_area");

            entity.HasOne(d => d.IdColumnaNavigation).WithMany(p => p.ProductoUbicacionBodega)
                .HasForeignKey(d => d.IdColumna)
                .HasConstraintName("FK_producto_ubicacion_bodega_columna");

            entity.HasOne(d => d.IdLocalNavigation).WithMany(p => p.ProductoUbicacionBodega)
                .HasForeignKey(d => d.IdLocal)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_producto_ubicacion_bodega_local");

            entity.HasOne(d => d.IdNivelNavigation).WithMany(p => p.ProductoUbicacionBodega)
                .HasForeignKey(d => d.IdNivel)
                .HasConstraintName("FK_producto_ubicacion_bodega_nivel");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.ProductoUbicacionBodega)
                .HasForeignKey(d => d.IdProducto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_producto_ubicacion_bodega_producto");
        });

        modelBuilder.Entity<ProductosProveedores>(entity =>
        {
            entity.HasKey(e => e.IdProductoProveedor).HasName("PK_sic_productos_proveedores");

            entity.ToTable("productos_proveedores", "sic");

            entity.HasIndex(e => e.Activo, "IX_productos_proveedores_activo");

            entity.HasIndex(e => e.EsProveedorPrincipal, "IX_productos_proveedores_principal").HasFilter("([es_proveedor_principal]=(1))");

            entity.HasIndex(e => e.IdProducto, "IX_productos_proveedores_producto");

            entity.HasIndex(e => e.IdProveedor, "IX_productos_proveedores_proveedor");

            entity.HasIndex(e => e.IdProducto, "UQ_productos_proveedores_principal")
                .IsUnique()
                .HasFilter("([es_proveedor_principal]=(1) AND [activo]=(1))");

            entity.HasIndex(e => new { e.IdProducto, e.IdProveedor }, "UQ_productos_proveedores_producto_proveedor").IsUnique();

            entity.Property(e => e.IdProductoProveedor).HasColumnName("id_producto_proveedor");
            entity.Property(e => e.Activo)
                .HasDefaultValue(true)
                .HasColumnName("activo");
            entity.Property(e => e.CodigoProducto)
                .HasMaxLength(20)
                .HasColumnName("codigo_producto");
            entity.Property(e => e.CodigoProveedor)
                .HasMaxLength(10)
                .HasColumnName("codigo_proveedor");
            entity.Property(e => e.CostoCompra).HasColumnName("costo_compra");
            entity.Property(e => e.CostoNeto).HasColumnName("costo_neto");
            entity.Property(e => e.Descuento1).HasColumnName("descuento_1");
            entity.Property(e => e.Descuento2).HasColumnName("descuento_2");
            entity.Property(e => e.Descuento3).HasColumnName("descuento_3");
            entity.Property(e => e.Descuento4).HasColumnName("descuento_4");
            entity.Property(e => e.DescuentoGeneral).HasColumnName("descuento_general");
            entity.Property(e => e.EsProveedorPrincipal).HasColumnName("es_proveedor_principal");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fecha_creacion");
            entity.Property(e => e.FechaIngreso)
                .HasColumnType("datetime")
                .HasColumnName("fecha_ingreso");
            entity.Property(e => e.FechaModificacion)
                .HasColumnType("datetime")
                .HasColumnName("fecha_modificacion");
            entity.Property(e => e.FechaModificacionAudit)
                .HasColumnType("datetime")
                .HasColumnName("fecha_modificacion_audit");
            entity.Property(e => e.FechaUltimaCompra)
                .HasColumnType("datetime")
                .HasColumnName("fecha_ultima_compra");
            entity.Property(e => e.IdProducto).HasColumnName("id_producto");
            entity.Property(e => e.IdProveedor).HasColumnName("id_proveedor");
            entity.Property(e => e.PorcentajePvp).HasColumnName("porcentaje_pvp");
            entity.Property(e => e.ProductoConsignacion).HasColumnName("producto_consignacion");
            entity.Property(e => e.UnidadCompra)
                .HasMaxLength(50)
                .HasColumnName("unidad_compra");
            entity.Property(e => e.UsuarioCreacion).HasColumnName("usuario_creacion");
            entity.Property(e => e.UsuarioModificacion).HasColumnName("usuario_modificacion");
            entity.Property(e => e.ValorUnidadCompra).HasColumnName("valor_unidad_compra");

            entity.HasOne(d => d.IdProductoNavigation).WithOne(p => p.ProductosProveedores)
                .HasForeignKey<ProductosProveedores>(d => d.IdProducto)
                .HasConstraintName("FK_productos_proveedores_producto");

            entity.HasOne(d => d.IdProveedorNavigation).WithMany(p => p.ProductosProveedores)
                .HasForeignKey(d => d.IdProveedor)
                .HasConstraintName("FK_productos_proveedores_proveedor");
        });

        modelBuilder.Entity<Proveedores>(entity =>
        {
            entity.HasKey(e => e.IdProveedor).HasName("PK_sic_proveedores");

            entity.ToTable("proveedores", "sic");

            entity.HasIndex(e => e.Activo, "IX_proveedores_activo");

            entity.HasIndex(e => e.CodigoProveedor, "IX_proveedores_codigo");

            entity.HasIndex(e => e.NombreProveedor, "IX_proveedores_nombre");

            entity.HasIndex(e => e.IdPersona, "IX_proveedores_persona");

            entity.HasIndex(e => e.RucProveedor, "IX_proveedores_ruc");

            entity.HasIndex(e => e.CodigoProveedor, "UQ_proveedores_codigo").IsUnique();

            entity.HasIndex(e => e.RucProveedor, "UQ_proveedores_ruc").IsUnique();

            entity.Property(e => e.IdProveedor).HasColumnName("id_proveedor");
            entity.Property(e => e.Activo)
                .HasDefaultValue(true)
                .HasColumnName("activo");
            entity.Property(e => e.Autorizacion)
                .HasMaxLength(10)
                .HasColumnName("autorizacion");
            entity.Property(e => e.CasillaProveedor)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("casilla_proveedor");
            entity.Property(e => e.CodigoBanco)
                .HasMaxLength(10)
                .HasColumnName("codigo_banco");
            entity.Property(e => e.CodigoCiudad)
                .HasMaxLength(10)
                .HasColumnName("codigo_ciudad");
            entity.Property(e => e.CodigoCuenta)
                .HasMaxLength(30)
                .HasDefaultValue("211101-001")
                .HasColumnName("codigo_cuenta");
            entity.Property(e => e.CodigoEan)
                .HasMaxLength(13)
                .HasColumnName("codigo_ean");
            entity.Property(e => e.CodigoPais).HasColumnName("codigo_pais");
            entity.Property(e => e.CodigoProveedor)
                .HasMaxLength(10)
                .HasColumnName("codigo_proveedor");
            entity.Property(e => e.CodigoRetencionFb)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("codigo_retencion_fb");
            entity.Property(e => e.CodigoRetencionFs)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("codigo_retencion_fs");
            entity.Property(e => e.CodigoRetencionIb)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("codigo_retencion_ib");
            entity.Property(e => e.CodigoRetencionIs)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("codigo_retencion_is");
            entity.Property(e => e.ContactoProveedor)
                .HasMaxLength(40)
                .HasColumnName("contacto_proveedor");
            entity.Property(e => e.CuentaCorriente)
                .HasMaxLength(20)
                .HasColumnName("cuenta_corriente");
            entity.Property(e => e.DescuentoGlobalMonto)
                .HasMaxLength(2)
                .HasColumnName("descuento_global_monto");
            entity.Property(e => e.DireccionProveedor)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("direccion_proveedor");
            entity.Property(e => e.EmailProveedor)
                .HasMaxLength(500)
                .HasColumnName("email_proveedor");
            entity.Property(e => e.FaxProveedor)
                .HasMaxLength(20)
                .HasColumnName("fax_proveedor");
            entity.Property(e => e.FechaAlta)
                .HasColumnType("datetime")
                .HasColumnName("fecha_alta");
            entity.Property(e => e.FechaCaducidad)
                .HasColumnType("datetime")
                .HasColumnName("fecha_caducidad");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fecha_creacion");
            entity.Property(e => e.FechaModificacion)
                .HasColumnType("datetime")
                .HasColumnName("fecha_modificacion");
            entity.Property(e => e.FechaModificacionAudit)
                .HasColumnType("datetime")
                .HasColumnName("fecha_modificacion_audit");
            entity.Property(e => e.FormaPago)
                .HasMaxLength(10)
                .HasColumnName("forma_pago");
            entity.Property(e => e.IdPersona).HasColumnName("id_persona");
            entity.Property(e => e.MontoDescuento).HasColumnName("monto_descuento");
            entity.Property(e => e.MotivoRetencion)
                .HasMaxLength(2)
                .HasColumnName("motivo_retencion");
            entity.Property(e => e.NoCambiarCostoProducto).HasColumnName("no_cambiar_costo_producto");
            entity.Property(e => e.NombreComercial)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("nombre_comercial");
            entity.Property(e => e.NombreProveedor)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("nombre_proveedor");
            entity.Property(e => e.Observaciones)
                .HasMaxLength(255)
                .HasColumnName("observaciones");
            entity.Property(e => e.OrigenProveedor)
                .HasMaxLength(15)
                .HasColumnName("origen_proveedor");
            entity.Property(e => e.PlazoPago).HasColumnName("plazo_pago");
            entity.Property(e => e.PlazoPagoC).HasColumnName("plazo_pago_c");
            entity.Property(e => e.PorcentajeDescuento).HasColumnName("porcentaje_descuento");
            entity.Property(e => e.PorcentajePvp).HasColumnName("porcentaje_pvp");
            entity.Property(e => e.PorcentajeRetencion).HasColumnName("porcentaje_retencion");
            entity.Property(e => e.PorcentajeRetencionFb).HasColumnName("porcentaje_retencion_fb");
            entity.Property(e => e.PorcentajeRetencionFs).HasColumnName("porcentaje_retencion_fs");
            entity.Property(e => e.PorcentajeRetencionIb).HasColumnName("porcentaje_retencion_ib");
            entity.Property(e => e.PorcentajeRetencionIs).HasColumnName("porcentaje_retencion_is");
            entity.Property(e => e.RepresentanteProveedor)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("representante_proveedor");
            entity.Property(e => e.RucProveedor)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ruc_proveedor");
            entity.Property(e => e.Tarifa).HasColumnName("tarifa");
            entity.Property(e => e.Telefono1Proveedor)
                .HasMaxLength(20)
                .HasColumnName("telefono_1_proveedor");
            entity.Property(e => e.Telefono2Proveedor)
                .HasMaxLength(20)
                .HasColumnName("telefono_2_proveedor");
            entity.Property(e => e.TelefonoProveedor)
                .HasMaxLength(20)
                .HasColumnName("telefono_proveedor");
            entity.Property(e => e.TiempoEntrega).HasColumnName("tiempo_entrega");
            entity.Property(e => e.TipoContado).HasColumnName("tipo_contado");
            entity.Property(e => e.TipoNacionalInternacional).HasColumnName("tipo_nacional_internacional");
            entity.Property(e => e.TipoProduccion).HasColumnName("tipo_produccion");
            entity.Property(e => e.TipoProducto)
                .HasMaxLength(1)
                .HasColumnName("tipo_producto");
            entity.Property(e => e.TipoProveedor)
                .HasMaxLength(2)
                .HasColumnName("tipo_proveedor");
            entity.Property(e => e.UsuarioCreacion).HasColumnName("usuario_creacion");
            entity.Property(e => e.UsuarioModificacionAudit).HasColumnName("usuario_modificacion_audit");
            entity.Property(e => e.WebProveedor)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("web_proveedor");

            entity.HasOne(d => d.IdPersonaNavigation).WithMany(p => p.Proveedores)
                .HasForeignKey(d => d.IdPersona)
                .HasConstraintName("FK_proveedores_personas");
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

        modelBuilder.Entity<Proyectos>(entity =>
        {
            entity.HasKey(e => e.IdProyecto).HasName("PK__proyecto__F38AD81D35FB7106");

            entity.ToTable("proyectos", "seguridades");

            entity.Property(e => e.IdProyecto).HasColumnName("id_proyecto");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.FechaIngreso).HasColumnName("fecha_ingreso");
            entity.Property(e => e.IdEmpresa).HasColumnName("id_empresa");

            entity.HasOne(d => d.IdEmpresaNavigation).WithMany(p => p.Proyectos)
                .HasForeignKey(d => d.IdEmpresa)
                .HasConstraintName("FK_proyectos_empresas");
        });

        modelBuilder.Entity<RecuperacionClave>(entity =>
        {
            entity.HasKey(e => e.IdRecuperacion).HasName("PK__recupera__44F7DEFD431C8677");

            entity.ToTable("recuperacion_clave", "seguridades");

            entity.Property(e => e.IdRecuperacion).HasColumnName("id_recuperacion");
            entity.Property(e => e.FechaExpiracion)
                .HasColumnType("datetime")
                .HasColumnName("fecha_expiracion");
            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.Token)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("token");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.RecuperacionClave)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_recuperacion_clave_usuario");
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

        modelBuilder.Entity<Sabores>(entity =>
        {
            entity.HasKey(e => e.IdSabor);

            entity.ToTable("sabores", "sic");

            entity.Property(e => e.IdSabor).HasColumnName("id_sabor");
            entity.Property(e => e.Activo)
                .HasDefaultValue(true)
                .HasColumnName("activo");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(80)
                .HasColumnName("descripcion");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fecha_creacion");
            entity.Property(e => e.FechaModificacion)
                .HasColumnType("datetime")
                .HasColumnName("fecha_modificacion");
        });

        modelBuilder.Entity<Seccion>(entity =>
        {
            entity.HasKey(e => e.IdSeccion).HasName("PK__seccion__7C91FD812731A8D4");

            entity.ToTable("seccion", "sic");

            entity.Property(e => e.IdSeccion).HasColumnName("id_seccion");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.IdDepartamento).HasColumnName("id_departamento");

            entity.HasOne(d => d.IdDepartamentoNavigation).WithMany(p => p.Seccion)
                .HasForeignKey(d => d.IdDepartamento)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_seccion_departamento");
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
            entity.Property(e => e.Estado).HasColumnName("estado");
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
            entity.Property(e => e.Url)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("url");
        });

        modelBuilder.Entity<Sscc>(entity =>
        {
            entity.HasKey(e => e.IdSscc).HasName("PK__sscc__42E294FF96DA476F");

            entity.ToTable("sscc", "sic");

            entity.Property(e => e.IdSscc).HasColumnName("id_sscc");
            entity.Property(e => e.DigitoControl)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("digito_control");
            entity.Property(e => e.Estado)
                .HasDefaultValue(true)
                .HasColumnName("estado");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fecha_creacion");
            entity.Property(e => e.IdCliente).HasColumnName("id_cliente");
            entity.Property(e => e.IdPrefijo).HasColumnName("id_prefijo");
            entity.Property(e => e.Indicador).HasColumnName("indicador");
            entity.Property(e => e.ObservacionEliminacion)
                .HasMaxLength(250)
                .HasColumnName("observacion_eliminacion");
            entity.Property(e => e.ProductoCodificado)
                .HasMaxLength(100)
                .HasColumnName("producto_codificado");
            entity.Property(e => e.SecuenciaFin).HasColumnName("secuencia_fin");
            entity.Property(e => e.SecuenciaInicio).HasColumnName("secuencia_inicio");
            entity.Property(e => e.Serial)
                .HasMaxLength(13)
                .IsUnicode(false)
                .HasColumnName("serial");
            entity.Property(e => e.Serie)
                .HasDefaultValue(false)
                .HasColumnName("serie");
            entity.Property(e => e.SsccCompleto)
                .HasMaxLength(18)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("sscc_completo");
            entity.Property(e => e.TotalGenerado).HasColumnName("total_generado");
            entity.Property(e => e.Usuario)
                .HasMaxLength(50)
                .HasColumnName("usuario");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Sscc)
                .HasForeignKey(d => d.IdCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SSCC_Cliente");

            entity.HasOne(d => d.IdPrefijoNavigation).WithMany(p => p.Sscc)
                .HasForeignKey(d => d.IdPrefijo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SSCC_Prefijo");
        });

        modelBuilder.Entity<Stocks>(entity =>
        {
            entity.HasKey(e => e.IdStock).HasName("PK_sic_stocks");

            entity.ToTable("stocks", "sic");

            entity.HasIndex(e => e.IdLocal, "IX_stocks_local");

            entity.HasIndex(e => e.IdProducto, "IX_stocks_producto");

            entity.HasIndex(e => new { e.IdProducto, e.IdLocal }, "UQ_stocks_producto_local").IsUnique();

            entity.Property(e => e.IdStock).HasColumnName("id_stock");
            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.FechaIngreso)
                .HasColumnType("datetime")
                .HasColumnName("fecha_ingreso");
            entity.Property(e => e.FechaModificacion)
                .HasColumnType("datetime")
                .HasColumnName("fecha_modificacion");
            entity.Property(e => e.IdLocal).HasColumnName("id_local");
            entity.Property(e => e.IdProducto).HasColumnName("id_producto");
            entity.Property(e => e.StockMax).HasColumnName("stock_max");
            entity.Property(e => e.StockMin).HasColumnName("stock_min");

            entity.HasOne(d => d.IdLocalNavigation).WithMany(p => p.Stocks)
                .HasForeignKey(d => d.IdLocal)
                .HasConstraintName("FK_stocks_locales");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.StocksNavigation)
                .HasForeignKey(d => d.IdProducto)
                .HasConstraintName("FK_stocks_producto");
        });

        modelBuilder.Entity<SubDivision>(entity =>
        {
            entity.HasKey(e => e.IdSubDivision).HasName("PK__sub_divi__78DF02640B242A6F");

            entity.ToTable("sub_division", "sic");

            entity.Property(e => e.IdSubDivision).HasColumnName("id_sub_division");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.IdDivision).HasColumnName("id_division");

            entity.HasOne(d => d.IdDivisionNavigation).WithMany(p => p.SubDivision)
                .HasForeignKey(d => d.IdDivision)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_subdivision_division");
        });

        modelBuilder.Entity<SubMenus>(entity =>
        {
            entity.HasKey(e => e.IdSub).HasName("PK__opciones__A41C30186FE59AD8");

            entity.ToTable("sub_menus", "seguridades");

            entity.Property(e => e.IdSub).HasColumnName("id_sub");
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
            entity.Property(e => e.Url)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("url");

            entity.HasOne(d => d.IdMenuNavigation).WithMany(p => p.SubMenus)
                .HasForeignKey(d => d.IdMenu)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_sub_menus_menus");
        });

        modelBuilder.Entity<TablaPrueba>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tabla_prueba", "seguridades");

            entity.Property(e => e.IdPrueba).HasColumnName("id_prueba");
            entity.Property(e => e.Prueba)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("prueba");
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
            entity.Property(e => e.Estado).HasColumnName("estado");
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

        modelBuilder.Entity<TipoDocumentoSri>(entity =>
        {
            entity.HasKey(e => e.IdTipoDocumento).HasName("PK__tipo_doc__9F38507CE90E40E8");

            entity.ToTable("tipo_documento_sri", "sic");

            entity.Property(e => e.IdTipoDocumento).HasColumnName("id_tipo_documento");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(25)
                .HasColumnName("descripcion");
            entity.Property(e => e.DocumentoSri)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("documento_sri");
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

        modelBuilder.Entity<TipoIdentificacionSri>(entity =>
        {
            entity.HasKey(e => e.IdTipIdSri).HasName("PK__tipo_ide__BF077D75C5B94DD9");

            entity.ToTable("tipo_identificacion_sri", "sic");

            entity.Property(e => e.IdTipIdSri).HasColumnName("id_tip_id_sri");
            entity.Property(e => e.CodigoSri)
                .HasMaxLength(3)
                .IsFixedLength()
                .HasColumnName("codigo_sri");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
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

        modelBuilder.Entity<TipoMovimiento>(entity =>
        {
            entity.HasKey(e => e.IdTipoMov).HasName("PK_Tipo_Movimiento");

            entity.ToTable("tipo_movimiento", "sic");

            entity.Property(e => e.IdTipoMov)
                .HasMaxLength(10)
                .HasColumnName("id_tipo_mov");
            entity.Property(e => e.Activo).HasColumnName("activo");
            entity.Property(e => e.Calculo)
                .HasMaxLength(10)
                .HasColumnName("calculo");
            entity.Property(e => e.CodigoCuenta)
                .HasMaxLength(10)
                .HasColumnName("codigo_cuenta");
            entity.Property(e => e.TipoMov)
                .HasMaxLength(30)
                .HasColumnName("tipo_mov");
        });

        modelBuilder.Entity<TipoMovimientoEstadoCuenta>(entity =>
        {
            entity.HasKey(e => e.IdTipDoc).HasName("PK__tipo_mov__17348CE48E06748E");

            entity.ToTable("tipo_movimiento_estado_cuenta", "sic");

            entity.Property(e => e.IdTipDoc).HasColumnName("id_tip_doc");
            entity.Property(e => e.CodigoTipDoc)
                .HasMaxLength(3)
                .HasColumnName("codigo_tip_doc");
            entity.Property(e => e.DescripcionTipDoc)
                .HasMaxLength(20)
                .HasColumnName("descripcion_tip_doc");
        });

        modelBuilder.Entity<TipoNegocio>(entity =>
        {
            entity.HasKey(e => e.IdTipoNegocio).HasName("PK__tipo_neg__D3EEC928AA1A0C72");

            entity.ToTable("tipo_negocio", "seguridades");

            entity.Property(e => e.IdTipoNegocio).HasColumnName("id_tipo_negocio");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.IdEmpresa).HasColumnName("id_empresa");

            entity.HasOne(d => d.IdEmpresaNavigation).WithMany(p => p.TipoNegocio)
                .HasForeignKey(d => d.IdEmpresa)
                .HasConstraintName("FK_tipo_negocio_empresas");
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

        modelBuilder.Entity<UbicacionArea>(entity =>
        {
            entity.HasKey(e => e.IdArea);

            entity.ToTable("ubicacion_area", "sic");

            entity.Property(e => e.IdArea).HasColumnName("id_area");
            entity.Property(e => e.Codigo)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("codigo");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(80)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.Estado)
                .HasDefaultValue(true)
                .HasColumnName("estado");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fecha_creacion");
            entity.Property(e => e.FechaModificacion)
                .HasColumnType("datetime")
                .HasColumnName("fecha_modificacion");
        });

        modelBuilder.Entity<UbicacionColumna>(entity =>
        {
            entity.HasKey(e => e.IdColumna);

            entity.ToTable("ubicacion_columna", "sic", tb => tb.HasComment("Columna en el estante"));

            entity.HasIndex(e => e.Codigo, "IX_ubicacion_columna_codigo").IsUnique();

            entity.Property(e => e.IdColumna).HasColumnName("id_columna");
            entity.Property(e => e.Codigo)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("codigo");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(80)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.Estado)
                .HasDefaultValue(true)
                .HasColumnName("estado");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fecha_creacion");
            entity.Property(e => e.FechaModificacion)
                .HasColumnType("datetime")
                .HasColumnName("fecha_modificacion");
            entity.Property(e => e.Orden).HasColumnName("orden");
        });

        modelBuilder.Entity<UbicacionNivel>(entity =>
        {
            entity.HasKey(e => e.IdNivel);

            entity.ToTable("ubicacion_nivel", "sic", tb => tb.HasComment("Nivel o fila en el estante"));

            entity.HasIndex(e => e.Codigo, "IX_ubicacion_nivel_codigo").IsUnique();

            entity.Property(e => e.IdNivel).HasColumnName("id_nivel");
            entity.Property(e => e.Codigo)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("codigo");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(80)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.Estado)
                .HasDefaultValue(true)
                .HasColumnName("estado");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fecha_creacion");
            entity.Property(e => e.FechaModificacion)
                .HasColumnType("datetime")
                .HasColumnName("fecha_modificacion");
            entity.Property(e => e.Orden).HasColumnName("orden");
        });

        modelBuilder.Entity<UnidadVenta>(entity =>
        {
            entity.HasKey(e => e.IdUnidadVenta).HasName("PK__unidad_v__8FA0577BB198A625");

            entity.ToTable("unidad_venta", "sic");

            entity.Property(e => e.IdUnidadVenta).HasColumnName("id_unidad_venta");
            entity.Property(e => e.Cantidad)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("cantidad");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.Status)
                .HasDefaultValue(true)
                .HasColumnName("status");
        });

        modelBuilder.Entity<Unidadmedida>(entity =>
        {
            entity.HasKey(e => e.Codigo);

            entity.ToTable("unidadmedida", "sic");

            entity.Property(e => e.Codigo).HasColumnName("codigo");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.NetContentUom)
                .HasMaxLength(5)
                .HasColumnName("netContentUOM");
            entity.Property(e => e.Unidad)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("unidad");
        });

        modelBuilder.Entity<Usuarios>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__usuarios__4E3E04AD6281436A");

            entity.ToTable("usuarios", "seguridades");

            entity.HasIndex(e => e.NombreUsuario, "UQ__usuarios__D4D22D747DE859FB").IsUnique();

            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");
            entity.Property(e => e.ContraseniaHash)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("contrasenia_hash");
            entity.Property(e => e.Correo)
                .HasMaxLength(100)
                .HasColumnName("correo");
            entity.Property(e => e.EstaBloqueado).HasColumnName("esta_bloqueado");
            entity.Property(e => e.Estado)
                .HasDefaultValue(true)
                .HasColumnName("estado");
            entity.Property(e => e.FechaBloqueo)
                .HasColumnType("datetime")
                .HasColumnName("fecha_bloqueo");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fecha_creacion");
            entity.Property(e => e.IdDepartamento).HasColumnName("id_departamento");
            entity.Property(e => e.IdEmpresa).HasColumnName("id_empresa");
            entity.Property(e => e.IdPersona).HasColumnName("id_persona");
            entity.Property(e => e.IntentosFallidos).HasColumnName("intentos_fallidos");
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

            entity.HasOne(d => d.IdPersonaNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdPersona)
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
