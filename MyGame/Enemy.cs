using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace MyGame
{
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
        public Enemy(Texture2D texture, Vector2 position,Rectangle size, float speed, float shotInterval, PlayerReimu player, int enemyHp)
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
        }

        public void Update(GameTime gameTime)
        {
            position.Y += speed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            // Отсчет времени между выстрелами.
            shotTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (shotTimer >= shotInterval)
            {
                // Сбрасываем таймер и выстреливаем пулю.
                shotTimer = 0;
                Shoot(player);
            }
           

            // Обновляем все пули.
           
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, size, Color.White, 0f, Vector2.Zero, 1.5f, SpriteEffects.None, 0f);

            // Рисуем все пули.
            

            for (int i = 0; i < bons.Count; i++)
            {
                bons[i].Draw(spriteBatch);
            }
        }
        public void Shoot(PlayerReimu player)
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
    }
}
