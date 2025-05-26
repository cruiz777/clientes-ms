using clientes_ms.Application.Commands.TipoCodigoGs1;
using clientes_ms.Application.Queries.TipoCodigoGs1;
using clientes_ms.Application.Records.Request;
using clientes_ms.Application.Records.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace clientes_ms.WepApi.Controllers;

/// <summary>
/// Controlador para la gestión de Tipos de Código GS1.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class TipoCodigoGs1Controller : ControllerBase
{
    private readonly IMediator _mediator;

    /// <summary>
    /// Constructor del controlador TipoCodigoGs1.
    /// </summary>
    /// <param name="mediator">Instancia de IMediator</param>
    public TipoCodigoGs1Controller(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Obtiene todos los tipos de código GS1 registrados.
    /// </summary>
    /// <returns>Lista de tipos de código GS1</returns>
    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<TipoCodigoGs1Response>>>> GetAll()
    {
        var result = await _mediator.Send(new GetAllTipoCodigoGs1Query());
        return Ok(result);
    }

    /// <summary>
    /// Obtiene un tipo de código GS1 por su ID.
    /// </summary>
    /// <param name="id">ID del tipo de código GS1</param>
    /// <returns>Tipo de código GS1 encontrado o mensaje de error</returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<TipoCodigoGs1Response>>> GetById(long id)
    {
        var result = await _mediator.Send(new GetTipoCodigoGs1ByIdQuery(id));
        return Ok(result);
    }

    /// <summary>
    /// Crea un nuevo tipo de código GS1.
    /// </summary>
    /// <param name="request">Datos del tipo de código GS1 a crear</param>
    /// <returns>Resultado de la operación</returns>
    [HttpPost]
    public async Task<ActionResult<ApiResponse<bool>>> Create([FromBody] TipoCodigoGs1Request request)
    {
        var result = await _mediator.Send(new CreateTipoCodigoGs1Command(request));
        return Ok(result);
    }

    /// <summary>
    /// Actualiza un tipo de código GS1 existente.
    /// </summary>
    /// <param name="id">ID del tipo de código GS1 a actualizar</param>
    /// <param name="request">Datos actualizados</param>
    /// <returns>Resultado de la operación</returns>
    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] TipoCodigoGs1Request request)
    {
        var result = await _mediator.Send(new UpdateTipoCodigoGs1Command(id, request));
        return Ok(result);
    }
}
