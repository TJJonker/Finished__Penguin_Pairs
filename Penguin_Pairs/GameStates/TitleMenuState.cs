using Engine;
using Engine.UI;
using Microsoft.Xna.Framework;

namespace Penguin_Pairs
{
    internal class TitleMenuState : GameState
    {
        private Button playButton, optionsButton, helpButton;

        public TitleMenuState()
        {
            SpriteGameObject titleMenu = new SpriteGameObject("Sprites/spr_titleScreen");
            gameObjects.AddChild(titleMenu);

            // Adding the playButton
            playButton = new Button("Sprites/UI/spr_button_play");
            playButton.Position = new Vector2(415, 540);
            gameObjects.AddChild(playButton);

            // Adding the optionsButton
            optionsButton = new Button("Sprites/UI/spr_button_options");
            optionsButton.Position = new Vector2(415, 650);
            gameObjects.AddChild(optionsButton);

            // Adding the helpButton
            helpButton = new Button("Sprites/UI/spr_button_help");
            helpButton.Position = new Vector2(415, 760);
            gameObjects.AddChild(helpButton);
        }

        public override void HandleInput(InputHelper inputHelper)
        {
            base.HandleInput(inputHelper);
            // Opening Help menu
            if (helpButton.Pressed)
                ExtendedGame.GameStateManager.SwitchTo(PenguinPairs.StateName_Help);

            // Opening Options menu
            if (optionsButton.Pressed)
                ExtendedGame.GameStateManager.SwitchTo(PenguinPairs.StateName_Options);

            // Opening Level menu
            if (playButton.Pressed)
                ExtendedGame.GameStateManager.SwitchTo(PenguinPairs.StateName_LevelMenu);
        }
    }
}