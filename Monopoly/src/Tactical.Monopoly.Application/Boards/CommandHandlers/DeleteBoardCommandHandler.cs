using Tactical.Framework.Application.CQRS.CommandHandling;
using Tactical.Framework.Application.CQRS.EventHandling;
using Tactical.Monopoly.Application.Contract.Boards.Commands;
using Tactical.Monopoly.Domain.Boards.Contracts;

namespace Tactical.Monopoly.Application.Boards.CommandHandlers
{
    public class DeleteBoardCommandHandler : CommandHandler<DeleteBoardCommand>
    {
        private readonly IBoardRepository _boardRepository;
        public DeleteBoardCommandHandler(IEventBus eventBus, IBoardRepository boardRepository) : base(eventBus)
        {
            _boardRepository = boardRepository;
        }

        public override async Task HandleAsync(DeleteBoardCommand command, CancellationToken cancellationToken)
        {
            var board = await _boardRepository.GetAsync(x => x.Id == command.BoardId, cancellationToken);
            _boardRepository.Delete(board);
        }
    }
}
