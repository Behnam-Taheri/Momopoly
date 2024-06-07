using Tactical.Framework.Domain.DomainAbstractions;

namespace Tactical.Monopoly.Domain.Boards.ValueObjects
{
    public class BoardScore : ValueObject<BoardScore>
    {
        private BoardScore() { }
        public BoardScore(int score, Guid playerId, Guid boardId)
        {
            Score = score;
            PlayerId = playerId;
            BoardId = boardId;
        }

        public int Score { get; private set; }
        public Guid PlayerId { get; private set; }
        public Guid BoardId { get; private set; }

        public BoardScore AddScore(int score)
        {
            Score += score;
            return new BoardScore(Score, PlayerId, BoardId);
        }

        public BoardScore MinusScore(int score)
        {
            Score -= score;
            return new BoardScore(Score, PlayerId, BoardId);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Score;
            yield return PlayerId;
            yield return BoardId;
        }
    }
}
