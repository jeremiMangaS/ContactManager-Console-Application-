using System;
using System.Collections.Generic;

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
            ProgramSystemClass newContact = new ProgramSystemClass(name, email, number);

            return newContact;
        }

        public static void AddObjectToList(ProgramSystemClass newObject)
        {
            contactManagement.Add(newObject);
        }

        public static void ShowMoreIteration()
        {
            if (contactManagement.Count == 0)
            {
                Console.WriteLine("Contact is still empty...");
            }
            else
            {
                for (int i = 0; i < contactManagement.Count; i++)
                {
                    Console.WriteLine($"hasil {i + 1} : {contactManagement[i].contactName}  |  {contactManagement[i].contactEmail}  |  {contactManagement[i].contactNumber}  | ");
                }
            }
        }

        public static void DefaultContactIteration()
        {
            int defaultIteration = 4;

            if (contactManagement.Count == 0)
            {
                Console.WriteLine("Contact is still empty...");
            }
            else
            {
                for (int i = 0; i < defaultIteration; i++)
                {
                    if ((i + 1) > contactManagement.Count)
                    {
                        Console.WriteLine("");
                    }
                    else
                    {
                        Console.WriteLine($"hasil {i + 1} : {contactManagement[i].contactName}  |  {contactManagement[i].contactEmail}  |  {contactManagement[i].contactNumber}  | ");
                    }
                }
            }
        }

    }
}