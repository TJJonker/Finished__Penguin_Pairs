using Engine;
using Engine.UI;
using Microsoft.Xna.Framework;

namespace Penguin_Pairs
{
    internal class OptionsMenuState : GameState
    {
        Button backButton;

        public OptionsMenuState()
        {
            SpriteGameObject optionsMenu = new SpriteGameObject("Sprites/spr_background_options");
            gameObjects.AddChild(optionsMenu);

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