using MediatR;
using Microsoft.AspNetCore.Mvc;
using clientes_ms.Application.Commands.NumeroControl;
using clientes_ms.Application.DTOs.NumeroControl;
using clientes_ms.Application.Records.Request;
using clientes_ms.Application.Records.Response;

namespace clientes_ms.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NumeroControlController : ControllerBase
    {
        private readonly IMediator _mediator;

        public NumeroControlController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/NumeroControl
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllNumeroControlQuery());
            return Ok(result);
        }

        // GET: api/NumeroControl/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var result = await _mediator.Send(new GetNumeroControlByIdQuery(id));
            return Ok(result);
        }

        // POST: api/NumeroControl
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] NumeroControlRequest request)
        {
            var result = await _mediator.Send(new CreateNumeroControlCommand(request));
            return Ok(result);
        }

        // PUT: api/NumeroControl/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, [FromBody] UpdateNumeroControlDto request)
        {
            var result = await _mediator.Send(new UpdateNumeroControlCommand
            {
                Id = id,
                Request = request
            });

            return Ok(result);
        }

        // DELETE: api/NumeroControl/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var result = await _mediator.Send(new DeleteNumeroControlCommand(id));
            return Ok(result);
        }

        // PATCH (opcional): api/NumeroControl/{id}/soft-delete
        //[HttpPatch("{id}/soft-delete")]
        //public async Task<IActionResult> SoftDelete(long id)
        //{
        //    var result = await _mediator.Send(new SoftDeleteNumeroControlCommand(id));
        //    return Ok(result);
        //}
    }
}
