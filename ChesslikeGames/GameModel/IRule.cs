namespace ChesslikeGames.GameModel
{
    /// <summary>
    /// Абстракция правил игры
    /// </summary>
    public interface IRule
    {
        /// <summary>
        /// Проверяет ход на правильность
        /// </summary>
        /// <param name="move">Ход, который необходимо проверить</param>
        /// <param name="game">Игра, которой соответствует ход. Можно использовать для
        /// доступа к полю и текущему игроку</param>
        /// <returns>результат проверки</returns>
        MoveCheckResult Check(Move move, Game game);
    }
}