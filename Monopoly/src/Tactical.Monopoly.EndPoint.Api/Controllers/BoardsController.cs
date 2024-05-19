using Microsoft.AspNetCore.Mvc;
using Tactical.Framework.Application.CQRS.CommandHandling;
using Tactical.Monopoly.Application.Boards.CommandHandlers;
using Tactical.Monopoly.Application.Contract.Boards.Commands;
using Tactical.Monopoly.Domain.Boards.Contracts;
using Tactical.Monopoly.Queries.Contracts;

namespace Tactical.Monopoly.EndPoint.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoardsController : ControllerBase
    {
        private readonly ICommandBus _commandBus;
        private readonly IBoardReadRepository _boardRepository;
        public BoardsController(ICommandBus commandBus, IBoardReadRepository boardRepository)
        {
            _commandBus = commandBus;
            _boardRepository = boardRepository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id, CancellationToken cancellationToken)
        {
            var board = await _boardRepository.GetAsync(id, cancellationToken);
            return Ok(board);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateBoardCommand command, CancellationToken cancellationToken)
        {
            await _commandBus.DispatchAsync(command, cancellationToken);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            await _commandBus.DispatchAsync(new DeleteBoardCommand(id), cancellationToken);
            return Ok();
        }

        [HttpPatch]
        public async Task<IActionResult> Patch(MovePlayerCommand command, CancellationToken cancellationToken)
        {
            await _commandBus.DispatchAsync(command, cancellationToken);
            return Ok();
        }
    }
}
