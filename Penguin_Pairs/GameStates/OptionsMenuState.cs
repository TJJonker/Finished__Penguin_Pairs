using Engine;

namespace Penguin_Pairs
{
    internal class OptionsMenuState : GameState
    {
        public OptionsMenuState()
        {
            SpriteGameObject optionsMenu = new SpriteGameObject("Sprites/spr_background_options");
            gameObjects.AddChild(optionsMenu);
        }
    }
}