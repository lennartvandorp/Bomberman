using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace ImpHunter
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Bomberman : GameEnvironment
    {
        public int rows = 11;
        public int columns = 11;
        public GameStates.Playingstate thePlayingstate;
        public int player1Score, player2Score;
        public SpriteFont font;


        public Bomberman()
        {
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            base.LoadContent();
            font = Content.Load<SpriteFont>("font");//hier laadt ik de font in
            Screen = new Point(880, 880);
            ApplyResolutionSettings();

            // TODO: use this.Content to load your game content here
            thePlayingstate = new GameStates.Playingstate(rows, columns);

            GameStateManager.AddGameState("Play", thePlayingstate);
            GameStateManager.AddGameState("Begin", new GameStates.Beginstate());
            GameStateManager.SwitchTo("Begin");
        }
        public static float Distance(Vector2 point1, Vector2 point2)
        {
            float dist;
            dist = (float)Math.Sqrt(Math.Pow(point1.X - point2.X, 2) + Math.Pow(point1.Y - point2.Y, 2));
            return dist;
            
        }
        
    }
}
