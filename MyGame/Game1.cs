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
        Level1 level1;
        HUD Hud;



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
            Texture2D hudTexture = Content.Load<Texture2D>("UI/HUD");
            SpriteFont font = Content.Load<SpriteFont>("Roboto - regular");
            level1 = new Level1(backgroundTexture);
            Hud = new HUD(hudTexture, font, level1.player);
            


            
            levelOneBack = new ScrollingBackground(backgroundTexture, 2);

            // TODO: use this.Content to load your game content here
            mainScreen.LoadContent(Content);
        }

        protected override void Update(GameTime gameTime)
        {
            
            Hud.Update(gameTime);
            level1.Update(gameTime);

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape) || level1.player.HP < 0)
                Exit();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();

            //mainScreen.Draw(_spriteBatch);
            
            level1.Draw(_spriteBatch);
            Hud.Draw(_spriteBatch);
            _spriteBatch.End();


            base.Draw(gameTime);
        }
    }

    public static class RandomHelper
    {
        private static readonly Random _random = new Random();

        public static int Next(int minValue, int maxValue)
        {
            return _random.Next(minValue, maxValue);
        }
    }
}