using clientes_ms.Application.Commands.Ssccs;
using clientes_ms.Application.Queries.Sscc;
using clientes_ms.Application.Queries.Ssccs;
using clientes_ms.Application.Records.Request;
using clientes_ms.Application.Records.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace clientes_ms.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SsccController : ControllerBase
{
    private readonly IMediator _mediator;

    public SsccController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Obtener todos los SSCC.
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<SsccResponse>>>> GetAll()
    {
        var result = await _mediator.Send(new GetAllSsccQuery());
        return Ok(result);
    }
    /// <summary>
    /// Obtener un SSCC por su número completo (SSCC).
    /// </summary>
    [HttpGet("por-numero")]
    public async Task<ActionResult<ApiResponse<SsccResponse>>> GetByNumeroSscc([FromQuery] string numeroSscc)
    {
        var result = await _mediator.Send(new GetSsccByNumeroQuery(numeroSscc));

        return result.Type == "ERROR"
            ? NotFound(result)
            : Ok(result);
    }

    /// <summary>
    /// Obtener un SSCC por ID.
    /// </summary>
    [HttpGet("{id:long}")]
    public async Task<ActionResult<ApiResponse<SsccResponse>>> GetById(long id)
    {
        var result = await _mediator.Send(new GetSsccByIdQuery(id));


        return result.Type == "NOT_FOUND"
            ? NotFound(result)
            : Ok(result);
    }

    /// <summary>
    /// Obtener SSCC paginados por ID de prefijo.
    /// </summary>
    [HttpGet("por-prefijo")]
    public async Task<ActionResult<ApiResponse<PaginationResponse<SsccResponse>>>> GetByPrefijo(
        [FromQuery] long idPrefijo,
        [FromQuery] int? page,
        [FromQuery] int? pageSize)
    {
        var safePage = page is > 0 ? page.Value : 1;
        var safePageSize = pageSize is > 0 ? Math.Min(pageSize.Value, 1000) : 50;

        var query = new GetSsccByPrefijoQuery(idPrefijo, safePage, safePageSize);
        var result = await _mediator.Send(query);
        return Ok(result);
    }


    /// <summary>
    /// Obtener SSCC paginados por ID de cliente.
    /// </summary>
    [HttpGet("por-cliente")]
    public async Task<ActionResult<ApiResponse<PaginationResponse<SsccResponse>>>> GetByCliente(
    [FromQuery] long idCliente,
    [FromQuery] int? page,
    [FromQuery] int? pageSize)
    {
        var safePage = page is > 0 ? page.Value : 1;
        var safePageSize = pageSize is > 0 ? Math.Min(pageSize.Value, 1000) : 50;

        var query = new GetAllSsccByIdClienteQuery(idCliente, safePage, safePageSize);
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    /// <summary>
    /// Crear un nuevo SSCC.
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] SsccRequest request)
    {
        var result = await _mediator.Send(new CreateSsccCommand(request));
        return Ok(result);
    }

    // OPCIÓN 1: Recibir directamente el bool (más simple y directo)
    /// <summary>
    /// Actualizar el estado de un SSCC existente.
    /// </summary>
    [HttpPut("{id}/status")]
    public async Task<IActionResult> UpdateStatus(long id, [FromBody] bool estado)
    {
        var result = await _mediator.Send(new UpdateSsccStatusCommand(id, estado));
        return Ok(result);
    }

    /// <summary>
    /// Genera una lista de códigos SSCC sin persistirlos.
    /// </summary>
    [HttpPost("generar")]
    public async Task<ActionResult<ApiResponse<List<string>>>> Generar([FromBody] GenerateSsccRequest request)
    {
        var result = await _mediator.Send(new GenerateSsccCommand(request));

        return result.Type == "ERROR"
            ? BadRequest(result)
            : Ok(result);
    }

    /// <summary>
    /// Obtener reporte de SSCC filtrado (sin paginación).
    /// </summary>
    [HttpGet("reporte")]
    public async Task<ActionResult<ApiResponse<List<SsccResponse>>>> GetReporte(
        [FromQuery] long? idPrefijo,
        [FromQuery] bool? estado,
        [FromQuery] DateTime? fechaDesde,
        [FromQuery] DateTime? fechaHasta,
        [FromQuery] string? operadorFecha // "=", "<", ">", "<=", ">=", "entre"
    )
    {
        var query = new GetSsccReportQuery(idPrefijo, estado, fechaDesde, fechaHasta, operadorFecha);
        var result = await _mediator.Send(query);
        return Ok(result);
    }
    /// <summary>
    /// Obtener SSCC filtrados y paginados para separarlo de la logica de filtrado del frontend
    /// </summary>
    [HttpGet("cliente/{idCliente}/filtros")]
    public async Task<ActionResult<ApiResponse<PaginationResponse<SsccResponse>>>> GetByClienteConFiltros(
    int idCliente,
    [FromQuery] int page = 1,
    [FromQuery] int pageSize = 50,
    [FromQuery] int? idPrefijo = null,
    [FromQuery] string? busqueda = null,
    [FromQuery] string? empaque = null,
    [FromQuery] string? serialDesde = null,
    [FromQuery] string? serialHasta = null,
    [FromQuery] bool? estado = null,
    [FromQuery] DateTime? fechaDesde = null,
    [FromQuery] DateTime? fechaHasta = null)
    {
        var query = new GetSsccByClienteConFiltrosQuery(
            IdCliente: idCliente,
            Page: page,
            PageSize: pageSize,
            IdPrefijo: idPrefijo,
            Busqueda: busqueda,
            Empaque: empaque,
            SerialDesde: serialDesde,
            SerialHasta: serialHasta,
            Estado: estado,
            FechaDesde: fechaDesde,
            FechaHasta: fechaHasta
        );

        var result = await _mediator.Send(query);

        if (result.Type == "ERROR")
            return BadRequest(result);

        return Ok(result);
    }

    /// <summary>
    /// Eliminar múltiples SSCC con auditoría (requiere observación).
    /// </summary>
    [HttpDelete("eliminar")]
    public async Task<ActionResult<ApiResponse<bool>>> DeleteConAuditoria([FromBody] DeleteSsccRequest request)
    {
        var command = new DeleteSsccCommand(request.Ids, request.Observacion, request.Usuario);
        var result = await _mediator.Send(command);

        return result.Type == "ERROR"
            ? BadRequest(result)
            : Ok(result);
    }
    [HttpGet("id-prefijo")]
    public async Task<ActionResult<ApiResponse<List<SsccResponse>>>> GetByPrefijo([FromQuery] long idPrefijo)
    {
        var query = new GetSsccByIdPrefijoNQuery(idPrefijo);
        var result = await _mediator.Send(query);

        return result.Type == "ERROR"
            ? BadRequest(result)
            : Ok(result);
    }
    [HttpPut("actualizar-idprefijo")]
    public async Task<IActionResult> ActualizarClientePorPrefijo([FromBody] UpdateSsccClientePorPrefijoCommand command)
    {
        var result = await _mediator.Send(command);
        return result.Type == "ERROR" ? BadRequest(result) : Ok(result);
    }

}
