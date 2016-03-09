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

namespace BomberClone
{
    class DestroWall:Map_Object
    {
        public DestroWall(Texture2D tekstura, ref Map map, int x, int y, int width, int height):base(tekstura,ref map,x,y,width,height)
        {
            editor_id = 1;
        }
        public DestroWall(Texture2D tekstura, int x, int y, int width, int height)
            : base(tekstura, x, y, width, height)
        {
            editor_id = 1;
        }
        public void Update(GameTime gameTime)
        {
            //
        }
    }
}
