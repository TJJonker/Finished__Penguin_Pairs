using Engine;

namespace Penguin_Pairs
{
    internal class HelpState : GameState
    {
        public HelpState()
        {
            SpriteGameObject helpState = new SpriteGameObject("Sprites/spr_background_help");
            gameObjects.AddChild(helpState);
        }
    }
}