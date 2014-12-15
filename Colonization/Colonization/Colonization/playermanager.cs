using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Colonization
{
    class playermanager
    {
        public Sprite Player;
        public playermanager(Texture2D sheet)
        {
            Player = new Sprite(new Vector2(300, 300), sheet, new Rectangle(2, 292, 43, 102), new Vector2(0,0));
            Player.AddFrame(new Rectangle(2, 292, 43, 102));
            Player.AddFrame(new Rectangle(2, 292, 43, 102));
            Player.AddFrame(new Rectangle(2, 292, 43, 102));
            Dance();
            
        }
        public void update(GameTime time)
        {
            if (Player.Velocity.X > 0) TurnRight();
            else if (Player.Velocity.X < 0) TurnLeft();
            else if (Player.Velocity.Y < 0) TurnUp();
            else if (Player.Velocity.Y > 0) TurnDown();
            
            Player.Update(time);
        
        }
        public void TurnRight()
        {
            Player.frames[0] = new Rectangle(353, 292, 37, 106);
            Player.frames[1] = new Rectangle(393, 292, 37, 106);
            Player.frames[2] = new Rectangle(434, 292, 37, 106);
            Player.frames[3] = new Rectangle(475, 292, 37, 106);
        }
        public void TurnLeft()
        {
            Player.frames[0] = new Rectangle(54, 292, 37, 106);
            Player.frames[1] = new Rectangle(95, 292, 37, 106);
            Player.frames[2] = new Rectangle(136, 292, 37, 106);
            Player.frames[3] = new Rectangle(177, 292, 37, 106);
        }
        public void TurnUp()
        {
            Player.frames[0] = new Rectangle(218, 295, 44, 106);
            Player.frames[1] = new Rectangle(262, 295, 44, 106);
            Player.frames[2] = new Rectangle(306, 295, 44, 106);
            Player.frames[3] = new Rectangle(218, 295, 44, 106);
        }
        public void TurnDown()//for what!
        {
            Player.frames[0] = new Rectangle(515, 295, 40, 106);
            Player.frames[1] = new Rectangle(560, 295, 40, 106);
            Player.frames[2] = new Rectangle(605, 295, 40, 106);
            Player.frames[3] = new Rectangle(515, 295, 40, 106);
        }
        public void Idle()
        {
            Player.frames[0] = new Rectangle(2, 292, 43, 102);
            Player.frames[1] = new Rectangle(2, 292, 43, 102);
            Player.frames[2] = new Rectangle(2, 292, 43, 102);
            Player.frames[3] = new Rectangle(2, 292, 43, 102);
        }
        public void Dance()//we can dance if you want to!
        {
            Player.frames[0] = new Rectangle(515, 295, 40, 106);
            Player.frames[1] = new Rectangle(260, 295, 40, 106);
            Player.frames[2] = new Rectangle(305, 295, 40, 106);
            Player.frames[3] = new Rectangle(350, 295, 40, 106);
        }
    }
}
