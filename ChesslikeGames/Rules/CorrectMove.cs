using System.Linq;
using ChesslikeGames.GameModel;
using System;
using System.Collections.Generic;

namespace ChesslikeGames.Rules
{
    /// <summary>
    /// Проверка правильности хода
    /// </summary>
    public class CorrectMove : IRule
    {
        private delegate MoveCheckResult TestDelegate(int FirstX, int FirstY, int LastX, int LastY);
        private string Color;
        public MoveCheckResult Check(Move move, Game game)
        {
            Color = game.Field[move.Cells.First()].Player.Color;
            var first = move.Cells.First();
            var last = move.Cells.Last();


            var figureDictionary = new Dictionary<string, MoveCheckResult>
            {
                {"p", PawnChecker(first.X, first.Y, last.X, last.Y)},
                {"h", HoreseChecker(first.X, first.Y, last.X, last.Y)},
                {"e", elephantChecker(first.X, first.Y, last.X, last.Y)},
                {"r", RookChecker(first.X, first.Y, last.X, last.Y)},
                {"q", QueenChecker(first.X, first.Y, last.X, last.Y)},
                {"k", KingChecker(first.X, first.Y, last.X, last.Y)}
            };






            return figureDictionary[game.Field[move.Cells.First()].Type];
        }

        private MoveCheckResult KingChecker(int x1, int y1, int x2, int y2)
        {
            throw new NotImplementedException();
        }

        private MoveCheckResult QueenChecker(int x1, int y1, int x2, int y2)
        {
            throw new NotImplementedException();
        }

        private MoveCheckResult RookChecker(int x1, int y1, int x2, int y2)
        {
            throw new NotImplementedException();
        }

        private MoveCheckResult elephantChecker(int x1, int y1, int x2, int y2)
        {
            throw new NotImplementedException();
        }

        private MoveCheckResult HoreseChecker(int x1, int y1, int x2, int y2)
        {
            throw new NotImplementedException();
        }

        private MoveCheckResult PawnChecker(int x1, int y1, int x2, int y2)
        {
            //Реализовать Проверки:
            //Ходит вертикально
            //Ходит на 1 (исключение 1 ход)
            //Рубит по горизонтали
            //Ходит в разные стороны по цветам

            if (x1 == x2)
            {

            }
            if (Color == "белый")
            {
                
                if ((y1 - y2) < 0)
                {

                }
            }


            return new MoveCheckResult
            {
                Success = (x1 == x2) && (Math.Abs(y1 - y2) < 2),
                Message = "Пешка так не ходит!"
            };
        }



    }
}
