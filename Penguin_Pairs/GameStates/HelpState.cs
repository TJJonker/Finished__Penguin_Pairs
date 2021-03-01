using Engine;
using Microsoft.Xna.Framework.Input;

namespace Penguin_Pairs
{
    internal class HelpState : GameState
    {
        public HelpState()
        {
            SpriteGameObject helpState = new SpriteGameObject("Sprites/spr_background_help");
            gameObjects.AddChild(helpState);
        }

        public override void HandleInput(InputHelper inputHelper)
        {
            if (inputHelper.KeyPressed(Keys.Back))
                ExtendedGame.GameStateManager.SwitchTo(PenguinPairs.StateName_Title);
        }
    }
}