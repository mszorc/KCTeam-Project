using System;
using System.Collections.Generic;
using System.Text;

namespace GameProject
{
    class Level
    {
        public char[,] Generator(char[,] buffer, int height, int width)
        {
            Random rnd = new Random();
            List<bool> blockDirection = new List<bool> { true, false };
            int tmp_number = rnd.Next(5, 20);
            int last_block_width = 5;
            int blocks_gap = 6;
            int double_block, direction, block_width, block_height;
            for (int k = 0; k < tmp_number; k++)
            {
                direction = rnd.Next(blockDirection.Count);
                block_width = rnd.Next(width/15, width / 4 - 2);
                block_height = rnd.Next(height/2, height - 2);

                if (k == 0) direction = 0;
                else
                {
                    double_block = rnd.Next(0, 100);
                    if (double_block%2 == 0) direction = 2;
                }

                if (last_block_width + block_width >= width - 4)
                {
                    block_width = width - last_block_width - 4;
                }

                switch (direction)
                {
                    case 0:
                        for (int i = height-2; i > height - block_height; i--)
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

                        int tmp_helper = rnd.Next(2, height - 2);

                        for (int i = tmp_helper; i < tmp_helper + 2; i++)
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

            return buffer;
        }
    }
}
