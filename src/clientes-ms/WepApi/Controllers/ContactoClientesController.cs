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
    public class ContactoClientesController : ControllerBase
    {
        private readonly IMediator _mediator;

        // Constructor con inyección de dependencia del Mediator
        public ContactoClientesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET api/examples
        // Obtiene todos los registros de Example
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllContactosClientesQuery()); // Envía la query a su handler correspondiente
            return Ok(result); // Devuelve la respuesta con estado 200
        }

        // GET api/contactos/clientes/{clientesCodigo}
        // Obtiene todos los contactos de un cliente específico
        [HttpGet("clientescontacto/{clientesCodigo}")]
        public async Task<IActionResult> GetByClientesCodigo(int clientesCodigo)
        {
            var result = await _mediator.Send(new GetContactosClientesByClientesCodigoQuery(clientesCodigo));
            return Ok(result);
        }


        // GET api/examples/status/{status}
        // Obtiene todos los registros activos o inactivos según el parámetro
        //[HttpGet("status/{status}")]
        //public async Task<IActionResult> GetByStatus(bool status)
        //{
        //    var result = await _mediator.Send(new GetExamplesByStatusQuery(status));
        //    return Ok(result);
        //}

        // POST api/examples
        // Crea un nuevo registro de Example
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ContactosClientesRequest request)
        {
            var result = await _mediator.Send(new CreateContactosClientesCommand(request));
            return Ok(result);
        }

        // PUT api/contactos/clientes/{clientesCodigo}/linea/{linea}
        // Actualiza un contacto por código de cliente y número de línea
        [HttpPut("clientes/{clientesCodigo}/linea/{linea}")]
        public async Task<IActionResult> UpdateByClienteCodigoAndLinea(int clientesCodigo, int linea, [FromBody] ContactosClientesRequest request)
        {
            // Asegurar que los datos estén en el request para el handler
            request.ClientesCodigo = clientesCodigo;
            request.Linea = linea;

            var result = await _mediator.Send(new UpdateContactosClientesCommand(request));
            return Ok(result);
        }

        // DELETE api/examples/{id}
        // Elimina físicamente un registro
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var result = await _mediator.Send(new DeleteContactosClientesCommand(id));
            return Ok(result);
        }

        // PUT api/examples/{id}/soft-delete
        // Elimina lógicamente un registro (cambia su status a false)
        //[HttpPatch("{id}/soft-delete")]
        //public async Task<IActionResult> SoftDelete(long id)
        //{
        //    var result = await _mediator.Send(new SoftDeleteExampleCommand(id));
        //    return Ok(result);
        //}
    }
}
