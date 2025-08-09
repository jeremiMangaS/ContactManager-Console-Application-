using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.IO;
using System.Reflection.Metadata.Ecma335;
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

        public static void AddObjectToList(ProgramSystemClass newObject) => contactManagement.Add(newObject);


        public static void ShowMoreIteration()
        {
            Console.WriteLine("Is it works ?");
            for (int i = 0; i < contactManagement.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {contactManagement[i].contactName}");
            }
        }

        public static void DefaultContactIteration()
        {
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
            contactManagement.RemoveAt(contactIndex);
            var dataLines = new List<string>();
            for (int i = 0; i < contactManagement.Count; i++)
            {
                dataLines.Add($"{contactManagement[i].contactName}, {contactManagement[i].contactEmail}, {contactManagement[i].contactNumber}");
            }
            ProgramSystemDataClass.StringDataUpdate(dataLines);
        }

    }
}