using Mediator.Application.Commands;
using Mediator.Application.Models;
using Mediator.Application.Query;
using Mediator.Data;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Mediator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly PessoaDbContext _context;

        public PessoaController(IMediator mediator, PessoaDbContext context)
        {
            this._mediator = mediator;
            this._context = context;
        }

        [HttpGet]
        public async Task<IActionResult> FindAll()
        {
            ProcuraTodasPessoasQuery query = new ProcuraTodasPessoasQuery();
            var response = await _mediator.Send(query);
            return Ok(response);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            ProcuraPessoaIdQuery query = new ProcuraPessoaIdQuery();
            query.Id = id;
            var response = await _mediator.Send(query);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CadastraPessoaCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Put(AlteraPessoaCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var obj = new ExcluiPessoaCommand { Id = id };
            var result = await _mediator.Send(obj);
            return Ok(result);
        }

    }
}
