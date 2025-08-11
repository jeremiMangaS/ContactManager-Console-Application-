using System;
using System.Formats.Asn1;
using System.Linq;
using System.Threading;

using MenuSystem;

namespace MainProgram
{
    class MainClassProgram
    {
        static void Main()
        {
            int loadTime = 500;

            while (true)
                {
                    Console.Clear();
                    MenuSystemClass.DefaultHeaderDisplay();
                    MenuSystemClass.DefaultContactDisplay();

                    ConsoleKeyInfo userInput = Console.ReadKey(true);

                if (userInput.Key == ConsoleKey.W)
                {
                    Console.Clear();
                    Thread.Sleep(loadTime);
                    Console.WriteLine("Show more");
                    MenuSystemClass.ShowMoreMenu();
                }
                else if (userInput.Key == ConsoleKey.T)
                {
                    Console.Clear();
                    Thread.Sleep(loadTime);
                    Console.WriteLine("Add");
                    MenuSystemClass.AddContactMenu();
                }
                else if (userInput.Key == ConsoleKey.X)
                {
                    Console.Clear();
                    Thread.Sleep(loadTime);
                    Console.WriteLine("Delete");
                    MenuSystemClass.DeleteContactMenu();
                }
                else if (userInput.Key == ConsoleKey.U)
                {
                    Console.Clear();
                    Thread.Sleep(loadTime);
                    Console.WriteLine("Update");
                    MenuSystemClass.UpdateContactMenu();
                }
                else if (userInput.Key == ConsoleKey.S)
                {
                    Console.Clear();
                    Thread.Sleep(loadTime);
                    Console.WriteLine("Search");
                    MenuSystemClass.SearchingContactMenu();
                }
                else if (userInput.Key == ConsoleKey.G)
                {
                    Thread.Sleep(loadTime);
                    Console.WriteLine("More Information");
                    MenuSystemClass.InfoContactMenu();                    
                }
                else if (userInput.Key == ConsoleKey.E)
                {
                    Console.Clear();
                    Thread.Sleep(loadTime);
                    Console.WriteLine("Exit the program....");
                    Thread.Sleep(loadTime);
                    Console.WriteLine("Thank you...");
                    Thread.Sleep(1000);
                    Console.Clear();
                    return;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Input invalid");
                    Console.WriteLine("Enter a valid key as shown");
                }
                }
        }
    }
}