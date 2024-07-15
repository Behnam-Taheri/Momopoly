using Tactical.Framework.Application.CQRS.CommandHandling;
using Tactical.Framework.Application.CQRS.EventHandling;
using Tactical.Monopoly.Application.Contract.Boards.Commands;
using Tactical.Monopoly.Domain.Boards.Contracts;

namespace Tactical.Monopoly.Application.Boards.CommandHandlers
{
    public class CreateHouseCommandHandler : CommandHandler<CreateHouseCommand>
    {
        private readonly IBoardRepository _boardRepository;
        public CreateHouseCommandHandler(IEventBus eventBus, IBoardRepository boardRepository) : base(eventBus)
        {
            _boardRepository = boardRepository;
        }

        public override async Task HandleAsync(CreateHouseCommand command, CancellationToken cancellationToken)
        {
            var board = await _boardRepository.GetAsync(x => x.Id == command.BoardId, cancellationToken) ?? throw new Exception();
            board.CreateHouse(command.Position, command.PlayerId);

            await PublishAggregatedEvents(board);
        }
    }
}
