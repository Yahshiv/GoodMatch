using System;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics;

namespace GoodMatch
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();

            string name1, name2;
            List<string> maleCandidates = new List<string>();
            List<string> femaleCandidates = new List<string>();
            Dictionary<string, int> results = new Dictionary<string, int>();

            Console.WriteLine("Welcome to GoodMatch <TM>!");
            //Console.WriteLine("We require 2 names in order to calculate a match.");

            //name1 = GetValidInput("first");
            //name2 = GetValidInput("second");

            //Console.WriteLine("\n" + FormatMatch(name1, name2));

            CSVReader reader = new CSVReader();
            FileWriter writer = new FileWriter();

            writer.ClearLog("log.txt");
            reader.ReadCSVFile("C:/Users/CodeShack/Documents/data.csv", ref maleCandidates, ref femaleCandidates);

            Console.WriteLine("\nMale Candidates:");
            for (int i = 0; i < maleCandidates.Count; i++)
            {
                Console.WriteLine(i+1 + "- " + maleCandidates[i]);
            }
            Console.WriteLine("\nFemale Candidates:");
            for (int i = 0; i < femaleCandidates.Count; i++)
            {
                Console.WriteLine(i+1 +"- " + femaleCandidates[i]);
            }

            for (int i = 0; i < maleCandidates.Count; i++)
            {
                for (int j = 0; j < femaleCandidates.Count; j++)
                {
                    string result = FormatMatch(maleCandidates[i], femaleCandidates[j], ref results);
                }
            }

            List<KeyValuePair<string, int>> resultList = results.ToList();
            resultList.Sort((pair1, pair2) => pair1.Value.CompareTo(pair2.Value));
            resultList.Reverse();

            Console.WriteLine("\nCandidate pairing values: ");
            foreach (var result in resultList)
            {
                Console.WriteLine(result.Key);
            }

            writer.WriteResults("output.txt", ref resultList);

            Console.ReadKey();
            timer.Stop();

            writer.AddLog("log.txt", "\nRuntime: " + timer.Elapsed);
        }

        //Returns the match score for two given names (order specific).
        static int CalculateMatch(string name1, string name2)
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

            return int.Parse(output);
        }

        //Returns a formatted string when provided to names to match
        static string FormatMatch(string name1, string name2, ref Dictionary<string, int> results)
        {
            int result = (CalculateMatch(name1, name2) + CalculateMatch(name2, name1))/2;
            string output = name1 + " matches " + name2 + " " + result + "%";

            if (result >= 80)
            {
                output += ", good match";
            }

            results.Add(output, result);

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
