using Engine;
using Engine.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Penguin_Pairs
{
    internal class LevelButton : Button
    {
        public int LevelIndex { get; private set; }
        private LevelStatus status;
        private TextGameObject label;

        public LevelButton(int levelIndex, LevelStatus startStatus) : base(getSpriteNameForStatus(startStatus))
        {
            LevelIndex = levelIndex;
            Status = startStatus;

            label = new TextGameObject("Fonts/ScoreFont", Color.Black, TextGameObject.Alignment.Center)
            {
                Position = sprite.Center + new Vector2(0, 12),
                Parent = this,
                Text = levelIndex.ToString()
            };
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            base.Draw(gameTime, spriteBatch);
            label.Draw(gameTime, spriteBatch);
        }

        public LevelStatus Status
        {
            get { return status; }
            set
            {
                status = value;
                sprite = new SpriteSheet(getSpriteNameForStatus(status));
                SheetIndex = (LevelIndex - 1) % sprite.NumberOfSheetElements;
            }
        }

        private static string getSpriteNameForStatus(LevelStatus status)
        {
            if (status == LevelStatus.Locked) return "Sprites/UI/spr_level_locked";
            if (status == LevelStatus.Unlocked) return "Sprites/UI/spr_level_unlocked";
            return "Sprites/UI/spr_level_solved@6";
        }
    }
}