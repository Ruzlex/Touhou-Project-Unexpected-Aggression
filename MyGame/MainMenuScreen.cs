using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata;

namespace MyGame
{
    public class MainMenuScreen 
    {

        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private Texture2D backgroundTexture;
        private SpriteFont menuFont;
        private List<Button> buttons = new List<Button>();
        private enum GameState
        {
            MainMenu,
            Playing,
            Paused,
            GameOver,
            Options
        }

        private GameState currentState;


        public MainMenuScreen(ContentManager content)
        {
        //    Texture2D startButtonTexture = content.Load<Texture2D>("startButtonTexture");
        //    Button startButton = new Button(startButtonTexture, new Vector2(100, 100), Color.White);

        //    Texture2D optionsButtonTexture = content.Load<Texture2D>("optionsButtonTexture");
        //    Button optionsButton = new Button(optionsButtonTexture, new Vector2(100, 200), Color.White);

        //    Texture2D exitButtonTexture = content.Load<Texture2D>("exitButtonTexture");
        //    Button exitButton = new Button(exitButtonTexture, new Vector2(100, 300), Color.White);

        //    buttons.Add(startButton);
        //    buttons.Add(optionsButton);
        //    buttons.Add(exitButton);
        }
        public void LoadContent(ContentManager content)
        {
            //menuFont = content.Load<SpriteFont>("Roboto - regular");

            backgroundTexture = content.Load<Texture2D>("MainMenuBackground");
        }
        public void Draw(SpriteBatch spriteBatch)
        {

            spriteBatch.Draw(backgroundTexture, new Vector2(-200, 0), Color.White);

            //foreach (Button button in buttons)
            //{
            //    button.Draw(spriteBatch);
            //}
        }

        public void Update(GameTime gameTime)
        {

            MouseState mouseState = Mouse.GetState();

            foreach (Button button in buttons)
            {
                if (button.IsClicked(mouseState))
                {
                    if (button == buttons[0])
                    {
                        currentState = GameState.Playing;
                    }
                    else if (button == buttons[1])
                    {
                        currentState = GameState.Options;
                    }
                    else if (button == buttons[2])
                    {
                        Game1.Instance.Exit();
                    }
                }
            }
        }
    }
    //protected override void LoadContent()
    //{
    //    // Загрузить шрифты
    //    menuFont = Content.Load<SpriteFont>("Roboto-Regular");

    //    // Загрузить фоновое изображение
    //    backgroundTexture = Content.Load<Texture2D>("MainMenuBackground");

    //    Texture2D startButtonTexture = Content.Load<Texture2D>("startButtonTexture");
    //    Button startButton = new Button(startButtonTexture, new Vector2(100, 100), Color.White);

    //    Texture2D optionsButtonTexture = Content.Load<Texture2D>("optionsButtonTexture");
    //    Button optionsButton = new Button(optionsButtonTexture, new Vector2(100, 200), Color.White);

    //    Texture2D exitButtonTexture = Content.Load<Texture2D>("exitButtonTexture");
    //    Button exitButton = new Button(exitButtonTexture, new Vector2(100, 300), Color.White);

    //}



    //private void InitializeButtons()
    //    {
    //        // Создать кнопки
    //        Button startButton = new Button("Start Game", menuFont, new Vector2(screenWidth / 2, screenHeight / 2), Color.White);
    //        startButton.Click += StartButton_Click;

    //        Button optionsButton = new Button("Options", menuFont, new Vector2(screenWidth / 2, screenHeight / 2 + 50), Color.White);
    //        optionsButton.Click += OptionsButton_Click;

    //        Button exitButton = new Button("Exit", menuFont, new Vector2(screenWidth / 2, screenHeight / 2 + 100), Color.White);
    //        exitButton.Click += ExitButton_Click;

    //        // Добавить кнопки в список
    //        buttons.Add(startButton);
    //        buttons.Add(optionsButton);
    //        buttons.Add(exitButton);
    //    }

    //    private void StartButton_Click(object sender, EventArgs e)
    //    {
    //        // Запустить новую игру
    //        // ...
    //    }

    //    private void OptionsButton_Click(object sender, EventArgs e)
    //    {
    //        // Открыть меню настроек
    //        // ...
    //    }

    //    private void ExitButton_Click(object sender, EventArgs e)
    //    {
    //        // Закрыть игру
    //        Exit();
    //    }



    public class Button
    {
        private Texture2D texture;
        private Vector2 position;
        private Rectangle rectangle;
        private Color color;

        public Button(Texture2D texture, Vector2 position, Color color)
        {
            this.texture = texture;
            this.position = position;
            this.rectangle = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);
            this.color = color;
        }

        public bool IsClicked(MouseState mouseState)
        {
            Rectangle mouseRectangle = new Rectangle(mouseState.X, mouseState.Y, 1, 1);

            if (mouseRectangle.Intersects(rectangle) && mouseState.LeftButton == ButtonState.Pressed)
            {
                return true;
            }

            return false;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, rectangle, color);
        }
    }
}
