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
        private String Direction = "DOWN";
        private String DirectionUp = "UP";
        private String DirectionDown = "DOWN";

        public int Points { get; set; }
        public int Health { get; set; }
        public ChampionSprite(Texture2D texture, Texture2D texture_flip): base(texture, texture_flip)
        {
            this.Health = 3;
        }

        public override void Update(List<Sprite> sprites)
        {
            Move();
            
            if(this.Position.Y == 0 || this.Position.Y == (Screen.getHeight()-2)*16)
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
                    if (this.IsTouchingLeft(Sprite) || this.IsTouchingRight(Sprite) ||
                        this.IsTouchingBottom(Sprite) || this.IsTouchingTop(Sprite))
                    {
                        this.GetPoint(Sprite, sprites);
                        break;
                    }
                    /*if(this.IsTouchingCenter(Sprite))
                    {
                        this.GetPoint(Sprite, sprites);
                        continue;
                    }*/
                    continue;
                }
                if (Sprite._texture == Board._exitTexture)
                {
                    if (this.IsTouchingLeft(Sprite) || this.IsTouchingRight(Sprite) ||
                        this.IsTouchingBottom(Sprite) || this.IsTouchingTop(Sprite))
                    {
                        Screen.ChangeMap(true);
                        break;
                    }
                }
                if (Sprite._texture == Board._exitTexture)
                {
                    if (this.IsTouchingLeft(Sprite) || this.IsTouchingRight(Sprite) ||
                        this.IsTouchingBottom(Sprite) || this.IsTouchingTop(Sprite))
                    {
                        Screen.ChangeMap(true);
                        break;
                    }
                }
                if (this.Velocity.X > 0 && this.IsTouchingLeft(Sprite))
                {
                    if (Sprite._texture == Board._tornTexture || Sprite._texture == Board._spaceTexture)
                    {
                        this.LoseHealth();
                        break;
                    }
                    this.Velocity.X = Sprite.Rectangle.Left - this.Rectangle.Right;
                }

                if (this.Velocity.X < 0 && this.IsTouchingRight(Sprite))
                {
                    if (Sprite._texture == Board._tornTexture || Sprite._texture == Board._spaceTexture)
                    {
                        this.LoseHealth();
                        break;
                    }
                    this.Velocity.X = - (this.Rectangle.Left - Sprite.Rectangle.Right);
                }

                if (this.Velocity.Y > 0 && this.IsTouchingTop(Sprite))
                {
                    if (Sprite._texture == Board._tornTexture || Sprite._texture == Board._spaceTexture)
                    {
                        this.LoseHealth();
                        break;
                    }
                    this.Velocity.Y = this.Rectangle.Bottom - Sprite.Rectangle.Top;
                }

                if (this.Velocity.Y < 0 && this.IsTouchingBottom(Sprite))
                {
                    if (Sprite._texture == Board._tornTexture || Sprite._texture == Board._spaceTexture)
                    {
                        this.LoseHealth();
                        break;
                    }
                    this.Velocity.Y = - (Sprite.Rectangle.Bottom - this.Rectangle.Top);
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
            this.Direction = "DOWN";
            this._texture = _texture_normal;
            sound.PlayMusic();
        }

        private void SetPositionStart()
        {
            Position.X = 16;
            Position.Y = (Screen.getHeight() - 3) * 16;
            this.Velocity = Vector2.Zero;
        }
    }
}
