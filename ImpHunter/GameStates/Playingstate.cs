
using Microsoft.Xna.Framework;
using System;

namespace ImpHunter.GameStates
{
    public class Playingstate : GameObjectList
    {
        public GameObjects.Player thePlayer;
        public GameObjects.Tiles theTiles;
        int rows, columns;
        public Playingstate(int rows, int columns)
        {
            thePlayer = new GameObjects.Player("spr_player", rows, columns);
            theTiles = new GameObjects.Tiles(rows,columns);

            this.rows = rows;
            this.columns = columns;
            this.Add(theTiles);
            this.Add(thePlayer);
    }

        public override void Update(GameTime gameTime)
        {

            foreach (GameObjects.Sensor s in thePlayer.sensors) {
                foreach (GameObjects.Floor f in theTiles.Objects) {

                    if (f.Position.X < s.Position.X && f.Position.Y < s.Position.Y 
                        && f.Position.X + (Bomberman.Screen.X / columns) > s.Position.X 
                        && f.Position.Y + (Bomberman.Screen.X/rows) > s.Position.Y
                        && f.isWall)
                    {
                        thePlayer.canMove[s.whichSensor] = false;
                    }
                }
            }
            base.Update(gameTime);
        }
    }
}