using MediatR;
using Microsoft.AspNetCore.Mvc;
using clientes_ms.Application.Records.Request;
using clientes_ms.Application.Records.Response;

namespace clientes_ms.WebApi.Controllers
{
    // Indica que esta clase es un controlador de API
    [ApiController]

    // Define la ruta base para este controlador
    [Route("api/[Controller]")]
    public class AuditoriaTransferenciaController : ControllerBase
    {
        private readonly IMediator _mediator;

        // Constructor con inyecci�n de dependencia del Mediator
        public AuditoriaTransferenciaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET api/examples
        // Obtiene todos los registros de Example
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllAuditoriaTransferenciaQuery()); // Env�a la query a su handler correspondiente
            return Ok(result); // Devuelve la respuesta con estado 200
        }
        [HttpGet]
        [Route("/api/listadoAuditoriaTransferencia")]
        public async Task<IActionResult> GetAuditoriaTransferenciaResumen()
        {
            var result = await _mediator.Send(new GetAuditoriaTransferenciaByResumen()); // Env�a la query a su handler correspondiente
            return Ok(result); // Devuelve la respuesta con estado 200
        }

        // GET api/examples/{id}
        // Obtiene un registro espec�fico por su ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var result = await _mediator.Send(new GetAuditoriaTransferenciaByIdQuery(id));
            return Ok(result);
        }

        // GET api/examples/status/{status}
        // Obtiene todos los registros activos o inactivos seg�n el par�metro
        //[HttpGet("status/{status}")]
        //public async Task<IActionResult> GetByStatus(bool status)
        //{
        //    var result = await _mediator.Send(new GetExamplesByStatusQuery(status));
        //    return Ok(result);
        //}

        // POST api/examples
        // Crea un nuevo registro de Example
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AuditoriaTransferenciaRequest request)
        {
            var result = await _mediator.Send(new CreateAuditoriaTransferenciaCommand(request));
            return Ok(result);
        }

        // PUT api/examples/{id}
        // Actualiza un registro existente de Example
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, [FromBody] AuditoriaTransferenciaRequest request)
        {
            var result = await _mediator.Send(new UpdateAuditoriaTransferenciaCommand(id, request));
            return Ok(result);
        }

        // DELETE api/examples/{id}
        // Elimina f�sicamente un registro
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var result = await _mediator.Send(new DeleteAuditoriaTransferenciaCommand(id));
            return Ok(result);
        }

        // PUT api/examples/{id}/soft-delete
        // Elimina l�gicamente un registro (cambia su status a false)
        //[HttpPatch("{id}/soft-delete")]
        //public async Task<IActionResult> SoftDelete(long id)
        //{
        //    var result = await _mediator.Send(new SoftDeleteExampleCommand(id));
        //    return Ok(result);
        //}
    }
}
