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

namespace BomberClone.Gra
{
    class Scene_Game:IScena
    {
        Map Mapa;
        Texture2D[] _textury;
        SpriteFont[] _fonts;
        Song[] _songs;
        SoundEffect[] _effects;
        PlayerConfig CFG;
        Obiekty.Player Player1;
        Obiekty.Player Player2;
        List<Gra.Obiekty.Game_Object> Lista_Obiektow = new List<Gra.Obiekty.Game_Object>();
        public static List<Gra.Obiekty.Player> Lista_Graczy = new List<Gra.Obiekty.Player>();
        public static List<Gra.Obiekty.Game_Object> Lista_Smietnik = new List<Gra.Obiekty.Game_Object>();
        public static string winner = "";


        public Scene_Game(ref Texture2D[] Textury, ref SpriteFont[] Fonts, ref Song[] Songs, ref SoundEffect[] Effects, ref PlayerConfig cfg)
        {
            _textury = Textury;
            _fonts = Fonts;
            _songs = Songs;
            _effects = Effects;
            CFG = cfg;
            Mapa = new Map(22, 16,ref Textury);
            Mapa.Load("basemap.map");
            Mapa.Game_Mode = true;
            Rectangle spawn = new Rectangle(2,2,3,3);
            foreach(Map_Object obj in Mapa.Mapa)
            {
                if(obj is PlayerStart && (obj as PlayerStart).editor_id==91)
                {
                    spawn=(obj as PlayerStart).collider;
                }
            }
            Obiekty.BombMan bomb1 = new Gra.Obiekty.BombMan(new Animation(_textury[8], 4, 3, 0.15), spawn, 4);
            foreach (Map_Object obj in Mapa.Mapa)
            {
                if (obj is PlayerStart && (obj as PlayerStart).editor_id == 92)
                {
                    spawn = (obj as PlayerStart).collider;
                }
            }
            Obiekty.BombMan bomb2 = new Gra.Obiekty.BombMan(new Animation(_textury[8], 4, 3, 0.15), spawn, 4);
            Lista_Obiektow.Add(bomb1);
            Lista_Obiektow.Add(bomb2);
            //Gracz 1
            CFG.Players[0].Name = "Gracz 1";
            CFG.Players[1].Name = "Gracz 2";
            CFG.Players[0].keys[0] = Keys.A;
            CFG.Players[0].keys[1] = Keys.D;
            CFG.Players[0].keys[2] = Keys.W;
            CFG.Players[0].keys[3] = Keys.S;
            CFG.Players[0].keys[4] = Keys.T;
            //Gracz 2
            CFG.Players[1].keys[0] = Keys.Left;
            CFG.Players[1].keys[1] = Keys.Right;
            CFG.Players[1].keys[2] = Keys.Up;
            CFG.Players[1].keys[3] = Keys.Down;
            CFG.Players[1].keys[4] = Keys.P;
            Player1 = new Obiekty.Player(ref CFG.Players[0], ref bomb1);
            Player2 = new Obiekty.Player(ref CFG.Players[1], ref bomb2);
            Player1.nazwa = "Gracz 1";
            Player2.nazwa = "Gracz 2";
            Lista_Graczy.Add(Player1);
            Lista_Graczy.Add(Player2);
            Player1.Akcja1 += SpawnBomb;
            Player2.Akcja1 += SpawnBomb;
        }
        public void SpawnBomb(Object obj, EventArgs Args)
        {
            Gra.Obiekty.Bomb bomba = new Gra.Obiekty.Bomb(new Animation(_textury[9], 2, 5, 0.5), (obj as Obiekty.BombMan).pos);
            Lista_Obiektow.Add(bomba);
            bomba.EventBombDestroy += (Object objj, EventArgs args) =>  Lista_Obiektow.Remove((Gra.Obiekty.Bomb)objj);

        }
        public void Draw(SpriteBatch spriteBatch)
        {
            Mapa.Draw(spriteBatch);
            foreach (Gra.Obiekty.Game_Object obj in Lista_Obiektow)
            {
                obj.Draw(spriteBatch);
            }
            if (winner != "")
            {
                spriteBatch.DrawString(_fonts[0], "Wygral " + winner + "\n Nacisnij ESC", new Vector2(200, 200), Color.Red);
            }
        }
        public void Update(GameTime gameTime)
        {
            if (winner == "")
            {
                foreach (Gra.Obiekty.Game_Object obj in Lista_Obiektow)
                {
                    obj.Update(gameTime);
                }
                if (Lista_Smietnik.Count != 0)
                {
                    foreach (Obiekty.Game_Object obj in Lista_Smietnik)
                    {
                        if (obj is Obiekty.Bomb)
                        {
                            new Obiekty.Explosion(ref Lista_Obiektow, 3, obj.pos, new Animation(_textury[10], 1, 4, 0.25), ref Mapa);
                            (obj as Obiekty.Bomb).Usun();
                        }
                        else if (obj is Obiekty.ExploTile)
                        {
                            Lista_Obiektow.Remove(obj);
                        }
                        else if (obj is Obiekty.BombMan)
                        {
                            Lista_Obiektow.Remove(obj);
                        }
                    }
                    Lista_Smietnik = new List<Obiekty.Game_Object>();
                }
                Player1.Update(Mapa);
                Player2.Update(Mapa);
            }
            else
            {
                if(Util.INPUT.Pressed(Keys.Escape))
                {
                    Scene_Menager.Stan = Scene_Menager.State.Menu;
                }
            }
        }
    }
}
