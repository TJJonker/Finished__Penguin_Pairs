using Engine;
using Microsoft.Xna.Framework.Input;

namespace Penguin_Pairs
{
    internal class LevelMenuState : GameState
    {
        public LevelMenuState()
        {
            SpriteGameObject levelMenu = new SpriteGameObject("Sprites/spr_background_levelselect");
            gameObjects.AddChild(levelMenu);
        }

        public override void HandleInput(InputHelper inputHelper)
        {
            if (inputHelper.KeyPressed(Keys.Back))
                ExtendedGame.GameStateManager.SwitchTo(PenguinPairs.StateName_Title);
        }
    }
}