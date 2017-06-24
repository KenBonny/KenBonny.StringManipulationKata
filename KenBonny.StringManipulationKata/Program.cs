using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CommandLine;
using KenBonny.StringManipulationKata.Adapters;
using KenBonny.StringManipulationKata.Capitalisers;
using KenBonny.StringManipulationKata.Commands;

namespace KenBonny.StringManipulationKata
{
    internal static class Program
    {
        private static ICapitaliser _capitaliser;
        
        private static void Main(string[] args)
        {
            var command =
                Parser.Default.ParseArguments<AllLowerCaseCommand,
                        AllUpperCaseCommand,
                        AlternatingCaseCommand,
                        AlternatingWordCaseCommand,
                        AlternativeAlternatingCaseCommand,
                        AlternativeAlternatingWordCaseCommand,
                        CamelCaseCommand>(args)
                    .MapResult((AllLowerCaseCommand cmd) => InitialiseCapitaliser(cmd),
                        (AllUpperCaseCommand cmd) => InitialiseCapitaliser(cmd),
                        (AlternatingCaseCommand cmd) => InitialiseCapitaliser(cmd),
                        (AlternatingWordCaseCommand cmd) => InitialiseCapitaliser(cmd),
                        (AlternativeAlternatingCaseCommand cmd) => InitialiseCapitaliser(cmd),
                        (AlternativeAlternatingWordCaseCommand cmd) => InitialiseCapitaliser(cmd),
                        (CamelCaseCommand cmd) => InitialiseCapitaliser(cmd),
                        errors => InitialiseCapitaliser(new ErrorCommand {Text = string.Join(", ", errors)}));
            
            var capitalisedText = _capitaliser.Capitalise(command);
            Console.WriteLine("Capitalised text: " + capitalisedText);
            
            var noNaughtyWordsCapitaliser = new NaughtyWordsAdapter(_capitaliser, new [] {"fuck", "shit"});
            var cleanCapitalisedText = noNaughtyWordsCapitaliser.Capitalise(command);
            Console.WriteLine("Capitalised text without naughty words: " + cleanCapitalisedText);
        }

        private static Command InitialiseCapitaliser(Command command)
        {
            var capitalisers = new Dictionary<Type, ICapitaliser>
            {
                {typeof(AllLowerCaseCommand), new AllLowerCaseCapitaliser()},
                {typeof(AllUpperCaseCommand), new AllUpperCaseCapitaliser()},
                {typeof(AlternatingCaseCommand), new AlternatingCaseCapitaliser()},
                {typeof(AlternativeAlternatingCaseCommand), new AlternativeAlternatingCaseCapitaliser()},
                {typeof(AlternatingWordCaseCommand), new AlternatingWordCaseCapitaliser()},
                {typeof(AlternativeAlternatingWordCaseCommand), new AlternativeAlternatingWordCaseCapitaliser()},
                {typeof(CamelCaseCommand), new CamelCaseCapitaliser()},
                {typeof(ErrorCommand), new ErrorCapitaliser()}
            };

            _capitaliser = capitalisers[command.GetType()];
            
            return command;
        }
    }
}