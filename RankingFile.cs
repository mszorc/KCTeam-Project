using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace GameProject
{
    static class RankingFile
    {
        private const string Path = "Ranking";
        private static List<SplitData> placements;  

        public static void WriteToFile()
        {
            List<SplitData> sorted = placements.OrderByDescending(o => o.score).ToList();
            sorted = sorted.Take(10).ToList();
            using (StreamWriter writer = new StreamWriter(Path))
            {
                foreach(var line in sorted)
                {
                    writer.WriteLine(line.name + ' ' + line.score);
                }
            }
        }
        public static void ReadFromFile()
        {
            placements = new List<SplitData>();
            if (File.Exists(Path))
            {
                using (StreamReader reader = new StreamReader(Path))
                {
                    while (!reader.EndOfStream)
                    {
                        String line = reader.ReadLine();
                        if (line != "")
                        {
                            string[] temp = line.Split(' ');
                            placements.Add(new SplitData(temp[0], Convert.ToInt32(temp[1])));
                        }
                    }                    
                }
            }
            else
            {
                StreamWriter writer = new StreamWriter(Path);
            }
        }
        public static List<SplitData> getPlacements()
        {
            List<SplitData> sorted = placements.OrderByDescending(o => o.score).ToList();
            sorted = sorted.Take(10).ToList();
            return sorted;
        }
        public static void AddToList(string name, int score)
        {
            placements.Add(new SplitData(name, score));
        }
    }

    public class SplitData
    {
        public string name;
        public int score;
        public SplitData(string name, int score)
        {
            this.name = name;
            this.score = score;
        }
    }
}
