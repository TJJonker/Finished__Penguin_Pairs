using Engine;
using Engine.UI;
using Microsoft.Xna.Framework;

namespace Penguin_Pairs
{
    internal class PlayingState : GameState
    {
        private Button hintButton, retryButton, quitButton;

        public PlayingState()
        {
            SpriteGameObject background = new SpriteGameObject("Sprites/spr_background_level");
            gameObjects.AddChild(background);

            // Adding the hintButton
            hintButton = new Button("Sprites/UI/spr_button_hint")
            {
                Position = new Vector2(916, 20)
            };
            gameObjects.AddChild(hintButton);

            // Adding the retryButton
            retryButton = new Button("Sprites/UI/spr_button_retry")
            {
                Position = new Vector2(916, 20),
                Visible = false
            };
            gameObjects.AddChild(retryButton);

            // Adding the quitButton
            quitButton = new Button("Sprites/UI/spr_button_quit")
            {
                Position = new Vector2(1058, 20)
            };
            gameObjects.AddChild(quitButton);
        }

        public override void HandleInput(InputHelper inputHelper)
        {
            base.HandleInput(inputHelper);
            if (quitButton.Pressed)
                ExtendedGame.GameStateManager.SwitchTo(PenguinPairs.StateName_LevelMenu);
        }
    }
}