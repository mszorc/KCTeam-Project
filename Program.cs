using System;
using System.Threading;

namespace GameProject
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.SetWindowSize(100, 40);
            Console.SetWindowSize(Screen.getWidth(), Screen.getHeight() + 2);
            RankingFile.ReadFromFile();
            Game g = new Game();
            Console.Title = "Sample Text Game";
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            g.Menu();
        }
    }
}