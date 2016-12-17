using System.Linq;

namespace ChesslikeGames.GameModel
{
    /// <summary>
    /// Ход в игре на шахматной доске
    /// </summary>
    public class Move
    {
        public Move(params string[] cells)
        {
            Cells = cells.Select(Cell.Parse).ToArray();
        }

        /// <summary>
        /// Клетки, выражающие последовательность хода.
        /// В шашках - клетка, через которые проходит фигура, 
        /// в реверси - клетка, на которую ставится фигура
        /// </summary>
        public Cell[] Cells { get; private set; }

       
    }
}