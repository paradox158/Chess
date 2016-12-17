using ChesslikeGames.GameModel;
using ChesslikeGames.Rules;
using ConsoleUI;
using DrawablesUI;

namespace ChesslikeGames
{
    internal class Program
    {
        private static void Main()
        {
            var game = new StupidGame
            {
                Field = new Field(8, 8),
                Rule = new And(
                    new MoveHasAtLeastCells(2),
                    new AllCellsAreOnField(),
                    new FirstCellNotEmpty(),
                    new CorrectPlayer(),
                    new CorrectMove()
                    //new TargetCellIsEven()
                )
            };
            var ui = new GameGraphicalGui(game.Field);

            ui.RegisterImage(Player.Black.Color + "-r", "C:/Users/komar/OneDrive/Документы/Visual Studio 2015/Projects/ChesslikeGames/ChesslikeGames/Pictures/black-r.png");
            ui.RegisterImage(Player.White.Color + "-r", "C:/Users/komar/OneDrive/Документы/Visual Studio 2015/Projects/ChesslikeGames/ChesslikeGames/Pictures/white-r.png");

            ui.RegisterImage(Player.Black.Color + "-e", "C:/Users/komar/OneDrive/Документы/Visual Studio 2015/Projects/ChesslikeGames/ChesslikeGames/Pictures/black-e.png");
            ui.RegisterImage(Player.White.Color + "-e", "C:/Users/komar/OneDrive/Документы/Visual Studio 2015/Projects/ChesslikeGames/ChesslikeGames/Pictures/white-e.png");

            ui.RegisterImage(Player.Black.Color + "-q", "C:/Users/komar/OneDrive/Документы/Visual Studio 2015/Projects/ChesslikeGames/ChesslikeGames/Pictures/black-q.png");
            ui.RegisterImage(Player.White.Color + "-q", "C:/Users/komar/OneDrive/Документы/Visual Studio 2015/Projects/ChesslikeGames/ChesslikeGames/Pictures/white-q.png");

            ui.RegisterImage(Player.Black.Color + "-k", "C:/Users/komar/OneDrive/Документы/Visual Studio 2015/Projects/ChesslikeGames/ChesslikeGames/Pictures/black-k.png");
            ui.RegisterImage(Player.White.Color + "-k", "C:/Users/komar/OneDrive/Документы/Visual Studio 2015/Projects/ChesslikeGames/ChesslikeGames/Pictures/white-k.png");

            ui.RegisterImage(Player.Black.Color + "-h", "C:/Users/komar/OneDrive/Документы/Visual Studio 2015/Projects/ChesslikeGames/ChesslikeGames/Pictures/black-h.png");
            ui.RegisterImage(Player.White.Color + "-h", "C:/Users/komar/OneDrive/Документы/Visual Studio 2015/Projects/ChesslikeGames/ChesslikeGames/Pictures/white-h.png");

            ui.RegisterImage(Player.Black.Color + "-p", "C:/Users/komar/OneDrive/Документы/Visual Studio 2015/Projects/ChesslikeGames/ChesslikeGames/Pictures/black-p.png");
            ui.RegisterImage(Player.White.Color + "-p", "C:/Users/komar/OneDrive/Документы/Visual Studio 2015/Projects/ChesslikeGames/ChesslikeGames/Pictures/white-p.png");



            game.Field.Add(new Cell { X = 0, Y = 1 }, new Figure(Player.White, "p"));
            game.Field.Add(new Cell { X = 1, Y = 1 }, new Figure(Player.White, "p"));
            game.Field.Add(new Cell { X = 2, Y = 1 }, new Figure(Player.White, "p"));
            game.Field.Add(new Cell { X = 3, Y = 1 }, new Figure(Player.White, "p"));
            game.Field.Add(new Cell { X = 4, Y = 1 }, new Figure(Player.White, "p"));
            game.Field.Add(new Cell { X = 5, Y = 1 }, new Figure(Player.White, "p"));
            game.Field.Add(new Cell { X = 6, Y = 1 }, new Figure(Player.White, "p"));
            game.Field.Add(new Cell { X = 7, Y = 1 }, new Figure(Player.White, "p"));

            game.Field.Add(new Cell { X = 0, Y = 6 }, new Figure(Player.Black, "p"));
            game.Field.Add(new Cell { X = 1, Y = 6 }, new Figure(Player.Black, "p"));
            game.Field.Add(new Cell { X = 2, Y = 6 }, new Figure(Player.Black, "p"));
            game.Field.Add(new Cell { X = 3, Y = 6 }, new Figure(Player.Black, "p"));
            game.Field.Add(new Cell { X = 4, Y = 6 }, new Figure(Player.Black, "p"));
            game.Field.Add(new Cell { X = 5, Y = 6 }, new Figure(Player.Black, "p"));
            game.Field.Add(new Cell { X = 6, Y = 6 }, new Figure(Player.Black, "p"));
            game.Field.Add(new Cell { X = 7, Y = 6 }, new Figure(Player.Black, "p"));

            game.Field.Add(new Cell { X = 0, Y = 7 }, new Figure(Player.Black, "r"));
            game.Field.Add(new Cell { X = 1, Y = 7 }, new Figure(Player.Black, "h"));
            game.Field.Add(new Cell { X = 2, Y = 7 }, new Figure(Player.Black, "e"));
            game.Field.Add(new Cell { X = 3, Y = 7 }, new Figure(Player.Black, "q"));
            game.Field.Add(new Cell { X = 4, Y = 7 }, new Figure(Player.Black, "k"));
            game.Field.Add(new Cell { X = 5, Y = 7 }, new Figure(Player.Black, "e"));
            game.Field.Add(new Cell { X = 6, Y = 7 }, new Figure(Player.Black, "h"));
            game.Field.Add(new Cell { X = 7, Y = 7 }, new Figure(Player.Black, "r"));

            game.Field.Add(new Cell { X = 0, Y = 0 }, new Figure(Player.White, "r"));
            game.Field.Add(new Cell { X = 1, Y = 0 }, new Figure(Player.White, "h"));
            game.Field.Add(new Cell { X = 2, Y = 0 }, new Figure(Player.White, "e"));
            game.Field.Add(new Cell { X = 3, Y = 0 }, new Figure(Player.White, "q"));
            game.Field.Add(new Cell { X = 4, Y = 0 }, new Figure(Player.White, "k"));
            game.Field.Add(new Cell { X = 5, Y = 0 }, new Figure(Player.White, "e"));
            game.Field.Add(new Cell { X = 6, Y = 0 }, new Figure(Player.White, "h"));
            game.Field.Add(new Cell { X = 7, Y = 0 }, new Figure(Player.White, "r"));

            var app = new Application();
            app.DefaultCommand = new MoveCommand(ui, game, app);
            app.AddCommand(new ExitCommand(app));
            app.AddCommand(new HelpCommand(app));
            app.AddCommand(new ExplainCommand(app));
            app.AddCommand(app.DefaultCommand);
            app.Welcome = game.CurrentPlayer.Color;

            ui.Start();
            app.Run();
            ui.Stop();
        }
    }
}