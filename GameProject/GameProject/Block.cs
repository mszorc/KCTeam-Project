﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GameProject
{
    class Block
    {
        private int start_x;
        private int finish_x;
        private string direction;
        private int height;
        public static string direction_up = "up";
        public static string direction_full = "full";
        public static string direction_down = "down";


        public Block(int start_x, int finish_x, int direction, int height)
        {
            this.start_x = start_x;
            this.finish_x = finish_x;
            if (direction == 0) this.direction = direction_down;
            else if (direction == 1) this.direction = direction_up;
            else if (direction == 2) this.direction = direction_full;
            this.height = height;
        }

        public int getWidth()
        {
            return finish_x - start_x;
        }

        public int getStartX()
        {
            return start_x;
        }

        public int getFinishX()
        {
            return finish_x;
        }

        public int getHeight()
        {
            return height;
        }

        public string getDirection()
        {
            return direction;
        }

    }
}
