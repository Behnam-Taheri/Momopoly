using Tactical.Framework.Application.CQRS.CommandHandling;
using Tactical.Framework.Application.CQRS.EventHandling;
using Tactical.Monopoly.Application.Contract.Boards.Commands;
using Tactical.Monopoly.Domain.Boards.Contracts;

namespace Tactical.Monopoly.Application.Boards.CommandHandlers
{
    public class MovePlayerCommandHandler : CommandHandler<MovePlayerCommand>
    {
        private readonly IBoardRepository _boardRepository;
        public MovePlayerCommandHandler(IEventBus eventBus, IBoardRepository boardRepository) : base(eventBus)
        {
            _boardRepository = boardRepository;
        }

        public override async Task HandleAsync(MovePlayerCommand command, CancellationToken cancellationToken)
        {
            var board = await _boardRepository.GetAsync(x => x.Id == command.BoardId, cancellationToken);
        }
    }
}
