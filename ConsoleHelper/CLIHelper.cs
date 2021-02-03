using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleHelper
{
    public static class CLIHelper
    {
        public static int MenuChoice(bool canCancel, params string[] options)
        {
            int currentSelection = 0;

            ConsoleKey key;

            Console.CursorVisible = false;

            (int startX, int startY) = Console.GetCursorPosition();

            do
            {
                Console.SetCursorPosition(startX, startY);
                for (int i = 0; i < options.Length; i++)
                {
                    if (i == currentSelection)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine($">> {options[i]}");
                    }
                    else
                    {
                        Console.WriteLine($"   {options[i]}");
                    }

                    Console.ResetColor();
                }

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

            Console.CursorVisible = true;
            Console.WriteLine();

            return currentSelection;
        }

        public static List<int> MultipleChoice(params string[] options)
        {
            List<int> result = new();

            int currentSelection = 0;

            ConsoleKey key;

            Console.CursorVisible = false;

            (int startX, int startY) = Console.GetCursorPosition();

            int padding = ">>  *".Length;

            do
            {
                Console.SetCursorPosition(startX, startY);
                for (int i = 0; i < options.Length; i++)
                {
                    if (result.Contains(i))
                    {
                        if (i == currentSelection)
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine($">> {options[i]} *");
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"   {options[i]} *");
                        }
                    }
                    else
                    {
                        if (i == currentSelection)
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine($">> {options[i]}".PadRight(options[i].Length + padding, ' '));
                        }
                        else
                        {
                            Console.WriteLine($"   {options[i]}".PadRight(options[i].Length + padding, ' '));
                        }
                    }

                    Console.ResetColor();
                }

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

            Console.WriteLine();

            return result;
        }
    }
}