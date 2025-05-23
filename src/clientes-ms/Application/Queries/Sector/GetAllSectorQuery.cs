﻿using clientes_ms.Application.Records.Response;
using MediatR;

public record GetAllSectorQuery : IRequest<ApiResponse<IEnumerable<SectorResponse>>>;