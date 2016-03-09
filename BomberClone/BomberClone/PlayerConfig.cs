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
using System.Xml.Serialization;
using System.IO;
using System.Runtime.Serialization.Formatters;

namespace BomberClone
{
    public class PlayerCFG
    {
        public string Name;
        public PlayerCFG(string name)
        {
            Name = name;
        }
        public Keys[] keys{get;set;}
    }
    public class PlayerConfig
    {
        public PlayerCFG[] Players{get;set;}
        public PlayerConfig()
        {
            Players = new PlayerCFG[2];
            Players[0] = new PlayerCFG("P1");
            Players[1] = new PlayerCFG("P2");
            Players[0].keys = new Keys[7];
            Players[1].keys = new Keys[7];
        }
    }
}
