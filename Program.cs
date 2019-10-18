using System;

namespace GameProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Screen s = new Screen();
            while(true)
            {
                s.Display();
                System.Threading.Thread.Sleep(100);
            }
            
        }
    }
}
