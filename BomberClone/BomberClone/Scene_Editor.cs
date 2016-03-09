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
    class Scene_Editor:IScena
    {
        Map mapa;
        Texture2D[] textury;
        SpriteFont[] fonts;
        private int _numerklocka;
        string[] Opisy_Klockow ={"Klocek\nniezniszczalny","Klocek\nniszczalny","Spawn\nGracza 1","Spawn\nGracza 2"};
        int numerklocka
        {
            get
            {
                return _numerklocka;
            }
            set
            {
                if (value >= 0 && value <= 3)
                {
                    _numerklocka = value;
                }
            }
        }
        public Scene_Editor(ref Texture2D[] Textury,ref SpriteFont[] Fonts)
        {
            mapa = new Map(22, 16,ref Textury);
            textury = Textury;
            numerklocka = 0;
            fonts = Fonts;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            mapa.Draw(spriteBatch); //352 530
            spriteBatch.DrawString(fonts[0], "Q,A - Wybor klocka,S-Zapis,L-Wczytaj\n Wczytuje i zapisuje pod \"0.txt\"\nF-Wypelnia dana kratka,Shif+F-Pustka", new Vector2(352, 510), Color.Black);
            spriteBatch.DrawString(fonts[0], "ID KLOCKA:" + numerklocka, new Vector2(710, 40), Color.Red);
            spriteBatch.DrawString(fonts[0],Opisy_Klockow[numerklocka],new Vector2(710,114),Color.Red);
            spriteBatch.DrawString(fonts[0], "Esc by wyjsc", new Vector2(730, 250), Color.Red);//730 250
            spriteBatch.Draw(textury[numerklocka + 1], new Vector2(740, 70), new Rectangle(0, 0, 32, 32), Color.White);
        }
        public void WyczyscMape()
        {
            for (int j=0; j < mapa.height; j++)
            {
                for (int i = 0; i < mapa.width; i++)
                {
                    mapa[i, j] = null;
                }
            }
        }
        public void Wypelnij()
        {
            string finito;
            if (numerklocka > 1 && numerklocka < 4)
            {
                finito = Convert.ToString(numerklocka + 89);
            }
            else
            {
                finito = Convert.ToString(numerklocka);
            }
            mapa.Wypelnij(finito);
        }
        public void Update(GameTime gameTime)
        {
            int x = Util.INPUT.now_m.X;
            int y = Util.INPUT.now_m.Y;
            if(Util.INPUT.Clicked(Keys.Q))numerklocka++;
            else if(Util.INPUT.Clicked(Keys.A))numerklocka--;
            if (Util.INPUT.Clicked(Keys.S)) mapa.Save(DateTime.Today.Second.ToString()+".txt");
            if (Util.INPUT.Clicked(Keys.L)) mapa.Load("0.txt");
            if (Util.INPUT.Pressed(Keys.LeftShift) && Util.INPUT.Clicked(Keys.F)) WyczyscMape();
            else if (Util.INPUT.Clicked(Keys.F)) Wypelnij();
            if (Util.INPUT.Clicked(Keys.Escape)) Scene_Menager.Stan = Scene_Menager.State.Menu;
            if (x < mapa.width * 32 && y < mapa.height * 32 && x >= 0 && y >= 0)
            {
                x = x / 32;
                y = y / 32;
                if (Util.INPUT.HoldLPM() && Util.INPUT.Pressed(Keys.LeftShift) == true)
                {
                    if (mapa[x, y] == null)
                    {
                        switch(numerklocka)
                        {
                            case 0:
                                new BrickWall(textury[1], ref mapa, x, y, 32, 32);
                                break;
                            case 1:
                                new DestroWall(textury[2], ref mapa, x, y, 32, 32);
                                break;
                            case 2:
                                new PlayerStart(textury[3], ref mapa, x, y, 32, 32, 91);
                                break;
                            case 3:
                                new PlayerStart(textury[4], ref mapa, x, y, 32, 32, 92);
                                break;
                        }
                    }
                }
                else if (Util.INPUT.ClickedLPM() == true)
                {
                    if (mapa[x, y] == null)
                    {
                        switch (numerklocka)
                        {
                            case 0:
                                new BrickWall(textury[1], ref mapa, x, y, 32, 32);
                                break;
                            case 1:
                                new DestroWall(textury[2], ref mapa, x, y, 32, 32);
                                break;
                            case 2:
                                new PlayerStart(textury[3], ref mapa, x, y, 32, 32, 91);
                                break;
                            case 3:
                                new PlayerStart(textury[4], ref mapa, x, y, 32, 32, 92);
                                break;
                        }
                    }
                }
                if (Util.INPUT.HoldPPM() && Util.INPUT.Pressed(Keys.LeftShift) == true)
                {
                    if (mapa[x, y] != null)
                    {
                        mapa[x, y] = null;
                    }
                }
                else if (Util.INPUT.HoldPPM() == true)
                {
                    if (mapa[x, y] != null)
                    {
                        mapa[x, y] = null;
                    }
                }
            }
        }
    }
}
