using System;

namespace GameProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(100, 15);
            Game g = new Game();
            g.Start();
        }
    }
}
