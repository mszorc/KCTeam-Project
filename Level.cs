using System;
using System.Collections.Generic;
using System.Text;

namespace GameProject
{
    class Level
    {

        public char[,] BlocksGenerator(char[,] buffer, int height, int width)
        {
            Random rnd = new Random();
            List<bool> blockDirection = new List<bool> { true, false };
            List<Block> blockList = new List<Block>();
            int tmp_number = rnd.Next(5, 20);
            int last_block_width = 5;
            int blocks_gap = 6;
            int tmp_helper = 0;
            int double_block, direction, block_width, block_height;
            for (int k = 0; k < tmp_number; k++)
            {
                direction = rnd.Next(blockDirection.Count);
                block_width = rnd.Next(width / 15, width / 4 - 2);
                block_height = rnd.Next(height / 3, height - 3);

                if (k == 0) direction = 0;
                else
                {
                    double_block = rnd.Next(0, 100);
                    if (double_block % 2 == 0)
                    {
                        direction = 2;
                        tmp_helper = rnd.Next(4, height - 4);
                        block_height = tmp_helper;
                    }

                }
                if (last_block_width + block_width >= width - 5)
                {
                    block_width = width - last_block_width - 5;
                }
                if (block_width > 0) blockList.Add(new Block(last_block_width, last_block_width + block_width, direction, block_height));
                switch (direction)
                {
                    case 0:
                        for (int i = height - 2; i > height - block_height; i--)
                        {
                            for (int j = last_block_width; j < last_block_width + block_width; j++)
                            {
                                buffer[i, j] = '\u2588';
                            }
                        }
                        last_block_width = last_block_width + block_width + blocks_gap;
                        break;

                    case 1:
                        for (int i = 1; i < block_height; i++)
                        {
                            for (int j = last_block_width; j < last_block_width + block_width; j++)
                            {
                                buffer[i, j] = '\u2588';
                            }
                        }
                        last_block_width = last_block_width + blocks_gap + block_width;
                        break;

                    case 2:
                        for (int i = 1; i < height - 1; i++)
                        {
                            for (int j = last_block_width; j < last_block_width + block_width; j++)
                            {
                                buffer[i, j] = '\u2588';
                            }
                        }

                        for (int i = tmp_helper; i < tmp_helper + 4; i++)

                        {
                            for (int j = last_block_width; j < last_block_width + block_width; j++)
                            {
                                buffer[i, j] = ' ';
                            }
                        }
                        last_block_width = last_block_width + blocks_gap + block_width;
                        break;
                }
            }
            buffer = TornsGenerator(buffer, height, width, blockList);


            buffer = GapGenertor(buffer, height, width, blockList);

            /*for(int i = 1; i < height-1; i = i + (height - 3))
            {
                for(int j = 1; j<width-5; j++)
                {
                    if(i==1)
                    {
                        if (buffer[i, j] == ' ') buffer[i, j] = '\u25BC';
                    }
                    else
                    {
                        if (j == 1) j += blocks_gap+1;                     
                        if (buffer[i, j] == ' ') buffer[i, j ] = '\u25B2';
                    }
                }
            }*/
            //generowanie punktów - do zrobienia

            return buffer;
        }

