using System.Collections.Generic;

namespace ChesslikeGames.GameModel
{
    /// <summary>
    ///  Игра на шахматной доске. Играют два игрока - белые и чёрные,
    ///  делая ходы по очереди.
    /// </summary>
    public abstract class Game
    {
        protected readonly List<Player> players = new List<Player>();
        protected int currentPlayer;
        protected GameResult gameResult;

        protected Game()
        {
            players.Add(Player.White);
            players.Add(Player.Black);
        }

        /// <summary>
        ///     Поле для игры
        /// </summary>
        public Field Field { get; set; }

        /// <summary>
        ///     Правила, проверяющие корректность хода
        /// </summary>
        public IRule Rule { get; set; }

        /// <summary>
        ///     Игрок, который должен сделать следующий ход
        /// </summary>
        public Player CurrentPlayer
        {
            get { return players[currentPlayer]; }
        }

        public GameResult Result
        {
            get
            {
                if (gameResult != null)
                {
                    return gameResult;
                }
                return gameResult = CalculateGameResult();
            }
        }

        /// <summary>
        ///     Чтобы определить алгоритм определения окончания игры и победителя,
        ///     нужно переопределить этот метод
        /// </summary>
        /// <returns></returns>
        protected abstract GameResult CalculateGameResult();

        /// <summary>
        ///     Чтобы переопределить, как ход изменяет позицию на доске,
        ///     нужно переопределить этот метод
        /// </summary>
        /// <param name="move"></param>
        protected abstract void ChangePosition(Move move);

        /// <summary>
        ///     Обработка хода. Происходит проверка хода на корректность,
        ///     манипуляции с позицией на доске, смена игроков, если ход был правильным.
        ///     Очередность ходов не контролируется - в общем случае белые могут ходить
        ///     черными, а черные - белыми. Если такой контроль предполагается логикой игры,
        ///     его необходимо явно включить в правила
        /// </summary>
        /// <param name="move">только что сделанный ход.</param>
        /// <returns>
        ///     результат проверки хода. Если поле <see cref="MoveCheckResult.Success" />
        ///     установлено в <code>false</code>, изменений на доске не произошло
        ///     и поле <see cref="MoveCheckResult.Message" /> содержит сообщение о нарушенном правиле.
        ///     В противном случае содержимое <see cref="MoveCheckResult.Message" /> не определено
        /// </returns>
        /// <remarks> </remarks>
        public virtual MoveCheckResult ProcessMove(Move move)
        {
            var result = Rule.Check(move, this);
            if (!result.Success)
            {
                return result;
            }
            gameResult = null;
            ChangePosition(move);
            NextPlayer();
            return new MoveCheckResult {Success = true};
        }

        protected void NextPlayer()
        {
            if (++currentPlayer >= players.Count)
            {
                currentPlayer = 0;
            }
        }
    }
}