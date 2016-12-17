using System.Linq;
using ChesslikeGames.GameModel;

namespace ChesslikeGames.Rules
{
    /// <summary>
    /// Проверка "черноты" последней клетки хода
    /// </summary>
    public class TargetCellIsEven : IRule
    {
        public MoveCheckResult Check(Move move, Game game)
        {
            var last = move.Cells.Last();
            return new MoveCheckResult
            {
                Success = (last.X + last.Y) % 2 == 0,
                Message = "Нельзя ходить на белые клетки!"
            };
        }
    }
}