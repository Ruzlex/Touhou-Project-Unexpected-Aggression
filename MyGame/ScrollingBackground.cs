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
        private Texture2D texture;
        private Vector2 position1, position2;
        private int speed;
        public PlayerReimu player;

        public ScrollingBackground(Texture2D texture, int speed)
        {
            this.texture = texture;
            this.speed = speed;
            position1 = new Vector2(50, 0);
            position2 = new Vector2(50, -texture.Height);
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
        }
    }
}
