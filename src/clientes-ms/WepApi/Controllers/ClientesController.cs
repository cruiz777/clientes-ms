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

        // Constructor con inyecci�n de dependencia del Mediator
        public ClientesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET api/examples
        // Obtiene todos los registros de Example
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllClientesQuery()); // Env�a la query a su handler correspondiente
            return Ok(result); // Devuelve la respuesta con estado 200
        }

        [HttpGet]
        [Route("resumen")]
        public async Task<IActionResult> GetClientesResumen(
     [FromQuery] int pageNumber = 1,
     [FromQuery] int pageSize = 10,
     [FromQuery] string? busquedaGeneral = null,
     [FromQuery] string? prefijoBusqueda = null)
        {
            var result = await _mediator.Send(new GetClientesByResumen(pageNumber, pageSize, busquedaGeneral, prefijoBusqueda));
            return Ok(result);
        }

        [HttpGet]
        [Route("resumeng")]
        public async Task<IActionResult> GetClientesPaged(
    [FromQuery] int pageNumber = 1,
    [FromQuery] int pageSize = 10,
    [FromQuery] string? busquedaGeneral = null,
    [FromQuery] string? prefijoBusqueda = null)
        {
            // Instanciamos la Query con los parámetros recibidos
            var query = new GetClientesPaged
            {
                PageNumber = pageNumber,
                PageSize = pageSize,
                BusquedaGeneral = busquedaGeneral,
                PrefijoBusqueda = prefijoBusqueda
            };

            var result = await _mediator.Send(query);

            // Si tu ApiResponse ya contiene Data y Count, esto lo devuelve tal cual.
            // Si quieres devolverlo como objeto simple con { data, count }, puedes ajustarlo aquí.
            return Ok(new { data = result.Data, count = result.Count });
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
                return NotFound(new { message = "No se pudo validar ning�n cliente" });

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
        // Elimina f�sicamente un registro
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var result = await _mediator.Send(new DeleteClientesCommand(id));
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

        [HttpGet("buscar")]
        public async Task<ActionResult<ApiResponse<List<ClienteSummaryResponse>>>> BuscarClientes([FromQuery] string filtro)
        {
            if (string.IsNullOrWhiteSpace(filtro))
                return BadRequest("Debe proporcionar un nombre o RUC como filtro.");

            var query = new GetClientesByNomcliAsyncQuery(filtro);
            var resultado = await _mediator.Send(query);
            return Ok(resultado);
        }
        [HttpGet("buscar-por-nomcli")]
        public async Task<ActionResult<ApiResponse<List<ClienteSummaryResponse>>>> BuscarClientesPorNombre([FromQuery] string nomcli)
        {
            if (string.IsNullOrWhiteSpace(nomcli))
                return BadRequest("Debe proporcionar un nombre para buscar.");

            var query = new GetClientesByNomcliAsyncQuery(nomcli);
            var resultado = await _mediator.Send(query);
            return Ok(resultado);
        }

    }
}
