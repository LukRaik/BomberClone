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
    class ExploTile:Game_Object
    {
        double counter;
        double destroy;
        public event EventHandler EventBombDestroy;
        public ExploTile(Animation Animation, Rectangle pos,ref Map mapa)
            : base(Animation, pos)
        {
            destroy = 1.5;
            counter = 0;
            mapa.Usun_Na_Pozycji(pos);
        }
        public override void Update(GameTime gameTime)
        {
            foreach (Player obj in Scene_Game.Lista_Graczy)
            {
                if (obj.Kukla.pos.Intersects(this.pos))
                {
                    Scene_Game.winner = obj.nazwa;
                }
            }
            if (counter >= destroy)
            {
                counter = 0;
                Scene_Game.Lista_Smietnik.Add(this);
            }
            else
            {
                counter += gameTime.ElapsedGameTime.TotalMilliseconds / 1000;
            }
            base.Update(gameTime);
        }
        public override void Usun()
        {
            if (EventBombDestroy != null)
            {
                EventBombDestroy(this, null);
            }
        }
    }
}
