using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using GameProject.Controls;

namespace GameProject.States
{
    public class MenuState : State
    {
        private List<Component> _components;

        public MenuState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content) : base(game, graphicsDevice, content)
        {
            var buttonTexture = _content.Load<Texture2D>("Controls/Button");
            var buttonFont = _content.Load<SpriteFont>("Fonts/Font");

            Texture2D backgroundTexture = content.Load<Texture2D>("Background");
            var background = new Sprite(backgroundTexture)
            {
                Position = new Vector2(0,0)
            };

            var newGameButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(650, 340),
                Text = "New Game",
            };

            newGameButton.Click += NewGameButton_Click;

            var rankingButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(650, 400),
                Text = "Ranking",
            };

            newGameButton.Click += RankingButton_Click;

            var creditsButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(650, 460),
                Text = "Ranking",
            };

            newGameButton.Click += CreditsButton_Click;

            var exitButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(650, 520),
                Text = "Ranking",
            };

            newGameButton.Click += ExitButton_Click;

            _components = new List<Component>()
            {
                background,
                newGameButton,
                rankingButton,
                creditsButton,
                exitButton

            };
        }

        

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            foreach (var component in _components)
                component.Draw(gameTime, spriteBatch);

            spriteBatch.End();
        }

        public override void PostUpdate(GameTime gameTime)
        {
            //Remove Sprites if they're not needed
        }

        public override void Update(GameTime gameTime)
        {
            foreach (var component in _components)
                component.Update(gameTime);
        }


        private void NewGameButton_Click(object sender, EventArgs e)
        {
            _game.ChangeState(new GameState(_game, _graphicsDevice, _content));
        }

        private void RankingButton_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void CreditsButton_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            _game.Exit();
        }

        

        

        
    }
}
