using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace MyGame
{
    public enum AttackType
    {
        StraightLine,
        TowardsPlayer,
        BulletSpray,
        Spiral
    }
    public class Enemy
    {
        private Texture2D texture;
        public Vector2 position;
        private Rectangle size;
        private float speed;
        private float shotTimer;
        private float shotInterval;
        private Texture2D bulletTexture;
        PlayerReimu player;
        public Rectangle boundingBox;
        List<Bonus> bons;
        public Bonuses bonuses;
        public bool isGrazed = false;
        public int enemyHp;
        public Vector2 velocity;
        public int BonsID;
        public Vector2 targetPosition;
        private int moveState = 0;
        float timer = 0;
        Vector2 tarPos1;
        Vector2 tarPos2;
        float timerInterval;
        int bulletCount;
        public AttackType AttackType { get; set; }

        public Enemy(Texture2D texture, Vector2 position,Rectangle size, float speed, float shotInterval, 
            PlayerReimu player, int enemyHp, int bonsID, Vector2 tarPos1, Vector2 tarPos2, float timerInterval, int bulletCount)
        {
            this.texture = texture;
            this.position = position;
            this.size = size;
            this.speed = speed;
            this.shotInterval = shotInterval;
            shotTimer = 0;
            this.bulletTexture = Game1.Instance.Content.Load<Texture2D>("EnBullAndBon");
            this.player = player;
            this.boundingBox = new Rectangle((int)position.X, (int)position.Y, size.Width, size.Height);
            bons = new List<Bonus>();
            bonuses = new Bonuses(Bonuses.position, player);
            this.enemyHp = enemyHp;
            this.velocity = Vector2.Zero;
            BonsID = bonsID;
            this.targetPosition = position;
            this.tarPos1 = tarPos1;
            this.tarPos2 = tarPos2;
            this.timerInterval = timerInterval;
            this.bulletCount = bulletCount;
        }

        public void Update(GameTime gameTime)
        {
            position += velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;
            SetTarget();
            CheckPosition();
            boundingBox.Location = position.ToPoint();
            // Отсчет времени между выстрелами.
            if (position.X > 50 && position.X < 554 && position.Y > 31 && position.Y < 562)
            {
                shotTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;
                if (shotTimer >= shotInterval)
                {
                    // Сбрасываем таймер и выстреливаем пулю.
                    shotTimer = 0;
                    Shoot();
                }
            }

            if(Vector2.Distance(position, targetPosition) < 1)
            {
                switch(moveState)
                {
                    case 0:
                        targetPosition = tarPos1;
                        timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
                        if (timer >= timerInterval)
                            moveState++;
                        break;
                    case 1:
                        targetPosition = tarPos2;
                        moveState++;
                        break;
                }
            }
           
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, size, Color.White, 0f, Vector2.Zero, 1.5f, SpriteEffects.None, 0f);          
            for (int i = 0; i < bons.Count; i++)
            {
                bons[i].Draw(spriteBatch);
            }
        }
        public void Shoot()
        {
            switch (AttackType)
            {
                case AttackType.StraightLine:
                    ShootStraightLine();
                    break;
                case AttackType.TowardsPlayer:
                    ShootTowardsPlayer(player);
                    break;
                case AttackType.BulletSpray:
                    ShootBulletSpray(bulletCount);
                    break;
                default:
                    break;
            }
        }

        private void ShootStraightLine()
        {
            // Создаем новую пулю и добавляем ее в список пуль.
            Vector2 bulletPosition = new Vector2(position.X + 8, position.Y);
            EnemBullet bullet = new EnemBullet(bulletTexture, bulletPosition, new Rectangle(17, 49, 16, 16), 3f);
            Enemies.enemBullets.Add(bullet);

            // Направляем пулю вниз по прямой линии.
            Vector2 direction = new Vector2(0, 1);
            bullet.SetDirection(direction);
        }

        private void ShootTowardsPlayer(PlayerReimu player)
        {
            // Создаем новую пулю и добавляем ее в список пуль.
            Vector2 bulletPosition = new Vector2(position.X + 8, position.Y);
            EnemBullet bullet = new EnemBullet(bulletTexture, bulletPosition, new Rectangle(17, 49, 16, 16), 3f);
            Enemies.enemBullets.Add(bullet);

            // Находим игрока и направляем пулю в его сторону.
            Vector2 playerPosition = player.position + new Vector2(20, 30);
            Vector2 direction = playerPosition - bulletPosition;
            direction.Normalize();
            bullet.SetDirection(direction);
        }

        private void ShootBulletSpray(int bulletCount)
        {
            float angleStep = MathHelper.TwoPi / bulletCount; // Угол между каждой пулей

            for (int i = 0; i < bulletCount; i++)
            {
                // Вычисляем направление для каждой пули
                float angle = i * angleStep;
                Vector2 direction = new Vector2((float)Math.Cos(angle), (float)Math.Sin(angle));

                // Создаем новую пулю и добавляем ее в список пуль
                Vector2 bulletPosition = new Vector2(position.X + 8, position.Y);
                EnemBullet bullet = new EnemBullet(bulletTexture, bulletPosition, new Rectangle(17, 49, 16, 16), 3f);
                Enemies.enemBullets.Add(bullet);
                bullet.SetDirection(direction);
            }
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
    }
}
