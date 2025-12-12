using MediatR;
using clientes_ms.Application.Records.Response;
using System.Collections.Generic;

public record GetNumeroControlPrefijosYGtinQuery() : IRequest<ApiResponse<IEnumerable<NumeroControlResponse>>>;
