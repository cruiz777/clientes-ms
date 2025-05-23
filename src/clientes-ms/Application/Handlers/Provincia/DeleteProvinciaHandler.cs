﻿using clientes_ms.Application.Records.Response;
using clientes_ms.Domain.Entities;
using MediatR;
using MicroservicesTemplate.Domain.Repositories;

public class DeleteProvinciaHandler : IRequestHandler<DeleteProvinciaCommand, ApiResponse<bool>>
{
    private readonly IBaseRepository<Provincia> _repository;
    public DeleteProvinciaHandler(IBaseRepository<Provincia> repository) => _repository = repository;

    public async Task<ApiResponse<bool>> Handle(DeleteProvinciaCommand request, CancellationToken cancellationToken)
    {
        try
        {
            await _repository.DeleteAsync(request.IdProvincia);
            return new ApiResponse<bool>(Guid.NewGuid(), "BOOLEAN", true, "Deleted successfully");
        }
        catch (Exception ex)
        {
            return new ApiResponse<bool>(Guid.NewGuid(), "ERROR", false, ex.Message);
        }
    }
}