using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImpHunter.GameObjects
{
    class Floor : SpriteGameObject
    {
        public string assetName;
        public bool isWall;
        public Floor(string assetName,bool isWall) : base(assetName) {
            this.assetName = assetName;

            this.isWall = isWall;

        }

        public override void Update(GameTime gameTime)
        {
            collision();
            base.Update(gameTime);
        }
        private void collision() {

        }

    }
}
