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
    class Player
    {
        PlayerCFG CFG;
        public BombMan Kukla;
        bool doing_smthg = false;
        public event EventHandler Akcja1;
        public string nazwa;
        public Player(ref PlayerCFG CFG, ref BombMan Man)
        {
            this.CFG = CFG;
            this.Kukla = Man;
        }
        public void Update(Map map)
        {
            doing_smthg = false;
            if (Util.INPUT.Pressed(CFG.keys[0]))
            {
                doing_smthg = true;
                Kukla.anim.stop_anim = false;
                Kukla.Anim_nr = 1;
                Kukla.Move(-1, 0, map);
            }
            if (Util.INPUT.Pressed(CFG.keys[1]))
            {
                doing_smthg = true;
                Kukla.anim.stop_anim = false;
                Kukla.Anim_nr = 2;
                Kukla.Move(1, 0, map);
            }
            if (Util.INPUT.Pressed(CFG.keys[2]))
            {
                doing_smthg = true;
                Kukla.anim.stop_anim = false;
                Kukla.Anim_nr = 3;
                Kukla.Move(0, -1, map);
            }
            if (Util.INPUT.Pressed(CFG.keys[3]))
            {
                doing_smthg = true;
                Kukla.anim.stop_anim = false;
                Kukla.Anim_nr = 0;
                Kukla.Move(0, 1, map);
            }
            if (Util.INPUT.Clicked(CFG.keys[4]))
            {
                if(Akcja1!=null)
                {
                    Akcja1(Kukla,null);
                }
            }
            if(doing_smthg==false)
                Kukla.anim.stop_anim = true;
        }
    }
}
