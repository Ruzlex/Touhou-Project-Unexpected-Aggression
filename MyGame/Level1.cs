using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Metadata;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace MyGame
{
    public class Level1
    {

        public PlayerReimu player;
        private ScrollingBackground background;
        private Enemies enemies;
        private int waveCount;
        private float waveTimer;
        Rectangle size;
        Song song;
        public Level1(Texture2D backgroundTexture)
        {
            background = new ScrollingBackground(backgroundTexture, 2);
            size = new Rectangle(8, 6, 19, 23);
            player = new PlayerReimu(new Vector2(220, 480), 170f, 32, 48, 4, 4);
            enemies = new Enemies(player);
            waveCount = 1;
            waveTimer = 0f;
            song = Game1.Instance.Content.Load<Song>("Level1music");
            MediaPlayer.Play(song);
            MediaPlayer.IsRepeating = true;

        }

        private void SpawnFirstWave()
        {
            Enemy enemy1 = new Enemy(enemies.texture, new Vector2(200, 15), size, 100f, 2.0f, player, 1, 0, new Vector2(200, 200), new Vector2(580,200), 5, 0);
            enemy1.AttackType = AttackType.StraightLine;           
            Enemies.enemies.Add(enemy1);

            Enemy enemy2 = new Enemy(enemies.texture, new Vector2(100, -50), size, 100f, 2.0f, player, 1, 1, new Vector2(100, 150), new Vector2(30, 150), 5, 0);
            enemy2.AttackType = AttackType.StraightLine;
            Enemies.enemies.Add(enemy2);

            Enemy enemy3 = new Enemy(enemies.texture, new Vector2(300, -125), size, 100f, 2.0f, player, 1, 1, new Vector2(300, 190), new Vector2(580, 190), 5, 0);
            enemy3.AttackType = AttackType.StraightLine;
            Enemies.enemies.Add(enemy3);

            Enemy enemy4 = new Enemy(enemies.texture, new Vector2(60, -200), size, 100f, 2.0f, player, 1, 0, new Vector2(60, 170), new Vector2(30, 170), 5, 0);
            enemy4.AttackType = AttackType.StraightLine;
            Enemies.enemies.Add(enemy4);

            Enemy enemy5 = new Enemy(enemies.texture, new Vector2(500, -275), size, 100f, 2.0f, player, 1, 0, new Vector2(500, 220), new Vector2(580, 220), 5, 0);
            enemy5.AttackType = AttackType.StraightLine;
            Enemies.enemies.Add(enemy5);

            Enemy enemy6 = new Enemy(enemies.texture, new Vector2(450, -375), size, 100f, 2.0f, player, 1, 1, new Vector2(450, 180), new Vector2(580, 180), 5, 0);
            enemy6.AttackType = AttackType.StraightLine;
            Enemies.enemies.Add(enemy6);

            Enemy enemy7 = new Enemy(enemies.texture, new Vector2(100, -500), size, 100f, 2.0f, player, 1, 1, new Vector2(100, 90), new Vector2(30, 90), 5, 0);
            enemy7.AttackType = AttackType.StraightLine;
            Enemies.enemies.Add(enemy7);

            Enemy enemy8 = new Enemy(enemies.texture, new Vector2(350, -650), size, 100f, 2.0f, player, 1, 0, new Vector2(350, 150), new Vector2(580, 150), 5, 0);
            enemy8.AttackType = AttackType.StraightLine;
            Enemies.enemies.Add(enemy8);

            Enemy enemy9 = new Enemy(enemies.texture, new Vector2(520, -925), size, 100f, 2.0f, player, 1, 0, new Vector2(520, 250), new Vector2(580, 250), 5, 0);
            enemy9.AttackType = AttackType.StraightLine;
            Enemies.enemies.Add(enemy9);

            Enemy enemy10 = new Enemy(enemies.texture, new Vector2(400, -1100), size, 100f, 2.0f, player, 1, 1, new Vector2(400, 250), new Vector2(580, 250), 5, 0);
            enemy10.AttackType = AttackType.StraightLine;
            Enemies.enemies.Add(enemy10);

            Enemy enemy11 = new Enemy(enemies.texture, new Vector2(36, 150), size, 100f, 2.0f, player, 1, 1, new Vector2(580, 150), new Vector2(0, 0), 5, 0);
            enemy11.AttackType = AttackType.TowardsPlayer;
            Enemies.enemies.Add(enemy11);

            Enemy enemy12 = new Enemy(enemies.texture, new Vector2(569, 120), size, 95f, 2.0f, player, 1, 0, new Vector2(30, 120), new Vector2(0, 0), 5, 0);
            enemy12.AttackType = AttackType.TowardsPlayer;
            Enemies.enemies.Add(enemy12);

            Enemy enemy13 = new Enemy(enemies.texture, new Vector2(36, 200), size, 90f, 2.0f, player, 1, 0, new Vector2(580, 200), new Vector2(0, 0), 5, 0);
            enemy13.AttackType = AttackType.TowardsPlayer;
            Enemies.enemies.Add(enemy13);

            Enemy enemy14 = new Enemy(enemies.texture, new Vector2(36, 150), size, 85f, 2.0f, player, 1, 0, new Vector2(580, 150), new Vector2(400, 150), 5, 0);
            enemy14.AttackType = AttackType.TowardsPlayer;
            Enemies.enemies.Add(enemy14);

            Enemy enemy15 = new Enemy(enemies.texture, new Vector2(569, 100), size, 80f, 2.0f, player, 1, 1, new Vector2(30, 100), new Vector2(0, 0), 5, 0);
            enemy15.AttackType = AttackType.TowardsPlayer;
            Enemies.enemies.Add(enemy15);

            Enemy enemy16 = new Enemy(enemies.texture, new Vector2(569, 250), size, 75f, 2.0f, player, 1, 1, new Vector2(30, 250), new Vector2(0, 0), 5, 0);
            enemy16.AttackType = AttackType.TowardsPlayer;
            Enemies.enemies.Add(enemy16);

            Enemy enemy17 = new Enemy(enemies.texture, new Vector2(36, 190), size, 70f, 2.0f, player, 1, 0, new Vector2(580, 190), new Vector2(0, 0), 5, 0);
            enemy17.AttackType = AttackType.TowardsPlayer;
            Enemies.enemies.Add(enemy17);

            Enemy enemy18 = new Enemy(enemies.texture, new Vector2(569, 170), size, 100f, 2.0f, player, 1, 0, new Vector2(30, 170), new Vector2(0, 0), 5, 0);
            enemy18.AttackType = AttackType.TowardsPlayer;
            Enemies.enemies.Add(enemy18);

            Enemy enemy19 = new Enemy(enemies.texture, new Vector2(36, 220), size, 100f, 2.0f, player, 1, 1, new Vector2(580, 220), new Vector2(0, 0), 3, 0);
            enemy19.AttackType = AttackType.TowardsPlayer;
            Enemies.enemies.Add(enemy19);

            Enemy enemy20 = new Enemy(enemies.texture, new Vector2(569, 300), size, 100f, 2.0f, player, 1, 1, new Vector2(30, 300), new Vector2(0, 0), 2, 0);
            enemy20.AttackType = AttackType.TowardsPlayer;
            Enemies.enemies.Add(enemy20);
        }

        private void SpawnSecondWave()
        {
            Enemy enemy1 = new Enemy(enemies.texture, new Vector2(60, 15), size, 100f, 0.5f, player, 1, 1, new Vector2(60, 300), new Vector2(30, 300), 0, 5);
            enemy1.AttackType = AttackType.BulletSpray;
            Enemies.enemies.Add(enemy1);

            Enemy enemy2 = new Enemy(enemies.texture, new Vector2(535, 15), size, 100f, 0.5f, player, 1, 0, new Vector2(535, 300), new Vector2(580, 300), 0, 5);
            enemy2.AttackType = AttackType.BulletSpray;
            Enemies.enemies.Add(enemy2);

            Enemy enemy3 = new Enemy(enemies.texture, new Vector2(95, -15), size, 100f, 0.8f, player, 1, 1, new Vector2(95, 300), new Vector2(30, 300), 0, 5);
            enemy3.AttackType = AttackType.BulletSpray;
            Enemies.enemies.Add(enemy3);

            Enemy enemy4 = new Enemy(enemies.texture, new Vector2(500, -15), size, 100f, 0.8f, player, 1, 0, new Vector2(500, 300), new Vector2(580, 300), 0, 5);
            enemy4.AttackType = AttackType.BulletSpray;
            Enemies.enemies.Add(enemy4);

            Enemy enemy5 = new Enemy(enemies.texture, new Vector2(130, -45), size, 100f, 1f, player, 1, 1, new Vector2(130, 300), new Vector2(30, 300), 0, 5);
            enemy5.AttackType = AttackType.BulletSpray;
            Enemies.enemies.Add(enemy5);

            Enemy enemy6 = new Enemy(enemies.texture, new Vector2(465, -45), size, 100f, 1f, player, 1, 1, new Vector2(465, 300), new Vector2(580, 300), 0, 5);
            enemy6.AttackType = AttackType.BulletSpray;
            Enemies.enemies.Add(enemy6);

            Enemy enemy7 = new Enemy(enemies.texture, new Vector2(165, -75), size, 100f, 1.2f, player, 1, 0, new Vector2(165, 300), new Vector2(30, 300), 0, 5);
            enemy7.AttackType = AttackType.BulletSpray;
            Enemies.enemies.Add(enemy7);

            Enemy enemy8 = new Enemy(enemies.texture, new Vector2(430, -75), size, 100f, 1.2f, player, 1, 0, new Vector2(430, 300), new Vector2(580, 300), 0, 5);
            enemy8.AttackType = AttackType.BulletSpray;
            Enemies.enemies.Add(enemy8);

            Enemy enemy9 = new Enemy(enemies.texture, new Vector2(200, -105), size, 100f, 1.4f, player, 1, 0, new Vector2(200, 300), new Vector2(30, 300), 0, 5);
            enemy9.AttackType = AttackType.BulletSpray;
            Enemies.enemies.Add(enemy9);

            Enemy enemy10 = new Enemy(enemies.texture, new Vector2(395, -105), size, 100f, 1.4f, player, 1, 1, new Vector2(395, 300), new Vector2(580, 300), 0, 5);
            enemy10.AttackType = AttackType.BulletSpray;
            Enemies.enemies.Add(enemy10);

            Enemy enemy11 = new Enemy(enemies.texture, new Vector2(235, -135), size, 100f, 1.6f, player, 1, 1, new Vector2(235, 300), new Vector2(30, 300), 0, 5);
            enemy11.AttackType = AttackType.BulletSpray;
            Enemies.enemies.Add(enemy11);

            Enemy enemy12 = new Enemy(enemies.texture, new Vector2(360, -105), size, 100f, 1.6f, player, 1, 0, new Vector2(360, 300), new Vector2(580, 300), 0, 5);
            enemy12.AttackType = AttackType.BulletSpray;
            Enemies.enemies.Add(enemy12);

            Enemy enemy13 = new Enemy(enemies.texture, new Vector2(270, -135), size, 100f, 1.8f, player, 1, 0, new Vector2(270, 300), new Vector2(30, 300), 0, 5);
            enemy13.AttackType = AttackType.BulletSpray;
            Enemies.enemies.Add(enemy13);

            Enemy enemy14 = new Enemy(enemies.texture, new Vector2(325, -105), size, 100f, 1.8f, player, 1, 1, new Vector2(325, 300), new Vector2(580, 300), 0, 5);
            enemy14.AttackType = AttackType.BulletSpray;
            Enemies.enemies.Add(enemy14);
        }

        private void SpawnThirdWave()
        {
            Enemy enemy1 = new Enemy(enemies.texture, new Vector2(60, 15), size, 120f, 0.5f, player, 1, 1, new Vector2(60, 150), new Vector2(580, 420), 0, 0);
            enemy1.AttackType = AttackType.StraightLine;
            Enemies.enemies.Add(enemy1);

            Enemy enemy2 = new Enemy(enemies.texture, new Vector2(85, 15), size, 120f, 0.5f, player, 1, 0, new Vector2(85, 150), new Vector2(580, 400), 0, 0);
            enemy2.AttackType = AttackType.StraightLine;
            Enemies.enemies.Add(enemy2);

            Enemy enemy3 = new Enemy(enemies.texture, new Vector2(60, -15), size, 120f, 0.5f, player, 1, 1, new Vector2(60, 150), new Vector2(580, 420), 0, 0);
            enemy3.AttackType = AttackType.StraightLine;
            Enemies.enemies.Add(enemy3);

            Enemy enemy4 = new Enemy(enemies.texture, new Vector2(85, -15), size, 120f, 0.5f, player, 1, 0, new Vector2(85, 150), new Vector2(580, 400), 0, 0);
            enemy4.AttackType = AttackType.StraightLine;
            Enemies.enemies.Add(enemy4);

            Enemy enemy5 = new Enemy(enemies.texture, new Vector2(60, -45), size, 120f, 0.5f, player, 1, 1, new Vector2(60, 150), new Vector2(580, 420), 0, 0);
            enemy5.AttackType = AttackType.StraightLine;
            Enemies.enemies.Add(enemy5);

            Enemy enemy6 = new Enemy(enemies.texture, new Vector2(85, -45), size, 120f, 0.5f, player, 1, 0, new Vector2(85, 150), new Vector2(580, 400), 0, 0);
            enemy6.AttackType = AttackType.StraightLine;
            Enemies.enemies.Add(enemy6);

            Enemy enemy7 = new Enemy(enemies.texture, new Vector2(60, -75), size, 120f, 0.5f, player, 1, 1, new Vector2(60, 150), new Vector2(580, 420), 0, 0);
            enemy7.AttackType = AttackType.StraightLine;
            Enemies.enemies.Add(enemy7);

            Enemy enemy8 = new Enemy(enemies.texture, new Vector2(85, -75), size, 120f, 0.5f, player, 1, 0, new Vector2(85, 150), new Vector2(580, 400), 0, 0);
            enemy8.AttackType = AttackType.StraightLine;
            Enemies.enemies.Add(enemy8);

            Enemy enemy9 = new Enemy(enemies.texture, new Vector2(60, -105), size, 120f, 0.5f, player, 1, 1, new Vector2(60, 150), new Vector2(580, 420), 0, 0);
            enemy9.AttackType = AttackType.StraightLine;
            Enemies.enemies.Add(enemy9);

            Enemy enemy10 = new Enemy(enemies.texture, new Vector2(85, -105), size, 120f, 0.5f, player, 1, 0, new Vector2(85, 150), new Vector2(580, 400), 0, 0);
            enemy10.AttackType = AttackType.StraightLine;
            Enemies.enemies.Add(enemy10);

            Enemy enemy11 = new Enemy(enemies.texture, new Vector2(450, -410), size, 120f, 0.5f, player, 1, 1, new Vector2(450, 150), new Vector2(30, 420), 0, 0);
            enemy11.AttackType = AttackType.StraightLine;
            Enemies.enemies.Add(enemy11);

            Enemy enemy12 = new Enemy(enemies.texture, new Vector2(475, -410), size, 120f, 0.5f, player, 1, 0, new Vector2(475, 150), new Vector2(30, 400), 0, 0);
            enemy12.AttackType = AttackType.StraightLine;
            Enemies.enemies.Add(enemy12);

            Enemy enemy13 = new Enemy(enemies.texture, new Vector2(450, -440), size, 120f, 0.5f, player, 1, 1, new Vector2(450, 150), new Vector2(30, 420), 0, 0);
            enemy13.AttackType = AttackType.StraightLine;
            Enemies.enemies.Add(enemy13);

            Enemy enemy14 = new Enemy(enemies.texture, new Vector2(475, -440), size, 120f, 0.5f, player, 1, 0, new Vector2(475, 150), new Vector2(30, 400), 0, 0);
            enemy14.AttackType = AttackType.StraightLine;
            Enemies.enemies.Add(enemy14);

            Enemy enemy15 = new Enemy(enemies.texture, new Vector2(450, -470), size, 120f, 0.5f, player, 1, 1, new Vector2(450, 150), new Vector2(30, 420), 0, 0);
            enemy15.AttackType = AttackType.StraightLine;
            Enemies.enemies.Add(enemy15);

            Enemy enemy16 = new Enemy(enemies.texture, new Vector2(475, -470), size, 120f, 0.5f, player, 1, 0, new Vector2(475, 150), new Vector2(30, 400), 0, 0);
            enemy16.AttackType = AttackType.StraightLine;
            Enemies.enemies.Add(enemy16);

            Enemy enemy17 = new Enemy(enemies.texture, new Vector2(450, -500), size, 120f, 0.5f, player, 1, 1, new Vector2(450, 150), new Vector2(30, 420), 0, 0);
            enemy17.AttackType = AttackType.StraightLine;
            Enemies.enemies.Add(enemy17);

            Enemy enemy18 = new Enemy(enemies.texture, new Vector2(475, -500), size, 120f, 0.5f, player, 1, 0, new Vector2(475, 150), new Vector2(30, 400), 0, 0);
            enemy18.AttackType = AttackType.StraightLine;
            Enemies.enemies.Add(enemy18);

            Enemy enemy19 = new Enemy(enemies.texture, new Vector2(450, -530), size, 120f, 0.5f, player, 1, 1, new Vector2(450, 150), new Vector2(30, 420), 0, 0);
            enemy19.AttackType = AttackType.StraightLine;
            Enemies.enemies.Add(enemy19);

            Enemy enemy20 = new Enemy(enemies.texture, new Vector2(475, -530), size, 120f, 0.5f, player, 1, 0, new Vector2(475, 150), new Vector2(30, 400), 0, 0);
            enemy20.AttackType = AttackType.StraightLine;
            Enemies.enemies.Add(enemy20);
        }

        private void SpawnForthWave()
        {
            Enemy enemy1 = new Enemy(enemies.texture, new Vector2(60, 15), size, 120f, 0.5f, player, 1, 1, new Vector2(60, 150), new Vector2(580, 420), 0, 0);
            enemy1.AttackType = AttackType.StraightLine;
            Enemies.enemies.Add(enemy1);

            Enemy enemy2 = new Enemy(enemies.texture, new Vector2(85, 15), size, 120f, 0.5f, player, 1, 0, new Vector2(85, 150), new Vector2(580, 420), 0, 8);
            enemy2.AttackType = AttackType.BulletSpray;
            Enemies.enemies.Add(enemy2);

            Enemy enemy3 = new Enemy(enemies.texture, new Vector2(110, 15), size, 120f, 0.5f, player, 1, 1, new Vector2(110, 150), new Vector2(580, 420), 0, 0);
            enemy3.AttackType = AttackType.StraightLine;
            Enemies.enemies.Add(enemy3);

            Enemy enemy4 = new Enemy(enemies.texture, new Vector2(135, 15), size, 120f, 0.5f, player, 1, 0, new Vector2(135, 150), new Vector2(580, 420), 0, 12);
            enemy4.AttackType = AttackType.BulletSpray;
            Enemies.enemies.Add(enemy4);

            Enemy enemy5 = new Enemy(enemies.texture, new Vector2(160, 15), size, 120f, 0.5f, player, 1, 1, new Vector2(160, 150), new Vector2(580, 420), 0, 0);
            enemy5.AttackType = AttackType.StraightLine;
            Enemies.enemies.Add(enemy5);

            Enemy enemy6 = new Enemy(enemies.texture, new Vector2(185, 15), size, 120f, 0.5f, player, 1, 0, new Vector2(185, 150), new Vector2(580, 420), 0, 0);
            enemy6.AttackType = AttackType.StraightLine;
            Enemies.enemies.Add(enemy6);

            Enemy enemy7 = new Enemy(enemies.texture, new Vector2(210, 15), size, 120f, 0.5f, player, 1, 1, new Vector2(210, 150), new Vector2(580, 420), 0, 0);
            enemy7.AttackType = AttackType.StraightLine;
            Enemies.enemies.Add(enemy7);

            Enemy enemy8 = new Enemy(enemies.texture, new Vector2(235, 15), size, 120f, 0.5f, player, 1, 0, new Vector2(235, 150), new Vector2(580, 420), 0, 5);
            enemy8.AttackType = AttackType.BulletSpray;
            Enemies.enemies.Add(enemy8);

            Enemy enemy9 = new Enemy(enemies.texture, new Vector2(260, 15), size, 120f, 0.5f, player, 1, 1, new Vector2(260, 150), new Vector2(580, 420), 0, 0);
            enemy9.AttackType = AttackType.StraightLine;
            Enemies.enemies.Add(enemy9);

            Enemy enemy10 = new Enemy(enemies.texture, new Vector2(285, 15), size, 120f, 0.5f, player, 1, 0, new Vector2(285, 150), new Vector2(580, 420), 0, 0);
            enemy10.AttackType = AttackType.TowardsPlayer;
            Enemies.enemies.Add(enemy10);
        }
        public void Update(GameTime gameTime)
        {
            background.Update(gameTime);
            enemies.Update(gameTime);
            player.Update(gameTime);
            if (waveCount == 1)
            {
                waveTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;
                if (waveTimer >= 2)
                {
                    SpawnFirstWave();
                    waveTimer = 0f;
                    waveCount++;
                }
            }
            else if (waveCount == 2)
            {
                waveTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;

                if (waveTimer >= 20)
                {
                    SpawnSecondWave();
                    waveTimer = 0f;
                    waveCount++;
                }
            }
            else if (waveCount == 3)
            {
                waveTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;

                if (waveTimer >= 10)
                {
                    SpawnThirdWave();
                    waveTimer = 0f;
                    waveCount++;
                }
            }
            else if (waveCount == 4)
            {
                waveTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;

                if (waveTimer >= 10)
                {
                    SpawnForthWave();
                    waveTimer = 0f;
                    waveCount++;
                }
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            background.Draw(spriteBatch);
            enemies.Draw(spriteBatch);
            player.Draw(spriteBatch);
        }

    }

}
