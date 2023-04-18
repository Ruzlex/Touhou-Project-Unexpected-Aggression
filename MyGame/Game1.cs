using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace MyGame
{
    public class Game1 : Game
    {

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        MainMenuScreen mainScreen;
        private ScrollingBackground levelOneBack;
        public static Game1 Instance;
        PlayerReimu Reimu;



        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            mainScreen = new MainMenuScreen(Content);
            Instance = this;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            _graphics.PreferredBackBufferWidth = 800; 
            _graphics.PreferredBackBufferHeight = 600; 
            _graphics.SynchronizeWithVerticalRetrace = true;
            _graphics.PreferMultiSampling = true;
            //_graphics.IsFullScreen = true;
            _graphics.ApplyChanges();
            _graphics.PreferredBackBufferFormat = SurfaceFormat.Rgba64;
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            Texture2D backgroundTexture = Content.Load<Texture2D>("UI/LevelOneBackground");
            Texture2D hud = Content.Load<Texture2D>("UI/HUD");
            Texture2D Player = Content.Load<Texture2D>("PlayerReimu");
            SpriteFont font = Content.Load<SpriteFont>("Roboto - regular");

            Reimu = new PlayerReimu(new Vector2(220,480), Player, 170f,32,48,4,4);
            levelOneBack = new ScrollingBackground(backgroundTexture, 2, hud, font, Reimu);

            // TODO: use this.Content to load your game content here
            mainScreen.LoadContent(Content);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            levelOneBack.Update(gameTime);
            Reimu.Update(gameTime);
            

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();

            // Рисуем главное меню
            //mainScreen.Draw(_spriteBatch);
            levelOneBack.Draw(_spriteBatch);
            Reimu.Draw(_spriteBatch);
            

            _spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}