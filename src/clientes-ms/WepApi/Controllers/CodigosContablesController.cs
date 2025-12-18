using MediatR;
using Microsoft.AspNetCore.Mvc;
using clientes_ms.Application.Records.Response;

// Asegúrate de tener este using en el namespace correcto según tu solución
// using clientes_ms.Application.Features.CodigosContables.Queries; 
// donde esté definido GetCodContableByPersonaQuery

namespace clientes_ms.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CodigosContablesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CodigosContablesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // ================================
        //  GET: api/CodigosContables/persona/{idPersona}
        //  Devuelve el IdCodContable asociado a una persona
        // ================================
        [HttpGet("persona/{idPersona:long}")]
        public async Task<IActionResult> GetByPersona(long idPersona)
        {
            var result = await _mediator.Send(new GetCodContableByPersonaQuery(idPersona));
            return Ok(result);
        }

        // Si luego quieres más endpoints (GetAll, GetById, Create, etc.)
        // los puedes agregar igual que en ZonaController.

        //// GET api/CodigosContables
        //// Ejemplo de futuro método GetAll (si tienes un query definido)
        //[HttpGet]
        //public async Task<IActionResult> GetAll()
        //{
        //    var result = await _mediator.Send(new GetAllCodigosContablesQuery());
        //    return Ok(result);
        //}

        //// GET api/CodigosContables/{id}
        //// Ejemplo de futuro GetById
        //[HttpGet("{id:long}")]
        //public async Task<IActionResult> GetById(long id)
        //{
        //    var result = await _mediator.Send(new GetCodContableByIdQuery(id));
        //    return Ok(result);
        //}
    }
}
