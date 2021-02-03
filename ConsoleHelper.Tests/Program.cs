using System;
using System.Collections.Generic;

namespace ConsoleHelper.Tests
{
    internal class Program
    {
        private static void Main()
        {
            ColorTests();

            Console.WriteLine();

            MenuTests();
        }

        private static void ColorTests()
        {
            ColorConsole.WriteWrappedHeader("Color Console Examples");

            Console.WriteLine("\nUsing a splash of color in your Console code more easily... (plain text)\n");

            ColorConsole.WriteLine("Color me this - in Red", ConsoleColor.Red);

            ColorConsole.WriteWrappedHeader("Off with their green Heads!", headerColor: ConsoleColor.Green);

            ColorConsole.WriteWarning("\nWorking...\n");

            Console.WriteLine("Writing some mixed colors: (plain text)");
            ColorConsole.WriteEmbeddedColorLine("Launch the site with [darkcyan]https://localhost:5200[/darkcyan] and press [yellow]Ctrl-c[/yellow] to exit.\n");

            ColorConsole.WriteSuccess("The operation completed successfully.");
        }

        private static void MenuTests()
        {
            string[] options = { "option_1", "option_2", "option_3", "option_4", "option_5", "option_6" };
            string[] descriptions = { "description_1", "description_2", "description_3", "description_4", "description_5", "description_6" };

            int choice = CLIHelper.MenuChoice(true, descriptions, options);
            if (choice != -1)
                Console.WriteLine($"Your choice was: {options[choice]}");

            Console.WriteLine();

            List<int> choices = CLIHelper.MultipleChoice(descriptions, options);
            string result = string.Empty;
            foreach (int i in choices)
            {
                result += $"{options[i]}, ";
            }
            Console.WriteLine($"Your choice was: {result.TrimEnd(',', ' ')}");
        }
    }
}