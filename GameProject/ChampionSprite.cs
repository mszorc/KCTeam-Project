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
        private static String Direction;
        private String DirectionUp = "UP";
        private String DirectionDown = "DOWN";

        public static void setDirection(string dir) => Direction = dir;

        public int Points { get; set; }
        public int Health { get; set; }
        public ChampionSprite(Texture2D texture, Texture2D texture_flip): base(texture, texture_flip)
        {
            this.Health = 3;
        }

        public override void Update(List<Sprite> sprites)
        {
            Move();
            if (this.Position.Y <= 0 || this.Position.Y >= (Screen.getHeight() - 2) * 16)
            {
                this.LoseHealth();
            }
            foreach (var Sprite in sprites)
            {
                if (Sprite == this) 
                {
                    continue;
                }
                if (Sprite._texture == Board._pointTexture)
                {
                    Point tmp_point = Sprite.Rectangle.Center;
                    var rect = new Rectangle(tmp_point.X, tmp_point.Y, 1, 1);
                    if (this.Rectangle.Intersects(rect))
                    {
                        this.GetPoint(Sprite, sprites);
                        break;
                    }
                    /*if (this.IsTouchingLeft(coin) || this.IsTouchingRight(coin) ||
                        this.IsTouchingBottom(coin) || this.IsTouchingTop(coin))
                    {
                        this.GetPoint(Sprite, sprites);
                        break;
                    }*/
                    /*if (this.Rectangle.Intersects(rect))
                    {
                        this.GetPoint(Sprite, sprites);
                        break;
                    }*/
                }
                else if (Sprite._texture == Board._exitTexture)
                {
                    if (this.Rectangle.Intersects(Sprite.Rectangle))
                    {
                        Screen.ChangeMap(true);
                        break;
                    }
                }
                else if (Sprite._texture == Board._tornTexture || Sprite._texture == Board._left_tornTexture
                        || Sprite._texture == Board._up_tornTexture || Sprite._texture == Board._right_tornTexture)
                {
                     if (this.Rectangle.Intersects(Sprite.Rectangle))
                     {

                        this.LoseHealth();
                        break;
                     }
                     
                }
                else
                {

                    if (this.Velocity.X > 0 && this.IsTouchingLeft(Sprite))

                    {
                        this.Velocity.X = Sprite.Rectangle.Left - this.Rectangle.Right;
                    }

                    if (this.Velocity.X < 0 && this.IsTouchingRight(Sprite))

                    {
                        this.Velocity.X = Sprite.Rectangle.Right - this.Rectangle.Left;
                    }

                    if (this.Velocity.Y > 0 && this.IsTouchingTop(Sprite))

                    {
                        this.Velocity.Y = Sprite.Rectangle.Top - this.Rectangle.Bottom;
                    }
                    if (this.Velocity.Y < 0 && this.IsTouchingBottom(Sprite))
                    {
                        this.Velocity.Y = Sprite.Rectangle.Bottom - this.Rectangle.Top;
                    }
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
                if (Direction != DirectionDown)
                {
                    _texture = _texture_normal;
                }
                Direction = DirectionDown;
                
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                //Velocity.Y = -Speed;
                if (Direction != DirectionUp)
                {
                    _texture = _texture_flip;
                }
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

        private void GetPoint(Sprite Sprite, List<Sprite> Sprites)
        {
            Sprites.Remove(Sprite);
            Velocity = Vector2.Zero;
            this.Points++;
        }

        private void LoseHealth()
        {
            SoundPlayer sound = new SoundPlayer("death.wav");
            SetPositionStart();
            this.Health--;
            if (!specialLevel)
            {
                Direction = DirectionDown;
                this._texture = _texture_normal;
            }
            else
            {
                Direction = DirectionUp;
                this._texture = _texture_flip;
            }
            
            sound.PlayMusic();
        }

        private void SetPositionStart()
        {
            if (!specialLevel)
            {
                Position.X = 16;
                Position.Y = (Screen.getHeight() - 3) * 16;
                this.Velocity = Vector2.Zero;
            }
            else
            {
                Position.X = (Screen.getWidth() - 3) * 16;
                Position.Y = 16;
                this.Velocity = Vector2.Zero;
            }
        }
    }
}
