using System;
using System.Collections.Generic;
using System.Formats.Asn1;
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
            ProgramSystemClass newContact = new ProgramSystemClass(name, email, number);
            ProgramSystemDataClass.StringData(name, email, number);

            return newContact;
        }

        public static void AddObjectToList(ProgramSystemClass newObject)
        {
            contactManagement.Add(newObject);
        }


        public static void ShowMoreIteration()
        {
            string getFileData = ProgramSystemDataClass.GetDataFile();
            string[] getDataLine = File.ReadAllLines(getFileData);

            if (!File.Exists(getFileData)) Console.WriteLine("Data can't be find...");
            else if (getDataLine.Length == 0) Console.WriteLine("Contact is still empty...");
            else
            {
                for (int i = 0; i < getDataLine.Length; i++)
                {
                    string[] column = getDataLine[i].Split(',');
                    if (column.Length == 3)
                    {
                        Console.WriteLine($"{i + 1}. {column[0]}  |  {column[1]}  |  {column[2]}  |");
                    }
                }
            }
        }

        public static void DefaultContactIteration()
        {
            int defaultIteration = 4;
            string getFileData = ProgramSystemDataClass.GetDataFile();
            string[] getDataLine = File.ReadAllLines(getFileData);

            if (!File.Exists(getFileData)) Console.WriteLine("Data can't be find...");
            else if (getDataLine.Length == 0) Console.WriteLine("Contact is still empty...");
            else
            {
                for (int i = 0; i < defaultIteration; i++)
                {

                    string[] column = getDataLine[i].Split(',');

                    if ((i + 1) > getDataLine.Length)
                    {
                        Console.WriteLine("");
                    }
                    else if (column.Length == 3)
                    {
                        Console.WriteLine($"{i + 1}. {column[0]}  |  {column[1]}  |  {column[2]}  |");
                    }
                    else
                    {
                        Console.WriteLine("Invalid data...");
                    }
                }
            }
        }

    }
}