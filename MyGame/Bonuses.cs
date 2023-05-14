using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;


namespace MyGame
{
    public class Bonuses
    {
        public static Texture2D texture;
        public static Vector2 position;
        public Rectangle sourceRec;
        public static List<Bonus> bonusesList;
        private PlayerReimu player;
        public bool IsCollected { get; private set; }
        public enum BonusType
        {
            PowerUp,
            ScoreBonus,
            HpPlus,
            BombPlus,
            FullPower,
            Graze,
            PowerUpPlus
        }
        public BonusType type { get; private set; }

        

        public Bonuses(Vector2 position, PlayerReimu player)
        {
            texture = Game1.Instance.Content.Load<Texture2D>("Bonuses"); 
            Bonuses.position = position;
            bonusesList = new List<Bonus>();
            this.player = player;
        }

        

        public void Update(GameTime gameTime)
        {
            if (bonusesList.Count > 0)
            {
                for (int i = 0; i < bonusesList.Count; i++)
                {
                    bonusesList[i].Update(gameTime);
                    
                    if (bonusesList[i].type == BonusType.Graze)
                    {
                        float distanceToPlayer = Vector2.Distance(position, player.position);
                        if (distanceToPlayer < 700)
                        {
                            bonusesList[i].AttractToPlayer(player, 10f, gameTime);
                        }
                    }
                    CheckCollision(player, bonusesList[i]);
                }
            }
            if(Keyboard.GetState().IsKeyDown(Keys.Q))
            {
                Bonus bonus = new Bonus(texture, position, WhichTexture(BonusType.PowerUp));
                bonus.type = BonusType.PowerUp;
                bonusesList.Add(bonus);
            }

            if (Keyboard.GetState().IsKeyDown(Keys.U))
            {
                Bonus bonus = new Bonus(texture, position, WhichTexture(BonusType.PowerUpPlus));
                bonus.type = BonusType.PowerUpPlus;
                bonusesList.Add(bonus);
            }

            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                Bonus bonus = new Bonus(texture, position, WhichTexture(BonusType.ScoreBonus));
                bonus.type = BonusType.ScoreBonus;
                bonusesList.Add(bonus);
            }

            if (Keyboard.GetState().IsKeyDown(Keys.E))
            {
                Bonus bonus = new Bonus(texture, position, WhichTexture(BonusType.HpPlus));
                bonus.type = BonusType.HpPlus;
                bonusesList.Add(bonus);
            }

            if (Keyboard.GetState().IsKeyDown(Keys.R))
            {
                Bonus bonus = new Bonus(texture, position, WhichTexture(BonusType.BombPlus));
                bonus.type = BonusType.BombPlus;
                bonusesList.Add(bonus);
            }

            if (Keyboard.GetState().IsKeyDown(Keys.T))
            {
                Bonus bonus = new Bonus(texture, position, WhichTexture(BonusType.FullPower));
                bonus.type = BonusType.FullPower;
                bonusesList.Add(bonus);
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Y))
            {
                Bonus bonus = new Bonus(texture, position, WhichTexture(BonusType.Graze));
                bonus.type = BonusType.Graze;
                bonusesList.Add(bonus);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach(var bonus in bonusesList)
            {
                bonus.Draw(spriteBatch);
            }
        }

        public static void CheckCollision(PlayerReimu player, Bonus bonus)
        {
            if (bonus.boundingBox.Intersects(player.boundingBox))
            {
                switch (bonus.type)
                {
                    case BonusType.PowerUp:
                        player.PowerUp();
                        break;
                    case BonusType.PowerUpPlus:
                        player.PowerUpPlus();
                        break;
                    case BonusType.ScoreBonus:
                        player.Score += 1000;
                        break;
                    case BonusType.HpPlus:
                        player.HP += 1;
                        break;
                    case BonusType.BombPlus:
                        player.BombsCount += 1;
                        break;
                    case BonusType.FullPower:
                        player.FullPower();
                        break;
                    case BonusType.Graze:
                        player.Graze += 1;
                        break;

                }
                bonusesList.Remove(bonus);
            }
        }

        public void MinusBonuses()
        {
            Random random = new Random();
            double minX = player.position.X - 120;
            double maxX = player.position.X + 120;
            double minY = player.position.Y - 80;
            double maxY = player.position.Y - 150;
            if (player.Power > 0)
            {
                for (int j = 0; j < 5; j++)
                {
                    double randomX = random.NextDouble() * (maxX - minX) + minX;
                    double randomY = random.NextDouble() * (maxY - minY) + minY;
                    Bonus bonus = new Bonus(texture, new Vector2((float)randomX, (float)randomY), WhichTexture(BonusType.PowerUp));
                    bonus.type = BonusType.PowerUp;
                    bonusesList.Add(bonus);
                    CheckCollision(player, bonus);
                }
                double randomX2 = random.NextDouble() * (maxX - minX) + minX;
                double randomY2 = random.NextDouble() * (maxY - minY) + minY;
                Bonus bonus2 = new Bonus(texture, new Vector2((float)randomX2, (float)randomY2), WhichTexture(BonusType.PowerUpPlus));
                bonus2.type = BonusType.PowerUpPlus;
                bonusesList.Add(bonus2);

                player.Power -= 16;
                if (player.Power < 0)
                    player.Power = 0;
                CheckCollision(player, bonus2);
            }
        }
        public static Rectangle WhichTexture(BonusType type)
        {
            switch(type)
            {
                case BonusType.PowerUp:
                    return new Rectangle(3, 3, 12, 12);
                case BonusType.PowerUpPlus:
                    return new Rectangle(33, 0, 16, 16);
                case BonusType.ScoreBonus:
                    return new Rectangle(19, 3, 12, 12);
                case BonusType.HpPlus:
                    return new Rectangle(81, 0, 16, 16);
                case BonusType.BombPlus:
                    return new Rectangle(49, 0, 16, 16);
                case BonusType.FullPower:
                    return new Rectangle(65, 0, 16, 16);
                case BonusType.Graze:
                    return new Rectangle(100, 4, 10, 10);
            }
            return Rectangle.Empty;
        }
    }
}
