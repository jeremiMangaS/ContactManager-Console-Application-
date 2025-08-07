using System;
using System.Runtime.CompilerServices;
using ProgramSystem;

namespace MenuSystem
{
    class MenuSystemClass
    {
        // Display Model
        public static void DefaultHeaderDisplay()
        {
            Console.WriteLine("                                  --- Contact Management ---                                  ");
            Console.WriteLine("T - Add New Contact  |  W - See More  |  S - Delete Contact  |  X - Search Contact  | E - Exit");
            Console.WriteLine("----------------------------------------------------------------------------------------------");
        }

        public static void DefaultContactDisplay()
        {
            ProgramSystemClass.DefaultContactIteration();
        }

        public static bool RepeatingInput()
        {
            while (true)
            {
                Console.WriteLine("Try again ? Y/n");
                ConsoleKeyInfo userInput = Console.ReadKey();
                if (userInput.Key == ConsoleKey.Y)
                {
                    return true;
                }
                else if (userInput.Key == ConsoleKey.N)
                {
                    return false;
                }
                else
                {
                    Console.WriteLine("Input Invalid");
                }
            }
        }

        public static void AddContactMenu()
        {
            while (true)
            {
                Console.WriteLine("Creating new contact, fill the column. ");
                Console.Write("Name : ");
                string contactName = Console.ReadLine();
                Console.Write("Email : ");
                string contactEmail = Console.ReadLine();
                Console.Write("Number : ");
                if (int.TryParse(Console.ReadLine(), out int contactNumber))
                {
                    Console.Beep();
                    ProgramSystemClass.AddObjectToList(ProgramSystemClass.CreatingObjectContact(contactName, contactEmail, contactNumber));
                    return;
                }
                else
                {
                    Console.WriteLine("Input invalid");
                    Console.WriteLine("Phone numbers consist only of numbers");
                    if (RepeatingInput()) { }
                    else { return; }
                }
            }
        }

        public static void ShowMoreMenu()
        {
            ProgramSystemClass.ShowMoreIteration();
        }



    }
}