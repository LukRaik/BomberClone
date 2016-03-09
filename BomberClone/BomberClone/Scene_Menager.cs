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
    class Scene_Menager:IScena
    {
        public enum State
        {
            Menu=0,
            Gra=1,
            Opcje=2,
            Edytor=3,
            Loading=4
        }
        Texture2D[] _textury;
        SpriteFont[] _fonts;
        Song[] _songs;
        SoundEffect[] _effects;
        PlayerConfig CFG;
        public static State Stan;
        public IScena[] Sceny = new IScena[5];
        public void NewGame(object o, EventArgs e)
        {
            Sceny[1] = new Gra.Scene_Game(ref _textury,ref _fonts,ref _songs,ref _effects,ref CFG);
            Gra.Scene_Game.winner = "";
            
        }
        public Scene_Menager(ref Texture2D[] Textury, ref SpriteFont[] Fonts, ref Song[] Songs, ref SoundEffect[] Effects, ref PlayerConfig plcfg)
        {
            _textury = Textury;
            _fonts = Fonts;
            _songs = Songs;
            _effects = Effects;
            CFG = plcfg;
            Stan = State.Menu;
            Sceny[0] = new Scene_Menu(ref Textury, ref Fonts, ref Songs, ref Effects);
            Sceny[3] = new Scene_Editor(ref Textury, ref Fonts);
            Sceny[2] = new Scene_Options(ref Textury, ref Fonts, ref Songs, ref Effects,ref plcfg);
            Sceny[1] = new Gra.Scene_Game(ref Textury, ref Fonts, ref Songs, ref Effects, ref plcfg);
            ((Scene_Menu)Sceny[0]).EventNewGame += NewGame;
            
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            switch (Stan)
            {
                case State.Menu:
                    Sceny[0].Draw(spriteBatch);
                    break;
                case State.Opcje:
                    Sceny[2].Draw(spriteBatch);
                    break;
                case State.Edytor:
                    Sceny[3].Draw(spriteBatch);
                    break;
                case State.Gra:
                    Sceny[1].Draw(spriteBatch);
                    break;
            }
        }
        public void Update(GameTime gameTime)
        {
            switch (Stan)
            {
                case State.Menu:
                    Sceny[0].Update(gameTime);
                    break;
                case State.Opcje:
                    Sceny[2].Update(gameTime);
                    break;
                case State.Edytor:
                    Sceny[3].Update(gameTime);
                    break;
                case State.Gra:
                    Sceny[1].Update(gameTime);
                    break;
            }
        }
    }
}
