using Engine;

namespace Penguin_Pairs
{
    internal abstract class Animal : SpriteGameObject
    {
        protected Level level;
        protected Animal(Level level, string spriteName, int sheetIndex = 0) : base(spriteName, sheetIndex)
        {
            this.level = level;
        }
    }
}