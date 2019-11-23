using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using GameProject.Controls;
using Microsoft.Xna.Framework.Input;

namespace GameProject.States
{
    class NewRekordState : State
    {
        private List<Component> _components;
        private SpriteFont _font;
        private ChampionSprite champ;
        private string name;
        private List<SplitData> placements = RankingFile.getPlacements();
        private bool isNewRekord;
        public NewRekordState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content) : base(game, graphicsDevice, content)
        {
        }

        public NewRekordState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content, ChampionSprite champ) : base(game, graphicsDevice, content, champ)
        {
            var buttonTexture = _content.Load<Texture2D>("Controls/Button");
            _font = _content.Load<SpriteFont>("Fonts/Font");

            var submitButton = new Button(buttonTexture, _font)
            {
                Position = new Vector2(650, 570),
                Text = "Submit your score"
            };

            var backButton = new Button(buttonTexture, _font)
            {
                Position = new Vector2(650, 570),
                Text = "Go to main menu"
            };

            backButton.Click += backButton_Click;
            submitButton.Click += submitButton_Click;

            var list = RankingFile.getPlacements();
            this.champ = champ;

            if (list.Count < 10 || list[list.Count - 1].score < champ.Points)
            {
                _components = new List<Component>()
                {
                    submitButton
                };
                isNewRekord = true;
            }
            else
            {
                _components = new List<Component>()
                {
                    backButton
                };
                isNewRekord = false;
            }

            
        }
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            string points = "Great job! You got " + champ.Points + " points!";
            string signature = "Please enter your three letter signature: ";
            
            Vector2 vector1 = new Vector2(710, 270);
            Vector2 vector2 = new Vector2(665, 320);
            Vector2 vector3 = new Vector2(820, 370);

            spriteBatch.Begin();

            spriteBatch.DrawString(_font, points, vector1, Color.White);
            if (isNewRekord)
            {
                spriteBatch.DrawString(_font, signature, vector2, Color.White);

                name += ReadThreeCharacters();
                spriteBatch.DrawString(_font, name, vector3, Color.White);
            }

            foreach (var component in _components)
                component.Draw(gameTime, spriteBatch);
            
            spriteBatch.End();
        }

        public override void PostUpdate(GameTime gameTime)
        {
        }

        public override void Update(GameTime gameTime)
        {
            foreach (var component in _components)
                component.Update(gameTime);
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            _game.ChangeState(new MenuState(_game, _graphicsDevice, _content));
        }
        private void submitButton_Click(object sender, EventArgs e)
        {
            RankingFile.AddToList(name, champ.Points);
            _game.ChangeState(new MenuState(_game, _graphicsDevice, _content));
        }
        private static string ReadThreeCharacters()
        {
            var x = Keyboard.GetState().GetPressedKeys();
            StringBuilder sb = new StringBuilder();
            for (int i=0; i<x.Length; i++)
            {
                sb.Append(x[0].ToString());
                
            }

            return sb.ToString();
        }
                  
    }
}
