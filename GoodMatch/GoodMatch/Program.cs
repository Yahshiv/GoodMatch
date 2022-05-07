using System;
using System.Linq;

namespace GoodMatch
{
    class Program
    {
        static void Main(string[] args)
        {
            string name1, name2;

            Console.WriteLine("Welcome to GoodMatch <TM>!");
            Console.WriteLine("We require 2 names in order to calculate a match.");

            name1 = GetValidInput("first");
            name2 = GetValidInput("second");

            Console.WriteLine("\n" + FormatMatch(name1, name2));

            Console.ReadKey();
        }

        //Returns the match score for two given names (order specific).
        static long CalculateMatch(string name1, string name2)
        {
            string data = name1 + " matches " + name2;
            string output = "";
            data = data.ToLower();
            data = String.Join("", data.Split(' '));

            while (data != "")
            {
                int val = 0;
                foreach(char c in data)
                {
                    if(c == data[0])
                    {
                        val++;
                    }
                }
                output += val;
                data = String.Join("", data.Split(data[0]));
            }

            data = output;

            while(data.Length > 2)
            {
                output = "";
                while (data != "")
                {
                    int val = 0;
                    int length = data.Length;
                    if (length > 1)
                    {
                        val = int.Parse(data.Substring(0, 1)) + int.Parse(data.Substring(length - 1, 1));
                        data = data.Remove(length - 1, 1).Remove(0, 1);
                    }
                    else
                    {
                        val = int.Parse(data);
                        data = data.Remove(0, 1);
                    }
                    output += val;
                }

                data = output;
            }

            return long.Parse(output);
        }

        //Returns a formatted string when provided to names to match
        static string FormatMatch(string name1, string name2)
        {
            long result = CalculateMatch(name1, name2);
            string output = name1 + " matches " + name2 + " " + result + "%";

            if (result >= 80)
            {
                output += ", good match";
            }

            return output;
        }

        //Requests a candidate name and checks its validity. Repeatedly requests a valid name if the provided name is invalid.
        static string GetValidInput(string title)
        {
            bool validInput = false;
            string name = "";
            while (!validInput)
            {
                Console.Write("\nPlease enter the " + title + " candidates name: ");
                name = Console.ReadLine();

                if (name.All(Char.IsLetter))
                {
                    validInput = true;
                }
                else
                {
                    Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - 1);
                    Console.WriteLine("Invalid Input! " + name + " contains non alphabetic characters. Input must be alphabetic.");
                }
            }

            return name;
        }
    }
}
