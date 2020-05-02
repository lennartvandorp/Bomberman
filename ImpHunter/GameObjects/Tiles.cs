using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImpHunter.GameObjects
{
    public class Tiles : GameObjectGrid
    {
        private string[] sprites;
        private int sprite;
        private bool isWall;
        private int[] gridMaker = {
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};//ints used to select where to build wall and floor tiles
        Random random = new Random();
        public Tiles(int rows, int columns) : base(rows, columns)
        {
            Console.WriteLine("gridmaker length     " + gridMaker.Length + "  " + columns * rows);
            sprites = new string[2];
            sprites[0] = "spr_wood_floor";
            sprites[1] = "spr_wall";
            //gridMaker = new int[100];

            //gridMaker = { 0, 0};

            for (int x = 0; x < columns; x++) {
                for (int y = 0; y < rows; y++)
                {
                    sprite = rows * y + x;
                    if (gridMaker[sprite] == 1) {
                        isWall = true;
                    }
                    this.Add(new Floor(sprites[gridMaker[sprite]], isWall), x, y);
                    cellHeight = Bomberman.Screen.Y / columns;
                    cellWidth = Bomberman.Screen.X / rows;
                }
            }            
        }

    }
}
