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
using NAudio.Wave;
using GameProject.Content;

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
        private static WaveOut sound;
        private static WaveFileReader reader;
        public static int lastLevel = 0;

        public GameState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content) : base(game, graphicsDevice, content)
        {
            
            _texture = content.Load<Texture2D>("Champ");
            _texture_flip = content.Load<Texture2D>("ChampFlip");
            _font = content.Load<SpriteFont>("Fonts/Font");
            _champ = new ChampionSprite(_texture, _texture_flip)
            {
                Speed = 4f,
            };

            ColorPattern _colorPattern = new ColorPattern();
            _sprites = _colorPattern.LoadGraphics(content, _champ);
            if (!Game1.isMusicPlaying)
            {
                
                if (!Sprite.specialLevel) reader = new WaveFileReader("gameplay.wav");
                else reader = new WaveFileReader("special.wav");
                LoopStream loop = new LoopStream(reader);
                sound = new WaveOut();
                sound.Init(loop);
                sound.Play();
                Game1.isMusicPlaying = true;
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


            ColorPattern _colorPattern = new ColorPattern();
            _sprites = _colorPattern.LoadGraphics(content, _champ);

            if(!ColorPattern.theSame && Sprite.specialLevel)
            {
                sound.Stop();
                sound.Dispose();
                sound = null;
                reader = new WaveFileReader("special.wav");
                LoopStream loop = new LoopStream(reader);
                sound = new WaveOut();
                sound.Init(loop);
                sound.Play();
                Game1.isMusicPlaying = true;
            }
            if (!ColorPattern.theSame && !Sprite.specialLevel)
            {
                sound.Stop();
                sound.Dispose();
                sound = null;
                reader = new WaveFileReader("gameplay.wav");
                LoopStream loop = new LoopStream(reader);
                sound = new WaveOut();
                sound.Init(loop);
                sound.Play();
                Game1.isMusicPlaying = true;
            }
        }

       
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            
            spriteBatch.Begin();
            //_champ.Draw(spriteBatch);
            //_board.Draw(spriteBatch);
            spriteBatch.DrawString(_font, "Score: " + _champ.Points + "  ", new Vector2(0, Screen.getHeight()*16), Color.White);
            spriteBatch.DrawString(_font, "  Level: " + Screen.getLevel() + "  ", new Vector2((Screen.getWidth()/3)*16, Screen.getHeight()*16), Color.White);
            spriteBatch.DrawString(_font, "  Health: " + _champ.Health + "  ", new Vector2((Screen.getWidth()* 2 / 3) * 16, Screen.getHeight()*16), Color.White);
            
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
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                sound.Stop();
                sound.Dispose();
                sound = null;
                Game1.isMusicPlaying = false;
                _game.ChangeState(new MenuState(_game, _graphicsDevice, _content));
                return;
            }
            if (_champ.Health <= 0)
            {
                sound.Stop();
                sound.Dispose();
                sound = null;
                Game1.isMusicPlaying = false;
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
