using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImpHunter.GameObjects
{
    class Tiles : GameObjectGrid
    {
        private string[] sprites;
        private int sprite, gridMaker; //ints used to select where to build wall and floor tiles
        Random random = new Random();
        public Tiles(int rows, int columns) : base(rows, columns)
        {
            sprites = new string[2];
            sprites[0] = "spr_wall";
            sprites[1] = "spr_wood_floor";

            for (int x = 0; x < 10; x++) {
                for (int y = 0; y < 10; y++)
                {
                    sprite = random.Next(0, 2);
                    Console.WriteLine(sprite);
                    this.Add(new Floor(sprites[sprite]), x, y);
                    cellHeight = Bomberman.Screen.Y / columns;
                    cellWidth = Bomberman.Screen.Y / rows;
                }
            }            
        }

    }
}
