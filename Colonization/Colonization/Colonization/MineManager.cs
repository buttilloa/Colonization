using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using xTile;
using xTile.Dimensions;
using xTile.Display;


namespace Colonization
{
    class MineManager
    {
        public Map mine;
        IDisplayDevice mapDisplayDevice;
        xTile.Dimensions.Rectangle viewport;
       public bool isHighlighted = false;
       public Location Highlighted;
        public MineManager(ContentManager content, GraphicsDevice graphicsDevice)
        {
         
             mapDisplayDevice = new XnaDisplayDevice(content, graphicsDevice);
             mine = content.Load<Map>("MineMap");
             mine.LoadTileSheets(mapDisplayDevice);
            
            viewport = new xTile.Dimensions.Rectangle(new Size(800, 600));
            
        }
        public void switchToMine(PlayerManager player)
        {
            player.Player.Location = new Vector2(10, 116);

        }
        public void Update(long time)
        {
            MouseState ms = Mouse.GetState();
            if(ms.X >96)
            {
                isHighlighted = true;
            }
           
           mine.Update(time);
        }

        public void Draw()
        {
            mine.Draw(mapDisplayDevice, viewport);
           
        }
    }
}
