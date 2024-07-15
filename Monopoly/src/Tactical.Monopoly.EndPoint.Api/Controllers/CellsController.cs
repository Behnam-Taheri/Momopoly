using Microsoft.AspNetCore.Mvc;
using Tactical.Framework.Application.CQRS.CommandHandling;
using Tactical.Monopoly.Domain.Boards.Events;
using Tactical.Monopoly.EndPoint.Api.Requests;

namespace Tactical.Monopoly.EndPoint.Api.Controllers
{
    [Route("api/boards/{boardId}/[controller]")]
    [ApiController]
    public class CellsController : ControllerBase
    {
        private readonly ICommandBus _commandBus;
        public CellsController(ICommandBus commandBus)
        {
            _commandBus = commandBus;
        }

        [HttpPatch("buy-cell")]
        public async Task<IActionResult> BuyCell(Guid boardId, ChangeCellRequest request, CancellationToken cancellationToken)
        {
            string message = string.Empty;
            await _commandBus.Execute(request.ToBuyCellCommand(boardId))
                .On<CellBoughtEvent>(e => message = e.Message)
                .DispatchAsync(cancellationToken);

            return Ok(message);
        }

        [HttpPatch("create-house")]
        public async Task<IActionResult> CreateHouse(Guid boardId, ChangeCellRequest request, CancellationToken cancellationToken)
        {
            string message = string.Empty;
            await _commandBus.Execute(request.ToCreateHouseCommand(boardId))
                .On<HouseCreatedEvent>(e => message = e.Message)
                .DispatchAsync(cancellationToken);

            return Ok(message);
        }

        //[HttpPatch("create-house")]
        //public async Task<IActionResult> CreateHouse(Guid boardId, ChangeCellRequest request, CancellationToken cancellationToken)
        //{
        //    await _commandBus.DispatchAsync(request.ToCreateHouseCommand(boardId), cancellationToken);
        //    return null;
        //}
    }
}
