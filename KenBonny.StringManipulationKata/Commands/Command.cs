using CommandLine;

namespace KenBonny.StringManipulationKata.Commands
{
    public abstract class Command
    {
        [Option('t', "text", Required = true,
            HelpText = "The text to capitalize.")]
        public string Text { get; set; }
    }
}