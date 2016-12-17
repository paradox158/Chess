using System.Linq;
using ChesslikeGames.GameModel;

namespace ChesslikeGames.Rules
{
    /// <summary>
    /// Проверка принадлежности клеток хода доске
    /// </summary>
    public class AllCellsAreOnField : IRule
    {
        public MoveCheckResult Check(Move move, Game game)
        {
            var errors = move.Cells
                .Where(cell => !game.Field.Contains(cell))
                .ToArray();
            return new MoveCheckResult
            {
                Success = errors.Length == 0,
                Message = string.Format("Клетки [{0}] лежат за пределами доски", 
                    string.Join(", ", errors))
            };
        }
    }
}