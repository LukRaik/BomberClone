using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace BomberClone.Gra.Obiekty
{
    class BombMan:Game_Object
    {
        int HP = 3;
        int move_speed;
        public BombMan(Animation Animation,Rectangle pos,int Move_speed):base(Animation,pos)
        {
            move_speed = Move_speed;
            anim.stop_anim = true;
        }
        public bool Move(int x, int y, Map map)
        {
            Rectangle testrect = new Rectangle(pos.X+(move_speed*x),pos.Y+(move_speed*y),pos.Width,pos.Height);
            foreach (Map_Object obj in map.Mapa)
            {
                if (obj != null)
                {
                    if (obj.collider.Intersects(testrect) == true && !(obj is PlayerStart))
                    {
                        return false;
                    }
                }
            }
            pos.X += move_speed * x;
            pos.Y += move_speed * y;
            return true;
        }

    }
}
