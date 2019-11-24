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

        public static KeyboardState CurrentState;
        public static KeyboardState PreviousState;
        public NewRekordState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content) : base(game, graphicsDevice, content)
        {
        }

        public NewRekordState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content, ChampionSprite champ) : base(game, graphicsDevice, content, champ)
        {
            var buttonTexture = _content.Load<Texture2D>("Controls/Button");
            _font = _content.Load<SpriteFont>("Fonts/Font");

            var submitButton = new Button(buttonTexture, _font)
            {
                Position = new Vector2(550, 570),
                Text = "Submit your score"
            };

            var backButton = new Button(buttonTexture, _font)
            {
                Position = new Vector2(550, 570),
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
            
            Vector2 vector1 = new Vector2(625, 270);
            Vector2 vector2 = new Vector2(525, 320);
            Vector2 vector3 = new Vector2(780, 370);

            spriteBatch.Begin();

            spriteBatch.DrawString(_font, points, vector1, Color.White);
            if (isNewRekord)
            {
                spriteBatch.DrawString(_font, signature, vector2, Color.White);
                name = ReadCharacter(name);
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


        private static bool HasThreeCharacters(string name)
        {
            if (name == null) return false;
            if (name.Length == 3) return true;
            else return false;
        }
        private static string ReadCharacter(string name)
        {
            PreviousState = CurrentState;
            CurrentState = Keyboard.GetState();

            StringBuilder sb = new StringBuilder();
            sb.Append(name);
            if (ActionWasJustPressed(Keys.Back))
                if (sb.Length > 0)
                {
                    sb.Remove(sb.Length - 1, 1);
                }
            if (!HasThreeCharacters(sb.ToString()))
            {
                if (ActionWasJustPressed(Keys.Q))
                    sb.Append('Q');
                if (ActionWasJustPressed(Keys.W))
                    sb.Append('W');
                if (ActionWasJustPressed(Keys.E))
                    sb.Append('E');
                if (ActionWasJustPressed(Keys.R))
                    sb.Append('R');
                if (ActionWasJustPressed(Keys.T))
                    sb.Append('T');
                if (ActionWasJustPressed(Keys.Y))
                    sb.Append('Y');
                if (ActionWasJustPressed(Keys.U))
                    sb.Append('U');
                if (ActionWasJustPressed(Keys.I))
                    sb.Append('I');
                if (ActionWasJustPressed(Keys.O))
                    sb.Append('O');
                if (ActionWasJustPressed(Keys.P))
                    sb.Append('P');
                if (ActionWasJustPressed(Keys.A))
                    sb.Append('A');
                if (ActionWasJustPressed(Keys.S))
                    sb.Append('S');
                if (ActionWasJustPressed(Keys.D))
                    sb.Append('D');
                if (ActionWasJustPressed(Keys.F))
                    sb.Append('F');
                if (ActionWasJustPressed(Keys.G))
                    sb.Append('G');
                if (ActionWasJustPressed(Keys.H))
                    sb.Append('H');
                if (ActionWasJustPressed(Keys.J))
                    sb.Append('J');
                if (ActionWasJustPressed(Keys.K))
                    sb.Append('K');
                if (ActionWasJustPressed(Keys.L))
                    sb.Append('L');
                if (ActionWasJustPressed(Keys.Z))
                    sb.Append('Z');
                if (ActionWasJustPressed(Keys.X))
                    sb.Append('X');
                if (ActionWasJustPressed(Keys.C))
                    sb.Append('C');
                if (ActionWasJustPressed(Keys.V))
                    sb.Append('V');
                if (ActionWasJustPressed(Keys.B))
                    sb.Append('B');
                if (ActionWasJustPressed(Keys.N))
                    sb.Append('N');
                if (ActionWasJustPressed(Keys.M))
                    sb.Append('M');
            }
           

            /*
            if (HasFourCharacters(name))
            {
                sb.Remove(sb.Length - 1, 1);
            }*/

            return sb.ToString();
        }




        public static bool ActionWasJustPressed(Keys key)
        {
            if (ActionIsPressed(key) && PreviousState.IsKeyUp(key))
                return true;
            else
                return false;

        }

        private static bool ActionIsPressed(Keys key)
        {
            if (CurrentState.IsKeyDown(key))
                return true;
            else
                return false;
        }

    }
}
