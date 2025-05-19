using MediatR;
using Microsoft.AspNetCore.Mvc;
using clientes_ms.Application.Records.Request;
using clientes_ms.Application.Records.Response;
using clientes_ms.Application.Queries.Clientes;

namespace clientes_ms.WebApi.Controllers
{
    // Indica que esta clase es un controlador de API
    [ApiController]

    // Define la ruta base para este controlador
    [Route("api/[Controller]")]
    public class ClientesController : ControllerBase
    {
        private readonly IMediator _mediator;

        // Constructor con inyección de dependencia del Mediator
        public ClientesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET api/examples
        // Obtiene todos los registros de Example
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllClientesQuery()); // Envía la query a su handler correspondiente
            return Ok(result); // Devuelve la respuesta con estado 200
        }

        [HttpGet]
        [Route("/api/resumen")]
        public async Task<IActionResult> GetClientesResumen()
        {
            var result = await _mediator.Send(new GetClientesByResumen()); // Envía la query a su handler correspondiente
            return Ok(result); // Devuelve la respuesta con estado 200
        }
        // busca por nombre
        [HttpGet("buscar-por-nombre")]
        public async Task<IActionResult> BuscarPorNombre([FromQuery] string nombre)
        {
            var resultado = await _mediator.Send(new GetClientesByNombreLikeQuery(nombre));
            return Ok(resultado);
        }


        // GET api/examples/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var result = await _mediator.Send(new GetClientesByIdQuery(id));

            if (result == null)
                return NotFound(new { message = "Cliente no encontrado" });

            return Ok(result);
        }


        [HttpGet]
        [Route("/api/ruc")]
        public async Task<IActionResult> GetByRuc(string ruc)
        {
            var result = await _mediator.Send(new GetClientesByRucQuery(ruc));
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
        public async Task<IActionResult> Create([FromBody] ClientesRequest request)
        {
            var result = await _mediator.Send(new CreateClientesCommand(request));
            return Ok(result);
        }

        // POST api/clientes/validar
        [HttpPost("validar")]
        public async Task<IActionResult> ValidarClienteSri([FromBody] long clienteId)
        {
            var result = await _mediator.Send(new ValidarClienteSriQuery(clienteId));

            if (result.Data == null)
                return NotFound(new { message = result.Message });

            return Ok(result);
        }

        // POST api/clientes/validar-masivo
        [HttpPost("validar-masivo")]
        public async Task<IActionResult> ValidarClientesSriMasivo([FromBody] List<long> clienteIds)
        {
            var result = await _mediator.Send(new ValidarClientesSriMasivoQuery(clienteIds));

            if (result.Data == null || result.Data.Count == 0)
                return NotFound(new { message = "No se pudo validar ningún cliente" });

            return Ok(result);
        }

        // PUT api/examples/{id}
        // Actualiza un registro existente de Example
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, [FromBody] ClientesRequest request)
        {
            var result = await _mediator.Send(new UpdateClientesCommand(id, request));
            return Ok(result);
        }

        // DELETE api/examples/{id}
        // Elimina físicamente un registro
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var result = await _mediator.Send(new DeleteClientesCommand(id));
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
