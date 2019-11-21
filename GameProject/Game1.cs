﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;
using GameProject.States;

namespace GameProject
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        private State _currentState;
        private State _nextState;

        public void ChangeState (State state)
        {
            _nextState = state;
        }

        private Texture2D _texture;
        private ChampionSprite _champ;
        private Board _board;
        private List<Sprite> _sprites;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 1600;  // set this value to the desired width of your window
            graphics.PreferredBackBufferHeight = 800;   // set this value to the desired height of your window
            graphics.ApplyChanges();
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            IsMouseVisible = true;
            ChangeState(new MenuState(this, graphics.GraphicsDevice, Content));

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            //_currentState = new MenuState(this,graphics.GraphicsDevice, Content);

            //_texture = Content.Load<Texture2D>("Champ");
            
            //_champ = new ChampionSprite(_texture)
            //{
            //    Speed = 5f,
            //};
            
            //_board = new Board(Content.Load<Texture2D>("Border"), Content.Load<Texture2D>("Block"),
            //    Content.Load<Texture2D>("Torn"), Content.Load<Texture2D>("Space"));

            //_sprites = new List<Sprite>()
            //{
            //    _champ
            //};
            
            //foreach(var x in Board._elemList)
            //{ 
            //    Sprite Sprite = new Sprite(x);
            //    _sprites.Add(Sprite);
            //}

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            if(_nextState!= null)
            {
                _currentState = _nextState;
                _nextState = null;
            }
            /*foreach (var sprite in _sprites)
            {
                sprite.Update(_sprites);
            }*/
            _currentState.Update(gameTime);
            _currentState.PostUpdate(gameTime);

            //_champ.Update(_sprites);

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            _currentState.Draw(gameTime, spriteBatch);

            //spriteBatch.Begin();
            ////_champ.Draw(spriteBatch);
            ////_board.Draw(spriteBatch);
            //foreach (var sprite in _sprites)
            //{
            //    sprite.Draw(spriteBatch);
            //}
            //spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
