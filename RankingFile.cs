using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GameProject
{
    static class RankingFile
    {
        private const string Path = "Ranking";

        public static void Write(string score)
        {
            using (StreamWriter writer = File.AppendText(Path))
            {
                writer.WriteLine(score);
            }
        }
        public static void Read()
        {
            using (StreamReader reader = new StreamReader(Path))
            {
                String line = reader.ReadToEnd();
                Console.WriteLine(line);
            }

        }
    }
}
