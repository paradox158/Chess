using System;
using ChesslikeGames.GameModel;
using ConsoleUI;
using DrawablesUI;

namespace ChesslikeGames
{
    public class MoveCommand : ICommand
    {
        private readonly Application app;
        private readonly Game game;
        private readonly GameGraphicalGui gui;

        public MoveCommand(GameGraphicalGui gui, Game game, Application app)
        {
            this.gui = gui;
            this.game = game;
            this.app = app;
        }

        public string Name
        {
            get { return "move"; }
        }

        public string Help
        {
            get { return "Сделать следующий игровой ход."; }
        }

        public string Description
        {
            get
            {
                return "В качестве параметров передаются координаты клеток,\n" +
                       "через которые должна пройти фигура, в формате\n" +
                       "<вертикальная коодината, буква><горизонтальная координата, цифра>:\n" +
                       " a1 f8 h3";
                ;
            }
        }

        public string[] Synonyms
        {
            get { return new[] {"m"}; }
        }

        public void Execute(params string[] parameters)
        {
            try
            {
                var move = new Move(parameters);
                var result = game.ProcessMove(move);
                if (!result.Success)
                {
                    Console.WriteLine("Неверный ход: {0}", result.Message);
                }
                else
                {
                    gui.Refresh();
                    if (game.Result.GameHasFinished)
                    {
                        if (game.Result.Winner != null)
                        {
                            Console.WriteLine("{0} выиграли!", game.Result.Winner.Color);
                        }
                        else
                        {
                            Console.WriteLine("ничья!");                            
                        }
                        app.Exit();
                        Console.ReadKey();
                    }
                    app.Welcome = game.CurrentPlayer.Color;
                }
            }
            catch (InvalidCellException ex)
            {
                Console.WriteLine("Не удалось распознать строку `{0}` как координаты клетки", ex.StringRepresentation);
            }
        }
    }
}