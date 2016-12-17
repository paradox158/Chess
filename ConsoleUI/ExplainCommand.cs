using System;
using System.Collections.Generic;

namespace ConsoleUI
{
    public class ExplainCommand : ICommand
    {
        private const string Line = "================================================";
        private const string Line1 = "...............................................";
        private readonly Application app;

        public ExplainCommand(Application app)
        {
            this.app = app;
        }

        public string Name
        {
            get { return "explain"; }
        }

        public string Help
        {
            get { return "Рассказать о команде или командах"; }
        }

        public string[] Synonyms
        {
            get { return new[] {"elaborate"}; }
        }

        public string Description
        {
            get
            {
                return "Выводит всю доступную информацию по команде или командам." + 
                    " Имена команд передаются как параметры";
            }
        }

        public void Execute(params string[] parameters)
        {
            foreach (var par in parameters)
            {
                var cmd = app.FindCommand(par);
                Console.WriteLine(Line);
                var name = cmd == app.DefaultCommand
                    ? string.Format("[{0}]", par)
                    : par;

                var syns = new List<string>(cmd.Synonyms);
                if (cmd.Name == par)
                {
                    Console.WriteLine("{0}: {1}", name, cmd.Help);
                }
                else
                {
                    Console.WriteLine("{0}: {1}", name, cmd.Help);
                    syns.Remove(par);
                    syns.Add(cmd.Name);
                }
                if (syns.Count > 0)
                {
                    Console.WriteLine("Синонимы: {0}", string.Join(", ", syns));
                }
                if (cmd.Description == string.Empty)
                {
                    continue;
                }
                Console.WriteLine(Line1);
                Console.WriteLine(cmd.Description);
            }
            Console.WriteLine(Line);
        }
    }
}