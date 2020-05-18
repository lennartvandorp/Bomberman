
using Microsoft.Xna.Framework;
using System;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using ImpHunter.GameObjects;

namespace ImpHunter.GameStates
{
    public class Playingstate : GameObjectList
    {
        public GameObjects.Player thePlayer;
        public GameObjects.Player theOtherPlayer;
        public GameObjects.Tiles theTiles;
        public List<GameObject> theDynamiteList;
        private GameObject newDynamite;
        private GameObject toBeRemoved;
        private bool removeDynamite;
        public int points;
        private bool firstTimeSetup = true;//checks if the game has been restarted or started for the first time

        Score theScore;

        

        int rows, columns;
        private int throwTimer, otherThrowTimer;
        public Playingstate(int rows, int columns)
        {
            theTiles = new GameObjects.Tiles(rows, columns);
            theScore = new Score();


            Reset(rows, columns);

    }
        private void Reset( int rows, int columns) {
            this.rows = rows;
            this.columns = columns;

            if (!firstTimeSetup)
            {
                this.Remove(thePlayer);
                this.Remove(theOtherPlayer);
            }
            thePlayer = new GameObjects.Player("spr_player", rows, columns, true);
            theOtherPlayer = new GameObjects.Player("spr_player", rows, columns, false);
            theDynamiteList = new List<GameObject>();
            
            this.Add(theTiles);
            this.Add(thePlayer);
            this.Add(theOtherPlayer);
            this.Add(theScore);

            firstTimeSetup = false;
        }

        public override void Update(GameTime gameTime)
        {

            foreach (GameObjects.Sensor s in thePlayer.sensors) {
                foreach (GameObjects.Floor f in theTiles.Objects) {

                    if (f.Position.X < s.Position.X
                        && f.Position.Y < s.Position.Y
                        && f.Position.X + 80 > s.Position.X
                        && f.Position.Y + 80 > s.Position.Y
                        && f.isWall)//checks to see wether a sensor is hitting a wall
                    {
                        thePlayer.canMove[s.whichSensor] = false;
                        f.isHit = true;
                    }
                }
            }
            foreach (GameObjects.Sensor s in theOtherPlayer.sensors)
            {
                foreach (GameObjects.Floor f in theTiles.Objects)
                {

                    if (f.Position.X < s.Position.X
                        && f.Position.Y < s.Position.Y
                        && f.Position.X + 80 > s.Position.X
                        && f.Position.Y + 80 > s.Position.Y
                        && f.isWall)//checks to see wether a sensor is hitting a wall
                    {
                        theOtherPlayer.canMove[s.whichSensor] = false;
                        f.isHit = true;
                    }
                }
                theScore.UpdateText(points.ToString());
            }

            foreach (Dynamite d in theDynamiteList) {
                if (d.isExplosion)
                {
                    if (d.CollidesWith(thePlayer))
                    {
                        points++;

                        Reset(rows, columns);
                    }
                    if (d.CollidesWith(theOtherPlayer))
                    {
                        points--;
                        Reset(rows, columns);
                    }
                }
                if (d.Position.X > Bomberman.Screen.X || d.Position.Y > Bomberman.Screen.Y
                    || d.Position.X < -100 || d.Position.Y < -100)//sets dynamite up to be removed 
                {
                    toBeRemoved = d;
                    removeDynamite = true;
                }
            }
            if (removeDynamite) {
                theDynamiteList.Remove(toBeRemoved);
                this.Remove(toBeRemoved);
                removeDynamite = false;
            }
            

            base.Update(gameTime);

            
        }


        public override void HandleInput(InputHelper inputHelper)
        {
            //shoots dynamite on keypress for player1
            if (thePlayer.moving && inputHelper.IsKeyDown(thePlayer.shoot))
            {
                throwTimer++;
                if (throwTimer == 1)
                {
                    newDynamite = new GameObjects.Dynamite("spr_tnt", thePlayer.direction, thePlayer.Position);
                    theDynamiteList.Add(newDynamite);//shoots dynamite
                    this.Add(newDynamite);
                }
            }
            else throwTimer = 0;
            thePlayer.HandleInput(inputHelper);

            //shoots dynamite on keypress for player2
            if (theOtherPlayer.moving && inputHelper.IsKeyDown(theOtherPlayer.shoot))
            {
                otherThrowTimer++;
                if (otherThrowTimer == 1)
                {
                    newDynamite = new GameObjects.Dynamite("spr_tnt", theOtherPlayer.direction, theOtherPlayer.Position);
                    theDynamiteList.Add(newDynamite);//shoots dynamite 
                    this.Add(newDynamite);
                }
            }
            else otherThrowTimer = 0;
            theOtherPlayer.HandleInput(inputHelper);
        }

    }
}