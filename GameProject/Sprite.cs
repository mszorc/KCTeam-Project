using GameProject.Logic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace GameProject
{
    public class Sprite
    {
        public Texture2D _texture;
        public Vector2 Position;
        public Vector2 Velocity;
        public Color Colour = Color.White;
        public float Speed = 5f;
        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle((int)Position.X, (int)Position.Y, _texture.Width, _texture.Height);
            }
        }

        public Sprite(Texture2D texture)
        {
            _texture = texture;
            Position.X = 10;
            Position.Y = (Screen.getHeight()-2)*10;
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
            else if (elem.Char == '\u035E' || elem.Char == '_')
            {
                _texture = Board._spaceTexture;
            }
            else
            {
                _texture = Board._pointTexture;
            }
            Position = new Vector2(elem.PosX * 10, elem.PosY * 10);
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