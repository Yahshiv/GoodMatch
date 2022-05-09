using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GoodMatch
{
    public partial class GoodMatch : Form
    {
        CSVReader reader = new CSVReader();
        FileWriter writer = new FileWriter();

        List<string> maleCandidates = new List<string>();
        List<string> femaleCandidates = new List<string>();
        Dictionary<string, int> results = new Dictionary<string, int>();

        public GoodMatch()
        {
            InitializeComponent();
            writer.ClearLog("log.txt");
        }

        private void buttonManual_Click_1(object sender, EventArgs e)
        {
            string candidate1 = textBoxC1.Text;
            string candidate2 = textBoxC2.Text;

            if (!CheckValidInput(candidate1))
            {
                labelManualResult.Text = "Candidate 1 is not alphabetic!";
                return;
            }
            else if (!CheckValidInput(candidate2))
            {
                labelManualResult.Text = "Candidate 2 is not alphabetic!";
                return;
            }

            labelManualResult.Text = FormatMatch(candidate1, candidate2);
        }

        private void buttonCSV_Click(object sender, EventArgs e)
        {
            labelCSVResult.Text = "Processing...";
            results = new Dictionary<string, int>();
            bool success = reader.ReadCSVFile(textBoxCSV.Text, ref maleCandidates, ref femaleCandidates);

            for (int i = 0; i < maleCandidates.Count; i++)
            {
                for (int j = 0; j < femaleCandidates.Count; j++)
                {
                    FormatMatch(maleCandidates[i], femaleCandidates[j], ref results);
                }
            }

            List<KeyValuePair<string, int>> resultList = results.ToList();
            resultList.Sort((pair1, pair2) => pair1.Value.CompareTo(pair2.Value));
            resultList.Reverse();

            writer.WriteResults(textBoxOutput.Text, ref resultList);
            if (success)
            {
                labelCSVResult.Text = "Result output to specified file.";
            }
            else
            {
                labelCSVResult.Text = "Error reading CSV. Please see log file.";
            }
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
                foreach (char c in data)
                {
                    if (c == data[0])
                    {
                        val++;
                    }
                }
                output += val;
                data = String.Join("", data.Split(data[0]));
            }

            data = output;

            while (data.Length > 2)
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
        static void FormatMatch(string name1, string name2, ref Dictionary<string, int> results)
        {
            int result = (CalculateMatch(name1, name2) + CalculateMatch(name2, name1)) / 2;
            string output = name1 + " matches " + name2 + " " + result + "%";

            if (result >= 80)
            {
                output += ", good match";
            }

            results.Add(output, result);
        }

        static string FormatMatch(string name1, string name2)
        {
            int result = (CalculateMatch(name1, name2) + CalculateMatch(name2, name1)) / 2;
            string output = name1 + " matches " + name2 + " " + result + "%";

            if (result >= 80)
            {
                output += ", good match";
            }

            return output;
        }

        //Requests a candidate name and checks its validity. Repeatedly requests a valid name if the provided name is invalid.
        static bool CheckValidInput(string candidate)
        {
            bool validInput = (candidate.All(Char.IsLetter) && candidate.Length > 0);

            return validInput;
        }
    }
}
