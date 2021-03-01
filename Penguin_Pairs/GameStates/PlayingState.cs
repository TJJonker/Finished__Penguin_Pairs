using Engine;
using Microsoft.Xna.Framework.Input;

namespace Penguin_Pairs
{
    internal class PlayingState : GameState
    {
        public PlayingState()
        {
            SpriteGameObject background = new SpriteGameObject("Sprites/spr_background_level");
            gameObjects.AddChild(background);
        }

        public override void HandleInput(InputHelper inputHelper)
        {
            if (inputHelper.KeyPressed(Keys.Back))
                ExtendedGame.GameStateManager.SwitchTo(PenguinPairs.StateName_LevelMenu);
        }
    }
}