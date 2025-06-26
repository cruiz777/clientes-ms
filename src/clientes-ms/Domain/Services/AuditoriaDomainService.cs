using clientes_ms.Domain.Interfaces.IDomainServices;
using clientes_ms.Infrastructure.Persistence.Context;
using Dapper;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace clientes_ms.Domain.Services;

public class AuditoriaDomainService : IAuditoriaDomainService
{
    private readonly ApplicationDbContext _dbContext;

    public AuditoriaDomainService(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }


    public async Task AuditarSsccCreateOrUpdateAsync(string accion, long idSscc, string usuario, string? observacion = null)
    {
        var connection = _dbContext.Database.GetDbConnection();
        if (connection.State == ConnectionState.Closed)
            await connection.OpenAsync();
        //DAPPER para un mejor manejamientro de los SP de la base
        var parameters = new DynamicParameters();
        parameters.Add("@accion", accion);
        parameters.Add("@id_sscc", idSscc);
        parameters.Add("@usuario", usuario);
        parameters.Add("@observacion", observacion);

        await connection.ExecuteAsync(
            "[sic].[sp_AuditarSsccCreateOrUpdate]",
            parameters,
            commandType: CommandType.StoredProcedure);
    }
}
