using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using static MyGame.Bonuses;

namespace MyGame
{
    public class Enemies
    {
        private Texture2D texture;
        private Vector2 position;
        private Rectangle size;
        private float speed;
        private float shotInterval;
        public static List<Enemy> enemies;
        public PlayerReimu player;
        public Shooting PlayerShoot;
        public List<Bonus> bonusesList;
        private KeyboardState previousState;
        private int enemyHp;
        public static List<EnemBullet> enemBullets;

        public Enemies(Rectangle size, float speed, float shotInterval, PlayerReimu player, int enemyHp)
        {
            texture = Game1.Instance.Content.Load<Texture2D>("SimpleEnemies");

            this.size = size;
            this.speed = speed;
            this.shotInterval = shotInterval;
            enemies = new List<Enemy>();
            this.player = player;
            this.bonusesList = new List<Bonus>();
            this.enemyHp = enemyHp;
            enemBullets = new List<EnemBullet>();

        }
            public void Update(GameTime gameTime, Shooting shooting)
            {
                // Обновляем всех врагов.
                for (int i = 0; i < enemies.Count; i++)
                {
                    enemies[i].Update(gameTime);

                }

                if (Keyboard.GetState().IsKeyDown(Keys.H) && !previousState.IsKeyDown(Keys.H))
                {
                for (int i = 0; i < 10; i++)
                {
                    var x = RandomHelper.Next(100, 400);
                    var y = RandomHelper.Next(25, 150);
                    position = new Vector2(x, y);
                    SpawnEnemy(position);
                    continue;

                }
                
                }
                previousState = Keyboard.GetState();
                var rnd = RandomHelper.Next(0, 10);
                // Удаляем уничтоженных врагов.
                for (int i = 0; i < enemies.Count; i++)
                {
                    for (int j = 0; j < Shooting.bullets.Count; j++)
                    {
                        if (enemies[i].boundingBox.Intersects(Shooting.bullets[j].boundingBox))
                        {

                            enemies[i].enemyHp -= 1;
                            Shooting.bullets.RemoveAt(j);
                            if (enemies[i].enemyHp <= 0)
                            {

                                enemies.RemoveAt(i);
                                DeathBons(rnd);

                            }
                            break;
                        }

                    }
                }
                for (int i = 0; i < enemBullets.Count; i++)
                {
                    enemBullets[i].Update(gameTime);
                    if (enemBullets[i].boundingBox.Intersects(player.hitbox) && !player.isImmortal)
                    {
                        //bonuses.MinusBonuses();
                        player.position = new Vector2(220, 480);

                        enemBullets.RemoveAt(i);
                    }

                    //if ((bullets[i].position.X - player.position.X <= 10 && bullets[i].position.Y - player.position.Y <= 10) ||
                    //    (bullets[i].position.X + player.position.X <= 10 && bullets[i].position.Y + player.position.Y <= 10) ||
                    //    (bullets[i].position.X - player.position.X <= 10 && bullets[i].position.Y + player.position.Y <= 10) ||
                    //    (bullets[i].position.X + player.position.X <= 10 && bullets[i].position.Y - player.position.Y <= 10))
                    //{
                    //    if (!isGrazed)
                    //    {
                    //        player.Graze = player.Graze + 0.15f;
                    //        isGrazed = true;
                    //        break;
                    //    }
                    //    isGrazed = false;
                    //}
                }
            }

            public void Draw(SpriteBatch spriteBatch)
            {
                // Рисуем всех врагов.
                for (int i = 0; i < enemies.Count; i++)
                {
                    enemies[i].Draw(spriteBatch);
                }

                for (int i = 0; i < enemBullets.Count; i++)
                {
                    enemBullets[i].Draw(spriteBatch);
                }
            }

            public void SpawnEnemy(Vector2 position)
            {
                Enemy enemy = new Enemy(texture, position, size, speed, shotInterval, player, enemyHp);
                enemies.Add(enemy);
            }

            public static void DeathBons(int rnd)
            {
                Bonus bonus = new Bonus(Bonuses.texture, Bonuses.position, WhichTexture(BonusType.PowerUp));
                Bonus bonus2 = new Bonus(Bonuses.texture, Bonuses.position, WhichTexture(BonusType.ScoreBonus));
                switch (rnd)
                {
                    case 0:
                    case 1:
                    case 2:
                    case 3:
                    case 4:
                        bonus.type = BonusType.PowerUp;
                        Bonuses.bonusesList.Add(bonus);
                        break;
                    case 5:
                    case 6:
                    case 7:
                    case 8:
                    case 9:
                    case 10:
                        bonus2.type = BonusType.ScoreBonus;
                        Bonuses.bonusesList.Add(bonus2);
                        break;
                }

            }
        }
    }