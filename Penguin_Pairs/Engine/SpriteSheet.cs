using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Engine
{
    internal class SpriteSheet
    {
        private Texture2D sprite;
        private Rectangle spriteRectangle;
        private int sheetIndex, sheetColumns, sheetRows;

        public int Width { get { return sprite.Width / sheetColumns; } }
        public int Height { get { return sprite.Height / sheetRows; } }
        public Vector2 Center { get { return new Vector2(Width, Height) / 2; } }
        public Rectangle Bounds { get { return new Rectangle(0, 0, Width, Height); } }
        public int NumberOfSheetElements { get { return sheetColumns * sheetRows; } }

        public SpriteSheet(string assetName, int sheetIndex = 0)
        {
            sprite = ExtendedGame.AssetManager.LoadSprite(assetName);
            sheetColumns = 1;
            sheetRows = 1;
            this.sheetIndex = sheetIndex;

            int columnIndex = sheetIndex % sheetColumns;
            int rowIndex = sheetIndex / sheetColumns;
            spriteRectangle = new Rectangle(columnIndex * Width, rowIndex * Height, Width, Height);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position, Vector2 origin)
        {
            spriteBatch.Draw(sprite, position, spriteRectangle, Color.White, 0.0f, origin, 1.0f, SpriteEffects.None, 0.0f);
        }
    }
}