using Engine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Penguin_Pairs
{
    internal class Tile : GameObject
    {
        public enum Type {  Normal, Empty, Wall, Hole };
        public Type TileType { get; private set; }

        SpriteGameObject image;

        public Tile(Type type, int x, int y)
        {
            TileType = type;

            // Adding corresponding image
            if (type == Type.Wall) image = new SpriteGameObject("Sprites/LevelObject/spr_wall");
            else if (type == Type.Hole) image = new SpriteGameObject("Sprites/LevelObject/spr_hole");
            else if (type == Type.Normal) image = new SpriteGameObject("Sprites/LevelObject/spr_field@2", (x+y) % 2);

            if (image != null) image.Parent = this;
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (image != null) image.Draw(gameTime, spriteBatch);
        }
    }
}