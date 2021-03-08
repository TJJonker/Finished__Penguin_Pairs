using Engine;
using Microsoft.Xna.Framework;

namespace Penguin_Pairs
{
    internal class MovableAnimal : Animal
    {
        private bool isInHole;

        public int AnimalIndex { get { return SheetIndex; } }

        public bool IsInHole
        {
            get { return isInHole; }
            set
            {
                isInHole = value;
                sprite = new SpriteSheet(GetSpriteName(IsInHole), AnimalIndex);
            }
        }

        public MovableAnimal(int animalIndex, bool isInHole, Level level) : base(level, GetSpriteName(isInHole), animalIndex)
        {
            this.isInHole = isInHole;
        }

        public override void HandleInput(InputHelper inputHelper)
        {
            if (Visible && BoundingBox.Contains(inputHelper.MousePositionWorld)
                && inputHelper.MouseLeftButtonPressed())
            {
                level.SelectAnimal(this);
            }
        }

        private static string GetSpriteName(bool isInHole)
        {
            if (isInHole)
                return "Sprites/LevelObjects/spr_penguin_boxed@8";
            return "Sprites/LevelObjects/spr_penguin@8";
        }

        public void TryMoveInDirection(Point direction)
        {
        }

        public bool CanMoveInDirection(Point direction)
        {
            return true;
        }
    }
}