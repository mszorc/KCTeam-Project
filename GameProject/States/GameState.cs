using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace GameProject.States
{
    public class GameState : State
    {
        private Texture2D _texture;
        private ChampionSprite _champ;
        private Board _board;
        private List<Sprite> _sprites;

        public GameState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content) : base(game, graphicsDevice, content)
        {
            _texture = content.Load<Texture2D>("Champ");

            _champ = new ChampionSprite(_texture)
            {
                Speed = 8f,
            };

            _board = new Board(content.Load<Texture2D>("Border"), content.Load<Texture2D>("Block"),
                content.Load<Texture2D>("Torn"), content.Load<Texture2D>("Space"),
                content.Load<Texture2D>("Point"));

            _sprites = new List<Sprite>()
            {
                _champ
            };

            foreach (var x in Board._elemList)
            {
                Sprite Sprite = new Sprite(x);
                _sprites.Add(Sprite);
            }
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            
            spriteBatch.Begin();
            //_champ.Draw(spriteBatch);
            //_board.Draw(spriteBatch);
            foreach (var sprite in _sprites)
            {
                sprite.Draw(spriteBatch);
            }
            spriteBatch.End();
            
        }

        public override void PostUpdate(GameTime gameTime)
        {
        }

        public override void Update(GameTime gameTime)
        {
            foreach (var sprite in _sprites)
            {
                sprite.Update(_sprites);
            }

            _champ.Update(_sprites);
        }
    }
}
