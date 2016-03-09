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
    public delegate void EventGame();
    class Scene_Menu:IScena
    {
        Texture2D[] _textury;
        SpriteFont[] _fonts;
        Song[] _songs;
        SoundEffect[] _effects;
        public event EventHandler EventNewGame;
        //
        int selected;
        public event EventGame EventClose;
        public int Selected
        {
            get
            {
                return selected;
            }
            set
            {
                if (value >= 0 && value < ilosc_pozycji)selected = value;
            }
        }
        int ilosc_pozycji = 4;//Ilosc pozycji w menu
        string[] Pozycje = { "Graj", "Edytor", "Opcje", "Wyjdz" };
        Vector2[] Wielkosci;
        int nr_czcionki = 1;
        Vector2 Pozycja_menu = new Vector2(300, 345);
        Vector2 Wielkosc_menu = new Vector2(0,0);
        Rectangle Menu = new Rectangle();
        int spacing = 5;
        public Scene_Menu(ref Texture2D[] Textury,ref SpriteFont[] Fonts,ref Song[] Songs,ref SoundEffect[] Effects)
        {
            _textury = Textury;
            _fonts = Fonts;
            _songs = Songs;
            _effects = Effects;
            selected = 0;
            Wielkosci = new Vector2[ilosc_pozycji];
            for (int i = 0; i < ilosc_pozycji; i++)
            {
                Wielkosci[i] = _fonts[nr_czcionki].MeasureString(Pozycje[i]);
                if(Wielkosci[i].X>Wielkosc_menu.X) Wielkosc_menu.X=Wielkosci[i].X;
                Wielkosc_menu.Y+=Wielkosci[i].Y;
            }
            Wielkosc_menu.X += 10;
            Wielkosc_menu.Y += 10 + ilosc_pozycji*4;
            Menu.X = (int)Pozycja_menu.X;
            Menu.Y = (int)Pozycja_menu.Y;
            Menu.Width = (int)Wielkosc_menu.X+100;
            Menu.Height = (int)Wielkosc_menu.Y;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_textury[6], new Vector2(0, 0), Color.White);
            spriteBatch.Draw(_textury[5], Menu,Color.White);
            int x=360;
            int y = 362;
            for (int i = 0; i < ilosc_pozycji; i++)
            {
                Color kolor;
                if (selected == i) kolor = Color.Red;
                else kolor = Color.Black;
                spriteBatch.DrawString(_fonts[nr_czcionki], Pozycje[i], new Vector2(x, y), kolor);
                y += (int)Wielkosci[0].Y;
            }

        }
        public void Update(GameTime gameTime)
        {
            if (Util.INPUT.Clicked(Keys.S)) Selected++;
            if (Util.INPUT.Clicked(Keys.W)) Selected--;
            if (Util.INPUT.Clicked(Keys.Enter))
            {
                switch(selected)
                {
                    case 3:
                        if(EventClose!=null)
                            EventClose();
                        break;
                    case 2:
                        Scene_Menager.Stan = Scene_Menager.State.Opcje;
                        break;
                    case 1:
                        Scene_Menager.Stan = Scene_Menager.State.Edytor;
                        break;
                    case 0:
                        if (EventNewGame != null) EventNewGame(null, null);
                        Scene_Menager.Stan = Scene_Menager.State.Gra;
                        break;
                        
                }
            }
        }


    }
}
