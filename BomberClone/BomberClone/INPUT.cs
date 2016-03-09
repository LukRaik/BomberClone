using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Util
{
    static class INPUT
    {
        static private KeyboardState old;
        static public KeyboardState now { get; private set; }
        static private MouseState old_m;
        static public MouseState now_m;
        static public List<Keys> konfiguracja = new List<Keys>();
        static public void Update()
        {
            old = now;
            now = Keyboard.GetState();
            old_m = now_m;
            now_m = Mouse.GetState();
        }
        static public bool Clicked(Keys key)
        {
            if (old.IsKeyUp(key) && now.IsKeyDown(key)) return true;
            return false;
        }
        static public bool ClickedLPM()
        {
            if (old_m.LeftButton == ButtonState.Released && now_m.LeftButton == ButtonState.Pressed) return true;
            return false;
        }
        static public bool HoldLPM()
        {
            if (now_m.LeftButton == ButtonState.Pressed) return true;
            return false;
        }
        static public bool ClickedPPM()
        {
            if (old_m.RightButton == ButtonState.Released && now_m.RightButton == ButtonState.Pressed) return true;
            return false;
        }
        static public bool HoldPPM()
        {
            if (now_m.RightButton == ButtonState.Pressed) return true;
            return false;
        }
        static public bool Pressed(Keys key)
        {
            if (now.IsKeyDown(key)) return true;
            return false;
        }
        static public bool Relased(Keys key)
        {
            if (now.IsKeyUp(key)) return true;
            return false;
        }
    }
}
