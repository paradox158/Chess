using System;

namespace ChesslikeGames.GameModel
{
    /// <summary>
    /// Исключение "неправильное строковое представление клетки"
    /// </summary>
    public class InvalidCellException : Exception
    {
        /// <summary>
        /// Строковое представление клетки, вызвавшее исключение
        /// </summary>
        public string StringRepresentation { get; set; }
    }
}