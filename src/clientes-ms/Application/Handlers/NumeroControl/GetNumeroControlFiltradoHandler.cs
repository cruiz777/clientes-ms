using clientes_ms.Application.Records.Response;
using clientes_ms.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MicroservicesTemplate.Domain.Repositories;

public class GetNumeroControlPrefijosYGtinHandler : IRequestHandler<GetNumeroControlPrefijosYGtinQuery, ApiResponse<IEnumerable<NumeroControlResponse>>>
{
    private readonly IBaseRepository<NumeroControl> _repository;

    public GetNumeroControlPrefijosYGtinHandler(IBaseRepository<NumeroControl> repository)
    {
        _repository = repository;
    }

    public async Task<ApiResponse<IEnumerable<NumeroControlResponse>>> Handle(GetNumeroControlPrefijosYGtinQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var modulos = new List<string>
            {
                "PREFIJOS 5",
                "PREFIJOS 6",
                "PREFIJOS 8",
                "GTIN 8",
                "MSV 8"
            };

            var data = await _repository
                .AsQueryable()
                .Where(nc => nc.Modcon != null && modulos.Contains(nc.Modcon.Trim()))
                .ToListAsync(cancellationToken);

            var result = data.Select(e => new NumeroControlResponse(
                e.IdNumeroControl,
                e.Codcon ?? 0,
                e.Modcon?.Trim() ?? string.Empty,
                e.Tipcon?.Trim() ?? string.Empty,
                e.Numcon?.Trim() ?? string.Empty,
                e.Ocupado ?? false,
                e.EmpresaCodigo ?? 0
            ));

            return new ApiResponse<IEnumerable<NumeroControlResponse>>(Guid.NewGuid(), "LIST", result, "Registros filtrados correctamente");
        }
        catch (Exception ex)
        {
            return new ApiResponse<IEnumerable<NumeroControlResponse>>(Guid.NewGuid(), "ERROR", null, ex.Message);
        }
    }
}
