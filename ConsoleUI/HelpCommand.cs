using System;

namespace ConsoleUI
{
    public class HelpCommand : ICommand
    {
        private readonly Application app;
        public string Name { get { return "help"; } }
        public string Help { get { return "Краткая помощь по всем командам"; } }
        public string[] Synonyms
        {
            get { return new[] { "?" }; }
        }
        public string Description
        {
            get { return "Выводит список  команд с краткой помощью"; }
        }

        public HelpCommand(Application app)
        {
            this.app = app;
        }
        public void Execute(params string[] parameters)
        {
            Console.WriteLine(line);
            foreach (var cmd in app.Commands)
            {
                var name = cmd == app.DefaultCommand
                    ? string.Format("[{0}]", cmd.Name)
                    : cmd.Name;
                Console.WriteLine("{0}: {1}", name, cmd.Help);
            }
            Console.WriteLine(line);
        }

        private const string line = "================================================";

    }

}
