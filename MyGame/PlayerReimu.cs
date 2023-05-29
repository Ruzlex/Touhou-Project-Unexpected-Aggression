using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using Microsoft.Xna.Framework.Input;
using static MyGame.Bonuses;

namespace MyGame
{
    public class PlayerReimu
    {
        private Texture2D texture;
        public Rectangle sourceRect;
        public Rectangle boundingBox;
        public Rectangle hitbox;
        private int currentFrame;
        private int frameWidth;
        private int frameHeight;
        private int framesPerRow;
        private int rows=1; 
        private int frameCount; 
        private double animationSpeed; 
        private double timeElapsed; 
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
        private KeyboardState previousState;



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
                currentFrame++;
                if (currentFrame == frameCount)
                {
                    currentFrame = 0;
                }
                timeElapsed = 0;
            }
            Bonuses.Update(gameTime);
            
            int row = (int)((float)currentFrame / (float)framesPerRow);
            int column = currentFrame % framesPerRow;
            sourceRect = new Rectangle(frameWidth * column, frameHeight * row, frameWidth, frameHeight);



            if (Keyboard.GetState().IsKeyDown(Keys.LeftShift) || Keyboard.GetState().IsKeyDown(Keys.RightShift))
            {
                isSlowMode = true;
            }
            else
            {
                isSlowMode = false;
            }

            float currentSpeed = isSlowMode ? speed / 2 : speed;

            const int GAME_FIELD_LEFT_BOUND = 47;
            const int GAME_FIELD_RIGHT_BOUND = 543;
            const int GAME_FIELD_TOP_BOUND = 27;
            const int GAME_FIELD_BOTTOM_BOUND = 550; 


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
            if (isBombActive == false)
            {
                if (currentKeyboardState.IsKeyDown(Keys.X) && !previousState.IsKeyDown(Keys.X) && BombsCount > 0)
                {
                    UseBomb();
                    BombsCount--;
                }
            }
            previousState = Keyboard.GetState();
            bombs.Update(gameTime);
            if (isBombActive)
            {
                if (bonusesList.Count > 0)
                {
                    for (int i = 0; i < bonusesList.Count; i++)
                    {
                        bonusesList[i].Update(gameTime);
                        bonusesList[i].AttractToPlayer(this, 10f, gameTime);                        
                        CheckCollision(this, bonusesList[i]);
                    }
                }
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
                spriteBatch.Draw(bombImage, new Vector2(30, 250), new Rectangle(0, 0, 763, 877), Color.White, 0f, Vector2.Zero, 0.4f, SpriteEffects.None, 0f);
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
                isDrawingBombImage = true;
                bombImageDuration = TimeSpan.FromSeconds(2.0);
                bombImageTimer = TimeSpan.Zero;
                bombDuration = TimeSpan.FromSeconds(5.0);
                bombTimer = TimeSpan.Zero;
            }
        }
    }
}
