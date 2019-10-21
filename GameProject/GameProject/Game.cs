using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
namespace GameProject
{
    class Game
    {
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
            Champion newChamp;
            while ((key = Console.ReadKey(true)).Key != ConsoleKey.Escape)
            {
                switch (key.Key)
                {
                    case ConsoleKey.RightArrow:
                        champ = MoveChamp(champ, 1, 0, s);
                        lastMoveRight = true;
                        break;
                    case ConsoleKey.LeftArrow:
                        champ = MoveChamp(champ, -1, 0, s);
                        lastMoveRight = false;
                        break;
                    case ConsoleKey.DownArrow:
                        while (CanMove(champ, s))
                        {
                            if (lastMoveRight)
                            {
                                newChamp = new Champion(champ.getPosX() + 1, champ.getPosY() + 1);
                                if (!CanMove(newChamp, s)) break;
                                champ = MoveChamp(champ, 1, 1, s);
                            }
                            else 
                            {
                                newChamp = new Champion(champ.getPosX() - 1, champ.getPosY() + 1);
                                if (!CanMove(newChamp, s)) break;
                                champ = MoveChamp(champ, -1, 1, s);
                            }
                            System.Threading.Thread.Sleep(60); //delay
                        }
                        break;
                    case ConsoleKey.UpArrow:
                        while (CanMove(champ, s))
                        {
                            if (lastMoveRight) 
                            {
                                newChamp = new Champion(champ.getPosX() + 1, champ.getPosY() - 1);
                                if (!CanMove(newChamp, s)) break;
                                champ = MoveChamp(champ, 1, -1, s);
                            }
                            else 
                            {
                                newChamp = new Champion(champ.getPosX() - 1, champ.getPosY() - 1);
                                if (!CanMove(newChamp, s)) break;
                                champ = MoveChamp(champ, -1, -1, s);
                            }
                            System.Threading.Thread.Sleep(60); //delay
                        }
                        break;
                }
            }
        }
        public Champion MoveChamp(Champion champ, int x, int y, Screen s)
        {
            Champion newChamp = new Champion(champ.getPosX() + x, champ.getPosY() + y);
            if (CanMove(newChamp, s))
            {
                RemoveChamp(champ);
                Console.SetCursorPosition(newChamp.getPosX(), newChamp.getPosY());
                Console.Write("%");

                return newChamp;
            }
            return champ;
        }

        static void RemoveChamp(Champion champ)
        {
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.SetCursorPosition(champ.getPosX(), champ.getPosY());
            Console.Write(" ");
        }
        public bool CanMove(Champion champ, Screen s)
        {
            if (champ.getPosX() < 1 || champ.getPosX() >= s.getWidth() - 1)
                return false;
            if (champ.getPosY() < 1 || champ.getPosY() >= s.getHeight() - 1)
                return false;
            return true;
        }
    }
}
