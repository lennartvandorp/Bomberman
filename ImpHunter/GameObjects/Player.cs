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
        private bool moving;
        private int direction;
        private float speed;
        private Vector2 sensorPos;
        public int whichSensor;

        public bool[] canMove;
        public GameObjects.Sensor[] sensors;

        public Player(string assetName, int rows, int columns) : base(assetName) {
            this.rows = rows;
            this.columns = columns;

            canMove = new bool[4];
            

            sensors = new Sensor[4];

            for (int i = 0; i < 4; i++) {
                switch (i) {
                    case 0:
                        sensorPos = new Vector2(-70, 10);
                        break;
                    case 1:
                        sensorPos = new Vector2(10, -70);
                        break;
                    case 2:
                        sensorPos = new Vector2(90, 10);
                        break;
                    case 3:
                        sensorPos = new Vector2(10, 90);
                        break;
                }
                whichSensor = i;
                sensors[i] = new Sensor("spr_empty", sensorPos, this, i);
            }

            speed = Bomberman.Screen.X / rows / 16;
        }

        public override void HandleInput(InputHelper inputHelper)
        {
            if (moving)
            {
                switch (direction)
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

            if (inputHelper.IsKeyDown(Keys.D) && canMove[2])
            {
                inputTimer++;
                if (inputTimer == 1)
                {
                    if (!moving)
                    {
                        lastPosition = position;
                    }
                    moving = true;
                    direction = 0;
                }
            }
            else if (inputHelper.IsKeyDown(Keys.A) && canMove[0]) {
                inputTimer++;
                if (inputTimer == 1)
                {
                    if (!moving) {
                        lastPosition = position;
                    }
                    moving = true;
                    direction = 1;
                }
            }
            else if (inputHelper.IsKeyDown(Keys.S) && canMove[3])
            {
                inputTimer++;
                if (inputTimer == 1)
                {
                    if (!moving)
                    {
                        lastPosition = position;
                    }
                    moving = true;
                    direction = 2;
                }
            }
            else if (inputHelper.IsKeyDown(Keys.W) && canMove[1])
            {
                inputTimer++;
                if (inputTimer == 1)
                {
                    if (!moving)
                    {
                        lastPosition = position;
                    }
                    moving = true;
                    direction = 3;
                }
            }
            else inputTimer = 0;

            if (Bomberman.Distance(position, lastPosition) >= Bomberman.Screen.X / rows) {
                moving = false;
                inputTimer = 0;
            }


            if (position.X < Bomberman.Screen.X / rows && !moving) {
                position.X = 0;
            }
            if(position.Y < Bomberman.Screen.Y / columns && !moving)
            {
                position.Y = 0;
            }
            if (position.X < 0) {
                position.X = 0f;
            }
            if (position.X > Bomberman.Screen.X - Bomberman.Screen.X / rows) {
                position.X = Bomberman.Screen.X - Bomberman.Screen.X / rows;
            }
            if(position.Y < 0)
            {
                position.Y = 0;
            }
            if (position.Y > Bomberman.Screen.Y - Bomberman.Screen.Y / columns) {
                position.Y = Bomberman.Screen.Y - Bomberman.Screen.Y / columns;
            }

            for (int i = 0; i < canMove.Length; i++)
            {
                canMove[i] = true;
            }
        }

        public override void Update(GameTime gameTime)
        {
            foreach(Sensor s in sensors) {
                s.Update(gameTime);
            }
            base.Update(gameTime);


        }
    }
}
