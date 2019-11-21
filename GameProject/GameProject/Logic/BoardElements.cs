using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject.Logic
{
    class BoardElements
    {
        private char _char;
        private int _posX;
        private int _posY;

        public int PosY { get => _posY; set => _posY = value; }
        public int PosX { get => _posX; set => _posX = value; }
        public char Char { get => _char; set => _char = value; }
    }
}
