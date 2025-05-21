using clientes_ms.Application.Records.Response;
using clientes_ms.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MicroservicesTemplate.Domain.Repositories;

public class UpdateClienteDatosAdicionalesHandler : IRequestHandler<UpdateClienteDatosAdicionalesCommand, ApiResponse<bool>>
{
    private readonly IBaseRepository<ClienteDatosAdicionales> _repository;

    public UpdateClienteDatosAdicionalesHandler(IBaseRepository<ClienteDatosAdicionales> repository)
    {
        _repository = repository;
    }

    public async Task<ApiResponse<bool>> Handle(UpdateClienteDatosAdicionalesCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var existing = await _repository
                .AsQueryable()
                .FirstOrDefaultAsync(x => x.ClientesCodigo == request.ClientesCodigo, cancellationToken);

            if (existing == null)
            {
                return new ApiResponse<bool>(
                    Guid.NewGuid(),
                    "OBJECT",
                    false,
                    $"No se encontró ClienteDatosAdicionales con ClientesCodigo = {request.ClientesCodigo}."
                );
            }

            // Actualiza propiedades
            existing.Expprod = request.Request.Expprod;
            existing.Vendeus = request.Request.Vendeus;
            existing.Medico = request.Request.Medico;
            existing.Gs1ec = request.Request.Gs1ec;
            existing.Instagram = request.Request.Instagram;
            existing.Facebook = request.Request.Facebook;
            existing.Web = request.Request.Web;
            existing.Prefijo = request.Request.Prefijo;
            existing.Guia = request.Request.Guia;
            existing.Estado = request.Request.Estado;

            await _repository.UpdateAsync(existing.IdDatosAdicionales, existing);

            return new ApiResponse<bool>(
                Guid.NewGuid(),
                "BOOLEAN",
                true,
                "Actualizado correctamente"
            );
        }
        catch (Exception ex)
        {
            return new ApiResponse<bool>(
                Guid.NewGuid(),
                "ERROR",
                false,
                ex.Message
            );
        }
    }
}
