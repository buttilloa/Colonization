using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
namespace Colonization
{
    class ToolTip
    {
        private static Texture2D sheet; //0, 1190, 10, 9
        private static String message1,message2;
        private static Rectangle position = new Rectangle(0,0,10,9);
       

        public static void AssignTexture(Texture2D texturesheet)
        {
            sheet = texturesheet;
           
        }
        public static void newDoubleToolTip(String mes1,String mes2, int x,int y)
       {
           message1 = mes1;
           message2 = mes2;
            if(message1.Length >= message2.Length)
               position = new Rectangle(x, y, message1.Length*7, 20);
            else
               position = new Rectangle(x, y, message2.Length * 7, 10);
       }
        public static void newToolTip(String mes1, int x, int y)
        {
            message1 = mes1;
            message2 = null;

            position = new Rectangle(x, y, message1.Length * 7, 13);
           
        }
        public static void drawToolTip(SpriteBatch batch,SpriteFont font)
        {
            if (message1 != null)
            {
                batch.Draw(sheet, position, Color.White);
                batch.DrawString(font, message1, new Vector2(position.X + 12, position.Y+2), Color.Black);
                if(message2 != null)
                batch.DrawString(font, message2, new Vector2(position.X + 12, position.Y + 10), Color.Black);
            }
        }                                                 
    
    }
}
