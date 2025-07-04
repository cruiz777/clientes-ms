using MediatR;
using Microsoft.AspNetCore.Mvc;
using clientes_ms.Application.Records.Request;
using clientes_ms.Application.Records.Response;
using clientes_ms.Application.Queries.Gln;

namespace clientes_ms.WebApi.Controllers
{
    // Indica que esta clase es un controlador de API
    [ApiController]

    // Define la ruta base para este controlador
    [Route("api/[Controller]")]
    public class GlnController : ControllerBase
    {
        private readonly IMediator _mediator;

        // Constructor con inyecci�n de dependencia del Mediator
        public GlnController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET api/examples
        // Obtiene todos los registros de Example
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllGlnQuery()); // Env�a la query a su handler correspondiente
            return Ok(result); // Devuelve la respuesta con estado 200
        }

        // GET api/examples/{id}
        // Obtiene un registro espec�fico por su ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var result = await _mediator.Send(new GetGlnByIdQuery(id));
            return Ok(result);
        }

        // GET api/examples/{id}
        // Obtiene un registro espec�fico por su ID
        [HttpGet("cliente/{clienteCodigo:long}")]
        public async Task<IActionResult> GetGlnByClienteCodigo(long clienteCodigo)
        {
            var result = await _mediator.Send(new GetGlnByClienteCodigoQuery(clienteCodigo));

            if (result.Type == "NOT_FOUND")
                return NotFound(result);

            if (result.Type == "ERROR")
                return StatusCode(500, result);

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
        public async Task<IActionResult> Create([FromBody] CreateGlnCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        // PUT api/examples/{id}
        // Actualiza un registro existente de Example
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, [FromBody] GlnRequest request)
        {
            var result = await _mediator.Send(new UpdateGlnCommand(id, request));
            return Ok(result);
        }

        // DELETE api/examples/{id}
        // Elimina f�sicamente un registro
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var result = await _mediator.Send(new DeleteGlnCommand(id));
            return Ok(result);
        }
        [HttpGet("ultima-secuencia")]
        public async Task<IActionResult> GetUltimaSecuencia([FromQuery] string codigoPais, [FromQuery] string prefijo)
        {
            var query = new GetUltimaSecuenciaGlnQuery(codigoPais, prefijo);
            var result = await _mediator.Send(query);
            return Ok(result); // Devuelve solo el número como int
        }

        //Obtiene los glns por Prefijo de cliente
        [HttpGet("prefijo/{idPrefijos:long}")]
        public async Task<IActionResult> GetGlnByPrefijoId(long idPrefijos)
        {
            var result = await _mediator.Send(new GetGlnByPrefijoIdQuery(idPrefijos));

            return result.Type switch
            {
                "NOT_FOUND" => NotFound(result),
                "ERROR" => StatusCode(500, result),
                _ => Ok(result)
            };
        }

        [HttpDelete("por-idprefijos/{idPrefijos}")]
        public async Task<IActionResult> DeleteGlnPorIdPrefijos(long idPrefijos)
        {
            var result = await _mediator.Send(new DeleteGlnByIdPrefijosCommand(idPrefijos));
            return Ok(result);
        }

        // PUT api/gln/actualizar-clientecodigo-por-idprefijo
        [HttpPut("actualizar-idprefijo")]
        public async Task<IActionResult> UpdateClientesCodigoPorIdPrefijo([FromBody] UpdateGlnClientesCodigoByIdPrefijoCommand command)
        {
            var result = await _mediator.Send(command);

            return result.Type switch
            {
                "NOT_FOUND" => NotFound(result),
                "ERROR" => StatusCode(500, result),
                _ => Ok(result)
            };
        }


    }
}
