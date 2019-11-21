using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace GameProject
{
    public class ChampionSprite
    {
        private Texture2D _texture;
        public Vector2 Position;
        public float Speed = 2f;

        public ChampionSprite(Texture2D texture)
        {
            _texture = texture;
        }

        public void Update()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                Position.Y += Speed;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                Position.Y -= Speed;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                Position.X -= Speed;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                Position.X += Speed;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, Position, Color.White);
        }

    }
}
