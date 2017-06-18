using CommandLine;

namespace KenBonny.StringManipulationKata.Commands
{
    [Verb("cc", HelpText = "CamelCase the text.")]
    public class CamelCaseCommand : Command { }
}