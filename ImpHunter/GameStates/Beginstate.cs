using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using ImpHunter.GameObjects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace ImpHunter.GameStates
{
    public class Beginstate : GameObjectList
    {
        public Beginstate() {
            this.Add(new BeginText());
        }
        public override void Update(GameTime gameTime)
        {
            
            base.Update(gameTime);
        }
        public override void HandleInput(InputHelper inputHelper)
        {
            if (inputHelper.IsKeyDown(Keys.Space)) {
                Bomberman.GameStateManager.SwitchTo("Play");
            }
            base.HandleInput(inputHelper);
        }

    }
}
