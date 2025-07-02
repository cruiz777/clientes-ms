using MediatR;
using Microsoft.AspNetCore.Mvc;
using clientes_ms.Application.Records.Request;
using clientes_ms.Application.Records.Response;
using clientes_ms.Application.Queries.Prefijos;

namespace clientes_ms.WebApi.Controllers
{
    // Indica que esta clase es un controlador de API
    [ApiController]

    // Define la ruta base para este controlador
    [Route("api/[Controller]")]
    public class PrefijosController : ControllerBase
    {
        private readonly IMediator _mediator;

        // Constructor con inyecci�n de dependencia del Mediator
        public PrefijosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET api/examples
        // Obtiene todos los registros de Example
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllPrefijosQuery()); // Env�a la query a su handler correspondiente
            return Ok(result); // Devuelve la respuesta con estado 200
        }

        // GET api/examples/{id}
        // Obtiene un registro espec�fico por su ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var result = await _mediator.Send(new GetPrefijosByIdQuery(id));
            return Ok(result);
        }

        [HttpGet]
        [Route("/api/Codpre")]
        public async Task<IActionResult> GetByCodpre(string Codpre)
        {
            var result = await _mediator.Send(new GetPefijosByCodpreQuery(Codpre));
            return Ok(result);
        }

        [HttpGet]
        [Route("/api/CodpreCliente")]
        public async Task<IActionResult> GetPrefijosByCodigoClienteQuery(long ClientesCodigo)
        {
            var result = await _mediator.Send(new GetPrefijosByCodigoClienteQuery(ClientesCodigo));
            return Ok(result);
        }

        [HttpGet("/api/prefijo-gln/CodpreCliente")]        
        public async Task<IActionResult> GetPrefijoGlnByClienteCodigoQuery(long ClientesCodigo)
        {
            var result = await _mediator.Send(new GetPrefijoGlnByClienteCodigoQuery(ClientesCodigo));
            return Ok(result);
        }

        [HttpGet("unicos/{ClientesCodigo}")]
        public async Task<IActionResult> GetPrefijosUnicosByClienteCodigo(long ClientesCodigo)
        {
            var result = await _mediator.Send(new GetPrefijoUnitByClienteCodigoQuery(ClientesCodigo));
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
        public async Task<IActionResult> Create([FromBody] PrefijosRequest request)
        {
            var result = await _mediator.Send(new CreatePrefijosCommand(request));
            return Ok(result);
        }

        // PUT api/examples/{id}
        // Actualiza un registro existente de Example
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, [FromBody] PrefijosRequest request)
        {
            var result = await _mediator.Send(new UpdatePrefijosCommand(id, request));
            return Ok(result);
        }

        // DELETE api/examples/{id}
        // Elimina f�sicamente un registro
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var result = await _mediator.Send(new DeletePrefijosCommand(id));
            return Ok(result);
        }

        // PATCH api/prefijos/{id}/cliente/{clientesCodigo}
        // Actualiza solo el campo ClientesCodigo de un prefijo
        [HttpPatch("{id}/cliente/{clientesCodigo}")]
        public async Task<IActionResult> ActualizarClientesCodigo(long id, int clientesCodigo)
        {
            var result = await _mediator.Send(new UpdatePrefijoClientesCodigoPrefijoCommand(id, clientesCodigo));
            return Ok(result);
        }



    }
}
