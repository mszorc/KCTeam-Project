using System;

namespace GameProject
{
    public class Champion
    {
        private int pos_x; //pozycja X
        private int pos_y; //pozycja Y
        public char model = '%';

        public Champion(int x, int y)
        {
            pos_x = x;
            pos_y = y;
        }

        public int getPosX()
        {
            return pos_x;
        }

        public void setPosX(int x)
        {
            pos_x = x;
        }

        public int getPosY()
        {
            return pos_y;
        }

        public void setPosY(int y)
        {
            pos_y = y;
        }

        public bool CanMove(int x, int y)
        {
            if (x < 1 || x >= Screen.getWidth() - 1)
            {
                Console.SetCursorPosition(x, y);
                Console.Write(Screen.getChar(x, y));
                return false;
            }
            if (y < 1 || y >= Screen.getHeight() - 1)
            {
                return false;
            }
            if (Screen.getChar(x, y) != ' ' && Screen.getChar(x, y) != '@')
            {
                Console.SetCursorPosition(x, y);
                Console.Write(Screen.getChar(x,y));
                LoseHealth();
                return false;
            }
            return true;
        } 

        public void MoveChamp(int x, int y)
        {
            if (CanMove(pos_x + x, pos_y + y))
            {
                RemoveChamp(pos_x, pos_y);
                Console.SetCursorPosition(pos_x + x, pos_y + y);
                pos_x += x;
                pos_y += y;
                Console.Write(model);
            }
        }

        public void LoseHealth()
        {
            Console.SetCursorPosition(pos_x, pos_y);
            Console.Write(' ');
            pos_x = 1;
            pos_y = 8;
            Console.SetCursorPosition(pos_x, pos_y);
            Console.Write(model);
        }

        private static void RemoveChamp(int x, int y)
        {
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.SetCursorPosition(x, y);
            Console.Write(' ');
        }

    }
}
