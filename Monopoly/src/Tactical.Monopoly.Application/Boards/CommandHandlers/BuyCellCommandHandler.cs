using Tactical.Framework.Application.CQRS.CommandHandling;
using Tactical.Framework.Application.CQRS.EventHandling;
using Tactical.Monopoly.Application.Contract.Boards.Commands;
using Tactical.Monopoly.Domain.Boards.Contracts;

namespace Tactical.Monopoly.Application.Boards.CommandHandlers
{
    public class BuyCellCommandHandler : CommandHandler<BuyCellCommand>
    {
        private readonly IBoardRepository _boardRepository;
        public BuyCellCommandHandler(IEventBus eventBus, IBoardRepository boardRepository) : base(eventBus)
        {
            _boardRepository = boardRepository;
        }

        public override async Task HandleAsync(BuyCellCommand command, CancellationToken cancellationToken)
        {
            var board = await _boardRepository.GetAsync(x => x.Id == command.BoardId, cancellationToken) ?? throw new Exception();
            board.BuyCell(command.Position, command.PlayerId);
            await PublishAggregatedEvents(board);
        }
    }

    public class SellHouseCommandHandler : CommandHandler<SellHouseCommand>
    {
        private readonly IBoardRepository _boardRepository;
        public SellHouseCommandHandler(IEventBus eventBus, IBoardRepository boardRepository) : base(eventBus)
        {
            _boardRepository = boardRepository;
        }

        public override async Task HandleAsync(SellHouseCommand command, CancellationToken cancellationToken)
        {
            var board = await _boardRepository.GetAsync(x => x.Id == command.BoardId, cancellationToken) ?? throw new Exception();
            board.BuyCell(command.Position, command.PlayerId);
        }
    }

    public class MortgageCellCommandHandler : CommandHandler<MortgageCellCommand>
    {
        private readonly IBoardRepository _boardRepository;
        public MortgageCellCommandHandler(IEventBus eventBus, IBoardRepository boardRepository) : base(eventBus)
        {
            _boardRepository = boardRepository;
        }

        public override async Task HandleAsync(MortgageCellCommand command, CancellationToken cancellationToken)
        {
            var board = await _boardRepository.GetAsync(x => x.Id == command.BoardId, cancellationToken) ?? throw new Exception();
            board.BuyCell(command.Position, command.PlayerId);
        }
    }

    public class RemoveMortgageCellCommandHandler : CommandHandler<RemoveMortgageCell>
    {
        private readonly IBoardRepository _boardRepository;
        public RemoveMortgageCellCommandHandler(IEventBus eventBus, IBoardRepository boardRepository) : base(eventBus)
        {
            _boardRepository = boardRepository;
        }

        public override async Task HandleAsync(RemoveMortgageCell command, CancellationToken cancellationToken)
        {
            var board = await _boardRepository.GetAsync(x => x.Id == command.BoardId, cancellationToken) ?? throw new Exception();
            board.BuyCell(command.Position, command.PlayerId);
        }
    }
}
