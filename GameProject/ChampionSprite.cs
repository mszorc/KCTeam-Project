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
    public class ChampionSprite: Sprite
    {
        private String Direction = "NULL";
        private String DirectionUp = "UP";
        private String DirectionDown = "Down";
        public ChampionSprite(Texture2D texture): base(texture)
        {
        }

        public override void Update(List<Sprite> sprites)
        {
            Move();
            
            foreach (var Sprite in sprites)
            {
                if (Sprite == this) 
                {
                    continue;
                }
               
                if (this.Velocity.X > 0 && this.IsTouchingLeft(Sprite))
                {
                    //this.Velocity.X = Sprite.Rectangle.Left - this.Rectangle.Right;
                    this.Velocity.X = 0;
                }

                if (this.Velocity.X < 0 && this.IsTouchingRight(Sprite))
                {
                    //this.Velocity.X = - (this.Rectangle.Left - Sprite.Rectangle.Right);
                    this.Velocity.X = 0;
                }

                if (this.Velocity.Y > 0 && this.IsTouchingTop(Sprite))
                {
                    this.Velocity.Y = this.Rectangle.Bottom - Sprite.Rectangle.Top;
                    //this.Velocity.Y = 0;
                }

                if (this.Velocity.Y < 0 && this.IsTouchingBottom(Sprite))
                {
                    this.Velocity.Y = - (Sprite.Rectangle.Bottom - this.Rectangle.Top);
                    //this.Velocity.Y = 0;
                }
            }

            Position += Velocity;

            Velocity = Vector2.Zero;
        }

        private void Move()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                //Velocity.Y = Speed;
                Direction = DirectionDown;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                //Velocity.Y = -Speed;
                Direction = DirectionUp;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                Velocity.X = -Speed;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                Velocity.X = Speed;
            }

            if (Direction == DirectionUp)
            {
                Velocity.Y = -Speed;
            }
            if (Direction == DirectionDown)
            {
                Velocity.Y = Speed;
            }
        }
    }
}
