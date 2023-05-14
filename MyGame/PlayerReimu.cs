using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using Microsoft.Xna.Framework.Input;

namespace MyGame
{
    public class PlayerReimu
    {
        private Texture2D texture;
        public Rectangle sourceRect;
        public Rectangle boundingBox;
        public Rectangle hitbox;
        private int currentFrame; // номер текущего кадра анимации
        private int frameWidth; // ширина кадра анимации
        private int frameHeight; // высота кадра анимации
        private int framesPerRow; // количество кадров в строке текстуры
        private int rows=1; // количество строк кадров анимации
        private int frameCount; // общее количество кадров анимации
        private double animationSpeed; // скорость анимации
        private double timeElapsed; // время, прошедшее с прошлого обновления кадра анимации
        public Vector2 position;
        private float speed;
        private bool isSlowMode;
        public Shooting shooting;
        private double shootingDelay;
        private Bonuses Bonuses;
        private int maxPower = 128;
        public int Power;
        public int Score;
        public int HP;
        public int BombsCount;
        public float Graze;
        private bool isBombActive = false;
        private Texture2D bombImage;
        private bool isDrawingBombImage;
        private TimeSpan bombImageDuration;
        private TimeSpan bombImageTimer;
        private Bombs bombs;
        private TimeSpan bombTimer;
        private TimeSpan bombDuration;
        public bool isImmortal = false;




        public PlayerReimu(Vector2 startPosition, float playerSpeed,
            int frameWidth, int frameHeight, int framesPerRow, int frameCount)
        {
            position = startPosition;
            speed = playerSpeed;
            isSlowMode = false;
            this.frameWidth = frameWidth;
            this.frameHeight = frameHeight;
            this.framesPerRow = framesPerRow;
            this.frameCount = frameCount;
            shooting = new Shooting(this);
            Bonuses = new Bonuses(new Vector2(200,70), this);
            texture = Game1.Instance.Content.Load<Texture2D>("PlayerReimu");
            bombImage = Game1.Instance.Content.Load<Texture2D>("AngryReimu");
            boundingBox = new Rectangle((int)position.X, (int)position.Y, (int)(frameWidth *1.5),(int)(frameHeight*1.5));
            hitbox = new Rectangle((int)position.X + 16, (int)position.Y + 30, 12, 12);
            // Задаем начальные значения переменных анимации
            frameWidth = texture.Width / framesPerRow;
            frameHeight = texture.Height / rows;
            //frameCount = framesPerRow * rows;
            currentFrame = 0;
            timeElapsed = 0;
            animationSpeed = 250;
            sourceRect = new Rectangle(0, 0, frameWidth, frameHeight);
            bombs = new Bombs(this, position);
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
            hitbox.Location = position.ToPoint()+ new Point(18,30);
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
            if (currentKeyboardState.IsKeyDown(Keys.X))
            {
                UseBomb();
            }
            bombs.Update(gameTime);
            if (isBombActive)
            {
                if (isDrawingBombImage)
                {
                    bombImageTimer += gameTime.ElapsedGameTime;
                    if (bombImageTimer >= bombImageDuration)
                    {
                        isDrawingBombImage = false;
                        bombImageTimer = TimeSpan.Zero;
                    }
                }
                else
                { 
                    isImmortal = true;
                    bombs.ShootBombs();
                    bombTimer += gameTime.ElapsedGameTime;
                    if (bombTimer >= bombDuration)
                    {
                        isBombActive = false;
                        isImmortal = false;
                        Bombs.bombs.Clear();
                    }
                }
            }

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (isDrawingBombImage)
            {
                spriteBatch.Draw(bombImage, new Vector2(50, 50), new Rectangle(0, 0, 763, 877), Color.White, 0f, Vector2.Zero, 0.3f, SpriteEffects.None, 0f);
            }
            spriteBatch.Draw(texture, position, sourceRect, Color.White, 0f, Vector2.Zero, 1.5f, SpriteEffects.None, 0f);
            shooting.Draw(spriteBatch);
            Bonuses.Draw(spriteBatch);
            bombs.Draw(spriteBatch);
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

        public void FullPower()
        {
            Power = maxPower;
        }

        public void UseBomb()
        {
            if (!isBombActive)
            {
                isBombActive = true;
                // Воспроизвести звук бомбы
                // Отобразить изображение игрока слева в виде картинки на пару секунд
                isDrawingBombImage = true;
                bombImageDuration = TimeSpan.FromSeconds(2.0); // Пример: изображение отображается 2 секунды
                bombImageTimer = TimeSpan.Zero;
                bombDuration = TimeSpan.FromSeconds(5.0); // Пример: изображение отображается 2 секунды
                bombTimer = TimeSpan.Zero;

                

                // Затем из самого игрока вылетают снаряды к ближайшим противникам
                // Уничтожают их и их пули
                // Игрок на это время становится бессмертным
                // Игровое поле становится темнее
            }
        }
    }
}
