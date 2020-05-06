using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImpHunter.GameObjects
{
    public class Score : TextGameObject
    {
        public Score(): base("font", 0, ""){
            position.X = Bomberman.Screen.X / 2;
            }
        public void UpdateText(string text)
        {
            this.text = text;
        }
    }
}
