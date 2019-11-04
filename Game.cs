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
            //Console.CursorVisible = false;
            Champion champ = new Champion(1, Screen.getHeight() - 2); // tworzenie nowej postaci

            Console.SetWindowSize(Screen.getWidth(), Screen.getHeight()+2);
            while (champ.getHealth() > 0)
            {
                champ.setPosStart();
                Screen.DisplayGame(champ);
                Move(champ);
                if (champ.getHealth() > 0) champ.setHealth(3);
            }
            AddPlacement(champ);
            Menu();

        }
        public void Credits()
        {
            Screen.DisplayCredits();
            Console.ReadKey();
        }

        public void AddPlacement(Champion champ)
        {
            Console.CursorVisible = true;
            Console.SetCursorPosition(0, 0);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            string name = Console.ReadLine();
            RankingFile.AddToList(name, champ.getPoints());
        }

        public void Ranking()
        {
            Screen.DisplayRanking();
            Console.ReadKey();
        }
        public void Menu()
        {
            ConsoleKeyInfo key;
            while (true)
            {

                Console.Clear();
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
                        if (pos == 4) break;
                        pos++;
                        Screen.DisplayMenu(pos);
                        break;
                    case ConsoleKey.Enter:
                        if (pos == 1) Start(); //zacznij gre
                        if (pos == 2) Ranking(); //ranking
                        if (pos == 3) Credits(); //napisy
                        if (pos == 4) 
                        {
                            RankingFile.WriteToFile();
                            Environment.Exit(0); //wyjdz z gry
                        }
                        break;
                    default:
                        Screen.DisplayMenu(pos);
                        break;
                }
            }
        }

        public void Move(Champion champ)
        {
            bool move = true;
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
                        move = true;
                        //System.Threading.Thread.Sleep(50); //delay
                        
                        break;
                    case ConsoleKey.LeftArrow:
                        champ.MoveChamp(-1, 0);
                        if (champ.isDirectionUp()) champ.MoveChamp(0, -1);
                        else champ.MoveChamp(0, 1);
                        move = true;
                        //System.Threading.Thread.Sleep(50); //delay
                        break;
                    case ConsoleKey.DownArrow:
                        champ.setDirectionDown();
                        champ.MoveChamp(0, 1);
                        System.Threading.Thread.Sleep(50); //delay

                        break;
                    case ConsoleKey.UpArrow:
                        champ.setDirectionUp();
                        champ.MoveChamp(0, -1);
                        System.Threading.Thread.Sleep(50); //delay

                        break;

                    case ConsoleKey.Escape:
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.Clear();
                        Menu();
                        break;

                }
                while (!Console.KeyAvailable)
                {
                    if (move)
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
                        System.Threading.Thread.Sleep(40);
                        
                    }
                    move = true;
                }
                if (champ.getHealth() <= 0) break;
                
            }
            Screen.ChangeMap(false);
        }
    }
}