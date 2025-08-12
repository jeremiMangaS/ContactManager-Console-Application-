using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Threading;
using MenuSystem;
using ProgramSystemData;
using ProgramSystemNumber;

namespace ProgramSystem
{
    class ProgramSystemClass
    {
        static int loadTime = 500; // Load duration for all transitions
        private string contactName;
        private string contactEmail;
        private long contactNumber;

        static List<ProgramSystemClass> contactManagement = new List<ProgramSystemClass>(); // List for Contact

        ProgramSystemClass(string name, string email, long number) // Constructor
        {
            this.contactName = name;
            this.contactEmail = email;
            this.contactNumber = number;
        }

        public static bool InputValidation(int userInput)
        {
            if (userInput > contactManagement.Count || userInput <= 0) return false;
            return true;
        }


        public static ProgramSystemClass CreatingObjectContact(string name, string email, long number)
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
            for (int i = 0; i < contactManagement.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {contactManagement[i].contactName}  |  {contactManagement[i].contactEmail}  |  {contactManagement[i].contactNumber}");
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
                long.TryParse(column[2], out long numberColumn);
                ProgramSystemClass newObject = new ProgramSystemClass(column[0], column[1], numberColumn);
                contactManagement.Add(newObject);
            }
        }

        public static void DeletingObjectContact(int contactIndex)
        {
            // Method for deleting object from List then rewrite everything into txt data via 'for' loop
            while (true)
            {
                Console.WriteLine($"Name : {contactManagement[contactIndex].contactName}");
                Console.WriteLine($"Email : {contactManagement[contactIndex].contactEmail}");
                Console.WriteLine($"Number : {contactManagement[contactIndex].contactNumber}");
                Console.WriteLine("Are you sure you want to delete this contact ? Y/n");
                ConsoleKeyInfo userInput = Console.ReadKey(true);
                if (userInput.Key == ConsoleKey.Y)
                {
                    contactManagement.RemoveAt(contactIndex);
                    break;
                }
                else if (userInput.Key == ConsoleKey.N)
                {
                    Console.WriteLine("Cancel deleting contact...");
                    Thread.Sleep(loadTime);
                    Console.Clear();
                    return;
                }
                else Console.WriteLine("Invalid input");
            }
            var dataLines = new List<string>();
            for (int i = 0; i < contactManagement.Count; i++)
            {
                // Adding all the data from contactManagement List to dataLines List 
                dataLines.Add($"{contactManagement[i].contactName},{contactManagement[i].contactEmail},{contactManagement[i].contactNumber}");
            }
            ProgramSystemDataClass.StringDataUpdate(dataLines); // Then put it into data file 'txt'
            Thread.Sleep(loadTime);
            Console.Clear();
            Console.WriteLine("Deleting Successfuly...");
            Thread.Sleep(1000);
            Console.Clear();
        }

