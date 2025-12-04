using clientes_ms.Application.Queries.NumeroControl;
using clientes_ms.Application.Records.Response;
using clientes_ms.Infrastructure.Persistence.Context;
using clientes_ms.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace clientes_ms.Application.Handlers.NumeroControl;

public class ObtenerYReservarNumeroControlHandler
    : IRequestHandler<ObtenerYReservarNumeroControlQuery, ApiResponse<NumeroReservadoResponse>>
{
    private readonly ApplicationDbContext _context;

    public ObtenerYReservarNumeroControlHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<ApiResponse<NumeroReservadoResponse>> Handle(
        ObtenerYReservarNumeroControlQuery request,
        CancellationToken cancellationToken)
    {
        using var transaction = await _context.Database.BeginTransactionAsync(cancellationToken);

        try
        {
            // 1. LEER Y BLOQUEAR
            var numControl = await _context.Set<Domain.Entities.NumeroControl>()
                .FromSqlRaw(@"
                    SELECT * FROM [sic].[numero_control] WITH (UPDLOCK, ROWLOCK) 
                    WHERE [id_numero_control] = {0}", request.IdControl)
                .FirstOrDefaultAsync(cancellationToken);

            if (numControl == null)
            {
                return ApiResponse<NumeroReservadoResponse>.Error(
                    $"NumeroControl con ID {request.IdControl} no encontrado");
            }

            // 2. ASIGNAR el número actual
            string numeroAsignado = numControl.Numcon!;

            // 3. CALCULAR el siguiente
            int numActual = int.Parse(numControl.Numcon!);
            string siguienteNumero = (numActual + 1).ToString().PadLeft(numControl.Numcon!.Length, '0');

            // 4. ACTUALIZAR inmediatamente
            numControl.Numcon = siguienteNumero;
            numControl.Ocupado = false;

            _context.Set<Domain.Entities.NumeroControl>().Update(numControl);
            await _context.SaveChangesAsync(cancellationToken);

            // 5. COMMIT
            await transaction.CommitAsync(cancellationToken);

            // 6. RETORNAR el número asignado
            var response = new NumeroReservadoResponse(numeroAsignado, siguienteNumero);

            return new ApiResponse<NumeroReservadoResponse>(
                Guid.NewGuid(),
                "OBJECT",
                response,
                "Número reservado correctamente");
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync(cancellationToken);
            return ApiResponse<NumeroReservadoResponse>.Error($"Error: {ex.Message}");
        }
    }
}