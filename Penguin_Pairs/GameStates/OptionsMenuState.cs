using Engine;
using Microsoft.Xna.Framework.Input;

namespace Penguin_Pairs
{
    internal class OptionsMenuState : GameState
    {
        public OptionsMenuState()
        {
            SpriteGameObject optionsMenu = new SpriteGameObject("Sprites/spr_background_options");
            gameObjects.AddChild(optionsMenu);
        }

        public override void HandleInput(InputHelper inputHelper)
        {
            if (inputHelper.KeyPressed(Keys.Back))
                ExtendedGame.GameStateManager.SwitchTo(PenguinPairs.StateName_Title);
        }

    }
}