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
    public abstract class Map_Object
    {
        Texture2D texture;
        int X;
        int Y;
        Map mapa;
        int Width;
        int Height;
        public int editor_id;
        public Rectangle collider;
        public Map_Object(Texture2D tekstura,ref Map map,int x,int y,int width,int height)
        {
            texture = tekstura;
            mapa = map;
            X = x;
            Y = y;
            Width = width;
            Height = height;
            mapa[X, Y] = this;
            collider = new Rectangle(X * width, Y * height, Width, Height);
        }
        public Map_Object(Texture2D tekstura,int x,int y,int width,int height)
        {
            
            texture = tekstura;
            X = x;
            Y = y;
            Width = width;
            Height = height;
            collider = new Rectangle(X * width, Y * height, Width, Height);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, new Vector2(X * Width, Y * Width), Color.White);
        }
        public void Update(GameTime gameTime)
        {
        }
    }
}
