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
    class Scene_Options:IScena
    {
        Texture2D[] _textury;
        SpriteFont[] _fonts;
        Song[] _songs;
        SoundEffect[] _effects;
        PlayerConfig CFG;
        String[] podpisy = { "LEWO:", "PRAWO:", "DOL:", "GORA:", "AKCJA1:", "AKCJA2:", "AKCJA3:" };
        int selected;
        int selected_y;
        bool changing = false;
        int Selected
        {
            get
            {
                return selected;
            }
            set
            {
                if (value >= 0 && value <= 6)
                    selected = value;
            }
        }
        int Selected_y
        {
            get
            {
                return selected_y;
            }
            set
            {
                if (value >= 0 && value <= 1)
                    selected_y = value;
            }
        }
        public Scene_Options(ref Texture2D[] Textury,ref SpriteFont[] Fonts,ref Song[] Songs,ref SoundEffect[] Effects,ref PlayerConfig cfg)
        {
            selected = 0;
            selected_y = 0;
            _textury = Textury;
            _fonts = Fonts;
            _songs = Songs;
            _effects = Effects;
            CFG = cfg;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            Color kolor;
            int spacing = (int)_fonts[1].MeasureString(podpisy[0]).X + 4;
            for(int j=0;j<2;j++)
            {
                int x = 200;
                int y = 100;
                if (j == 1)
                {
                    x = 500;
                }
                for (int i = 0; i < 7; i++)
                {
                    if (i == selected && j == selected_y) kolor = Color.Red;
                    else kolor = Color.Black;
                    if (i == selected && j == selected_y && changing == true)
                    {
                        spriteBatch.DrawString(_fonts[1], "Wcisnij Klawisz", new Vector2(x, y), kolor);
                    }
                    else
                    {
                        spriteBatch.DrawString(_fonts[1], podpisy[i] + CFG.Players[j].keys[i].ToString(), new Vector2(x, y), kolor);
                    }
                    y += spacing;
                    
                }
            }
            //230,55
            spriteBatch.DrawString(_fonts[0], "Gracz 1", new Vector2(230, 55), Color.Black);

            //520,55
            spriteBatch.DrawString(_fonts[0], "Gracz 2", new Vector2(520, 55), Color.Black);
        }
        public void Update(GameTime gameTime)
        {
            if (changing == true&&Util.INPUT.now.GetPressedKeys().Length == 1 && Util.INPUT.now.GetPressedKeys()[0] != Keys.Enter)
            {
                CFG.Players[Selected_y].keys[Selected] = Util.INPUT.now.GetPressedKeys()[0];
                changing = false;
            }
            if(Util.INPUT.Clicked(Keys.W)) Selected--;
            if (Util.INPUT.Clicked(Keys.S)) Selected++;
            if (Util.INPUT.Clicked(Keys.A)) Selected_y--;
            if (Util.INPUT.Clicked(Keys.D)) Selected_y++;
            if (Util.INPUT.Clicked(Keys.Escape)) Scene_Menager.Stan = Scene_Menager.State.Menu;
            if (changing == false && Util.INPUT.Clicked(Keys.Enter)) changing = true;

        }
    }
}
