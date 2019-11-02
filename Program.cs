using System;

namespace GameProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(100, 40);

            Game g = new Game();
            Console.Title = "Sample Text Game";
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            g.Menu();
        }
    }
}