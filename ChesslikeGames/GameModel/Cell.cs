namespace ChesslikeGames.GameModel
{
    /// <summary>
    /// Координаты клетки
    /// </summary>
    public struct Cell
    {
        public int X { get; set; }
        public int Y { get; set; }

        public override string ToString()
        {
            return (Y < 0 ? '_' : Alpha[Y]) + (X + 1).ToString();
        }

        /// <summary>
        /// Разбор строкового представления координат в виде <буква><целое>.
        /// Регистр букв не учитывается, знак и значение чисел не контролируется.
        /// Допускаются только английские буквы a-z
        /// </summary>
        /// <param name="s">строковое представление клетки</param>
        /// <returns>координаты клетки</returns>
        public static Cell Parse(string s)
        {
            var cell = new Cell();
            if (s.Length < 2)
            {
                throw new InvalidCellException
                {
                    StringRepresentation = s
                };
            }
            cell.Y = Alpha.IndexOf(s.ToLower()[0]);
            int x;
            if (!int.TryParse(s.Substring(1), out x))
            {
                throw new InvalidCellException
                {
                    StringRepresentation = s
                };
            }
            cell.X = x - 1;
            return cell;
        }

        private const string Alpha = "abcdefghijklmnopqrstuvwxyz";
    }
}