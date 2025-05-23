﻿using MediatR;
using clientes_ms.Application.Records.Request;
using clientes_ms.Application.Records.Response;

public record CreateClienteObservacionCommand(ClienteObservacionRequest Request) : IRequest<ApiResponse<bool>>;