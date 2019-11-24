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


namespace GameProject.States
{
    public class GameState : State
    {
        private Texture2D _texture;
        private Texture2D _texture_flip;
        private ChampionSprite _champ;
        private Board _board;
        private List<Sprite> _sprites;
        private SpriteFont _font;

        public GameState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content) : base(game, graphicsDevice, content)
        {
            _texture = content.Load<Texture2D>("Champ");
            _texture_flip = content.Load<Texture2D>("ChampFlip");
            _font = content.Load<SpriteFont>("Fonts/Font");
            _champ = new ChampionSprite(_texture, _texture_flip)
            {
                Speed = 4f,
            };
            Random rnd = new Random();
            int level = rnd.Next(1, 3);
            //int level = 2;
            switch (level)
            {
                case 1:
                    _board = new Board(content.Load<Texture2D>("Red_Level/Border"), content.Load<Texture2D>("Red_Level/Block"),
                content.Load<Texture2D>("Red_Level/Torn"),
                content.Load<Texture2D>("Red_Level/Point"), content.Load<Texture2D>("Red_Level/Exit"),
                content.Load<Texture2D>("Red_Level/TornLeft"), content.Load<Texture2D>("Red_Level/TornRight"),
                content.Load<Texture2D>("Red_Level/TornUp"));
                    _sprites = new List<Sprite>()
                    {

                        new Sprite(content.Load<Texture2D>("Red_Level/Background"), 0, 0),
                        _champ
                    };
                    break;
                case 2:
                    _board = new Board(content.Load<Texture2D>("Ice_Level/Border"), content.Load<Texture2D>("Ice_Level/Block"),
                content.Load<Texture2D>("Ice_Level/Torn"),
                content.Load<Texture2D>("Ice_Level/Point"), content.Load<Texture2D>("Ice_Level/Exit"),
                content.Load<Texture2D>("Ice_Level/TornLeft"), content.Load<Texture2D>("Ice_Level/TornRight"),
                content.Load<Texture2D>("Ice_Level/TornUp"));
                    _sprites = new List<Sprite>()
                    {

                        new Sprite(content.Load<Texture2D>("Ice_Level/Background"), 0, 0),
                        _champ
                    };
                    break;
            }
                      

            
            foreach (var x in Board._elemList)
            {
                Sprite Sprite = new Sprite(x);
                _sprites.Add(Sprite);
            }
        }

        public GameState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content, ChampionSprite champ) : base(game, graphicsDevice, content, champ)
        {
            _texture = content.Load<Texture2D>("Champ");
            _texture_flip = content.Load<Texture2D>("ChampFlip");
            _font = content.Load<SpriteFont>("Fonts/Font");
            float tmp_speed = 0f;
            if (Screen.getLevel() % 10 == 0) tmp_speed = champ.Speed * 2;
            else tmp_speed = champ.Speed;
            _champ = new ChampionSprite(_texture, _texture_flip)
            {
                Points = champ.Points,
                Speed = tmp_speed,
            };


            Random rnd = new Random();
            int level = rnd.Next(1, 3);

            switch (level)
            {
                case 1:
                    _board = new Board(content.Load<Texture2D>("Red_Level/Border"), content.Load<Texture2D>("Red_Level/Block"),
                content.Load<Texture2D>("Red_Level/Torn"),
                content.Load<Texture2D>("Red_Level/Point"), content.Load<Texture2D>("Red_Level/Exit"),
                content.Load<Texture2D>("Red_Level/TornLeft"), content.Load<Texture2D>("Red_Level/TornRight"),
                content.Load<Texture2D>("Red_Level/TornUp"));
                    _sprites = new List<Sprite>()
                    {

                        new Sprite(content.Load<Texture2D>("Red_Level/Background"), 0, 0),
                        _champ
                    };
                    break;
                case 2:
                    _board = new Board(content.Load<Texture2D>("Ice_Level/Border"), content.Load<Texture2D>("Ice_Level/Block"),
                content.Load<Texture2D>("Ice_Level/Torn"),
                content.Load<Texture2D>("Ice_Level/Point"), content.Load<Texture2D>("Ice_Level/Exit"),
                content.Load<Texture2D>("Ice_Level/TornLeft"), content.Load<Texture2D>("Ice_Level/TornRight"),
                content.Load<Texture2D>("Ice_Level/TornUp"));
                    _sprites = new List<Sprite>()
                    {

                        new Sprite(content.Load<Texture2D>("Ice_Level/Background"), 0, 0),
                        _champ
                    };
                    break;
            }


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
            spriteBatch.DrawString(_font, "Score: " + _champ.Points + "  ", new Vector2(0, Screen.getHeight()*16), Color.White);
            spriteBatch.DrawString(_font, "  Level: " + Screen.getLevel() + "  ", new Vector2(100, Screen.getHeight()*16), Color.White);
            spriteBatch.DrawString(_font, "  Health: " + _champ.Health + "  ", new Vector2(200, Screen.getHeight()*16), Color.White);
            
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
            if(_champ.Health <= 0)
            {
                _game.ChangeState(new NewRekordState(_game, _graphicsDevice, _content, _champ));
                return;
            }
            _champ.Update(_sprites);
            if (Screen.getChange())
            {
                Screen.ChangeMap(false);
                _champ.Points += 15;
                Screen.setLevel(Screen.getLevel() + 1);
                _champ.Health = 3;
                _game.ChangeState(new GameState(_game, _graphicsDevice, _content, _champ));
                
            }
            
        }
    }
}
