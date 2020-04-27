using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace ImpHunter.GameObjects
{
    class Player : SpriteGameObject
    {
        private int inputTimer = 0;
        private int rows, columns;
        private Vector2 lastPosition;
        private bool moving;
        private int direction;
        private float speed;

        public Player(string assetName, int rows, int columns) : base(assetName) {
            this.rows = rows;
            this.columns = columns;
            speed = 5f;
        }

        public override void HandleInput(InputHelper inputHelper)
        {
            if (inputHelper.IsKeyDown(Keys.D))
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
            else if (inputHelper.IsKeyDown(Keys.A)) {
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
            else if (inputHelper.IsKeyDown(Keys.S))
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
            else if (inputHelper.IsKeyDown(Keys.W))
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

            if (moving) {
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
        }
    }
}
