using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;


namespace MyGame
{
    public class Bonuses
    {
        private Texture2D texture;
        private Vector2 position;
        public Rectangle sourceRec;
        public List<Bonus> bonusesList;
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
            this.texture = Game1.Instance.Content.Load<Texture2D>("Bonuses"); 
            this.position = position;
            this.bonusesList = new List<Bonus>();
            this.player = player;
        }
        public void Update(GameTime gameTime)
        {

            for(int i = 0; i < this.bonusesList.Count; i++)
            {
                bonusesList[i].Update(gameTime);
                CheckCollision(player, bonusesList[i]);
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
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach(var bonus in bonusesList)
            {
                bonus.Draw(spriteBatch);
            }
        }

        public void CheckCollision(PlayerReimu player, Bonus bonus)
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
                        //case BonusType.ScoreBonus:
                        //    player.Score += 1000;
                        //    break;
                        //case BonusType.HpPlus:
                        //    player.HP += 1;
                        //    break;
                        //case BonusType.BombPlus:
                        //    player.Bombs += 1;
                        //    break;
                        //case BonusType.FullPower:
                        //    player.FullPower();
                        //    break;
                        //case BonusType.Graze:
                        //    player.Graze();
                        //    break;

                }
                bonusesList.Remove(bonus);
            }
        }

        //public static Rectangle WhichTexture(Dictionary<BonusType, Keys> keyBindings)
        //{
        //    foreach (var bind in keyBindings)
        //    {
        //        switch (bind.Key)
        //        {
        //            case BonusType.PowerUp:
        //                return new Rectangle(3, 3, 12, 12);
        //            case BonusType.ScoreBonus:
        //                return new Rectangle(19, 3, 12, 12);
        //            case BonusType.PowerUpPlus:
        //                return new Rectangle(33, 0, 16, 16);
        //            case BonusType.BombPlus:
        //                return new Rectangle(49, 0, 16, 16);
        //            case BonusType.FullPower:
        //                return new Rectangle(65, 0, 16, 16);
        //            case BonusType.HpPlus:
        //                return new Rectangle(81, 0, 16, 16);
        //            case BonusType.Graze:
        //                return new Rectangle(100, 4, 10, 10);
        //        }
        //    }
        //    return Rectangle.Empty;
        //}

        public Rectangle WhichTexture(BonusType type)
        {
            switch(type)
            {
                case BonusType.PowerUp:
                    return new Rectangle(3, 3, 12, 12);
                case BonusType.PowerUpPlus:
                    return new Rectangle(33, 0, 16, 16);
            }
            return Rectangle.Empty;
        }
    }
}
