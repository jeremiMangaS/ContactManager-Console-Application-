using System;
using System.Collections.Generic;
using System.IO;

namespace ProgramSystemData
{
    class ProgramSystemDataClass
    {
        static string fileData = @"LocalDatabaseTxt\UserData.txt"; // The local database 'txt'

        public static void StringData(string name, string email, long number)
        {
            File.AppendAllText(fileData, StringDataModel(name, email, number) + Environment.NewLine);
            Console.WriteLine("Done... !");
            // Function for adding new object from List into the file data 'txt', using AppendAllText
            // Do the that, the new data will added in the next line (new line cause using Environment.NewLine)
        }

        public static void StringDataUpdate(List<string> newDataLines)
        {
            File.WriteAllLines(fileData, newDataLines);
            // Writeing all lines from previous function into fileData with newDataLines as the parameter 
        }

        static string StringDataModel(string name, string email, long number)
        {
            string dataModel = $"{name},{email},{number}";
            return dataModel;
            // Tempelate for adding the data from List into the data file 'txt' 
        }

        public static string GetDataFile()
        {
            string getFileData = fileData;
            return getFileData;
        }
    }
}