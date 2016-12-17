using System.Linq;
using ChesslikeGames.GameModel;

namespace ChesslikeGames.Rules
{
    /// <summary>
    /// Проверка непустоты первой клетки хода
    /// </summary>
    public class FirstCellNotEmpty : IRule
    {
        public MoveCheckResult Check(Move move, Game game)
        {
            var figure = game.Field[move.Cells.First()];
            return new MoveCheckResult
            {
                Success = figure != null,
                Message = "Вы выбрали пустую клетку для начала хода"
            };
        }
    }
}