using clientes_ms.Application.Queries.Gln;
using clientes_ms.Domain.Entities;
using MicroservicesTemplate.Domain.Repositories;
using MediatR;

namespace clientes_ms.Application.Handlers.Glns
{
    public class GetUltimaSecuenciaGlnHandler : IRequestHandler<GetUltimaSecuenciaGlnQuery, int>
    {
        private readonly IBaseRepository<Gln> _glnRepository;

        public GetUltimaSecuenciaGlnHandler(IBaseRepository<Gln> glnRepository)
        {
            _glnRepository = glnRepository;
        }

        public async Task<int> Handle(GetUltimaSecuenciaGlnQuery request, CancellationToken cancellationToken)
        {
            var prefijoCompleto = request.CodigoPais + request.Prefijo;

            var glns = await _glnRepository.GetListByConditionAsync(
                g => g.Gln1 != null && g.Gln1.StartsWith(prefijoCompleto)
            );

            var ultimo = glns.OrderByDescending(g => g.Gln1).FirstOrDefault();

            if (ultimo == null || string.IsNullOrWhiteSpace(ultimo.Gln1))
                return 0;

            // Extraer los 4 dígitos de secuencia que van justo después del prefijo
            var cuerpo = ultimo.Gln1;
            if (cuerpo.Length < prefijoCompleto.Length + 4)
                return 0;

            var secuenciaStr = cuerpo.Substring(prefijoCompleto.Length, 4);
            return int.TryParse(secuenciaStr, out int secuencia) ? secuencia : 0;
        }
    }
}
