using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;


namespace GameProject
{
    public class Screen
    {
        private static int width = 100;

        private static int height = 30;
        private static char[,] screen = new char[height, width];
        public static int titleBeg = height / 4, menuBeg = height / 2, middle = width / 2-8;
        private static int finishX = width - 4;
        private static int finishY = height - 4;
        private static bool change = false;
        private static int level = 1;

        public static void setLevel(int lvl)
        {
            level = lvl;
        }

        public static int getLevel()
        {
            return level;
        }

        public static int getFinishX()
        {
            return finishX;
        }

        public static int getFinishY()
        {
            return finishY;
        }

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

        public static void setChar(int x, int y, char c)
        {
            screen[y, x] = c;
        }

        public static void ChangeMap(bool state)
        {
            change = state;
        }

        public static bool getChange()
        {
            return change;
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
                    buffer[i, j] = ' ';
                }
            }


            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (i == 0 || j == 0 || i == height - 1 || j == width - 1)
                    {
                        buffer[i, j] = '\u2593';
                    }
                }
            }

            buffer = l.BlocksGenerator(buffer, height, width);
            buffer = l.PointsGenerator(buffer, height, width);
            return buffer;
        }

       
        public static char[,] FillRanking()
        {

            char[,] buffer = new char[height, width];
            return buffer;
        }

        public static void DisplayMenu(int position)
        {

            //Console.Clear();
            Console.CursorVisible = false;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(0, 0);
            string title1 = "sample text game", title2 = "ǝɯɐƃ ʇxǝʇ ǝldɯɐs", menu1 = "New Game", menu2 = "Ranking", menu3 = "Credits", menu4 = "Exit";

            for (int i = 0; i < height; i++)
            {
                Console.ForegroundColor = ConsoleColor.White;
                if(i==titleBeg)
                {
                    Console.SetCursorPosition(middle,titleBeg);
                    Console.Write(title1);
                }
                if(i == titleBeg + 2)
                {
                    Console.SetCursorPosition(middle, titleBeg+2);
                    Console.Write(title2);
                }
                if (i == menuBeg)
                {
                    Console.SetCursorPosition(middle, menuBeg);
                    if (position == 1) Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(menu1);
                }
                if (i == menuBeg + 2)
                {
                    Console.SetCursorPosition(middle, menuBeg+2);
                    if (position == 2) Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(menu2);
                }
                if (i == menuBeg + 4)
                {
                    Console.SetCursorPosition(middle, menuBeg+4);
                    if (position == 3) Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(menu3);
                }
                if (i == menuBeg + 6)
                {
                    Console.SetCursorPosition(middle, menuBeg+6);
                    if (position == 4) Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(menu4);
                }
                
                Console.WriteLine();
                //System.Threading.Thread.Sleep(100);
            }

        }

        public static void DisplayRanking()
        {
            //screen = FillRanking();
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            Console.BackgroundColor = ConsoleColor.Black;
            //Console.CursorVisible = false;
            List<SplitData> placements = RankingFile.getPlacements();
            
            foreach(var placement in placements)
            {
                Console.WriteLine(placement.name + ' ' + placement.score);
            }
            Console.SetCursorPosition(0, 0);
            //RankingFile.ReadFromFile();

        }
        public static void DisplayRanking()
        {
            //screen = FillRanking();
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.CursorVisible = false;
            List<SplitData> placements = RankingFile.getPlacements();
            
            foreach(var placement in placements)
            {
                Console.WriteLine(placement.name + ' ' + placement.score);
            }
            Console.SetCursorPosition(0, 0);
            //RankingFile.ReadFromFile();

        }

        public static void DisplayGame(Champion champ) //wyswietlenie tego co w buforze
        {
            screen = Fill(champ);
            Console.SetCursorPosition(0, 0);
            Console.BackgroundColor = ConsoleColor.DarkGray;

            //Console.CursorVisible = false;
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
                    
                    if (i >= height - 4 && i < height - 1 && j >= width - 4 && j < width - 1)
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.DarkGray;
                    }
                    Console.Write(screen[i, j]);

                }
                Console.WriteLine();
            }
            //Console.WriteLine();

            Console.WriteLine("Health: {0} Points: {1} Level: {2}", champ.getHealth(), champ.getPoints(),level); 

        }


        public static void DisplayCredits()
        {
            string name1 = "Adam Sulima Dolina", name2 = "Michał Szorc", name3 = "Piotr Awramiuk";
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            //Console.CursorVisible = false;
            for (int i = 0; i < height; i++)
            {
                if(i==menuBeg)
                {
                    Console.SetCursorPosition(middle, titleBeg+4);
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write(name1);
                }
                if(i==menuBeg+2)
                {
                    Console.SetCursorPosition(middle, titleBeg+6);
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write(name2);
                }
                if(i==menuBeg+4)
                {
                    Console.SetCursorPosition(middle, titleBeg+8);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(name3);
                }

                Console.WriteLine();
            }
        }
    }
}