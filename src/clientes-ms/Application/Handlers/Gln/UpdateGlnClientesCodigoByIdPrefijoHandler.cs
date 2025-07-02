using clientes_ms.Domain.Entities;
using clientes_ms.Application.Records.Response;
using MediatR;
using MicroservicesTemplate.Domain.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

public class UpdateGlnClientesCodigoByIdPrefijoHandler : IRequestHandler<UpdateGlnClientesCodigoByIdPrefijoCommand, ApiResponse<bool>>
{
    private readonly IBaseRepository<Gln> _repository;

    public UpdateGlnClientesCodigoByIdPrefijoHandler(IBaseRepository<Gln> repository)
    {
        _repository = repository;
    }

    public async Task<ApiResponse<bool>> Handle(UpdateGlnClientesCodigoByIdPrefijoCommand request, CancellationToken cancellationToken)
    {
        try
        {
            // Obtener todos los registros GLN
            var allGln = await _repository.GetAllAsync();
            var glnList = allGln.Where(g => g.IdPrefijos == request.IdPrefijos).ToList();

            if (!glnList.Any())
            {
                return new ApiResponse<bool>(
                    Guid.NewGuid(),
                    "NOT_FOUND",
                    false,
                    $"No se encontraron registros GLN con IdPrefijos = {request.IdPrefijos}."
                );
            }

            // Actualizar todos los registros GLN con ese IdPrefijo
            foreach (var gln in glnList)
            {
                gln.ClientesCodigo = request.ClientesCodigo;
                await _repository.UpdateAsync(gln.IdGln, gln);
            }

            return new ApiResponse<bool>(
                Guid.NewGuid(),
                "SUCCESS",
                true,
                $"ClientesCodigo actualizado a {request.ClientesCodigo} para {glnList.Count} GLN(s) con IdPrefijos = {request.IdPrefijos}."
            );
        }
        catch (Exception ex)
        {
            return new ApiResponse<bool>(
                Guid.NewGuid(),
                "ERROR",
                false,
                $"Error al actualizar ClientesCodigo: {ex.Message}"
            );
        }
    }
}
