using Engine;

namespace Penguin_Pairs.LevelObjects
{
    internal abstract class Animal : SpriteGameObject
    {
        protected Animal(string spriteName, int sheetIndex = 0) : base(spriteName, sheetIndex)
        {
        }
    }
}