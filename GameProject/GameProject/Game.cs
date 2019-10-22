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



            while ((key = Console.ReadKey(true)).Key != ConsoleKey.Escape)
            {
                switch (key.Key)
                {
                    case ConsoleKey.RightArrow:
                        champ.MoveChamp(1, 0, s);
                        lastMoveRight = true;
                        break;
                    case ConsoleKey.LeftArrow:
                        champ.MoveChamp(-1, 0, s);
                        lastMoveRight = false;
                        break;
                    case ConsoleKey.DownArrow:
                        if (lastMoveRight)
                        {
                            while (champ.CanMove(champ.getPosX() + 1, champ.getPosY() + 1, s))
                            {
                                champ.MoveChamp(1, 1, s);
                                System.Threading.Thread.Sleep(60); //delay
                            }
                            while (champ.CanMove(champ.getPosX(), champ.getPosY() + 1, s))
                            {
                                champ.MoveChamp(0, 1, s);
                                System.Threading.Thread.Sleep(60); //delay
                            }
                        }
                        else
                        {
                            while (champ.CanMove(champ.getPosX() - 1, champ.getPosY() + 1, s))
                            {
                                champ.MoveChamp(-1, 1, s);
                                System.Threading.Thread.Sleep(60); //delay
                            }
                            while (champ.CanMove(champ.getPosX(), champ.getPosY() + 1, s))
                            {
                                champ.MoveChamp(0, 1, s);
                                System.Threading.Thread.Sleep(60); //delay
                            }
                        }
                        System.Threading.Thread.Sleep(60); //delay
                        break;
                    case ConsoleKey.UpArrow:
                        direction = directionUp;
                        if (lastMoveRight)
                        {
                            while (champ.CanMove(champ.getPosX() + 1, champ.getPosY() - 1, s))
                            {
                                champ.MoveChamp(1, -1, s);
                                System.Threading.Thread.Sleep(60); //delay
                            }
                            while (champ.CanMove(champ.getPosX(), champ.getPosY() - 1, s))
                            {
                                champ.MoveChamp(0, -1, s);
                                System.Threading.Thread.Sleep(60); //delay
                            }
                        }
                        else
                        {
                            while (champ.CanMove(champ.getPosX() - 1, champ.getPosY() - 1, s))
                            {
                                champ.MoveChamp(-1, -1, s);
                                System.Threading.Thread.Sleep(60); //delay
                            }
                            while (champ.CanMove(champ.getPosX(), champ.getPosY() - 1, s))
                            {
                                champ.MoveChamp(0, -1, s);
                                System.Threading.Thread.Sleep(60); //delay
                            }
                        }
                        break;
                }
            }
        }
    }
}
