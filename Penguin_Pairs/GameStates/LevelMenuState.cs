using Engine;
using Engine.UI;
using Microsoft.Xna.Framework;

namespace Penguin_Pairs
{
    internal class LevelMenuState : GameState
    {
        private Button backButton;

        public LevelMenuState()
        {
            SpriteGameObject levelMenu = new SpriteGameObject("Sprites/spr_background_levelselect");
            gameObjects.AddChild(levelMenu);

            backButton = new Button("Sprites/UI/spr_button_back");
            backButton.Position = new Vector2(415, 720);
            gameObjects.AddChild(backButton);
        }

        public override void HandleInput(InputHelper inputHelper)
        {
            base.HandleInput(inputHelper);
            if (backButton.Pressed)
                ExtendedGame.GameStateManager.SwitchTo(PenguinPairs.StateName_Title);
        }
    }
}