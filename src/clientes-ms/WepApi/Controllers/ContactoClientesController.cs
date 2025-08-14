using MediatR;
using Microsoft.AspNetCore.Mvc;
using clientes_ms.Application.Records.Request;
using clientes_ms.Application.Records.Response;

namespace clientes_ms.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactoClientesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ContactoClientesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET api/contactoclientes
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllContactosClientesQuery());
            return Ok(result);
        }

        // GET api/contactoclientes/clientescontacto/{clientesCodigo}
        [HttpGet("clientescontacto/{clientesCodigo}")]
        public async Task<IActionResult> GetByClientesCodigo(int clientesCodigo)
        {
            var result = await _mediator.Send(new GetContactosClientesByClientesCodigoQuery(clientesCodigo));
            return Ok(result);
        }

        // ? NUEVO ENDPOINT
        // GET api/contactoclientes/facturacion/{clientesCodigo}
        [HttpGet("facturacion/{clientesCodigo}")]
        public async Task<IActionResult> GetFacturacionByClientesCodigo(int clientesCodigo)
        {
            var result = await _mediator.Send(new GetContactosFacturacionByClientesCodigoQuery(clientesCodigo));
            return Ok(result);
        }

        // POST api/contactoclientes
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ContactosClientesRequest request)
        {
            var result = await _mediator.Send(new CreateContactosClientesCommand(request));
            return Ok(result);
        }

        // PUT api/contactoclientes/clientes/{clientesCodigo}/linea/{linea}
        [HttpPut("clientes/{clientesCodigo}/linea/{linea}")]
        public async Task<IActionResult> UpdateByClienteCodigoAndLinea(int clientesCodigo, int linea, [FromBody] ContactosClientesRequest request)
        {
            request.ClientesCodigo = clientesCodigo;
            request.Linea = linea;

            var result = await _mediator.Send(new UpdateContactosClientesCommand(request));
            return Ok(result);
        }

        // DELETE api/contactoclientes/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var result = await _mediator.Send(new DeleteContactosClientesCommand(id));
            return Ok(result);
        }
    }
}
