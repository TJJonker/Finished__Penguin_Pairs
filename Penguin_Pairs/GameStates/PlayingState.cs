using Engine;

namespace Penguin_Pairs
{
    internal class PlayingState : GameState
    {
        public PlayingState()
        {
            SpriteGameObject background = new SpriteGameObject("Sprites/spr_background_level");
            gameObjects.AddChild(background);
        }
    }
}