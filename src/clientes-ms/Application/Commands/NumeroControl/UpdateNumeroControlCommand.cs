﻿using clientes_ms.Application.DTOs.NumeroControl;
using clientes_ms.Application.Records.Response;
using MediatR;

namespace clientes_ms.Application.Commands.NumeroControl
{
    public class UpdateNumeroControlCommand : IRequest<ApiResponse<bool>>
    {
        public long Id { get; set; }
        public UpdateNumeroControlDto Request { get; set; } = null!;
    }
}
