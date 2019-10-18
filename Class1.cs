using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;


namespace GameProject
{
    public class Screen
    {
        private static int width = 100;
        private static int height = 25;
        private char[,] screen = new char[height,width];

        public ConsoleColor pickColor()
        {
            Random rnd = new Random();
            var color = Enum.GetValues(typeof(ConsoleColor));
            return (ConsoleColor)color.GetValue(rnd.Next(color.Length));
        }

        public char[,] Fill()
        {
            char[,] buffer = new char[height, width];
            Random rnd = new Random();
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    
                    if (i == 0 || j == 0 || i == height-1 || j == width-1)
                    {
                        buffer[i, j] = '@';
                    }
                }
            }
            return buffer;
        }

        public void Display()
        {
            screen = Fill();
            Console.SetCursorPosition(0, 0);
            Console.BackgroundColor = ConsoleColor.DarkGray;
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (i == 0 || j == 0 || i == height - 1 || j == width - 1)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.ForegroundColor = pickColor();
                    }
                    Console.Write(screen[i, j]);
                    
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }


    }
}
