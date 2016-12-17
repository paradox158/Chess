namespace ChesslikeGames.GameModel
{
    /// <summary>
    /// Игровая фигура на доске
    /// </summary>
    public class Figure
    {
        public Figure(Player player, string type)
        {
            Player = player;
            Type = type.ToLower();
        }

        /// <summary>
        /// Строковое предстваление типа фигуры.
        /// соответствие типов фигур игровым не контролируется
        /// </summary>
        public string Type { get; private set; }

        /// <summary>
        /// Игрок, который владеет фигурой
        /// </summary>
        public Player Player { get; private set; }

        /// <summary>
        /// Строковый ключ, который используется для идентификации
        /// изображения фигуры.
        /// </summary>
        public string PictureHandle
        {
            get { return string.Format("{0}-{1}", Player.Color, Type); }
        }
    }
}