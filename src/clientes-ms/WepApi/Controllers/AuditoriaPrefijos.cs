using MediatR;
using Microsoft.AspNetCore.Mvc;
using clientes_ms.Application.Records.Request;
using clientes_ms.Application.Records.Response;

namespace clientes_ms.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuditoriaPrefijosController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuditoriaPrefijosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/AuditoriaPrefijos
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllAuditoriaPrefijosQuery());
            return Ok(result);
        }

        // GET: api/AuditoriaPrefijos/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var result = await _mediator.Send(new GetAuditoriaPrefijosByIdQuery(id));
            return Ok(result);
        }

        // POST: api/AuditoriaPrefijos
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AuditoriaPrefijosRequest request)
        {
            var result = await _mediator.Send(new CreateAuditoriaPrefijosCommand(request));
            return Ok(result);
        }

        // PUT: api/AuditoriaPrefijos/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, [FromBody] AuditoriaPrefijosRequest request)
        {
            var result = await _mediator.Send(new UpdateAuditoriaPrefijosCommand(id, request));
            return Ok(result);
        }

        // DELETE: api/AuditoriaPrefijos/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var result = await _mediator.Send(new DeleteAuditoriaPrefijosCommand(id));
            return Ok(result);
        }
    }
}
