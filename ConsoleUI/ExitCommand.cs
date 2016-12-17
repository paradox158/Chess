namespace ConsoleUI
{
    public class ExitCommand : ICommand
    {
        private readonly Application app;
        public ExitCommand(Application app)
        {
            this.app = app;
        }
        public string Name { get { return "exit"; } }
        public string Help { get { return "Выход из программы"; } }
        public string[] Synonyms
        {
            get { return new[] { "quit", "bye" }; }
        }
        public string Description
        {
            get { return "Длинное и подробное описание команды выхода "; }
        }
        public void Execute(params string[] parameters)
        {
            app.Exit();
        }
    }
}
