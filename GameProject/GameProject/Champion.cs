using System;
using System.Collections.Generic;
using System.Text;

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

        public bool CanMove(int x, int y, Screen s)
        {
            if (x < 1 || x >= s.getWidth() - 1)
                return false;
            if (y < 1 || y >= s.getHeight() - 1)
                return false;
            return true;
        }

        static void RemoveChamp(int x, int y)
        {
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.SetCursorPosition(x, y);
            Console.Write(" ");
        }

        public void MoveChamp(int x, int y, Screen s)
        {
            if (CanMove(pos_x + x, pos_y + y, s))
            {
                RemoveChamp(pos_x, pos_y);
                Console.SetCursorPosition(pos_x + x, pos_y + y);
                pos_x += x;
                pos_y += y;
                Console.Write(model);
            }
        }

    }
}
