using System;
using System.Reflection.Metadata;
using System.Threading;
using ProgramSystem;

namespace MenuSystem
{
    class MenuSystemClass
    {
        static int loadTime = 1500;
        // Display Model
        public static void DefaultHeaderDisplay()
        {
            Console.WriteLine("                                                 -- Contact Management ---                                          ");
            Console.WriteLine("G - Select Contact | T - Add New Contact  |  W - See More  |  X - Delete Contact  |  S - Search Contact  | E - Exit ");
            Console.WriteLine("--------------------------------------------------------------------------------------------------------------------");
        }

        public static void ShowMoreHeaderDisplay()
        {
            Console.WriteLine("                                     --- Contact Management ---                                   ");
            Console.WriteLine("G - Select Contact | T - Add New Contact  |  X - Delete Contact  |  S - Search Contact  | E - Back");
            Console.WriteLine("--------------------------------------------------------------------------------------------------");
        }

        // All method model
        public static void DefaultContactDisplay() => ProgramSystemClass.DefaultContactIteration();

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
                string tempStringNumber = Console.ReadLine();
                if (tempStringNumber.Length <= 16 && long.TryParse(Console.ReadLine(), out long contactNumber))
                {
                    Console.Beep();
                    ProgramSystemClass.AddObjectToList(ProgramSystemClass.CreatingObjectContact(contactName, contactEmail, contactNumber));
                    return;
                }
                else
                {
                    Console.WriteLine("Input invalid");
                    Console.WriteLine("Phone numbers consist only of numbers");
                    Console.WriteLine("Phone number Length must be < 16");
                    if (RepeatingInput()) { }
                    else return;
                }
            }
        }

        public static void ShowMoreMenu()
        {
            int loadTime = 500;
            while (true)
            {
                Console.Clear();
                MenuSystemClass.ShowMoreHeaderDisplay();
                ProgramSystemClass.ShowMoreIteration();

                ConsoleKeyInfo userInput = Console.ReadKey(true);

                if (userInput.Key == ConsoleKey.T)
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

        public static void DeleteContactMenu()
        {
            Console.Write("Enter the contact index : ");
            if (!int.TryParse(Console.ReadLine(), out int contactIndex))
            {
                Console.WriteLine("Input invalid...");
                return;
            }
            if (!ProgramSystemClass.InputValidation(contactIndex))
            {
                Console.WriteLine("\n\nInvalid input.. too long or equal 0");
                Thread.Sleep(loadTime);
                return;
            }
            ProgramSystemClass.DeletingObjectContact(contactIndex - 1);
        }

        public static void UpdateContactMenu()
        {
            Console.Write("Enter contact index : ");
            if (!int.TryParse(Console.ReadLine(), out int indexTarget))
            {
                Console.WriteLine("Invalid input");
                return;
            }
            ProgramSystemClass.UpdatingContact(indexTarget - 1);
        }

        public static void SearchingContactMenu()
        {
            Console.Write("Masukkan kata kunci : ");
            string inputUser = Console.ReadLine();
            ProgramSystemClass.SearchingContacts(inputUser);
        }

        public static void InfoContactMenu()
        {
            Console.Write("Enter the index contact : ");
            if (!int.TryParse(Console.ReadLine(), out int contactIndex)) ;
            ProgramSystemClass.InformationContact(contactIndex - 1);
        }
    }
}