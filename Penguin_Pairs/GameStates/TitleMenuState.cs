using Engine;
using Microsoft.Xna.Framework.Input;

namespace Penguin_Pairs
{
    internal class TitleMenuState : GameState
    {
        public TitleMenuState()
        {
            SpriteGameObject titleMenu = new SpriteGameObject("Sprites/spr_titleScreen");
            gameObjects.AddChild(titleMenu);
        }

        public override void HandleInput(InputHelper inputHelper)
        {
            // Opening Help menu
            if (inputHelper.KeyPressed(Keys.H))
                ExtendedGame.GameStateManager.SwitchTo(PenguinPairs.StateName_Help);

            // Opening Options menu
            if (inputHelper.KeyPressed(Keys.O))
                ExtendedGame.GameStateManager.SwitchTo(PenguinPairs.StateName_Options);

            // Opening Level menu
            if (inputHelper.KeyPressed(Keys.L))
                ExtendedGame.GameStateManager.SwitchTo(PenguinPairs.StateName_LevelMenu);
        }
    }
}