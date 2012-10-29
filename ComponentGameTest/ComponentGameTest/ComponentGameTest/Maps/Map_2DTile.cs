using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace ComponentGameTest
{
    class Map_2DTile
    {
        int[,] map = new int[GameConstants.MapWidth, GameConstants.MapHeight];

        Dictionary<int, Texture2D> tiles = new Dictionary<int, Texture2D>();

        public int[,] Map
        {
            get { return map;}
        }

        public Map_2DTile()
        {

        }


        public void Load(ContentManager Content, string FilePath)
        {
            string[] mapData = File.ReadAllLines("./Content/SampleMap.txt");

            // Fill map with empty tiles in case of error in map, don't want null in any of these.
            for (int x = 0; x < GameConstants.MapWidth; x++)
            {
                for (int y = 0; y < GameConstants.MapHeight; y++)
                {
                    map[x, y] = 0;
                }
            }

            int mapX = 0;
            int mapY = 0;
            foreach (string s in mapData)
            {
                string[] split = s.Split(' ');

                switch (split[0].ToLower())
                {
                    case "t":
                        {
                            tiles.Add(Convert.ToInt32(split[1]), Content.Load<Texture2D>(split[2]));
                            break;
                        }
                    case "m":
                        {

                            for (int i = 1; i < split.Length; i++)
                            {
                                map[mapX, mapY] = Convert.ToInt32(split[i]);
                                mapX++;
                            }
                            mapY++;
                            mapX = 0;
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            for (int x = 0; x < GameConstants.MapWidth; x++)
            {
                for (int y = 0; y < GameConstants.MapHeight; y++)
                {
                    spriteBatch.Draw(tiles[map[x,y]], new Vector2(x*GameConstants.TileWidth, y*GameConstants.TileHeight), Color.White);
                }
            }
        }

    }
}
