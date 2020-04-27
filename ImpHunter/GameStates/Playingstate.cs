
namespace ImpHunter.GameStates
{
    internal class Playingstate : GameObjectList
    {
        public Playingstate(int rows, int columns)
        {
            this.Add(new GameObjects.Tiles(rows, columns));
            this.Add(new GameObjects.Player("spr_player", rows, columns));
    }
    }
}