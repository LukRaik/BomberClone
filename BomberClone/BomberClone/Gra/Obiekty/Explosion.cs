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
    class Explosion
    {
        public Explosion(ref List<Gra.Obiekty.Game_Object> Lista_Obiektow, int lenght,Rectangle pos,Animation animacja,ref Map mapa)
        {
            Lista_Obiektow.Add(new ExploTile(animacja, pos, ref mapa));
            for (int i = 1; i < lenght; i++)//PRAWO
            {
                Lista_Obiektow.Add(new ExploTile(animacja, new Rectangle(pos.X + (i * 32), pos.Y, 32, 32), ref mapa));
            }
            for (int i = 1; i < lenght; i++)//lewo
            {
                Lista_Obiektow.Add(new ExploTile(animacja, new Rectangle(pos.X + (i * -32), pos.Y, 32, 32), ref mapa));
            }
            for (int i = 1; i < lenght; i++)//gora
            {
                Lista_Obiektow.Add(new ExploTile(animacja, new Rectangle(pos.X, pos.Y + (i * -32), 32, 32), ref mapa));
            }
            for (int i = 1; i < lenght; i++)//dol
            {
                Lista_Obiektow.Add(new ExploTile(animacja, new Rectangle(pos.X, pos.Y + (i * 32), 32, 32), ref mapa));
            }

        }
    }
}
