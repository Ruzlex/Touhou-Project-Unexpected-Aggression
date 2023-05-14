using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;


namespace MyGame
{
    public class Shooting
    {
        private Texture2D texture;
        public Vector2 position;
        public static List<Bullet> bullets;
        private Rectangle size;
        private Rectangle size2;
        public SoundEffect shoot;
        public PlayerReimu player;
        private List<HomingBullet> homingBullets;
        private Enemy enemy;
        public Rectangle boundingBox;
        public Shooting(PlayerReimu player)
        {
            this.texture = Game1.Instance.Content.Load<Texture2D>("PlayerReimu");
            bullets = new List<Bullet>();
            this.homingBullets = new List<HomingBullet>();
            this.size = new Rectangle(132, 3, 10, 13);
            this.size2 = new Rectangle(147, 2, 13, 14);
            shoot = Game1.Instance.Content.Load<SoundEffect>("Shooting");
            this.player = player;
            this.boundingBox = new Rectangle((int)position.X, (int)position.Y, size.Width, size.Height);
        }

        public void Update(GameTime gameTime)
        {
            foreach (Bullet bullet in bullets)
            {
                bullet.Update(gameTime);
            }

            foreach (HomingBullet hbullet in homingBullets)
            {
                hbullet.Update(gameTime);
            }
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            foreach(Bullet bullet in bullets)
            {
                bullet.Draw(spriteBatch);
                bullet.SetRotationAngle(bullet.rotationAngle + MathHelper.ToRadians(5));
            }

            foreach (HomingBullet hbullet in homingBullets)
            {
                hbullet.Draw(spriteBatch);
                hbullet.SetRotationAngle(hbullet.rotationAngle + MathHelper.ToRadians(5));
            }
        }

        public void Shoot(Vector2 position)
        {
            if (player.Power < 8)
            {
                Bullet bullet = new Bullet(texture, position, size, 8f);
                bullets.Add(bullet);
                bullet.SetRotationAngle(MathHelper.ToRadians(45));
            }
            else if (player.Power >= 8 && player.Power < 16)
            {
               
                    Bullet bullet = new Bullet(texture, position, size, 8f);
                    bullets.Add(bullet);
                    bullet.SetRotationAngle(MathHelper.ToRadians(45));
               
                //    HomingBullet Hbullet = new HomingBullet(texture, position, size2, 8f, enemy);
                //Hbullet.FindWay(Hbullet.direction, enemy);
                //    homingBullets.Add(Hbullet);
                //    Hbullet.SetRotationAngle(MathHelper.ToRadians(45));
            }

            else if (player.Power >= 16 && player.Power < 32)
            {
                Bullet bullet = new Bullet(texture, new Vector2(position.X - 8, position.Y), size, 8f);
                bullet.direction = new Vector2(0.01f, -1);
                bullets.Add(bullet);
                bullet.SetRotationAngle(MathHelper.ToRadians(45));

                Bullet bullet2 = new Bullet(texture, new Vector2(position.X + 8, position.Y), size, 8f);
                bullet2.direction = new Vector2(0.01f, -1);
                bullets.Add(bullet2);
                bullet2.SetRotationAngle(MathHelper.ToRadians(45));
            }

            else if (player.Power >= 32)
            {
                Bullet bullet = new Bullet(texture, position, size, 8f);
                bullet.direction = new Vector2(-0.06f, -1);
                bullets.Add(bullet);
                bullet.SetRotationAngle(MathHelper.ToRadians(45));

                Bullet bullet2 = new Bullet(texture, position, size, 8f);
                bullet2.direction = new Vector2(0f, -1);
                bullets.Add(bullet2);
                bullet2.SetRotationAngle(MathHelper.ToRadians(45));

                Bullet bullet3 = new Bullet(texture, position, size, 8f);
                bullet3.direction = new Vector2(0.06f, -1);
                bullets.Add(bullet3);
                bullet3.SetRotationAngle(MathHelper.ToRadians(45));
            }
        }
    }
}