        public static void UpdatingContact(int indexContact)
        {
            // Method for Edit/Updating contact.
            // Default value for each variabel so that variables whose values are not edited
            // will remain at their default values. 
            string currentName = contactManagement[indexContact].contactName;
            string currentEmail = contactManagement[indexContact].contactEmail;
            long currentNumber = contactManagement[indexContact].contactNumber;
            // Another variabel for receive the value, which later will be updated according
            // to whetever the user giving input or not.
            string newName = currentName;
            string newEmail = currentEmail;
            long newNumber = currentNumber;
            // Using conditional Loop for the edit phase
            while (true)
            {
                if (indexContact > contactManagement.Count) { Console.WriteLine("Index can't be found..."); return; }
                Console.WriteLine($"Contact info : ");
                Console.WriteLine("E. cancel   |   F. Save");
                Console.WriteLine($"A. Name = {newName}");
                Console.WriteLine($"S. Email = {newEmail}");
                Console.WriteLine($"D. Number = {newNumber}");
                Console.Write("Enter index column : ");
                ConsoleKeyInfo column = Console.ReadKey(true);
                // Using control flow statement for each input given by user
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
                    string tempStringNumber = Console.ReadLine();
                    if (tempStringNumber.Length <= 16 && long.TryParse(tempStringNumber, out long inputNumber)) newNumber = inputNumber;
                    else Console.WriteLine("Invalid input");
                }
                else if (column.Key == ConsoleKey.E)
                {
                    Console.WriteLine("Cancel edit mode...");
                    return;
                }
                else if (column.Key == ConsoleKey.F)
                {
                    // Saving statement for saving new contact data to the 'txt' file
                    contactManagement[indexContact].contactName = newName;
                    contactManagement[indexContact].contactEmail = newEmail;
                    contactManagement[indexContact].contactNumber = newNumber;
                    Thread.Sleep(loadTime);
                    Console.WriteLine("Saving...");
                    var dataLines = new List<string>();
                    for (int i = 0; i < contactManagement.Count; i++)
                    {
                        dataLines.Add($"{contactManagement[i].contactName},{contactManagement[i].contactEmail},{contactManagement[i].contactNumber}");
                    }
                    ProgramSystemDataClass.StringDataUpdate(dataLines);
                    return;
                }
                else Console.WriteLine("Invalid input...");
            }
        }

        public static void SearchingContacts(string searchContent)
        {
            // Method for searching a contact from the Name or Email
            if (string.IsNullOrWhiteSpace(searchContent))
            {
                Console.WriteLine("Keywords cannot be empty");
                return;
            }
            string searchContentLower = searchContent.ToLower();
            List<ProgramSystemClass> searchResult = contactManagement.Where(
                contact => contact.contactName.ToLower().Contains(searchContentLower) ||
                contact.contactEmail.ToLower().Contains(searchContentLower)
            ).ToList(); // Using ToList() for copying data to a new List to perform search process
            if (searchResult.Count == 0)
            {
                Thread.Sleep(loadTime);
                Console.WriteLine("No result found...");
            }
            else
            {
                while (true)
                {
                    for (int i = 0; i < searchResult.Count; i++)
                    {
                        ProgramSystemClass contact = searchResult[i];
                        Console.WriteLine($"{i + 1}. {contact.contactName}  |  {contact.contactEmail}  |  {contact.contactNumber}");
                    }
                    Console.WriteLine("");
                    ConsoleKeyInfo inputUser = Console.ReadKey();
                    if (inputUser.Key == ConsoleKey.E)
                    {
                        break;
                    }
                }
            }
        }

        public static void InformationContact(int contactIndex)
        {
            if (contactIndex > contactManagement.Count)
            {
                Console.WriteLine("Theres no contact with that index...");
                Thread.Sleep(loadTime);
                return;
            }
            while (true)
            {
                Console.Clear();
                long CountryNumber = contactManagement[contactIndex].contactNumber;
                Console.WriteLine("===== Contact Information =====");
                Console.WriteLine($"Name    : {contactManagement[contactIndex].contactName}");
                Console.WriteLine($"Email   : {contactManagement[contactIndex].contactEmail}");
                Console.WriteLine($"Number  : {contactManagement[contactIndex].contactNumber}");
                Console.WriteLine($"Country : {ProgramSystemNumberClass.NumberCodeTake(CountryNumber)}");
                Console.WriteLine("-------------------------------");
                Console.WriteLine("X - Delete  |  U - Edit  | E - Exit |");
                ConsoleKeyInfo inputUser = Console.ReadKey(true);
                if (inputUser.Key == ConsoleKey.X)
                {
                    Console.Clear();
                    Thread.Sleep(loadTime);
                    DeletingObjectContact(contactIndex);
                    return;
                }
                else if (inputUser.Key == ConsoleKey.U)
                {
                    Console.Clear();
                    Thread.Sleep(loadTime);
                    UpdatingContact(contactIndex);
                }
                else if (inputUser.Key == ConsoleKey.E)
                {
                    return;
                }
                else Console.WriteLine("Invalid input...");
            }
        }
    }
}