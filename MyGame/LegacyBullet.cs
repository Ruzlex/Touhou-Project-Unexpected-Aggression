using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public class LegacyBullet
    {
        private Texture2D texture;          // Текстура снаряда
        private Vector2 position;           // Позиция снаряда
        private Vector2 velocity;           // Скорость снаряда
        private Rectangle boundingBox;      // Ограничивающий прямоугольник снаряда
        private const float speed = 500f;   // Скорость снаряда (пиксели в секунду)

        public LegacyBullet(Texture2D texture, Vector2 position, Vector2 direction)
        {
            texture = Game1.Instance.Content.Load<Texture2D>("bullet");
            this.texture = texture;
            this.position = position;
            velocity = direction * speed;   // Вычисляем скорость снаряда по направлению движения
            boundingBox = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);  // Создаем ограничивающий прямоугольник
        }

        public void Update(GameTime gameTime)
        {
            position += velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;    // Обновляем позицию снаряда на основе его скорости
            boundingBox.Location = position.ToPoint();     // Обновляем позицию ограничивающего прямоугольника
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);   // Отрисовываем снаряд
        }

        public bool IsOnScreen
        {
            get
            {
                Rectangle screenRectangle = new Rectangle(0, 0, GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width, GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height);  // Создаем прямоугольник экрана
                return boundingBox.Intersects(screenRectangle);   // Проверяем, пересекается ли ограничивающий прямоугольник снаряда с экраном
            }
        }

        public Rectangle BoundingBox
        {
            get { return boundingBox; }   // Возвращаем ограничивающий прямоугольник снаряда
        }
    }
}
