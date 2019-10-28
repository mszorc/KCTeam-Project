﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;


namespace GameProject
{
    public static class Screen
    {
        private static int width = 100;
        private static int height = 10;
        private static char[,] screen = new char[height, width];

        public static int getWidth()
        {
            return width;
        }

        public static int getHeight()
        {
            return height;
        }

        public static char getChar(int x, int y)
        {
            return screen[y, x];
        }

        public static ConsoleColor pickColor() //losowy wybor kolorów
        {
            Random rnd = new Random();
            var color = Enum.GetValues(typeof(ConsoleColor));
            return (ConsoleColor)color.GetValue(rnd.Next(color.Length));
        }

        public static char[,] Fill(Champion champ) //wypelnianie bufora (postac, ramka, przeszkody)
        {
            char[,] buffer = new char[height, width];
            Random rnd = new Random();

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    buffer[i, j] = ' ';
                }
            }

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (i == 0 || j == 0 || i == height - 1 || j == width - 1)
                    {
                        buffer[i, j] = '@';
                    }
                }
            }
            buffer[champ.getPosY(), champ.getPosX()] = '%';
            buffer[champ.getPosY(), champ.getPosX() + 3] = 'z';
            return buffer;
        }

        public static void Display(Champion champ) //wyswietlenie tego co w buforze
        {
            screen = Fill(champ);
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
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    Console.Write(screen[i, j]);

                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

    }
}
