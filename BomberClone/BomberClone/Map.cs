using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using System.Runtime.Serialization.Formatters;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace BomberClone
{
    public class Map
    {
        Vector2 tile = new Vector2(32, 32);
        public int width;
        public int height;
        public Map_Object[,] Mapa{get;private set;}
        Texture2D[] textures;
        Texture2D Tile;
        public bool Game_Mode = false;
        public Map_Object this[int i,int j]
        {
            get
            {
                return Mapa[i, j];
            }
            set
            {
                Mapa[i, j] = value;
            }
        }
        public Map()
        {

        }
        public void Usun_Na_Pozycji(Rectangle position)
        {
            for (int j = 0; j < height; j++)
            {
                for (int i = 0; i < width; i++)
                {
                    if (Mapa[i, j] is Map_Object && !(Mapa[i,j] is BrickWall))
                    {
                        if (position.Intersects(Mapa[i, j].collider))
                        {
                            Mapa[i, j] = null;
                        }
                    }
                }
            }
        }
        public Map(int m_x,int m_y,ref Texture2D[] Textures)
        {
            Mapa = new Map_Object[m_x, m_y];
            Tile = Textures[0];
            textures = Textures;
            width = m_x;
            height = m_y;
        }
        public void Wypelnij(string id)
        {
            for (int j = 0; j < height; j++)
            {
                for (int i = 0; i < width; i++)
                {
                    switch (id)
                    {
                        case "0":
                            Mapa[i, j] = new BrickWall(textures[1], i, j, 32, 32);
                            break;
                        case "1":
                            Mapa[i, j] = new DestroWall(textures[2], i, j, 32, 32);
                            break;
                        case "91":
                            Mapa[i, j] = new PlayerStart(textures[3], i, j, 32, 32, 91);
                            break;
                        case "92":
                            Mapa[i, j] = new PlayerStart(textures[4], i, j, 32, 32, 92);
                            break;
                    }
                }
            }
        }
        public void Load(string path)
        {
            Mapa = new Map_Object[width, height];
            StreamReader asd = new StreamReader(path);
            for (int j = 0; j < height; j++)
            {
                string[] buffor = asd.ReadLine().Split('|');
                for (int i = 0; i < width; i++)
                {
                    switch (buffor[i])
                    {
                        case "0":
                            Mapa[i, j] = new BrickWall(textures[1], i, j, 32, 32);
                            break;
                        case "1":
                            Mapa[i, j] = new DestroWall(textures[2], i, j, 32, 32);
                            break;
                        case "91":
                            Mapa[i, j] = new PlayerStart(textures[3], i, j, 32, 32, 91);
                            break;
                        case "92":
                            Mapa[i, j] = new PlayerStart(textures[4], i, j, 32, 32, 92);
                            break;
                    }

                    
                }
            }
            asd.Close();
        }
        public void Save(string path)
        {
            StreamWriter asd = new StreamWriter(path);
            for (int j=0; j < height; j++)
            {
                for (int i = 0; i < width; i++)
                {
                    if (Mapa[i, j] != null)
                    {
                        asd.Write(Mapa[i, j].editor_id);
                    }
                    else
                    {
                        asd.Write("E");
                    }
                    if (i + 1 != width)asd.Write("|");
                }
                asd.WriteLine();
            }
            asd.Close();
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    if (Mapa[i, j] == null||Game_Mode==true&&Mapa[i,j] is PlayerStart)
                    {
                        if (Game_Mode == false)
                        {
                            spriteBatch.Draw(Tile, new Vector2(i * tile.X, j * tile.Y), Color.White);
                        }
                        else
                        {
                            spriteBatch.Draw(textures[7], new Vector2(i * tile.X, j * tile.Y), Color.White);
                        }
                    }
                    else
                    {
                        Mapa[i, j].Draw(spriteBatch);
                    }
                }
            }
        }
        public void Update(GameTime gameTime)
        {
            //Tutaj bedzie update
        }


    }
}
