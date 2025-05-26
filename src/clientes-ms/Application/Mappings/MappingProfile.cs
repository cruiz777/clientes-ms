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
        }
    }
}
