using System.Linq;
using ChesslikeGames.GameModel;

namespace ChesslikeGames.Rules
{
    /// <summary>
    /// Проверка соответствия цвета фигуры цвету игрока, делающего ход
    /// </summary>
    public class CorrectPlayer : IRule
    {
        public MoveCheckResult Check(Move move, Game game)
        {
            var figure = game.Field[move.Cells.First()];
            return new MoveCheckResult
            {
                Success = game.CurrentPlayer == figure.Player,
                Message = string.Format("Должны ходить {0}, а не {1}",
                    game.CurrentPlayer.Color, figure.Player.Color)
            };
        }
    }
}