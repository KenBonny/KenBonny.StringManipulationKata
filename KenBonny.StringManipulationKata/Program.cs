using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CommandLine;
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
        }

        private static Command InitialiseCapitaliser(Command command)
        {
            if(command is AllLowerCaseCommand)
                _capitaliser = new AllLowerCaseCapitaliser();
            if(command is AllUpperCaseCommand)
                _capitaliser = new AllUpperCaseCapitaliser();
            if(command is AlternatingCaseCommand)
                _capitaliser = new AlternatingCaseCapitaliser();
            if(command is AlternativeAlternatingCaseCommand)
                _capitaliser = new AlternativeAlternatingCaseCapitaliser();
            if(command is AlternatingWordCaseCommand)
                _capitaliser = new AlternatingWordCaseCapitaliser();
            if(command is AlternativeAlternatingWordCaseCommand)
                _capitaliser = new AlternativeAlternatingWordCaseCapitaliser();
            if(command is CamelCaseCommand)
                _capitaliser = new CamelCaseCapitaliser();
            if(command is ErrorCommand)
                _capitaliser = new ErrorCapitaliser();
            
            return command;
        }
    }
}