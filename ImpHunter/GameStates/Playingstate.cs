using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace ImpHunter.GameStates
{
    class Playingstate : GameObjectList
    {
        public Playingstate(){
            this.Add(new GameObjects.Tiles());
            this.Add(new SpriteGameObject("spr_background"));
}
    }
}
