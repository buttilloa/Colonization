using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Colonization
{
    class ShelterManager
    {
       private Texture2D sheet;
       Vector2 Location = new Vector2(15, 50);
       int upgradeLevel = 0;
       Rectangle Hitbox = new Rectangle(15, 50, 22, 22);
        public ShelterManager(Texture2D shelterSheet)
        {
            sheet = shelterSheet;
        
        }
        public void Update(GameTime gameTime,MouseState ms)
        {
            if (Hitbox.Intersects(new Rectangle(ms.X, ms.Y, 5, 5)))
            {
              ToolTip.newDoubleToolTip("Next Upgrade: ","", (int)Location.X + 22, (int)Location.Y);  
                if (ms.LeftButton == ButtonState.Pressed && UpgradeManager.CanUpgradeShelter(upgradeLevel + 1))
                    upgradeLevel++;
            }
        }
        public void Draw(SpriteBatch batch)
        {
            batch.Draw(sheet,Location, new Rectangle(upgradeLevel *25,25,22,22), Color.White);
        }
    }
}
