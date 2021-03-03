using Engine;
using Engine.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Media;

namespace Penguin_Pairs
{
    internal class OptionsMenuState : GameState
    {
        Button backButton;
        Switch hintSwitch;
        Slider volumeSlider;

        public OptionsMenuState()
        {
            SpriteGameObject optionsMenu = new SpriteGameObject("Sprites/spr_background_options");
            gameObjects.AddChild(optionsMenu);

            // Adding the backButton
            backButton = new Button("Sprites/UI/spr_button_back");
            backButton.Position = new Vector2(415, 720);
            gameObjects.AddChild(backButton);

            // Adding a hintsButton and Text
            //- Button
            hintSwitch = new Switch("Sprites/UI/spr_switch@2");
            hintSwitch.Position = new Vector2(650, 340);
            gameObjects.AddChild(hintSwitch);
            //- Text
            TextGameObject hintsLabel = new TextGameObject("Fonts/MenuFont", Color.DarkBlue);
            hintsLabel.Text = "Hints";
            hintsLabel.Position = new Vector2(150, 340);
            gameObjects.AddChild(hintsLabel);

            // Adding a slider for music volume
            // - Slider
            volumeSlider = new Slider("Sprites/UI/spr_slider_bar", "Sprites/UI/spr_slider_button", 0, 1, 8);
            volumeSlider.Position = new Vector2(650, 500);
            gameObjects.AddChild(volumeSlider);
            // - Text
            TextGameObject musicVolumeLabel = new TextGameObject("Fonts/MenuFont", Color.DarkBlue);
            musicVolumeLabel.Text = "Music Volume";
            musicVolumeLabel.Position = new Vector2(150, 480);
            gameObjects.AddChild(musicVolumeLabel);

            // Apply initial game settings
            volumeSlider.Value = MediaPlayer.Volume;
            hintSwitch.Selected = PenguinPairs.HintsEnabled;
        }

        public override void HandleInput(InputHelper inputHelper)
        {
            base.HandleInput(inputHelper);
            if (backButton.Pressed)
                ExtendedGame.GameStateManager.SwitchTo(PenguinPairs.StateName_Title);

            if (volumeSlider.ValueChanged)
                MediaPlayer.Volume = volumeSlider.Value;

            if (hintSwitch.Pressed)
                PenguinPairs.HintsEnabled = hintSwitch.Selected;
        }

    }
}