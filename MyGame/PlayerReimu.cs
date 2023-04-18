using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;

namespace MyGame
{
    public class PlayerReimu
    {
        private Texture2D texture;
        public Rectangle sourceRect;
        public Rectangle boundingBox;
        private int currentFrame; // номер текущего кадра анимации
        private int frameWidth; // ширина кадра анимации
        private int frameHeight; // высота кадра анимации
        private int framesPerRow; // количество кадров в строке текстуры
        private int rows=4; // количество строк кадров анимации
        private int frameCount; // общее количество кадров анимации
        private double animationSpeed; // скорость анимации
        private double timeElapsed; // время, прошедшее с прошлого обновления кадра анимации
        private Vector2 position;
        private KeyboardState keyboardState;
        private float speed;
        private bool isSlowMode;
        private Shooting shooting;
        private double shootingDelay;
        private Bonuses Bonuses;
        private int maxPower = 128;
        public int Power;


        public PlayerReimu(Vector2 startPosition, Texture2D playerTexture, float playerSpeed,
            int frameWidth, int frameHeight, int framesPerRow, int frameCount)
        {
            position = startPosition;
            texture = playerTexture;
            speed = playerSpeed;
            isSlowMode = false;
            this.frameWidth = frameWidth;
            this.frameHeight = frameHeight;
            this.framesPerRow = framesPerRow;
            this.frameCount = frameCount;
            shooting = new Shooting(this);
            Bonuses = new Bonuses(new Vector2(200,70), this);
            playerTexture = Game1.Instance.Content.Load<Texture2D>("PlayerReimu");
            this.boundingBox = new Rectangle((int)position.X, (int)position.Y, frameWidth, frameHeight);

            // Задаем начальные значения переменных анимации
            frameWidth = playerTexture.Width / framesPerRow;
            frameHeight = playerTexture.Height / rows;
            //frameCount = framesPerRow * rows;
            currentFrame = 0;
            timeElapsed = 0;
            animationSpeed = 250;
            sourceRect = new Rectangle(0, 0, frameWidth, frameHeight);
        }
        public void Update(GameTime gameTime)
        {
            timeElapsed += gameTime.ElapsedGameTime.TotalMilliseconds;
            if (timeElapsed > animationSpeed)
            {
                // Обновляем текущий кадр анимации
                currentFrame++;
                if (currentFrame == frameCount)
                {
                    currentFrame = 0;
                }
                timeElapsed = 0;
            }
            Bonuses.Update(gameTime);

            // Обновляем прямоугольник с текущим кадром анимации
            int row = (int)((float)currentFrame / (float)framesPerRow);
            int column = currentFrame % framesPerRow;
            sourceRect = new Rectangle(frameWidth * column, frameHeight * row, frameWidth, frameHeight);


            // Обновляем скорость персонажа на основе нажатых клавиш
            if (Keyboard.GetState().IsKeyDown(Keys.LeftShift) || Keyboard.GetState().IsKeyDown(Keys.RightShift))
            {
                isSlowMode = true;
            }
            else
            {
                isSlowMode = false;
            }

            // Вычисляем скорость в зависимости от того, включен ли режим замедления
            float currentSpeed = isSlowMode ? speed / 2 : speed;

            // Обновляем позицию персонажа
            const int GAME_FIELD_LEFT_BOUND = 47;
            const int GAME_FIELD_RIGHT_BOUND = 543; // ширина игрового поля
            const int GAME_FIELD_TOP_BOUND = 27;
            const int GAME_FIELD_BOTTOM_BOUND = 550; // высота игрового поля

            // Обновляем позицию персонажа
            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                if (position.Y - currentSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds >= GAME_FIELD_TOP_BOUND)
                {
                    position.Y -= currentSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                }
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                if (position.Y + currentSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds <= GAME_FIELD_BOTTOM_BOUND - frameHeight)
                {
                    position.Y += currentSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                }
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                if (position.X - currentSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds >= GAME_FIELD_LEFT_BOUND)
                {
                    position.X -= currentSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                }
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                if (position.X + currentSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds <= GAME_FIELD_RIGHT_BOUND - frameWidth)
                {
                    position.X += currentSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                }
            }
            boundingBox.Location = position.ToPoint();
            KeyboardState currentKeyboardState = Keyboard.GetState();

            if (currentKeyboardState.IsKeyDown(Keys.Z) && gameTime.TotalGameTime.TotalSeconds > shootingDelay)
            {
                Vector2 bulPos= position;
                bulPos.X = bulPos.X + 19;
                shooting.Shoot(bulPos); 
                shooting.shoot.Play();
                shootingDelay = gameTime.TotalGameTime.TotalSeconds + 0.1;
            }

            shooting.Update(gameTime);

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, sourceRect, Color.White, 0f, Vector2.Zero, 1.5f, SpriteEffects.None, 0f);
            shooting.Draw(spriteBatch);
            Bonuses.Draw(spriteBatch);
        }
        public void PowerUpPlus()
        {
            Power += 8;
            if (Power > maxPower)
            {
                Power = maxPower;
            }
        }
        public void PowerUp()
        {
            Power++;
            if (Power > maxPower)
            {
                Power = maxPower;
            }
        }

        
    }
}
