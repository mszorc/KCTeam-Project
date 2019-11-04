using System;

namespace GameProject
{
    public class Champion
    {
        private int pos_x; //pozycja X
        private int pos_y; //pozycja Y
        public char model = '%';
        private int points = 0;
        private string directionUp = "UP";
        private string directionDown = "DOWN";
        private string direction = "null";
        private int health;
        public int WindowHeight = 0;
        public int WindowWidth = 0;

        public Champion(int x, int y)
        {
            pos_x = x;
            pos_y = y;
            health = 3;
            WindowHeight = Screen.getHeight();
            WindowWidth = Screen.getWidth();
        }

        public int getPosX()
        {
            return pos_x;
        }

        public void setPosX(int x)
        {
            pos_x = x;
        }

        public int getPosY()
        {
            return pos_y;
        }

        public void setPosY(int y)
        {
            pos_y = y;
        }

        public void setPosStart()
        {
            pos_x = 1;
            pos_y = Screen.getHeight() - 2;
            Console.SetCursorPosition(pos_x, pos_y);
        }

        public void setDirectionUp()
        {
            direction = directionUp;
        }

        public void setDirectionDown()
        {
            direction = directionDown;
        }

        public bool isDirectionUp()
        {
            if (direction == directionUp) return true;
            else return false;
        }

        public int getHealth()
        {
            return health;
        }

        public void setHealth(int health)
        {
            this.health = health;
        }

        public bool isDirectionDown()
        {
            if (direction == directionDown) return true;
            else return false;
        }

        public int getPoints()
        {
            return points;
        }

        public void incrementPoints()
        {
            points++;
        }

        public bool CanMove(int x, int y)
        {

            if (Screen.getChar(x, y) != ' ' && Screen.getChar(x, y) != '\u2593' && Screen.getChar(x, y) != '*')
            {
                //System.Threading.Thread.Sleep(30);
                if (Screen.getChar(x, y) != '\u2588') //block
                {
                    LoseHealth();
                    Console.SetCursorPosition(0, WindowHeight);
                    Console.WriteLine("Health: {0} Points: {1}", health, points);
                }
                else
                {
                    Screen.setChar(x, y, '\u2588');
                    Console.SetCursorPosition(pos_x, pos_y);
                }

                return false;
            }
            if (Screen.getChar(x, y) == '\u2593') return false;

            if (x >= Screen.getFinishX() && y >= Screen.getFinishY())
            {
                if (x >= Screen.getFinishX() || y >= Screen.getFinishY())
                {
                    Screen.ChangeMap(true);
                    if (Screen.getLevel() < 15) Screen.setLevel(Screen.getLevel() + 3);
                }
                return false;
            }
            return true;
        }

        public void MoveChamp(int x, int y)
        {

            //if (Screen.getChar(pos_x + x, pos_y + y) != ' ' && Screen.getChar(pos_x + x, pos_y + y) != '\u2593' && Screen.getChar(pos_x + x, pos_y + y) != '*')
            //{
            //    System.Threading.Thread.Sleep(30);
            //    if (Screen.getChar(pos_x + x, pos_y + y) != '\u2588') //block
            //    {
            //        LoseHealth();
            //        Console.SetCursorPosition(0, WindowHeight);
            //        Console.WriteLine("Health: {0} Points: {1}", health, points);
            //    }
            //    else
            //    {
            //        Screen.setChar(pos_x + x, pos_y + y, '\u2588');
            //        Console.SetCursorPosition(pos_x, pos_y);
            //    }

            //    return;
            //}
            if (CanMove(pos_x + x, pos_y + y))
            {
                RemoveChamp(pos_x, pos_y);
                Console.Write(Screen.getChar(Console.CursorLeft, Console.CursorTop));
                pos_x += x;
                pos_y += y;
                if (Screen.getChar(pos_x, pos_y) != '*')
                {
                    Console.SetCursorPosition(pos_x, pos_y);
                }
                else
                {
                    incrementPoints();
                    Screen.setChar(pos_x, pos_y, ' ');
                    Console.SetCursorPosition(0, WindowHeight);
                    Console.WriteLine("Health: {0} Points: {1}", health, points);
                    Console.SetCursorPosition(pos_x, pos_y);
                }
                Console.Write(model);
                Console.SetCursorPosition(pos_x, pos_y);
            }
            else
            {
                Console.SetCursorPosition(pos_x, pos_y);
                Console.Write(model);
                Console.SetCursorPosition(pos_x, pos_y);
            }



        }

        public void LoseHealth()
        {
            Console.SetCursorPosition(pos_x, pos_y);
            Console.Write(' ');
            setPosStart();
            setDirectionDown();
            Console.SetCursorPosition(pos_x, pos_y);
            Console.Write(model);
            health--;
        }

        private static void RemoveChamp(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Write(' ');
            Console.SetCursorPosition(x, y);
        }

    }
}
