using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace ImpHunter.GameObjects
{
    public class Player : SpriteGameObject
    {
        private int inputTimer = 0;
        private int rows, columns;
        private Vector2 lastPosition;
        public bool moving, player1;//player1 determines what keys are used for gameplay and where the player starts
        public int direction;
        private float speed;
        private Vector2 sensorPos;
        public Keys left, down, right, up, shoot;
        

        public bool[] canMove;
        public GameObjects.Sensor[] sensors;

        public Player(string assetName, int rows, int columns, bool player1) : base(assetName) {
            this.rows = rows;
            this.columns = columns;
            this.player1 = player1;
            canMove = new bool[4];

            //key selection for different players
            if (player1) {
                left = Keys.A;
                up = Keys.W;
                right = Keys.D;
                down = Keys.S;
                shoot = Keys.V;
            }
            else
            {
                left = Keys.Left;
                up = Keys.Up;
                right = Keys.Right;
                down = Keys.Down;
                shoot = Keys.M;
                position.X = Bomberman.Screen.X - (columns / Bomberman.Screen.X);
                position.Y = Bomberman.Screen.Y - (rows / Bomberman.Screen.Y);
                sprite = new SpriteSheet("spr_theOtherPlayer", 0);

            }

            sensors = new Sensor[4];//This is an array of sensors that feel around the player to determine wether the player can move in a direction

            for (int i = 0; i < 4; i++) {
                switch (i) {
                    case 0:
                        sensorPos = new Vector2(-50, 30);//links
                        break;
                    case 1:
                        sensorPos = new Vector2(30, -50);//boven
                        break;
                    case 2:
                        sensorPos = new Vector2(130, 30);//rechts
                        break;
                    case 3:
                        sensorPos = new Vector2(30, 130);//benee
                        break;
                }
                sensors[i] = new Sensor("spr_empty", sensorPos, this, i);
            }

            speed = Bomberman.Screen.X / rows / 8;
        }

        public override void HandleInput(InputHelper inputHelper)
        {
            if (moving)
            {
                switch (direction)//moves the player
                {
                    case 0:
                        position.X += speed;
                        break;
                    case 1:
                        position.X -= speed;
                        break;
                    case 2:
                        position.Y += speed;
                        break;
                    case 3:
                        position.Y -= speed;
                        break;
                    default:
                        break;
                }
            }

            if (inputHelper.IsKeyDown(right) && canMove[2])//checks if there isn't a wall next to it and moves the player. 
            {
                inputTimer++;
                if (inputTimer == 1)
                {
                    if (!moving)
                    {
                        lastPosition = position;
                        direction = 0;
                    }
                    moving = true;
                }
            }
            else if (inputHelper.IsKeyDown(left) && canMove[0])
            {//checks if there isn't a wall next to it and moves the player. 
                inputTimer++;
                if (inputTimer == 1)
                {
                    if (!moving) {
                        lastPosition = position;
                        direction = 1;
                    }
                    moving = true;
                }
            }
            else if (inputHelper.IsKeyDown(down) && canMove[3])//checks if there isn't a wall next to it and moves the player. 
            {
                inputTimer++;
                if (inputTimer == 1)
                {
                    if (!moving)
                    {
                        lastPosition = position; 
                        direction = 2;

                    }
                    moving = true;
                }
            }
            else if (inputHelper.IsKeyDown(up) && canMove[1])//checks if there isn't a wall next to it and moves the player. 
            {
                inputTimer++;
                if (inputTimer == 1)
                {
                    if (!moving)
                    {
                        lastPosition = position;
                        direction = 3;
                    }
                    moving = true;
                }
            }
            else inputTimer = 0;

            if (Bomberman.Distance(position, lastPosition) >= Bomberman.Screen.X / rows) {//stops the player when it reached the next tile
                moving = false;
                inputTimer = 0;
            }

            //stops the player moving out of bounds
            if (position.X < Bomberman.Screen.X / rows && !moving) {
                position.X = 0;
                moving = false;
            }
            if(position.Y < Bomberman.Screen.Y / columns && !moving)
            {
                position.Y = 0;
                moving = false;
            }
            if (position.X < 0) {
                position.X = 0f;
                moving = false;
            }
            if (position.X > Bomberman.Screen.X - Bomberman.Screen.X / rows) {
                position.X = Bomberman.Screen.X - Bomberman.Screen.X / rows;
                moving = false;
            }
            if(position.Y < 0)
            {
                moving = false;
                position.Y = 0;
            }
            if (position.Y > Bomberman.Screen.Y - Bomberman.Screen.Y / columns) {
                position.Y = Bomberman.Screen.Y - Bomberman.Screen.Y / columns;
                moving = false;
            }

            for (int i = 0; i < canMove.Length; i++)//resets the ability for the player to move, this will be determined again the next round
            {
                canMove[i] = true;
            }
        }

        public override void Update(GameTime gameTime)
        {
            foreach(Sensor s in sensors) {//updates the sensors in the player
                s.Update(gameTime);
            }
            base.Update(gameTime);


        }
    }
}
