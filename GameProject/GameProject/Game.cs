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
            Screen s = new Screen();                        // tworzenie nowego ekranu
            Champion champ = new Champion(1, s.getHeight() - 2); // tworzenie nowej postaci
            s.Display(champ);
            Move(champ, s.getHeight(), s.getWidth(), s);
        }
        public void Move(Champion champ, int height, int width, Screen s)
        {
            ConsoleKeyInfo key;
            bool lastMoveRight = true;
            while (true)
            {
                key = Console.ReadKey();
                while (!Console.KeyAvailable)
                {
                    if (direction == directionUp)
                    {
                        if (lastMoveRight == true)
                        {
                            if (champ.CanMove(champ.getPosX() + 1, champ.getPosY() - 1, s))
                            {
                                champ.MoveChamp(1, -1, s);
                                System.Threading.Thread.Sleep(60); //delay
                            }
                            else if (champ.CanMove(champ.getPosX(), champ.getPosY() - 1, s))
                            {
                                champ.MoveChamp(0, -1, s);
                                System.Threading.Thread.Sleep(60); //delay
                            }
                        }
                        else
                        {
                            if (champ.CanMove(champ.getPosX() - 1, champ.getPosY() - 1, s))
                            {
                                champ.MoveChamp(-1, -1, s);
                                System.Threading.Thread.Sleep(60); //delay
                            }
                            else if (champ.CanMove(champ.getPosX(), champ.getPosY() - 1, s))
                            {
                                champ.MoveChamp(0, -1, s);
                                System.Threading.Thread.Sleep(60); //delay
                            }
                        }
                    }
                    else if (direction == directionDown)
                    {
                        if (lastMoveRight == true)
                        {
                            if (champ.CanMove(champ.getPosX() + 1, champ.getPosY() + 1, s))
                            {
                                champ.MoveChamp(1, 1, s);
                                System.Threading.Thread.Sleep(60); //delay
                            }
                            else if (champ.CanMove(champ.getPosX(), champ.getPosY() + 1, s))
                            {
                                champ.MoveChamp(0, 1, s);
                                System.Threading.Thread.Sleep(60); //delay
                            }
                        }
                        else
                        {
                            if (champ.CanMove(champ.getPosX() - 1, champ.getPosY() + 1, s))
                            {
                                champ.MoveChamp(-1, 1, s);
                                System.Threading.Thread.Sleep(60); //delay
                            }
                            else if (champ.CanMove(champ.getPosX(), champ.getPosY() + 1, s))
                            {
                                champ.MoveChamp(0, 1, s);
                                System.Threading.Thread.Sleep(60); //delay
                            }
                        }
                    }
                    switch (key.Key)
                    {
                        case ConsoleKey.RightArrow:
                            champ.MoveChamp(1, 0, s);
                            lastMoveRight = true;
                            System.Threading.Thread.Sleep(20); //delay
                            if (direction == directionDown) goto case ConsoleKey.DownArrow;
                            else if (direction == directionUp) goto case ConsoleKey.UpArrow;
                            break;
                        case ConsoleKey.LeftArrow:
                            champ.MoveChamp(-1, 0, s);
                            lastMoveRight = false;
                            System.Threading.Thread.Sleep(20); //delay
                            if (direction == directionDown) goto case ConsoleKey.DownArrow;
                            else if (direction == directionUp) goto case ConsoleKey.UpArrow;
                            break;
                        case ConsoleKey.DownArrow:
                            direction = directionDown;
                            if (lastMoveRight)
                            {
                                if (champ.CanMove(champ.getPosX() + 1, champ.getPosY() + 1, s))
                                {
                                    champ.MoveChamp(1, 1, s);
                                }
                                else if (champ.CanMove(champ.getPosX(), champ.getPosY() + 1, s))
                                {
                                    champ.MoveChamp(0, 1, s);
                                }
                            }
                            else
                            {
                                if (champ.CanMove(champ.getPosX() - 1, champ.getPosY() + 1, s))
                                {
                                    champ.MoveChamp(-1, 1, s);
                                }
                                else if (champ.CanMove(champ.getPosX(), champ.getPosY() + 1, s))
                                {
                                    champ.MoveChamp(0, 1, s);
                                }
                            }
                            System.Threading.Thread.Sleep(20); //delay
                            break;
                        case ConsoleKey.UpArrow:
                            direction = directionUp;
                            if (lastMoveRight)
                            {
                                if (champ.CanMove(champ.getPosX() + 1, champ.getPosY() - 1, s))
                                {
                                    champ.MoveChamp(1, -1, s);
                                }
                                else if (champ.CanMove(champ.getPosX(), champ.getPosY() - 1, s))
                                {
                                    champ.MoveChamp(0, -1, s);
                                }
                            }
                            else
                            {
                                if (champ.CanMove(champ.getPosX() - 1, champ.getPosY() - 1, s))
                                {
                                    champ.MoveChamp(-1, -1, s);
                                }
                                else if (champ.CanMove(champ.getPosX(), champ.getPosY() - 1, s))
                                {
                                    champ.MoveChamp(0, -1, s);
                                }
                            }
                            System.Threading.Thread.Sleep(20); //delay
                            break;
                    }
                }
            }
        }
    }
}
