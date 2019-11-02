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
        public int lifeNo = 1;
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
            //Console.SetCursorPosition(x, y);
            //Console.Write(Screen.getChar(x, y));
            if (x < 1 || x >= Screen.getWidth() - 1)
            {
                return false;
            }
            if (y < 1 || y >= Screen.getHeight() - 1)
            {
                return false;
            }
            if (Screen.getChar(x, y + 1) == '_'|| Screen.getChar(x,y-1) == '\u035E')
            {
                LoseHealth();
                Console.SetCursorPosition(0, WindowHeight);
                Console.WriteLine("Try: {0} Points: {1}", lifeNo, points);
            }
            if (Screen.getChar(x, y) != ' ' && Screen.getChar(x, y) != '\u2593' && Screen.getChar(x, y) != '*')
            {
                System.Threading.Thread.Sleep(30);
                if (Screen.getChar(x, y) != '\u2588')
                {
                    LoseHealth();
                    Console.SetCursorPosition(0,WindowHeight);
                    Console.WriteLine("Try: {0} Points: {1}", lifeNo, points);
                }
                return false;
            }

            if (x >= Screen.getFinishX() && y >= Screen.getFinishY())
            {
                if (x >= Screen.getFinishX() || y >= Screen.getFinishY()) Screen.ChangeMap(true);
                return false;
            }
            return true;
        } 

        public void MoveChamp(int x, int y)
        {
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
                    Console.Write(' ');
                    Screen.setChar(pos_x, pos_y);
                    Console.SetCursorPosition(0, WindowHeight);
                    Console.WriteLine("Try: {0} Points: {1}", lifeNo, points);
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
            lifeNo++;
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
