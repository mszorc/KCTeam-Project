using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameProject.Logic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace GameProject
{
    class Board
    {
        public static List<BoardElements> _elemList;
        public Vector2 Position;
        public static Texture2D _borderTexture;
        public static Texture2D _blockTexture;
        public static Texture2D _tornTexture;
        public static Texture2D _spaceTexture;

        public Board(Texture2D border, Texture2D block, Texture2D torn, Texture2D space)
        {
            _borderTexture = border;
            _blockTexture = block;
            _tornTexture = torn;
            _spaceTexture = space;
            _elemList = new List<BoardElements>();
            char[,] buffer = Screen.Fill();
            for(int i=0; i<buffer.GetLength(0); i++)
            {
                for(int j=0; j<buffer.GetLength(1); j++)
                {
                    if (buffer[i, j] != ' ')
                    {
                        BoardElements elem = new BoardElements();
                        elem.PosX = j;
                        elem.PosY = i;
                        elem.Char = buffer[i, j];
                        _elemList.Add(elem);
                    }                 
                }

            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach(BoardElements elem in _elemList)
            {
                Position = new Vector2(elem.PosX*10, elem.PosY*10);
                if (elem.Char == '\u2593')
                {
                    spriteBatch.Draw(_borderTexture, Position, Color.White);
                }
                else if (elem.Char == '#')
                {
                    spriteBatch.Draw(_tornTexture, Position, Color.White);
                }
                else if (elem.Char == '\u2588')
                {
                    spriteBatch.Draw(_blockTexture, Position, Color.White);
                }
                else if (elem.Char == '\u035E' || elem.Char == '_')
                {
                    spriteBatch.Draw(_spaceTexture, Position, Color.White);
                }
            }
            //spriteBatch.Draw(_texture, Position, Color.White);
        }
    }
}
