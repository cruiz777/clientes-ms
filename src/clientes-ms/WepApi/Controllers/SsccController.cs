using clientes_ms.Application.Commands.Ssccs;
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

    /// <summary>
    /// Actualizar un SSCC existente.
    /// </summary>
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(long id, [FromBody] SsccRequest request)
    {
        var result = await _mediator.Send(new UpdateSsccCommand(id, request));
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
}
