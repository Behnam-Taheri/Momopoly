using Tactical.Framework.Domain.DomainAbstractions;
using Tactical.Monopoly.Domain.Boards.Enums;

namespace Tactical.Monopoly.Domain.Boards.ValueObjects
{
    public class BoardScore : ValueObject<BoardScore>
    {
        private BoardScore() { }
        public BoardScore(int score, Guid playerId, Guid boardId, PlayerState playerState)
        {
            Score = score;
            PlayerId = playerId;
            BoardId = boardId;
            PlayerState = playerState;
        }

        public int Score { get; private set; }
        public Guid PlayerId { get; private set; }
        public Guid BoardId { get; private set; }
        public PlayerState PlayerState { get; private set; }

        public BoardScore AddScore(int score)
        {
            Score += score;
            if (Score >= 0)
                PlayerState = PlayerState.Active;
            return new BoardScore(Score, PlayerId, BoardId, PlayerState);
        }

        public BoardScore MinusScore(int score)
        {
            Score -= score;
            if (Score < 0)
                PlayerState = PlayerState.Lose;
            return new BoardScore(Score, PlayerId, BoardId, PlayerState);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Score;
            yield return PlayerId;
            yield return BoardId;
        }
    }
}
