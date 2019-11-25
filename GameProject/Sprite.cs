using GameProject.Logic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace GameProject
{
    public class Sprite
    {
        public Texture2D _texture;
        public Texture2D _texture_flip;
        public Texture2D _texture_normal;
        public Vector2 Position;
        public Vector2 Velocity;
        public Color Colour = Color.White;
        public float Speed = 4f;

        public static bool specialLevel = false;

        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle((int)Position.X, (int)Position.Y, _texture.Width, _texture.Height);
            }
            set { }

        }

        public void setRect(Rectangle rect)
        {
            Rectangle = rect;
        }

        public Sprite(Texture2D texture)
        {
            _texture = texture;
            Position.X = 16;
            Position.Y = (Screen.getHeight()-3)*16;
        }

        public Sprite(Texture2D texture, Texture2D texture_flip)
        {
            _texture_flip = texture_flip;
            _texture_normal = texture;
            _texture = _texture_normal;
            Position.X = 16;
            Position.Y = (Screen.getHeight() - 3) * 16;
        }

        public Sprite (Texture2D texture,int X, int Y)
        {
            _texture = texture;
            Position.X = X;
            Position.Y = Y;
        }



        public Sprite(BoardElements elem)
        {
            if (elem.Char == '\u2593')
            {
                _texture = Board._borderTexture;
            }
            else if (elem.Char == '#')
            {
                _texture = Board._tornTexture;
            }
            else if (elem.Char == '\u2588')
            {
                _texture = Board._blockTexture;
            }
            else if (elem.Char == '$')
            {
                _texture = Board._pointTexture;
            }
            else if (elem.Char == '/')
            {
                _texture = Board._left_tornTexture;
            }
            else if (elem.Char == '?')
            {
                _texture = Board._right_tornTexture;
            }
            else if (elem.Char == '&')
            {
                _texture = Board._up_tornTexture;
            }
            else
            {
                _texture = Board._exitTexture;
            }
            Position = new Vector2(elem.PosX * 16, elem.PosY * 16);
        }


        public Sprite(BoardElements elem, bool x)
        {
            if (elem.Char == '\u2593')
            {
                _texture = Board._borderTexture;
            }
            else if (elem.Char == '#')
            {
                _texture = Board._tornTexture;
            }
            else if (elem.Char == '\u2588')
            {
                _texture = Board._blockTexture;
            }
            else if (elem.Char == '$')
            {
                _texture = Board._pointTexture;
            }
            else if (elem.Char == '/')
            {
                _texture = Board._left_tornTexture;
            }
            else if (elem.Char == '?')
            {
                _texture = Board._right_tornTexture;
            }
            else if (elem.Char == '&')
            {
                _texture = Board._up_tornTexture;
            }
            else
            {
                _texture = Board._exitTexture;
            }

            if (_texture == Board._exitTexture)
            {
                Position = new Vector2(16, 16);
            }
            else Position = new Vector2((Screen.getWidth()-1-elem.PosX) * 16, (Screen.getHeight()-1-elem.PosY) * 16);

        }
        public virtual void Update(List<Sprite> sprites)
        { 
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this._texture, Position, Color.White);
        }

        #region Collision       
        protected bool IsTouchingLeft(Sprite sprite)
        {
            return this.Rectangle.Right + this.Velocity.X > sprite.Rectangle.Left &&
                this.Rectangle.Left < sprite.Rectangle.Left &&
                this.Rectangle.Bottom > sprite.Rectangle.Top &&
                this.Rectangle.Top < sprite.Rectangle.Bottom;
        }
        protected bool IsTouchingRight(Sprite sprite)
        {
            return this.Rectangle.Left + this.Velocity.X < sprite.Rectangle.Right &&
                this.Rectangle.Right > sprite.Rectangle.Right &&
                this.Rectangle.Bottom > sprite.Rectangle.Top &&
                this.Rectangle.Top < sprite.Rectangle.Bottom;
        }
        protected bool IsTouchingTop(Sprite sprite)
        {
            return this.Rectangle.Bottom + this.Velocity.Y > sprite.Rectangle.Top &&
                this.Rectangle.Top < sprite.Rectangle.Top &&
                this.Rectangle.Right > sprite.Rectangle.Left &&
                this.Rectangle.Left < sprite.Rectangle.Right;
        }
        protected bool IsTouchingBottom(Sprite sprite)
        {
            return this.Rectangle.Top + this.Velocity.Y < sprite.Rectangle.Bottom &&
                this.Rectangle.Bottom > sprite.Rectangle.Bottom &&
                this.Rectangle.Right > sprite.Rectangle.Left &&
                this.Rectangle.Left < sprite.Rectangle.Right;
        }

     
        #endregion
    }
}