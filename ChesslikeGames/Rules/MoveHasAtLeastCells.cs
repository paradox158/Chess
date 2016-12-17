using ChesslikeGames.GameModel;

namespace ChesslikeGames.Rules
{
    /// <summary>
    /// Проверка хода на количество переходов по клеткам (ограничение сизу)
    /// </summary>
    public class MoveHasAtLeastCells : IRule
    {
        private readonly int atLeast;

        public MoveHasAtLeastCells(int atLeast)
        {
            this.atLeast = atLeast;
        }

        public MoveCheckResult Check(Move move, Game game)
        {
            return new MoveCheckResult
            {
                Success = move.Cells.Length >= atLeast,
                Message = string.Format("Ход должен содежать как минимум {0} позиций", atLeast)
            };
        }
    }
}