using System.IO;
using System.Collections.Generic;

namespace GoodMatch
{
    class FileWriter
    {
        public void WriteResults(string path, ref List<KeyValuePair<string, int>> resultList)
        {
            StreamWriter streamWriter = new StreamWriter(path);

            foreach (var result in resultList)
            {
                streamWriter.WriteLine(result.Key);
            }

            streamWriter.Flush();
            streamWriter.Close();
        }

        public void AddLog(string path, string logEntry)
        {
            StreamWriter logWriter = File.AppendText(path);

            logWriter.WriteLine(logEntry);

            logWriter.Flush();
            logWriter.Close();
        }

        public void ClearLog(string path)
        {
            StreamWriter logWriter = new StreamWriter(path);

            logWriter.WriteLine("Errors and Exceptions:");

            logWriter.Flush();
            logWriter.Close();
        }
    }
}
