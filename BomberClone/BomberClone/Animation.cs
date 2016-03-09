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
    class Animation
    {
        int frames;
        int cur_frame;
        int anim_nr=0;
        int frame_width;
        int frame_height;
        double counter;
        double delay;
        Texture2D Sprite;
        public bool stop_anim;
        public int Anim_nr
        {
            get
            {
                return anim_nr;
            }
            set
            {
                if(anim_nr!=value)cur_frame = 0;
                anim_nr = value;
            }
        }
        public int Cur_frame
        {
            get
            {
                return cur_frame;
            }
            set
            {
                if (cur_frame == frames)
                {
                    cur_frame = 0;
                }
                else
                {
                    cur_frame++;
                }
            }
        }
        public Animation(Texture2D sprite,int anim_nr,int frames_nr,double delay)
        {
            Sprite = sprite;
            frame_width = sprite.Width / frames_nr;
            frame_height = sprite.Height / anim_nr;
            this.delay = delay;
            cur_frame = 0;
            frames = frames_nr-1;
            counter = 0;
            stop_anim = false;
        }
        public void Draw(SpriteBatch spriteBatch,int x,int y,Color Kolor)
        {
            spriteBatch.Draw(Sprite, new Vector2(x, y), new Rectangle(frame_width * cur_frame, frame_height * anim_nr, frame_width, frame_height), Kolor);
        }
        public void Update(GameTime gameTime)
        {
            if (stop_anim==true)
            {
                cur_frame = 0;
                counter = 0;
            }
            else
            {
                if (counter >= delay)
                {
                    counter = 0;
                    Cur_frame++;
                }
                counter += gameTime.ElapsedGameTime.TotalMilliseconds / 1000;
            }
        }
    }
}
