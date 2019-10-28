using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
namespace GameProject
{
    class Game
    {
        public int pos = 1; //pozycja kursora w menu

        public void Start()
        {
            Console.SetWindowSize(100, 15);
            Console.CursorVisible = false;
            Champion champ = new Champion(1, Screen.getHeight() - 2); // tworzenie nowej postaci
            Screen.DisplayGame(champ);
            Move(champ, Screen.getHeight(), Screen.getWidth());
        }
        public void Credits()
        {
            Screen.DisplayCredits();
            Console.ReadKey();
        }
        public void Menu()
        {
            ConsoleKeyInfo key;
            while (true)
            {
                Screen.DisplayMenu(pos);
                key = Console.ReadKey();
                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (pos == 1) break;
                        pos--;
                        Screen.DisplayMenu(pos);
                        break;
                    case ConsoleKey.DownArrow:
                        if (pos == 3) break;
                        pos++;
                        Screen.DisplayMenu(pos);
                        break;
                    case ConsoleKey.Enter:
                        if (pos == 1) Start(); //zacznij gre
                        if (pos == 2) Credits(); //napisy
                        if (pos == 3) Environment.Exit(0); //wyjdz z gry
                        break;
                    default:
                        Screen.DisplayMenu(pos);
                        break;
                }
            }
        }
        public void MenuCursor()
        {

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
                        champ.setDirectionDown();
                        champ.MoveChamp(0, 1);
                        System.Threading.Thread.Sleep(20); //delay
                        break;
                    case ConsoleKey.UpArrow:
                        champ.setDirectionUp();
                        champ.MoveChamp(0, -1);
                        System.Threading.Thread.Sleep(20); //delay
                        break;

                }
                while (!Console.KeyAvailable)
                {
                    if (champ.isDirectionUp())
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