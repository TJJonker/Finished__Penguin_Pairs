using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Engine
{
    internal class SpriteGameObject : GameObject
    {
        protected SpriteSheet sprite;
        protected Vector2 origin;

        public int Width { get { return sprite.Width; } }
        public int Height { get { return sprite.Height; } }

        public int SheetIndex { get { return sprite.SheetIndex; } set { sprite.SheetIndex = value; } } 

        public SpriteGameObject(string spriteName)
        {
            sprite = new SpriteSheet(spriteName);
            origin = Vector2.Zero;
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
                spriteBounds.Offset(GlobalPosition - origin);
                return spriteBounds;
            }
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (Visible)
                sprite.Draw(spriteBatch, GlobalPosition, origin);
        }

        public void SetOriginToCenter()
        {
            origin = new Vector2(Width / 2, Height / 2);
        }
    }
}