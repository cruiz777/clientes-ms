using clientes_ms.Application.Records.Response;
using MediatR;

public record GetPefijosByCodpreQuery(string Codpre) : IRequest<ApiResponse<IEnumerable<PrefijosResponse>>>;
