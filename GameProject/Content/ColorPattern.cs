using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace GameProject.Content
{
    class ColorPattern
    {
        public Board LoadBrick(ContentManager content)
        {
            Board board = new Board(content.Load<Texture2D>("Red_Level/Border"), content.Load<Texture2D>("Red_Level/Block"),
                content.Load<Texture2D>("Red_Level/Torn"),
                content.Load<Texture2D>("Red_Level/Point"), content.Load<Texture2D>("Red_Level/Exit"),
                content.Load<Texture2D>("Red_Level/TornLeft"), content.Load<Texture2D>("Red_Level/TornRight"),
                content.Load<Texture2D>("Red_Level/TornUp"));
            return board;
        }
    }
}
