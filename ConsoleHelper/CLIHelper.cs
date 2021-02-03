using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleHelper
{
    public static class CLIHelper
    {
        public static int MenuChoice(bool canCancel, string[] descriptions = null, params string[] options)
        {
            int currentSelection = 0;

            ConsoleKey key;

            Console.CursorVisible = false;

            do
            {
                for (int i = 0; i < options.Length; i++)
                {
                    if (i == currentSelection)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine(descriptions is not null ? $">> {options[i]} : {descriptions[i]}".Substring(0, Console.BufferWidth - 2)
                            : $">> {options[i]}".Substring(0, Console.BufferWidth - 2));
                    }
                    else
                    {
                        Console.WriteLine(descriptions is not null ? $"   {options[i]} : {descriptions[i]}".Substring(0, Console.BufferWidth - 2)
                            : $"   {options[i]}".Substring(0, Console.BufferWidth - 2));
                    }

                    Console.ResetColor();
                }

                Console.CursorTop -= options.Length;

                key = Console.ReadKey(true).Key;

                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        {
                            if (currentSelection > 0)
                                currentSelection--;
                            break;
                        }

                    case ConsoleKey.DownArrow:
                        {
                            if (currentSelection < options.Length - 1)
                                currentSelection++;
                            break;
                        }

                    case ConsoleKey.Escape:
                        {
                            if (canCancel)
                                return -1;
                            break;
                        }
                }
            } while (key != ConsoleKey.Enter);

            Console.CursorTop += options.Length;

            Console.CursorVisible = true;
            Console.WriteLine();

            return currentSelection;
        }

        public static List<int> MultipleChoice(string[] descriptions = null, params string[] options)
        {
            List<int> result = new();

            int currentSelection = 0;

            ConsoleKey key;

            Console.CursorVisible = false;

            int padding = ">>  *".Length;

            do
            {
                for (int i = 0; i < options.Length; i++)
                {
                    if (result.Contains(i))
                    {
                        if (i == currentSelection)
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine(descriptions is not null ? $">> {options[i]} * : {descriptions[i]}".Substring(0, Console.BufferWidth - 2)
                                : $">> {options[i]} *".Substring(0, Console.BufferWidth - 10));
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine(descriptions is not null ? $"   {options[i]} * : {descriptions[i]}".Substring(0, Console.BufferWidth - 2)
                                : $"   {options[i]} *".Substring(0, Console.BufferWidth - 2));
                        }
                    }
                    else
                    {
                        if (i == currentSelection)
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine(descriptions is not null ? $">> {options[i]}   : {descriptions[i]}".Substring(0, Console.BufferWidth - 2)
                                : $"   {options[i]} *".PadRight(options[i].Length + padding, ' ').Substring(0, Console.BufferWidth - 2));
                        }
                        else
                        {
                            Console.WriteLine(descriptions is not null ? $"   {options[i]}   : {descriptions[i]}".Substring(0, Console.BufferWidth - 2)
                                : $"   {options[i]}".PadRight(options[i].Length + padding, ' ').Substring(0, Console.BufferWidth - 2));
                        }
                    }

                    Console.ResetColor();
                }

                Console.CursorTop -= options.Length;

                key = Console.ReadKey(true).Key;

                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        {
                            if (currentSelection > 0)
                                currentSelection--;
                            break;
                        }

                    case ConsoleKey.DownArrow:
                        {
                            if (currentSelection < options.Length - 1)
                                currentSelection++;
                            break;
                        }

                    case ConsoleKey.Enter:
                        {
                            if (!result.Contains(currentSelection))
                                result.Add(currentSelection);
                            else
                                _ = result.Remove(currentSelection);
                            break;
                        }
                }
            } while (key != ConsoleKey.Escape);

            Console.CursorVisible = true;

            Console.CursorTop += options.Length;

            Console.WriteLine();

            return result;
        }
    }
}