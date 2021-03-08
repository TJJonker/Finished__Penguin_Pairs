using Engine;
using Microsoft.Xna.Framework;

namespace Penguin_Pairs
{
    internal abstract class Animal : SpriteGameObject
    {
        protected Level level;
        protected Point currentGridPosition;

        protected Animal(Level level, Point gridPosition, string spriteName, int sheetIndex = 0) : base(spriteName, sheetIndex)
        {
            this.level = level;
            currentGridPosition = gridPosition;

            ApplyCurrentPosition();
        }

        protected virtual void ApplyCurrentPosition()
        {
            level.AddAnimalToGrid(this, currentGridPosition);
            Position = level.GetCellPosition(currentGridPosition.X, currentGridPosition.Y);
        }
    }
}