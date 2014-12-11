using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Colonization
{
    class UpgradeManager
    {

        public static bool CanUpgradeShelter(int NextUpgrade)
        {
            switch (NextUpgrade)
            {
                case 1:
                    {
                        if (Game1.WoodCount >= 5)
                        {
                            Game1.WoodCount -= 5;
                            return true;
                        }
                        break;
                    }
                case 2:
                    {
                        if (Game1.WoodCount >= 10)
                        {
                            Game1.WoodCount -= 10;
                            return true;
                        }
                        break;
                    }
                case 3:
                    {
                        if (Game1.WoodCount >= 10 && Game1.StoneCount >=5)
                        {
                            Game1.WoodCount -= 10;
                            Game1.StoneCount -= 5;
                            return true;
                        }
                        break;
                    }
                case 4:
                    {
                        if (Game1.IronCount >= 1 && Game1.StoneCount >= 10 && Game1.WoodCount >= 15)
                        {
                            Game1.IronCount -= 1;
                            Game1.StoneCount -= 10;
                            Game1.WoodCount -= 15;
                            return true;
                        }
                        break;
                    }
                case 5:
                    {
                        if (Game1.IronCount >= 5 && Game1.StoneCount >= 15 && Game1.WoodCount >= 20)
                        {
                            Game1.IronCount -= 5;
                            Game1.StoneCount -= 15;
                            Game1.WoodCount -= 20;
                            return true;
                        }
                        break;
                    }

                case 6:
                    {
                        if (Game1.IronCount >= 10 && Game1.StoneCount >= 10 && Game1.WoodCount >= 10)
                        {
                            Game1.IronCount -= 10;
                            Game1.StoneCount -= 10;
                            Game1.WoodCount -= 10;
                            return true;
                        }
                        break;
                    }
            }
            return false;

        }
        public static bool CanUpgradeWeapon(int NextUpgrade)
        {
            switch (NextUpgrade)
            {
                case 1:
                    {
                        if (Game1.WoodCount >= 10)
                        {
                            Game1.WoodCount -= 10;
                            return true;
                        }
                        break;
                    }
                case 2:
                    {
                        if (Game1.WoodCount >= 5 && Game1.StoneCount >= 5)
                        {
                            Game1.WoodCount -= 10;
                            Game1.StoneCount -= 5;
                            return true;
                        }
                        break;
                    }
                case 3:
                    {
                        if (Game1.StoneCount >= 10)
                        {
                            Game1.StoneCount -= 5;
                            return true;
                        }
                        break;
                    }
                case 4:
                    {
                        if (Game1.IronCount >= 5 && Game1.StoneCount >= 5)
                        {
                            Game1.IronCount -= 10;
                            Game1.StoneCount -= 5;
                            return true;
                        }
                        break;
                    }
                case 5:
                    {
                        if (Game1.IronCount >= 10)
                        {
                            Game1.IronCount -= 10;
                            return true;
                        }
                        break;
                    }
            }
            return false;
           
        }
    }
}
