using Tactical.Framework.Application.CQRS.CommandHandling;
using Tactical.Framework.Application.CQRS.EventHandling;
using Tactical.Monopoly.Application.Contract.Boards.Commands;
using Tactical.Monopoly.Domain.Boards;
using Tactical.Monopoly.Domain.Boards.Contracts;

namespace Tactical.Monopoly.Application.Boards.CommandHandlers
{
    public class CreateBoardCommandHandler : CommandHandler<CreateBoardCommand>
    {
        private readonly IBoardRepository _boardRepository;
        public CreateBoardCommandHandler(IEventBus eventBus, IBoardRepository boardRepository) : base(eventBus)
        {
            _boardRepository = boardRepository;
        }

        public override async Task HandleAsync(CreateBoardCommand command, CancellationToken cancellationToken)
        {
            var board = new Board(command.PlayerIds);
            await _boardRepository.CreateAsync(board);
        }
    }
}