        public char[,] TornsGenerator(char[,] buffer, int height, int width, List<Block> blockList)
        {
            Random rnd = new Random();
            foreach (Block b in blockList)
            {
                int torn_sets_number = rnd.Next(1, 6);
                int torn_number = 0;
                int position = 0;
                int starting_block = 0;
                if (torn_sets_number >= 1 && b.getDirection() != Block.direction_full && Screen.getLevel() >= 0)
                {
                    torn_number = rnd.Next(1, b.getWidth());
                    if (b.getDirection() == Block.direction_down) position = height - b.getHeight();
                    else if (b.getDirection() == Block.direction_up) position = b.getHeight();
                    starting_block = rnd.Next(b.getStartX(), b.getFinishX() - (b.getWidth() / 2));
                    for (int i = starting_block; i < starting_block + torn_number && i < b.getFinishX(); i++)
                    {
                        buffer[position, i] = '#';
                    }

                }

                if (torn_sets_number >= 2 && b.getDirection() != Block.direction_full && Screen.getLevel() >= 3)
                {

                    torn_number = rnd.Next(3, b.getHeight());
                    position = b.getStartX() - 1;
                    if (b.getDirection() == Block.direction_down)
                    {
                        starting_block = rnd.Next(height - b.getHeight() + 1, height - 2);
                        for (int i = starting_block; i < starting_block + torn_number && i < height - 2; i++)
                        {
                            buffer[i, position] = '#';
                        }
                    }
                    else
                    {
                        starting_block = rnd.Next(1, b.getHeight());
                        for (int i = starting_block; i < starting_block + torn_number && i < b.getHeight(); i++)
                        {
                            buffer[i, position] = '#';
                        }
                    }
                }

                if (torn_sets_number == 3 && b.getDirection() != Block.direction_full && Screen.getLevel() >= 6)
                {
                    torn_number = rnd.Next(3, b.getHeight());
                    position = b.getFinishX();
                    if (b.getDirection() == Block.direction_down)
                    {
                        starting_block = rnd.Next(height - b.getHeight() + 1, height - 2);
                        for (int i = starting_block; i < starting_block + torn_number && i < height - 2; i++)
                        {
                            buffer[i, position] = '#';
                        }
                    }
                    else
                    {
                        starting_block = rnd.Next(1, b.getHeight());
                        for (int i = starting_block; i < starting_block + torn_number && i < b.getHeight(); i++)
                        {
                            buffer[i, position] = '#';
                        }
                    }
                }

                if (b.getDirection() == Block.direction_full)
                {

                    starting_block = rnd.Next(1, height / 2);
                    torn_number = rnd.Next(1, height - 2);
                    int sides = rnd.Next(0, 4);
                    if (sides == 0)
                    {
                        position = b.getStartX() - 1;
                        for (int i = starting_block; i < starting_block + torn_number && i < height - 2; i++)
                        {
                            if (buffer[i, position + 1] != ' ') buffer[i, position] = '#';
                            else break;
                        }
                    }
                    else
                    {
                        position = b.getFinishX();
                        for (int i = starting_block; i < starting_block + torn_number && i < height - 2; i++)
                        {
                            if (buffer[i, position - 1] != ' ') buffer[i, position] = '#';
                            else break;
                        }
                    }
                }
            }
            return buffer;
        }

        public char[,] GapGenertor(char[,] buffer, int height, int width, List<Block> blockList)
        {
            Random rnd = new Random();
            int length = 0;
            int isGapRoll = 0;
            int j = 1;
            bool isGap = false;
            bool wasGap = false;

            foreach (Block b in blockList) //if (string.Equals(b.getDirection(), "down") == false)
                {

                    while (j < b.getStartX())
                    {
                        isGapRoll = rnd.Next(1, 100);

                        length = rnd.Next(2, 5);

                        if (wasGap == true)
                        {
                            j += length;
                            wasGap = false;
                        }
                        else
                        {
                            if (isGapRoll < 40) isGap = true;

                            if (isGap == true)
                            {
                                for (int k = 0; k < length; k++)
                                {
                                    if (j < b.getStartX()) buffer[0, j] = '\u035E';
                                    j++;
                                }
                                wasGap = true;
                            }
                            else
                            {
                                j += (length - 1);
                                wasGap = false;
                            }
                        }

                    }
                    j = b.getFinishX() + 1;
                }

            isGap = false;
            wasGap = false;
            isGapRoll = 0;
            j = 5;
            length = 0;

            foreach (Block b in blockList) //if (string.Equals(b.getDirection(), "up") == false)
                {

                    while (j < b.getStartX())
                    {
                        isGapRoll = rnd.Next(1, 100);

                        length = rnd.Next(2, 5);

                        if (wasGap == true)
                        {
                            j += length;
                            wasGap = false;
                        }
                        else
                        {
                            if (isGapRoll < 40) isGap = true;

                            if (isGap == true)
                            {
                                for (int k = 0; k < length; k++)
                                {
                                    if (j < b.getStartX()) buffer[height - 1, j] = '_';
                                    j++;
                                }
                                wasGap = true;
                            }
                            else
                            {
                                j += (length - 1);
                                wasGap = false;
                            }
                        }

                    }
                    j = b.getFinishX() + 1;
                }
            return buffer;
        }

        public char[,] PointsGenerator(char[,] buffer, int height, int width) 
        {
            Random rnd = new Random();
            int numOfPoints = rnd.Next(1, 10);
            int rndHeight = 0;
            int rndWidth = 0;
            for (int i = 0; i< numOfPoints; i++)
            {
                while(buffer[rndHeight, rndWidth] != ' ')
                {
                    rndHeight = rnd.Next(2, height - 2);
                    rndWidth = rnd.Next(4, width - 5);
                }
                buffer[rndHeight, rndWidth] = '*';
            }
            return buffer;
        }
    }
}


