using System.Linq;

namespace ChesslikeGames.GameModel
{
    public class StupidGame : Game
    {
        protected override GameResult CalculateGameResult()
        {
            var totalFigures = Field.Figures.Count();
            var counts = players.ToDictionary(player => player, player => 0);
            // подсчитываем фигуры каждого цвета
            foreach (var pair in Field.Figures) 
            {
                counts[pair.Value.Player]++;
            }
            var winners = counts.Where(x => x.Value == totalFigures)
                .Select(x => x.Key)
                .ToArray();
            // на доске остались фигуры разных цветов
            if (winners.Length != 1)
            {
                return new GameResult {GameHasFinished = false};
            }
            var cell = Field.Figures.First().Key;
            var hasWinner = totalFigures == 1 && cell.ToString() == "a1";
            return new GameResult
            {
                Winner = hasWinner ? winners[0] : null,
                GameHasFinished = CurrentPlayer != winners[0],
            };
        }

        protected override void ChangePosition(Move move)
        {
            var first = move.Cells.First();
            var figure = Field[first];
            Field.Remove(first);
            Field.Add(move.Cells.Last(), figure);
        }
    }
}