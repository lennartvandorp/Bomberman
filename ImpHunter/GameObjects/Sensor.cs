using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImpHunter.GameObjects
{
    public class Sensor : SpriteGameObject
    {
        Vector2 RelativeLocation;
        GameObjects.Player thePlayer;
        public int whichSensor;
        public Sensor(string assetName, Vector2 RelativeLocation, GameObjects.Player thePlayer, int whichSensor) : base(assetName) {
            this.RelativeLocation = RelativeLocation;
            this.thePlayer = thePlayer;
            this.whichSensor = whichSensor;
        }

        public override void Update(GameTime gameTime) {

            position = thePlayer.Position + RelativeLocation;
            base.Update(gameTime);
        }
    }
}
