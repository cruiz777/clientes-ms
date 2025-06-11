using AutoMapper;
using clientes_ms.Application.Records.Request;
using clientes_ms.Application.Records.Response;
using clientes_ms.Domain.Entities;

namespace clientes_ms.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Entidad -> Response
            CreateMap<TipoCodigoGs1, TipoCodigoGs1Response>();

            // Request -> Entidad
            CreateMap<TipoCodigoGs1Request, TipoCodigoGs1>()
                .ForMember(dest => dest.Descripcion, opt => opt.MapFrom(src => src.Descripcion.Trim()));

            // PersonaRequest → Personas
            CreateMap<PersonaRequest, Personas>()
                .ForMember(dest => dest.Documento, opt => opt.MapFrom(src => src.NumeroDocumento.Trim()))
                .ForMember(dest => dest.Nombre1, opt => opt.MapFrom(src => string.IsNullOrEmpty(src.Nombre1) ? string.Empty : src.Nombre1.Trim()))
                .ForMember(dest => dest.Nombre2, opt => opt.MapFrom(src => src.Nombre2 != null ? src.Nombre2.Trim() : null))
                .ForMember(dest => dest.Apellido1, opt => opt.MapFrom(src => string.IsNullOrEmpty(src.Apellido1) ? string.Empty : src.Apellido1.Trim()))
                .ForMember(dest => dest.Apellido2, opt => opt.MapFrom(src => src.Apellido2 != null ? src.Apellido2.Trim() : null))
                .ForMember(dest => dest.FechaNacimiento, opt => opt.MapFrom(src => src.FechaNacimiento.HasValue ? src.FechaNacimiento.Value : default))
                .ForMember(dest => dest.IdEstadoCivil, opt => opt.MapFrom(src => src.IdEstadoCivil))
                .ForMember(dest => dest.IdTipoDocumento, opt => opt.MapFrom(src => src.IdTipoDocumento))
                .ForMember(dest => dest.IdGenero, opt => opt.MapFrom(src => src.IdGenero))
                .ForMember(dest => dest.TipoPersona, opt => opt.MapFrom(src => src.TipoPersona != null ? src.TipoPersona.Trim() : null))
                .ForMember(dest => dest.IdCiudad, opt => opt.MapFrom(src => src.IdCiudad))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
                .ForMember(dest => dest.FechaRegistro, opt => opt.Ignore())
                .ForMember(dest => dest.Correos, opt => opt.Ignore())
                .ForMember(dest => dest.Telefonos, opt => opt.Ignore())
                .ForMember(dest => dest.Direcciones, opt => opt.Ignore())
                .ForMember(dest => dest.Contadores, opt => opt.Ignore())
                .ForMember(dest => dest.Gerentes, opt => opt.Ignore())
                .ForMember(dest => dest.Usuarios, opt => opt.Ignore())
                .ForMember(dest => dest.IdCiudadNavigation, opt => opt.Ignore())
                .ForMember(dest => dest.IdEstadoCivilNavigation, opt => opt.Ignore())
                .ForMember(dest => dest.IdGeneroNavigation, opt => opt.Ignore())
                .ForMember(dest => dest.IdTipoDocumentoNavigation, opt => opt.Ignore());

            CreateMap<CorreoRequest, Correos>()
                .ForMember(dest => dest.Tipo, opt => opt.MapFrom(src => string.IsNullOrEmpty(src.Tipo) ? "Trabajo" : src.Tipo.Trim()))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email.Trim()));

            CreateMap<TelefonoRequest, Telefonos>()
                .ForMember(dest => dest.Tipo, opt => opt.MapFrom(src => string.IsNullOrEmpty(src.Tipo) ? "Móvil" : src.Tipo.Trim()))
                .ForMember(dest => dest.Numero, opt => opt.MapFrom(src => src.Numero.Trim()));

            CreateMap<DireccionRequest, Direcciones>()
                .ForMember(dest => dest.Tipo, opt => opt.MapFrom(src => string.IsNullOrEmpty(src.Tipo) ? "Casa" : src.Tipo.Trim()))
                .ForMember(dest => dest.Calle, opt => opt.MapFrom(src => src.Calle.Trim()))
                .ForMember(dest => dest.Ciudad, opt => opt.MapFrom(src => src.Ciudad != null ? src.Ciudad.Trim() : null))
                .ForMember(dest => dest.Estado, opt => opt.MapFrom(src => src.Estado != null ? src.Estado.Trim() : null))
                .ForMember(dest => dest.CodigoPostal, opt => opt.MapFrom(src => src.CodigoPostal != null ? src.CodigoPostal.Trim() : null))
                .ForMember(dest => dest.Pais, opt => opt.MapFrom(src => src.Pais != null ? src.Pais.Trim() : null));
            
            CreateMap<Gln, GlnResponse>()
                .ForMember(dest => dest.NombreLocalizacion, opt => opt.MapFrom(src => src.IdTipoLocalizacionNavigation.Descripcion));
            CreateMap<GlnRequest, Gln>();

            CreateMap<Prefijos, PrefijosResponse>()
                .ForMember(dest => dest.Nomcli, opt => opt.MapFrom(src => src.ClientesCodigoNavigation.Nomcli))
                .ForMember(dest => dest.EstadoEmpresa, opt => opt.MapFrom(src => src.ClientesCodigoNavigation.IdEstadoEmpresaNavigation.Nombre))
                .ForMember(dest => dest.Ruccli, opt => opt.MapFrom(src => src.ClientesCodigoNavigation.Ruc))
                .ForMember(dest => dest.Fecing, opt => opt.MapFrom(src => src.ClientesCodigoNavigation.Fecing))
                .ForMember(dest => dest.Zona, opt => opt.MapFrom(src => src.ClientesCodigoNavigation.IdZonaNavigation.Referencia))
                .ForMember(dest => dest.TipoCliente, opt => opt.MapFrom(src => src.ClientesCodigoNavigation.IdTipoClienteNavigation.Descripcion))
                .ForMember(dest => dest.GrupoProducto, opt => opt.MapFrom(src => src.ClientesCodigoNavigation.IdGrupoProductoNavigation.Descripcion))
                .ForMember(dest => dest.GrupoEmpresa, opt => opt.MapFrom(src => src.ClientesCodigoNavigation.IdGrupoEmpresaNavigation.Nombre))
                .ForMember(dest => dest.Representante, opt => opt.MapFrom(src => src.ClientesCodigoNavigation.Representante))
                .ForMember(dest => dest.Direccion, opt => opt.MapFrom(src => src.ClientesCodigoNavigation.Dircli))
                .ForMember(dest => dest.Telefono, opt => opt.MapFrom(src => src.ClientesCodigoNavigation.Telefono1))
                .ForMember(dest => dest.Web, opt => opt.MapFrom(src => src.ClientesCodigoNavigation.Web))
                .ForMember(dest => dest.Postal, opt => opt.MapFrom(src => src.ClientesCodigoNavigation.CodigoPostal))
                .ForMember(dest => dest.Ciudad, opt => opt.MapFrom(src => src.ClientesCodigoNavigation.IdCiudadNavigation.Nombre))
                .ForMember(dest => dest.Canton, opt => opt.MapFrom(src => src.ClientesCodigoNavigation.IdCiudadNavigation.IdCantonNavigation.Nombre))
                .ForMember(dest => dest.Provincia, opt => opt.MapFrom(src => src.ClientesCodigoNavigation.IdCiudadNavigation.IdCantonNavigation.IdProvinciaNavigation.Nombre))
                .ForMember(dest => dest.Glns, opt => opt.MapFrom(src => src.Gln));

        }
    }
}
