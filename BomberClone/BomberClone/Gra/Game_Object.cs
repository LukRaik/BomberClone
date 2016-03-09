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
    abstract class Game_Object
    {
        public Animation anim;
        public event EventHandler EventBombDestroy;
        public int Anim_nr
        {
            get
            {
                return anim.Anim_nr;
            }
            set
            {
                anim.Anim_nr = value;
            }
        }
        public Rectangle pos;
        public Game_Object(Animation Animation,Rectangle pos)
        {
            anim = Animation;
            this.pos = pos;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            anim.Draw(spriteBatch, pos.X, pos.Y, Color.White);
        }
        public virtual void Update(GameTime gameTime)
        {
            anim.Update(gameTime);
        }
        public virtual void Usun()
        {
            if (EventBombDestroy != null)
            {
                EventBombDestroy(this, null);
            }
        }
    }
}
