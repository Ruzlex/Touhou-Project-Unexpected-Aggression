using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public class HUD
    {
        private Texture2D hud;
        private SpriteFont font;
        public PlayerReimu player;

        public HUD(Texture2D hud, SpriteFont font, PlayerReimu player)
        {
            this.hud = hud;
            this.font = font;
            this.player = player;
            player.Score = 0;
            player.HP = 3;
            player.BombsCount = 3;
            player.Power = 0;
            player.Graze = 0;
        }

        public void Update(GameTime gameTime)
        {
            if (player.Score == 1000000)
                player.HP++;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(hud, new Vector2(0, 0), Color.White);

            spriteBatch.DrawString(font, "SCORE: " + player.Score, new Vector2(669, 25), Color.White);
            spriteBatch.DrawString(font, "LIVES: " + player.HP, new Vector2(669, 45), Color.White);
            spriteBatch.DrawString(font, "BOMBS: " + player.BombsCount, new Vector2(669, 65), Color.White);
            spriteBatch.DrawString(font, "POWER: " + player.Power, new Vector2(669, 85), Color.White);
            spriteBatch.DrawString(font, "GRAZE: " + (int)player.Graze, new Vector2(669, 105), Color.White);
        }
    }
}
