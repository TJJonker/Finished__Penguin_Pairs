using Engine;
using Engine.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Penguin_Pairs
{
    internal class PlayingState : GameState
    {
        private Button hintButton, retryButton, quitButton;
        private Level level;
        private SpriteGameObject completedOverlay;

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

            completedOverlay = new SpriteGameObject("Sprites/spr_level_finished");
            gameObjects.AddChild(completedOverlay);
        }

        public override void HandleInput(InputHelper inputHelper)
        {
            base.HandleInput(inputHelper);

            if (completedOverlay.Visible)
            {
                if (inputHelper.MouseLeftButtonPressed())
                    PenguinPairs.GoToNextLevel(level.LevelIndex);
            }
            else
            {
                if (quitButton.Pressed)
                    ExtendedGame.GameStateManager.SwitchTo(PenguinPairs.StateName_LevelMenu);

                if (level != null)
                    level.HandleInput(inputHelper);

                if (hintButton.Pressed)
                    level.ShowHint();

                if (retryButton.Pressed)
                    level.Reset();
            }
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if (level != null)
                level.Update(gameTime);

            hintButton.Visible = PenguinPairs.HintsEnabled && !level.FirstMoveMade;
            retryButton.Visible = level.FirstMoveMade;
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            base.Draw(gameTime, spriteBatch);
            if (level != null)
                level.Draw(gameTime, spriteBatch);
        }

        public void LoadLevel(int levelIndex)
        {
            level = new Level(levelIndex, "Content/Levels/level" + levelIndex + ".txt");
            hintButton.Visible = PenguinPairs.HintsEnabled;
            completedOverlay.Visible = false;
        }

        public void LevelCompleted(int levelIndex)
        {
            completedOverlay.Visible = true;
            level.Visible = false;

            PenguinPairs.MarkLevelAsSolved(levelIndex);
        }
    }
}