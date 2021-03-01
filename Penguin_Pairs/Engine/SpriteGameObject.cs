﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Engine
{
    internal class SpriteGameObject : GameObject
    {
        protected Texture2D sprite;
        protected Vector2 origin;

        public int Width { get { return sprite.Width; } }
        public int Height { get { return sprite.Height; } }

        public SpriteGameObject(string spriteName)
        {
            sprite = ExtendedGame.AssetManager.LoadSprite(spriteName);
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
                spriteBatch.Draw(sprite, GlobalPosition, null, Color.White, 0, origin, 1.0f, SpriteEffects.None, 0);
        }

        public void SetOriginToCenter()
        {
            origin = new Vector2(Width / 2, Height / 2);
        }
    }
}