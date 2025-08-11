using System;
using System.Collections.Generic;
using System.IO;
using ProgramSystemData;

namespace ProgramSystem
{
    class ProgramSystemClass
    {
        private string contactName;
        private string contactEmail;
        private int contactNumber;

        static List<ProgramSystemClass> contactManagement = new List<ProgramSystemClass>(); // List for Contact

        ProgramSystemClass(string name, string email, int number) // Constructor
        {
            this.contactName = name;
            this.contactEmail = email;
            this.contactNumber = number;
        }


        public static ProgramSystemClass CreatingObjectContact(string name, string email, int number)
        {
            // For making object from the Constructor
            ProgramSystemClass newContact = new ProgramSystemClass(name, email, number);
            ProgramSystemDataClass.StringData(name, email, number);
            // Using StringData function as the tempelate for adding it into the data dfile 'txt'
            return newContact;
        }

        public static void AddObjectToList(ProgramSystemClass newObject) => contactManagement.Add(newObject); 
        // Adding object to the List


        public static void ShowMoreIteration()
        {
            // Loop for display the list of saved contacts from Menu
            Console.WriteLine("Is it works ?");
            for (int i = 0; i < contactManagement.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {contactManagement[i].contactName}");
            }
        }

        public static void DefaultContactIteration()
        {
            //Loop for display the list of saved contacts fro default display
            int defaultIteration = 4;
            LoadData();
            if (contactManagement.Count == 0) Console.WriteLine("Data can't be find...");
            else
            {
                for (int i = 0; i < defaultIteration; i++)
                {
                    if ((i + 1) > contactManagement.Count) Console.WriteLine("");
                    else Console.WriteLine($"{i + 1}. {contactManagement[i].contactName} | {contactManagement[i].contactEmail} | {contactManagement[i].contactNumber}  |");
                }
            }
        }

        public static void LoadData() 
        {
            // For loading data from local database txt
            contactManagement.Clear();
            string getFileData = ProgramSystemDataClass.GetDataFile();
            string[] getDataLine = File.ReadAllLines(getFileData);

            for (int i = 0; i < getDataLine.Length; i++)
            {
                string[] column = getDataLine[i].Split(',');
                int.TryParse(column[2], out int numberColumn);
                ProgramSystemClass newObject = new ProgramSystemClass(column[0], column[1], numberColumn);
                contactManagement.Add(newObject);
            }
        }

        public static void DeletingObjectContact(int contactIndex)
        {
            // Method for deleting object from List then rewrite everything into txt data via 'for' loop
            contactManagement.RemoveAt(contactIndex);
            var dataLines = new List<string>();
            for (int i = 0; i < contactManagement.Count; i++)
            {
                // Adding all the data from contactManagement List to dataLines List 
                dataLines.Add($"{contactManagement[i].contactName},{contactManagement[i].contactEmail},{contactManagement[i].contactNumber}");
            }
            ProgramSystemDataClass.StringDataUpdate(dataLines); // Then put it into data file 'txt'
        }

        public static void UpdatingContact(int indexContact)
        {
            string currentName = contactManagement[indexContact].contactName;
            string currentEmail = contactManagement[indexContact].contactEmail;
            int currentNumber = contactManagement[indexContact].contactNumber;

            string newName = currentName;
            string newEmail = currentEmail;
            int newNumber = currentNumber;
            
            while (true)
            {
                if (indexContact > contactManagement.Count) { Console.WriteLine("Index can't be found..."); return; }
                Console.WriteLine($"Contact info : ");
                Console.WriteLine("E. cancel   |   F. Save");
                Console.WriteLine($"A. Name = {newName}");
                Console.WriteLine($"S. Email = {newEmail}");
                Console.WriteLine($"D. Number = {newNumber}");
                Console.WriteLine("Enter index column : ");
                ConsoleKeyInfo column = Console.ReadKey(true);

                if (column.Key == ConsoleKey.A)
                {
                    Console.Write("Name : ");
                    string inputName = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(inputName)) newName = inputName;
                }
                else if (column.Key == ConsoleKey.S)
                {
                    Console.Write("Email : ");
                    string inputEmail = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(inputEmail)) newEmail = inputEmail;
                }
                else if (column.Key == ConsoleKey.D)
                {
                    Console.Write("Number : ");
                    if (!int.TryParse(Console.ReadLine(), out int inputNumber))
                    {
                        Console.WriteLine("Invalid input");
                    }
                    else
                    {
                        newNumber = inputNumber;
                    }
                }
                else if (column.Key == ConsoleKey.E)
                {
                    Console.WriteLine("Cancel edit mode...");
                    return;
                }
                else if (column.Key == ConsoleKey.F)
                {
                    contactManagement[indexContact].contactName = newName;
                    contactManagement[indexContact].contactEmail = newEmail;
                    contactManagement[indexContact].contactNumber = newNumber;
                    Console.WriteLine("Saving...");
                    var dataLines = new List<string>();
                    for (int i = 0; i < contactManagement.Count; i++)
                    {
                        dataLines.Add($"{contactManagement[i].contactName},{contactManagement[i].contactEmail},{contactManagement[i].contactNumber}");
                    }
                    ProgramSystemDataClass.StringDataUpdate(dataLines);
                    return;
                }
                else
                {
                    Console.WriteLine("Invalid input...");
                }
            }
        }

    }
}