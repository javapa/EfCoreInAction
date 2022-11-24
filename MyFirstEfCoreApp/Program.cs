// Copyright (c) 2016 Jon P Smith, GitHub: JonPSmith, web: http://www.thereformedprogrammer.net/
// Licensed under MIT licence. See License.txt in the project root for license information.

using System;

namespace MyFirstEfCoreApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(
                $"Commands:{Environment.NewLine}\tl (list){Environment.NewLine}\tu (change url){Environment.NewLine}\tr (resetDb){Environment.NewLine}\te (exit){Environment.NewLine}{Environment.NewLine}Add -l to first two commands if you want to see logs");
            Console.WriteLine(
                $"{Environment.NewLine}Checking if database exists... ");
            Console.WriteLine(Commands.WipeCreateSeed(true) ? "Created database and seeded it." : "It exists.");
            do
            {
                Console.Write("> ");
                var command = Console.ReadLine();
                switch (command)
                {
                    case "l":
                        Commands.ListAll();
                        break;
                    case "u":
                        Commands.ChangeWebUrl();
                        break;
                    case "l -l":
                        Commands.ListAllWithLogs();
                        break;
                    case "u -l":
                        Commands.ChangeWebUrlWithLogs();
                        break;
                    case "r":
                        Commands.WipeCreateSeed(false);
                        break;
                    case "e":
                        return;
                    case "cls":
                        Console.Clear();
                        break;
                    default: 
                        Console.WriteLine("Unknown command.");
                        break;
                }
            } while (true);
        }
    }
}
