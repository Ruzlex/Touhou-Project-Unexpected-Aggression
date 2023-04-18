using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public class ScrollingBackground
    {
        private Texture2D HUD;
        private Texture2D texture;
        private Vector2 position1, position2;
        private int speed;
        private SpriteFont font;
        private int score;
        private int lives;
        private int bombs;
        private int power;
        private int graze;
        public PlayerReimu player;

        public ScrollingBackground(Texture2D texture, int speed, Texture2D hud, SpriteFont font, PlayerReimu player)
        {
            this.texture = texture;
            this.speed = speed;
            position1 = new Vector2(50, 0);
            position2 = new Vector2(50, -texture.Height);
            this.HUD = hud;
            this.font = font;
            this.player = player;
            score = 0;
            lives = 3;
            bombs = 3;
            player.Power = 0;
            graze = 0;
        }

        public void Update(GameTime gameTime)
        {
            position1.Y += speed;
            position2.Y += speed;

            if (position1.Y >= texture.Height)
                position1.Y = position2.Y - texture.Height;

            if (position2.Y >= texture.Height)
                position2.Y = position1.Y - texture.Height;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position1, Color.White);
            spriteBatch.Draw(texture, position2, Color.White);
            spriteBatch.Draw(HUD, new Vector2(0, 0), Color.White);

            spriteBatch.DrawString(font, "SCORE: " + score, new Vector2(669, 25), Color.White);
            spriteBatch.DrawString(font, "LIVES: " + lives, new Vector2(669, 45), Color.White);
            spriteBatch.DrawString(font, "BOMBS: " + bombs, new Vector2(669, 65), Color.White);
            spriteBatch.DrawString(font, "POWER: " + player.Power, new Vector2(669, 85), Color.White);
            spriteBatch.DrawString(font, "GRAZE: " + graze, new Vector2(669, 105), Color.White);
        }

        public void IncrementScore(int amount)
        {
            score += amount;
        }

        public void DecrementLives()
        {
            lives--;
        }

        public void DecrementBombs()
        {
            bombs--;
        }

        public void IncrementPower(int amount)
        {
            power += amount;
        }

        public void IncrementGraze()
        {
            graze++;
        }
    }
}
