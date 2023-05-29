using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace MyGame
{
    public class Marisa
    {
        private Texture2D texture;
        private Vector2 position;
        private Rectangle sourceRect;
        private Rectangle boundingBox;
        Vector2 velocity;
        private float speed;
        private float shootTimer;
        private List<MarisaBullet> bullets;
        //private List<SparkSegment> sparkSegments;
        private float health;
        float timer = 0;
        Vector2 targetPosition;
        private Random random = new Random();
        public bool startFight = false;


        public Marisa()
        {
            this.texture = Game1.Instance.Content.Load<Texture2D>("Marisa");
            this.position = new Vector2 (580,300);
            sourceRect = new Rectangle(0, 0, 55, 64);
            this.boundingBox = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);
            this.speed = 2f;
            this.shootTimer = 0f;
            this.bullets = new List<MarisaBullet>();
            //this.sparkSegments = new List<SparkSegment>();
            this.health = 1000f; 
        }

        public void Update(GameTime gameTime)
        {
            if (startFight)
            {
                timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
                shootTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;
                position += velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;
                SetTarget();
                CheckPosition();
                boundingBox.Location = position.ToPoint();

                if (timer > 1)
                    targetPosition = new Vector2(250, 100);
                while (timer < 11)
                {
                    if (shootTimer >= 0.01f)
                    {
                        ShootChaotic(3f);
                        shootTimer = 0f;
                    }
                }

                for (int i = bullets.Count - 1; i >= 0; i--)
                {
                    bullets[i].Update(gameTime);



                    //if (bullets[i].position.Y > GameConstants.WindowHeight)
                    //    bullets.RemoveAt(i);
                }
            }

            //for (int i = sparkSegments.Count - 1; i >= 0; i--)
            //{
            //    sparkSegments[i].Update(gameTime);


            //    if (sparkSegments[i].lifespan <= 0)
            //        sparkSegments.RemoveAt(i);
            //}
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, sourceRect, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);

            foreach (MarisaBullet bullet in bullets)
                bullet.Draw(spriteBatch);

            //foreach (SparkSegment segment in sparkSegments)
            //    segment.Draw(spriteBatch);
        }

        private void ShootBullet()
        {

        }

        private void ShootMasterSpark()
        {

        }

        public void SetTarget()
        {
            Vector2 direction = Vector2.Normalize(targetPosition - position);
            velocity = direction * speed;
        }
        public void CheckPosition()
        {
            if (Vector2.Distance(position, targetPosition) < 1)
                velocity = Vector2.Zero;
        }

        private void ShootTowardsPlayer(PlayerReimu player, float speed)
        {
            Vector2 bulletPosition = new Vector2(position.X + 25, position.Y);
            MarisaBullet bullet = new MarisaBullet(bulletPosition, speed);
            bullets.Add(bullet);

            Vector2 playerPosition = player.position + new Vector2(20, 30);
            Vector2 direction = playerPosition - bulletPosition;
            direction.Normalize();
            bullet.SetDirection(direction);
        }

        private void ShootBulletSpray(int bulletCount, float speed)
        {
            float angleStep = MathHelper.TwoPi / bulletCount;

            for (int i = 0; i < bulletCount; i++)
            {
                float angle = i * angleStep;
                Vector2 direction = new Vector2((float)Math.Cos(angle), (float)Math.Sin(angle));

                Vector2 bulletPosition = new Vector2(position.X + 8, position.Y);
                MarisaBullet bullet = new MarisaBullet(bulletPosition, speed);
                bullets.Add(bullet);
                bullet.SetDirection(direction);
            }
        }


        private void ShootChaotic(float speed)
        {

            Vector2 bulletPosition = new Vector2(position.X + 25, position.Y);
            MarisaBullet bullet = new MarisaBullet(bulletPosition, speed);
            bullets.Add(bullet);

            Vector2 direction = new Vector2(RandomFloat(-100, 100), RandomFloat(1, 100));

            direction.Normalize();
            bullet.SetDirection(direction);
        }

        private float RandomFloat(float min, float max)
        {
            return (float)(random.NextDouble() * (max - min) + min);
        }

    }
}


