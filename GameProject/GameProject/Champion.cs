using System;
using System.Collections.Generic;
using System.Text;

namespace GameProject
{
    public class Champion
    {
        private int pos_x; //pozycja X
        private int pos_y; //pozycja Y

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


    }
}
