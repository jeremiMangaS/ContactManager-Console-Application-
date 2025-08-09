using System;

using MenuSystem;

namespace MainProgram
{
    class MainClassProgram
    {
        static void Main()
        {
            while (true)
            {
                MenuSystemClass.DefaultHeaderDisplay();
                MenuSystemClass.DefaultContactDisplay();

                ConsoleKeyInfo userInput = Console.ReadKey(true);

                if (userInput.Key == ConsoleKey.W)
                {
                    Console.WriteLine("Show more");
                    MenuSystemClass.ShowMoreMenu();
                }
                else if (userInput.Key == ConsoleKey.T)
                {
                    Console.WriteLine("Add");
                    MenuSystemClass.AddContactMenu();
                }
                else if (userInput.Key == ConsoleKey.X)
                {
                    Console.WriteLine("Delete");

                    MenuSystemClass.DeleteContactMenu();
                }
                else if (userInput.Key == ConsoleKey.S)
                {
                    Console.WriteLine("Search");
                }
                else if (userInput.Key == ConsoleKey.E)
                {
                    Console.WriteLine("Exit");
                    return;
                }
                else
                {
                    Console.WriteLine("Input invalid");
                    Console.WriteLine("Enter a valid key as shown");
                }                
            }
        }
    }
}