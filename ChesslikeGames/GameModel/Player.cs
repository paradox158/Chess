namespace ChesslikeGames.GameModel
{
    /// <summary>
    /// Абстракция "игрок".
    /// </summary>
    public class Player 
    {
        public static readonly Player White = new Player("белые");
        public static readonly Player Black = new Player("чёрные");

        /// <summary>
        /// цвет фигур, которыми играет этот игрок
        /// </summary>
        public string Color { get; private set; }

        public Player(string color)
        {
            Color = color;
        }
    }
}