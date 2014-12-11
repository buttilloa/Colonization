using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Colonization
{
    class WeaponManager
    {
        private Texture2D sheet;
        Vector2 Location = new Vector2(15, 20);
        int upgradeLevel = 0;
        Rectangle Hitbox = new Rectangle(15,20,22,22);
        
        public WeaponManager(Texture2D weaponSheet)
        {
            sheet = weaponSheet;
        }
        public void Update(GameTime gameTime, MouseState ms)
        {
            if (Hitbox.Intersects(new Rectangle(ms.X, ms.Y, 5, 5)))
            {
                ToolTip.newToolTip("Next Upgrade: Stone", (int)Location.X+22, (int)Location.Y);
                if (ms.LeftButton == ButtonState.Pressed && UpgradeManager.CanUpgradeWeapon(upgradeLevel + 1))
                    upgradeLevel++;
            }
        }
       
        public void Draw(SpriteBatch batch)
        {
            batch.Draw(sheet, Location, new Rectangle(upgradeLevel * 25, 0, 22, 22), Color.White);
        }
    }
}
