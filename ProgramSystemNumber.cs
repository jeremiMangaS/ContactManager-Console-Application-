using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;

namespace ProgramSystemNumber
{
    class ProgramSystemNumberClass
    {
        static string numberDataFile = @"DataSheet\CountryCode";
        static string[] dataLines => File.ReadAllLines(numberDataFile);

        public static string NumberCodeTake(long number)
        {
            string numberCode = number.ToString().Substring(0, 2);
            return CountryCodeCheck(numberCode);
        }

        public static string CountryCodeCheck(string inputCode)
        {
            string code = "+" + inputCode;
            string secondChoice = inputCode.Substring(0, 1);
            string secondCode = "+" + secondChoice;
            for (int i = 0; i < dataLines.Length; i++)
            {
                string[] column = dataLines[i].Split(',');
                if (code == column[0] || secondCode == column[0])
                {
                    return column[1];
                }
            }
            return "Unknown";
        }

        public static void CodeLoad()
        {
            Console.WriteLine("=== Country Number ===   |   E - Back   |");
            for (int i = 0; i < dataLines.Length; i++)
            {
                string[] column = dataLines[i].Split(',');
                Console.WriteLine($"{column[0]}  |  {column[1]}");
            }
        }
    }
}