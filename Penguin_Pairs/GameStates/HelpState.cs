using Engine;
using Engine.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Penguin_Pairs
{
    internal class HelpState : GameState
    {
        private Button backButton;

        public HelpState()
        {
            SpriteGameObject helpState = new SpriteGameObject("Sprites/spr_background_help");
            gameObjects.AddChild(helpState);

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