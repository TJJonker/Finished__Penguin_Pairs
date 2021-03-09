using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Engine
{
    public class SpriteGameObject : GameObject
    {
        protected SpriteSheet sprite;

        public int Width { get { return sprite.Width; } }
        public int Height { get { return sprite.Height; } }

        public Vector2 Origin { get; set; }

        public int SheetIndex { get { return sprite.SheetIndex; } set { sprite.SheetIndex = value; } } 

        public SpriteGameObject(string spriteName, int sheetIndex = 0)
        {
            sprite = new SpriteSheet(spriteName);
            Origin = Vector2.Zero;
            SheetIndex = sheetIndex;
        }

        /// <summary>
        /// Returns a rectangle that describes this game object's bounding box
        /// Usefull for collision detection
        /// </summary>
        public Rectangle BoundingBox
        {
            get
            {
                Rectangle spriteBounds = sprite.Bounds;
                spriteBounds.Offset(GlobalPosition - Origin);
                return spriteBounds;
            }
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (Visible)
                sprite.Draw(spriteBatch, GlobalPosition, Origin);
        }

        public void SetOriginToCenter()
        {
            Origin = new Vector2(Width / 2, Height / 2);
        }
    }
}