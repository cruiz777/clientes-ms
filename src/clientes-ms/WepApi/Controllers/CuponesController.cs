using clientes_ms.Application.Commands.Cupon;
using clientes_ms.Application.Queries.Cupon;
using clientes_ms.Application.Queries.Cupones;
using clientes_ms.Application.Records.Request;
using clientes_ms.Application.Records.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace clientes_ms.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CuponesController : ControllerBase
{
    private readonly IMediator _mediator;

    public CuponesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Obtener cupones paginados por ID de cliente.
    /// </summary>
    [HttpGet("por-cliente")]
    public async Task<ActionResult<ApiResponse<PaginationResponse<CuponResponse>>>> GetByCliente(
        [FromQuery] long idCliente,
        [FromQuery] int? page,
        [FromQuery] int? pageSize)
    {
        var safePage = page is > 0 ? page.Value : 1;
        var safePageSize = pageSize is > 0 ? Math.Min(pageSize.Value, 1000) : 50;

        var query = new GetAllCuponesByIdClienteQuery(idCliente, safePage, safePageSize);
        var result = await _mediator.Send(query);

        return Ok(result);
    }

    /// <summary>
    /// Buscar cupones con filtros avanzados (por cliente, prefijo, estado, fechas, etc.).
    /// </summary>
    [HttpGet("buscar")]
    public async Task<ActionResult<ApiResponse<PaginationResponse<CuponResponse>>>> BuscarCuponesConFiltros(
        [FromQuery] long idCliente,
        [FromQuery] int? page,
        [FromQuery] int? pageSize,
        [FromQuery] long? idPrefijo,
        [FromQuery] string? busqueda,
        [FromQuery] int? serialDesde,
        [FromQuery] int? serialHasta,
        [FromQuery] bool? estado,
        [FromQuery] DateOnly? fechaInicioDesde,
        [FromQuery] DateOnly? fechaInicioHasta,
        [FromQuery] DateOnly? fechaCaducidadDesde,
        [FromQuery] DateOnly? fechaCaducidadHasta
    )
    {
        var safePage = page is > 0 ? page.Value : 1;
        var safePageSize = pageSize is > 0 ? Math.Min(pageSize.Value, 1000) : 50;

        var query = new GetCuponesByClienteConFiltrosQuery(
            IdCliente: idCliente,
            Page: safePage,
            PageSize: safePageSize,
            IdPrefijo: idPrefijo,
            Busqueda: busqueda,
            SerialDesde: serialDesde,
            SerialHasta: serialHasta,
            Estado: estado,
            FechaInicioDesde: fechaInicioDesde,
            FechaInicioHasta: fechaInicioHasta,
            FechaCaducidadDesde: fechaCaducidadDesde,
            FechaCaducidadHasta: fechaCaducidadHasta
        );

        var result = await _mediator.Send(query);
        return Ok(result);
    }


    /// <summary>
    /// Obtener cupones vigentes paginados por ID de cliente.
    /// </summary>
    [HttpGet("por-cliente/vigentes")]
    public async Task<ActionResult<ApiResponse<PaginationResponse<CuponResponse>>>> GetVigentesByCliente(
        [FromQuery] long idCliente,
        [FromQuery] int? page,
        [FromQuery] int? pageSize)
    {
        var safePage = page is > 0 ? page.Value : 1;
        var safePageSize = pageSize is > 0 ? Math.Min(pageSize.Value, 1000) : 50;

        var query = new GetAllCuponesVigentesByIdClienteQuery(idCliente, safePage, safePageSize);
        var result = await _mediator.Send(query);

        return Ok(result);
    }

    /// <summary>
    /// Crear un nuevo cupón.
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CuponRequest request)
    {
        var result = await _mediator.Send(new CreateCuponCommand(request));
        return Ok(result);
    }

    /// <summary>
    /// Eliminar cupones con auditoría (requiere observación).
    /// </summary>
    [HttpDelete("eliminar")]
    public async Task<ActionResult<ApiResponse<bool>>> DeleteConAuditoria([FromBody] DeleteCuponRequest request)
    {
        var command = new DeleteCuponCommand(request.Ids, request.Observacion, request.Usuario);
        var result = await _mediator.Send(command);

        return result.Type == "ERROR"
            ? BadRequest(result)
            : Ok(result);
    }
    /// <summary>
    /// Generar reporte de cupones con filtros avanzados.
    /// </summary>
    [HttpGet("reporte")]
    public async Task<ActionResult<ApiResponse<List<CuponResponse>>>> GetReporteCupones(
        [FromQuery] long? idPrefijo,
        [FromQuery] bool? estado,
        [FromQuery] DateTime? fechaDesde,
        [FromQuery] DateTime? fechaHasta,
        [FromQuery] string? operadorFecha
    )
    {
        var query = new GetCuponReportQuery(
            IdPrefijo: idPrefijo,
            Estado: estado,
            FechaDesde: fechaDesde,
            FechaHasta: fechaHasta,
            OperadorFecha: operadorFecha
        );

        var result = await _mediator.Send(query);
        return Ok(result);
    }
}
