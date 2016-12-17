namespace ChesslikeGames.GameModel
{
    /// <summary>
    /// Результат проверки хода
    /// </summary>
    public class MoveCheckResult
    {
        /// <summary>
        /// сообщение о причинах "неправильности" хода
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// true, если ход правильный, в противном случае false
        /// </summary>
        public bool Success { get; set; }
    }
}