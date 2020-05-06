using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImpHunter.GameObjects
{
    public class BeginText : TextGameObject
    {
        public BeginText() :base("font", 0, "") {
            text = "wasd to move V to shoot, player 2: arrows to move, m to shoot. Press Space to begin. ";
        }
    }
}
