using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImpHunter.GameObjects
{
    class Tiles : GameObjectGrid
    {
        public Tiles() : base(10,10) {
            this.Add(new Floor("spr_floor"), 1, 1);
            
        }

    }
}
