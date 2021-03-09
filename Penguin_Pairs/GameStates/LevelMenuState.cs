using Engine;
using Engine.UI;
using Microsoft.Xna.Framework;

namespace Penguin_Pairs
{
    internal class LevelMenuState : GameState
    {
        private Button backButton;
        private LevelButton[] levelButtons;

        public LevelMenuState()
        {
            SpriteGameObject levelMenu = new SpriteGameObject("Sprites/spr_background_levelselect");
            gameObjects.AddChild(levelMenu);

            backButton = new Button("Sprites/UI/spr_button_back");
            backButton.Position = new Vector2(415, 720);
            gameObjects.AddChild(backButton);

            int numberOfLevels = PenguinPairs.NumberOfLevels;
            levelButtons = new LevelButton[numberOfLevels];

            Vector2 gridOffset = new Vector2(155, 230);
            const int buttonsPerRow = 5;
            const int spaceBetweenColumns = 30;
            const int spaceBetweenRows = 5;

            for (int i = 0; i < numberOfLevels; i++)
            {
                LevelButton levelButton = new LevelButton(i + 1, PenguinPairs.GetLevelStatus(i + 1));

                int row = i / buttonsPerRow;
                int column = i % buttonsPerRow;
                levelButton.Position = gridOffset + new Vector2(
                    column * (levelButton.Width + spaceBetweenColumns),
                    row * (levelButton.Height + spaceBetweenRows));

                gameObjects.AddChild(levelButton);
                levelButtons[i] = levelButton;
            }
        }

        public override void HandleInput(InputHelper inputHelper)
        {
            base.HandleInput(inputHelper);
            if (backButton.Pressed)
                ExtendedGame.GameStateManager.SwitchTo(PenguinPairs.StateName_Title);

            foreach (LevelButton button in levelButtons)
            {
                if (button.Pressed && button.Status != LevelStatus.Locked)
                {
                    ExtendedGame.GameStateManager.SwitchTo(PenguinPairs.StateName_Playing);
                    PlayingState playingstate = (PlayingState)ExtendedGame.GameStateManager.GetGameState(PenguinPairs.StateName_Playing);
                    playingstate.LoadLevel(button.LevelIndex);
                    return;
                }
            }
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            foreach (LevelButton button in levelButtons)
                if (button.Status != PenguinPairs.GetLevelStatus(button.LevelIndex))
                    button.Status = PenguinPairs.GetLevelStatus(button.LevelIndex);
        }
    }
}