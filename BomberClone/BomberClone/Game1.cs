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

namespace BomberClone
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Util.FPS_METER fps_meter = new Util.FPS_METER();
        // Textury
        Texture2D[] textury = new Texture2D[30];
        // Dzwieki
        Song[] Songs = new Song[10];
        SoundEffect[] Effects = new SoundEffect[20];
        // Fonts
        SpriteFont[] Fonts = new SpriteFont[10];

        PlayerConfig CFG_FILE;
        //
        Animation animation;
        //
        Scene_Menager Scene_menager;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = 900;
            graphics.PreferredBackBufferHeight = 600;
            this.Window.Title = "Bomber Clone V0.1";
            this.IsMouseVisible = true;
            //graphics.ToggleFullScreen();
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            textury[0] = Content.Load<Texture2D>("EditorTile"); //Editor Tile
            textury[1] = Content.Load<Texture2D>("Wall"); //SCIANA
            textury[2] = Content.Load<Texture2D>("WallDestroyable"); //SCIANA DO ZNISZCZENIA
            textury[3] = Content.Load<Texture2D>("Player1");        // SPAWN P1
            textury[4] = Content.Load<Texture2D>("Player2");        // SPAWN P2
            textury[5] = Content.Load<Texture2D>("Window");         // Okienko
            textury[6] = Content.Load<Texture2D>("Tlo");            // Tlo
            textury[7] = Content.Load<Texture2D>("floor");          // Trawa
            textury[8] = Content.Load<Texture2D>("char");          // Postac
            textury[9] = Content.Load<Texture2D>("Glyph");          // GLYPH
            textury[10] = Content.Load<Texture2D>("explosion");     // EPLOSION
            ////
            //FONTS
            Fonts[0] = Content.Load<SpriteFont>("MainFont"); // MAIN FONT
            Fonts[1] = Content.Load<SpriteFont>("Font2");


            PlayerConfig CFG_FILE = new PlayerConfig();



            Scene_menager = new Scene_Menager(ref textury, ref Fonts, ref Songs, ref Effects,ref CFG_FILE);
            Scene_Menu scene = (Scene_Menu)Scene_menager.Sceny[0];
            scene.EventClose += this.Exit;
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            Scene_menager.Update(gameTime);
            Util.INPUT.Update();
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            fps_meter.Count();
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            
            Scene_menager.Draw(spriteBatch);
            spriteBatch.DrawString(Fonts[0], "FPS:" + fps_meter.Get_Fps()+" MX:"+Util.INPUT.now_m.X+" MY:"+Util.INPUT.now_m.Y, new Vector2(0, 540), Color.Red);
            
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
