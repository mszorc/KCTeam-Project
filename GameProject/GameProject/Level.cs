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
            int double_block;
            for (int k = 0; k < tmp_number; k++)
            {
                int direction = rnd.Next(blockDirection.Count);
                if (k == 0) direction = 0;
                double_block = rnd.Next(0, 2);
                if (double_block == 1) direction = 2;
                int block_width = rnd.Next(2, width / 4 - 2);
                int block_height = rnd.Next(5, height - 2);
                if (last_block_width + block_width >= width-2) block_width = width - last_block_width - 2;
                switch (direction)
                {
                    case 0:
                        for (int i = block_height; i < height - 1; i++)
                        {
                            for (int j = last_block_width; j < last_block_width + block_width; j++)
                            {
                                buffer[i, j] = '\u2588';
                            }
                        }
                        last_block_width = last_block_width + block_width + 8;
                        break;
                    case 1:
                        for (int i = 1; i < block_height; i++)
                        {
                            for (int j = last_block_width; j < last_block_width + block_width; j++)
                            {
                                buffer[i, j] = '\u2588';
                            }
                        }
                        last_block_width = last_block_width + 8 + block_width;
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
                        last_block_width = last_block_width + 8 + block_width;
                        break;
                }
            }

            return buffer;
        }
    }
}
