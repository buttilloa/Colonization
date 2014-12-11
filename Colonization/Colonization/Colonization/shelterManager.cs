using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Colonization
{
    class ShelterManager
    {
       private Texture2D sheet;
        public ShelterManager(Texture2D shelterSheet)
        {
            sheet = shelterSheet;
        }
        public void Draw(SpriteBatch batch)
        {
            batch.Draw(sheet,new Vector2(300,300), new Rectangle(0,25,22,22), Color.White);
        }
    }
}
