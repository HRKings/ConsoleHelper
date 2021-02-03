using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleHelper
{
    public static class CLIHelper
    {
        public static int MenuChoice(bool canCancel, int optionsPerLine = 1, params string[] options)
        {
            const int spacingPerLine = 14;

            int currentSelection = 0;

            ConsoleKey key;

            Console.CursorVisible = false;

            (int startX, int startY) = Console.GetCursorPosition();

            do
            {
                for (int i = 0; i < options.Length; i++)
                {
                    Console.SetCursorPosition(startX + (i % optionsPerLine) * spacingPerLine, startY + i / optionsPerLine);

                    if (i == currentSelection)
                        Console.ForegroundColor = ConsoleColor.Blue;

                    Console.Write(options[i]);

                    Console.ResetColor();
                }

                key = Console.ReadKey(true).Key;

                switch (key)
                {
                    case ConsoleKey.LeftArrow:
                        {
                            if (currentSelection % optionsPerLine > 0)
                                currentSelection--;
                            break;
                        }
                    case ConsoleKey.RightArrow:
                        {
                            if (currentSelection % optionsPerLine < optionsPerLine - 1)
                                currentSelection++;
                            break;
                        }
                    case ConsoleKey.UpArrow:
                        {
                            if (currentSelection >= optionsPerLine)
                                currentSelection -= optionsPerLine;
                            break;
                        }
                    case ConsoleKey.DownArrow:
                        {
                            if (currentSelection + optionsPerLine < options.Length)
                                currentSelection += optionsPerLine;
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

        public static List<int> MultipleChoice(int optionsPerLine = 1, params string[] options)
        {
            const int spacingPerLine = 14;

            List<int> result = new();

            int currentSelection = 0;

            ConsoleKey key;

            Console.CursorVisible = false;

            (int startX, int startY) = Console.GetCursorPosition();

            do
            {
                for (int i = 0; i < options.Length; i++)
                {
                    Console.SetCursorPosition(startX + (i % optionsPerLine) * spacingPerLine, startY + i / optionsPerLine);

                    if (i == currentSelection)
                        Console.ForegroundColor = ConsoleColor.Blue;

                    if (result.Contains(i))
                        Console.ForegroundColor = ConsoleColor.Green;

                    Console.Write(options[i]);

                    Console.ResetColor();
                }

                key = Console.ReadKey(true).Key;

                switch (key)
                {
                    case ConsoleKey.LeftArrow:
                        {
                            if (currentSelection % optionsPerLine > 0)
                                currentSelection--;
                            break;
                        }

                    case ConsoleKey.RightArrow:
                        {
                            if (currentSelection % optionsPerLine < optionsPerLine - 1)
                                currentSelection++;
                            break;
                        }

                    case ConsoleKey.UpArrow:
                        {
                            if (currentSelection >= optionsPerLine)
                                currentSelection -= optionsPerLine;
                            break;
                        }

                    case ConsoleKey.DownArrow:
                        {
                            if (currentSelection + optionsPerLine < options.Length)
                                currentSelection += optionsPerLine;
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