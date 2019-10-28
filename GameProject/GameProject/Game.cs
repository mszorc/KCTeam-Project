using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
namespace GameProject
{
    class Game
    {
        private string directionUp = "UP";
        private string directionDown = "DOWN";
        private string direction = "null";
        public void Start()
        {
            Console.SetWindowSize(100, 15);
            Console.CursorVisible = false;
            Champion champ = new Champion(1, Screen.getHeight() - 2); // tworzenie nowej postaci
            Screen.Display(champ);
            Move(champ, Screen.getHeight(), Screen.getWidth());
        }
        public void Move(Champion champ, int height, int width)
        {
            ConsoleKeyInfo key;
            while (true)
            {
                key = Console.ReadKey();

                switch (key.Key)
                {
                    case ConsoleKey.RightArrow:
                        champ.MoveChamp(1, 0);
                        System.Threading.Thread.Sleep(20); //delay
                        //if (direction == directionDown) goto case ConsoleKey.DownArrow;
                        //else if (direction == directionUp) goto case ConsoleKey.UpArrow;
                        break;
                    case ConsoleKey.LeftArrow:
                        champ.MoveChamp(-1, 0);
                        System.Threading.Thread.Sleep(20); //delay
                        //if (direction == directionDown) goto case ConsoleKey.DownArrow;
                        //else if (direction == directionUp) goto case ConsoleKey.UpArrow;
                        break;
                    case ConsoleKey.DownArrow:
                        direction = directionDown;
                        champ.MoveChamp(0, 1);
                        System.Threading.Thread.Sleep(20); //delay
                        break;
                    case ConsoleKey.UpArrow:
                        direction = directionUp;
                        champ.MoveChamp(0, -1);
                        System.Threading.Thread.Sleep(20); //delay
                        break;
                }
                while (!Console.KeyAvailable)
                {
                    if (direction == directionUp)
                    {
                        champ.MoveChamp(0, -1);
                    }
                    else
                    {
                        champ.MoveChamp(0, 1);
                    }
                    System.Threading.Thread.Sleep(50);
                }
            }
        }
    }
}
