using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

namespace GoodMatch
{
    class CSVReader
    {
        FileWriter logger = new FileWriter();

        public bool ReadCSVFile(string path, ref List<string> maleCandidates, ref List<string> femaleCandidates)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();

            maleCandidates = new List<string>();
            femaleCandidates = new List<string>();

            if (File.Exists(path))
            {
                StreamReader streamReader = new StreamReader(path);

                streamReader.BaseStream.Seek(0, SeekOrigin.Begin);

                string entry = streamReader.ReadLine();

                if(entry == null)
                {
                    logger.AddLog("log.txt", "\nNo data in file: " + path);

                    streamReader.Close();
                    timer.Stop();
                    logger.AddLog("log.txt", "\nExecution time of CSV reader: " + timer.Elapsed);
                    return false;
                }

                while (entry != null)
                {
                    ParseCSVData(entry, ref maleCandidates, ref femaleCandidates);

                    entry = streamReader.ReadLine();
                }

                if(maleCandidates.Count == 0 && femaleCandidates.Count == 0)
                {
                    logger.AddLog("log.txt", "\nNo valid data in file: " + path);

                    streamReader.Close();
                    timer.Stop();
                    logger.AddLog("log.txt", "\nExecution time of CSV reader: " + timer.Elapsed);
                    return false;
                }

                if (maleCandidates.Count == 0 || femaleCandidates.Count == 0)
                {
                    logger.AddLog("log.txt", "\nNo valid matches produced as all candidates are the same sex in file: " + path);

                    streamReader.Close();
                    timer.Stop();
                    logger.AddLog("log.txt", "\nExecution time of CSV reader: " + timer.Elapsed);
                    return false;
                }

                logger.AddLog("log.txt", "\nSuccessfully read data from file: " + path);

                streamReader.Close();
                timer.Stop();
                logger.AddLog("log.txt", "\nExecution time of CSV reader: " + timer.Elapsed);
                return true;
            }
            else
            {
                logger.AddLog("log.txt", "No file found at: " + path);
                timer.Stop();
                logger.AddLog("log.txt", "\nExecution time of CSV reader: " + timer.Elapsed);
                return false;
            }
        }

        public void ParseCSVData(string line, ref List<string> maleCandidates, ref List<string> femaleCandidates)
        {
            var data = line.Split(',');

            if (data.Length < 2)
            {
                logger.AddLog("log.txt", "Missing data in entry: " + line);

                return;
            }

            data[0] = String.Join("", data[0].Split(' '));
            data[1] = String.Join("", data[1].Split(' '));

            if (!IsAlphabetic(data[0]) || data[0].Length == 0)
            {
                logger.AddLog("log.txt", "Invalid name in entry: " + line);

                return;
            }

            string sex = data[1][0].ToString().ToLower();

            if (!IsAlphabetic(data[1]) || data[1].Length == 0 || !(sex == "m" || sex == "f"))
            {
                logger.AddLog("log.txt", "Invalid sex in entry: " + line);

                return;
            }

            if(sex == "m")
            {
                if (maleCandidates.Contains(data[0]))
                {
                    logger.AddLog("log.txt", "Duplicate male candidate in entry: " + line);
                    return;
                }
                maleCandidates.Add(data[0]);
            }
            else
            {
                if (femaleCandidates.Contains(data[0]))
                {
                    logger.AddLog("log.txt", "Duplicate female candidate in entry: " + line);
                    return;
                }
                femaleCandidates.Add(data[0]);
            }
        }

        bool IsAlphabetic(string name)
        {
            if (name.All(Char.IsLetter))
            {
                return true;
            }

            return false;
        }
    }
}
