using System;
using System.Collections.Generic;
using System.IO;

namespace ConsoleUI
{
    public class Application
    {
        /// <summary>
        /// Command executed when no command found.
        /// arguments passed to the command includes full line, 
        /// unlike other named ommands. By default set to NotFoundCommand
        /// </summary>
        public ICommand DefaultCommand { get; set; }
        public IList<ICommand> Commands { get { return commands; } }
        public string Welcome { get; set; }

        public Application()
        {
            DefaultCommand = new NotFoundCommand();
        }
        public void Exit()
        {
            keepRunning = false;
        }
        public void AddCommand(ICommand cmd)
        {
            commands.Add(cmd);
            if (commandMap.ContainsKey(cmd.Name))
            {
                throw new Exception(string.Format("Команда {0} уже добавлена", cmd.Name));
            }
            commandMap.Add(cmd.Name, cmd);
            foreach (var s in cmd.Synonyms)
            {
                if (commandMap.ContainsKey(s))
                {
                    Console.WriteLine("ERROR: Игнорирую синоним {0} для команды {1}, поскольку имя {0}  уже использовано", s, cmd.Name);
                    continue;
                }
                commandMap.Add(s, cmd);
            }
        }
        public void Run(TextReader reader=null, bool echoInput=false)
        {
            if (reader == null)
            {
                // set input limit to 10M
                var stdin = Console.OpenStandardInput(1024*1024*10);
                reader = new StreamReader(stdin);
            }
            while (keepRunning)
            {
                Console.Write(Welcome + "> ");
                var rawInput = reader.ReadLine();
                if (rawInput == null)
                {
                    break;
                }
                if (echoInput)
                {
                    Console.WriteLine(rawInput);
                }
                var cmdline = rawInput.Split(
                    new[] { ' ', '\t' },
                    StringSplitOptions.RemoveEmptyEntries
                );
                if (cmdline.Length == 0)
                {
                    continue;
                }
                try
                {
                    var cmd = FindCommand(cmdline[0]);
                    if (cmd != null)
                    {
                        var parameters = new string[cmdline.Length - 1];
                        Array.Copy(cmdline, 1, parameters, 0, cmdline.Length - 1);
                        cmd.Execute(parameters);
                    }
                    else
                    {
                        DefaultCommand.Execute(cmdline);
                    }
                }
                catch (Exception x)
                {
                    Console.WriteLine("ERROR: Unexpected exception occured\n{0}",x);
                }
            }
        }

        public  ICommand FindCommand(string s)
        {
            ICommand cmd;
            return !commandMap.TryGetValue(s, out cmd) ? null : cmd;
        }

        private bool keepRunning = true;
        private readonly List<ICommand> commands = new List<ICommand>();
        private readonly Dictionary<string, ICommand> commandMap = new Dictionary<string, ICommand>();
    }
}
