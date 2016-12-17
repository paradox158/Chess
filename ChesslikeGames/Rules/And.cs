using ChesslikeGames.GameModel;

namespace ChesslikeGames.Rules
{
    /// <summary>
    /// Составное правило, реализующее логику And
    /// </summary>
    public class And : IRule
    {
        private readonly IRule[] rules;

        public And(params IRule[] rules)
        {
            this.rules = rules;
        }

        public MoveCheckResult Check(Move move, Game game)
        {
            foreach (var rule in rules)
            {
                var result = rule.Check(move, game);
                if (!result.Success)
                {
                    return result;
                }
            }
            return new MoveCheckResult {Success = true};
        }
    }
}