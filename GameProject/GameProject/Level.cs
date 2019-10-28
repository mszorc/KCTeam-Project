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
            int tmp_number = rnd.Next(5, 7);
            int last_block_width = 5;
            for (int k = 0; k < tmp_number; k++)
            {
                int direction = rnd.Next(blockDirection.Count);
                int block_width = rnd.Next(6, width / 5 - 2);
                int block_height = rnd.Next(5, height-2);
                if (last_block_width + block_width >= width) break;
                switch (direction)
                {
                    case 0:
                        for (int i = block_height; i < height - 1; i++)
                        {
                            for (int j = last_block_width; j < last_block_width + block_width; j++)
                            {
                                buffer[i, j] = '*';
                            }
                        }
                        last_block_width = last_block_width + block_width + 8;
                        break;
                    case 1:
                        for (int i = 1; i < block_height; i++)
                        {
                            for (int j = last_block_width; j < last_block_width + block_width; j++)
                            {
                                buffer[i, j] = '*';
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
