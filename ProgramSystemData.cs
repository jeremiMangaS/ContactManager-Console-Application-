using System;
using System.Collections.Generic;
using System.IO;

namespace ProgramSystemData
{
    class ProgramSystemDataClass
    {
        static string fileData = @"LocalDatabaseTxt\UserData.txt";

        public static void StringData(string name, string email, int number)
        {
            File.AppendAllText(fileData, StringDataModel(name, email, number) + Environment.NewLine);
            Console.WriteLine("Berhasil memasukkan ke database !");
        }

        public static void StringDataUpdate(List<string> newDataLines)
        {
            File.WriteAllLines(fileData, newDataLines);
        }

        static string StringDataModel(string name, string email, int number)
        {
            string dataModel = $"{name}, {email}, {number}";

            return dataModel;
        }

        public static string GetDataFile()
        {
            string getFileData = fileData;
            return getFileData;
        }
    }
}