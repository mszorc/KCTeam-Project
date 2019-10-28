using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;


namespace GameProject
{
    public  class Screen
    {
        private static int width = 100;
        private static int height = 25;
        private static char[,] screen = new char[height, width];
        public static int titleBeg = height / 4, menuBeg = height / 2, middle = width / 2;

        public static int getWidth()
        {
            return width;
        }

        public static int getHeight()
        {
            return height;
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
            Level l = new Level();
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
            buffer = l.Generator(buffer, height, width);
            buffer[champ.getPosY(), champ.getPosX()] = '%';
            return buffer;
        }
        
        public static char[,] FillMenu()
        {           
            string title1 = "sample text game", title2 = "ǝɯɐƃ ʇxǝʇ ǝןdɯɐs", menu1 = "New Game", menu2 = "Credits", menu3 = "Exit";

            char[,] buffer = new char[height, width];
            for(int i = 0 ; i < height ; i++)
            {
                for(int j=0;j<width;j++)
                {

                    if(i==titleBeg && j==(middle-8))
                    {
                        for(int k=0;k<16;k++)
                        {
                            buffer[i, j] = title1[k];
                            j++;
                        }

                    }else
                    if(i == titleBeg+2 && j == (middle - 8))
                    {
                        for (int k = 0; k < 16; k++)
                        {
                            buffer[i, j] = title2[k];
                            j++;
                        }
                    }
                    if (i == menuBeg && j == middle - 8)
                    {
                        for (int k = 0; k < 8; k++)
                        {
                            buffer[i, j] = menu1[k];
                            j++;
                        }
                    }
                    else
                    if (i == menuBeg+2 && j == middle - 8)
                    {
                        for (int k = 0; k < 7; k++)
                        {
                            buffer[i, j] = menu2[k];
                            j++;
                        }
                    }else
                    if (i == menuBeg+4 && j == middle - 8)
                    {
                        for (int k = 0; k < 4; k++)
                        {
                            buffer[i, j] = menu3[k];
                            j++;
                        }
                    }
                }
            }
            return buffer;
        }
        public static char[,] FillCredits() 
        {
            string name1 = "Adam Sulima-Dolina", name2 = "Michał Szorc", name3 = "Piotr Awramiuk";
            char[,] buffer = new char[height, width];
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (i == menuBeg && j == (middle - 9))
                    {
                        for (int k = 0; k < 18; k++)
                        {
                            buffer[i, j] = name1[k];
                            j++;
                        }

                    }
                    if (i == menuBeg+2 && j == (middle - 6))
                    {
                        for (int k = 0; k < 12; k++)
                        {
                            buffer[i, j] = name2[k];
                            j++;
                        }

                    }
                    if (i == menuBeg+4 && j == (middle - 7))
                    {
                        for (int k = 0; k < 14; k++)
                        {
                            buffer[i, j] = name3[k];
                            j++;
                        }

                    }
                }
            }
            return buffer;
        }
        public static void DisplayMenu(int position)
        {
            screen = FillMenu();
            Console.SetCursorPosition(0, 0);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.CursorVisible = false;
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    if (position == 1)
                        if (i == menuBeg)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write(screen[i,j]);
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write(screen[i, j]);
                        }
                    if (position == 2)
                        if (i == menuBeg+2)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write(screen[i, j]);
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write(screen[i, j]);
                        }
                    if (position == 3)
                        if (i == menuBeg + 4)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write(screen[i, j]);
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write(screen[i, j]);
                        }
                }
                Console.WriteLine();
            }
            Console.WriteLine();

        }

        public static void DisplayGame(Champion champ) //wyswietlenie tego co w buforze
        {
            screen = Fill(champ);
            Console.SetCursorPosition(0, 0);
            Console.BackgroundColor = ConsoleColor.DarkGray;

            Console.CursorVisible = false;
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

        public static void DisplayCredits()
        {
            screen = FillCredits();
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            Console.CursorVisible = false;
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (i == menuBeg || i== menuBeg+2 || i==menuBeg+4) Console.Write(screen[i,j]);                    
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
