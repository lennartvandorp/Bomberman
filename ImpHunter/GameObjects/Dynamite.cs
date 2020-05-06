using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImpHunter.GameObjects
{
    public class Dynamite : SpriteGameObject
    {
        private float speed;
        private int explosionTimer;
        public bool isExplosion;//defines wether the dynamite has exploded

        public Dynamite(string assetName, int direction, Vector2 position): base(assetName) {
            speed = 20;
            this.position = position;
            switch (direction) {
                case 0:
                    velocity.X = speed;
                    break;
                case 1:
                    velocity.X = -speed;
                    break;
                case 2:
                    velocity.Y = speed;
                    break;
                case 3:
                    velocity.Y = -speed;
                    break;
            }
        }
        public override void Update(GameTime gameTime)
        {
            position += velocity;
            explosionTimer++;
            if (explosionTimer > 10) {
                sprite = new SpriteSheet("spr_explosion", 0);
                isExplosion = true;
            }


            base.Update(gameTime);
        }
    
    }
}
