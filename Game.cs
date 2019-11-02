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
            Console.CursorVisible = false;
            Champion champ = new Champion(1, Screen.getHeight() - 2,Screen.getHeight(),Screen.getWidth()); // tworzenie nowej postaci

            Console.SetWindowSize(Screen.getWidth(), Screen.getHeight()+2);
            while (true)
            {
                champ.setPosStart();
                Screen.DisplayGame(champ);
                Move(champ);
            }

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
        
        public void Move(Champion champ)
        {
            ConsoleKeyInfo key;
            Console.SetCursorPosition(champ.getPosX(), champ.getPosY());
            Console.Write(champ.model);
            while (!Screen.getChange())
            {
                key = Console.ReadKey();

                switch (key.Key)
                {
                    case ConsoleKey.RightArrow:
                        champ.MoveChamp(1, 0);
                        if (champ.isDirectionUp()) champ.MoveChamp(0, -1);
                        else champ.MoveChamp(0, 1);
                       // System.Threading.Thread.Sleep(20); //delay
                        
                        break;
                    case ConsoleKey.LeftArrow:
                        champ.MoveChamp(-1, 0);
                        if (champ.isDirectionUp()) champ.MoveChamp(0, -1);
                        else champ.MoveChamp(0, 1);
                        //System.Threading.Thread.Sleep(20); //delay
                        break;
                    case ConsoleKey.DownArrow:
                        champ.setDirectionDown();
                        champ.MoveChamp(0, 1);

                        //System.Threading.Thread.Sleep(30); //delay

                        break;
                    case ConsoleKey.UpArrow:
                        champ.setDirectionUp();
                        champ.MoveChamp(0, -1);

                        //System.Threading.Thread.Sleep(30); //delay

                        break;

                    case ConsoleKey.Escape:
                        //Console.Clear();
                        Menu();
                        break;

                }
                while (!Console.KeyAvailable)
                {
                    if (champ.isDirectionUp())
                    {
                        champ.MoveChamp(0, -1);
                        if (!champ.CanMove(champ.getPosX(), champ.getPosY() - 1)) break; 
                        System.Threading.Thread.Sleep(30);

                    }
                    else
                    {
                        champ.MoveChamp(0, 1);
                        if (!champ.CanMove(champ.getPosX(), champ.getPosY() + 1)) break;
                        System.Threading.Thread.Sleep(30);

                    }
                    System.Threading.Thread.Sleep(50);
                }
            }
            Screen.ChangeMap(false);
        }
    }
}