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
        public Texture2D texture;
        public static Vector2 position;
        public static List<Enemy> enemies;
        public PlayerReimu player;
        public Shooting PlayerShoot;
        public List<Bonus> bonusesList;
        private KeyboardState previousState;
        public static List<EnemBullet> enemBullets;
        public Bonuses bonuses;

        public Enemies(PlayerReimu player)
        {
            texture = Game1.Instance.Content.Load<Texture2D>("SimpleEnemies");
            enemies = new List<Enemy>();
            this.player = player;
            this.bonusesList = new List<Bonus>();
            enemBullets = new List<EnemBullet>();
            bonuses = new Bonuses(Bonuses.position, player);
        }
        public void Update(GameTime gameTime)
        {
            for (int i = 0; i < enemies.Count; i++)
            {
                enemies[i].Update(gameTime);
            }
            for (int i = 0; i < enemies.Count; i++)
            {
                if (enemies[i].position.X < 35 || enemies[i].position.X > 570)
                {
                    enemies.RemoveAt(i);
                    break;
                }
                
                for (int j = 0; j < Shooting.bullets.Count; j++)
                {
                   
                    if (enemies[i].boundingBox.Intersects(Shooting.bullets[j].boundingBox))
                    {

                        enemies[i].enemyHp -= 1;
                        Shooting.bullets.RemoveAt(j);
                        if (enemies[i].enemyHp <= 0)
                        {
                            DeathBons(enemies[i].BonsID, enemies[i].position);
                            enemies.RemoveAt(i);
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
                    bonuses.MinusBonuses();
                    player.position = new Vector2(220, 480);
                    player.HP = -1;
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
            for (int i = 0; i < enemies.Count; i++)
            {
                enemies[i].Draw(spriteBatch);
            }

            for (int i = 0; i < enemBullets.Count; i++)
            {
                enemBullets[i].Draw(spriteBatch);
            }
        }


        public static void DeathBons(int bonsId, Vector2 position)
        {
            Bonus bonus = new Bonus(Bonuses.texture, position, WhichTexture(BonusType.PowerUp));
            Bonus bonus2 = new Bonus(Bonuses.texture, position, WhichTexture(BonusType.ScoreBonus));
            Bonus bonus3 = new Bonus(Bonuses.texture, position, WhichTexture(BonusType.PowerUpPlus));
            Bonus bonus4 = new Bonus(Bonuses.texture, position, WhichTexture(BonusType.HpPlus));
            Bonus bonus5 = new Bonus(Bonuses.texture, position, WhichTexture(BonusType.BombPlus));
            switch (bonsId)
            {
                case 0:
                    bonus.type = BonusType.PowerUp;
                    Bonuses.bonusesList.Add(bonus);
                    break;
                case 1:
                    bonus2.type = BonusType.ScoreBonus;
                    Bonuses.bonusesList.Add(bonus2);
                    break;
                case 2:
                    bonus3.type = BonusType.PowerUpPlus;
                    Bonuses.bonusesList.Add(bonus3);
                    break;
                case 3:
                    bonus4.type = BonusType.HpPlus;
                    Bonuses.bonusesList.Add(bonus4);
                    break;
                case 4:
                    bonus5.type = BonusType.BombPlus;
                    Bonuses.bonusesList.Add(bonus5);
                    break;
                default:
                    break;
            }
        }
    }
}