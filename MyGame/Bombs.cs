using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace MyGame
{
    public class Bombs
    {
        private static Texture2D texture;
        public Vector2 position;
        public static List<Bomb> bombs;
        private static Rectangle sourceRect;
        public PlayerReimu player;
        public static List<Enemy> enemies;
        public Rectangle boundingBox;

        public Bombs(PlayerReimu player, Vector2 position)
        {
            bombs = new List<Bomb>();
            texture = Game1.Instance.Content.Load<Texture2D>("PlayerReimu");
            sourceRect = new Rectangle(5, 104, 54, 50);
            this.player = player;
            //enemies = new List<Enemy>();
            this.position = position;
            this.boundingBox = new Rectangle((int)position.X, (int)position.Y, sourceRect.Width, sourceRect.Height);
        }

        public void Update(GameTime gameTime)
        {
            foreach (Bomb bomb in bombs)
            {
                bomb.Update(gameTime);
            }

        }


        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Bomb bomb in bombs)
            {
                bomb.Draw(spriteBatch);
            }
        }

        public void ShootBombs()
        {
            for (int i = 0; i < Enemies.enemies.Count; i++)
            {
                Vector2 bombPosition = new Vector2(position.X, position.Y);
                Bomb bomb = new Bomb(texture, sourceRect, bombPosition, 10f);
                bombs.Add(bomb);
                continue;
            }

                for (int j = 0; j < Enemies.enemies.Count; j++)
                {
                    var rnd = RandomHelper.Next(0, 10);
                    Vector2 enemyPosition = Enemies.enemies[j].position;
                    Vector2 direction = enemyPosition - bombs[j].position;
                    direction.Normalize();
                    bombs[j].SetDirection(direction);

                    if (bombs[j].boundingBox.Intersects(Enemies.enemies[j].boundingBox))
                    {
                    Enemies.DeathBons(Enemies.enemies[j].BonsID, Enemies.enemies[j].position);
                        Enemies.enemies.RemoveAt(j);

                    }
                for (int w = 0; w < Enemies.enemBullets.Count; w++)
                {
                    if (bombs[j].boundingBox.Intersects(Enemies.enemBullets[w].boundingBox))
                        Enemies.enemBullets.RemoveAt(w);
                }
            }
            
        }
    }
}
