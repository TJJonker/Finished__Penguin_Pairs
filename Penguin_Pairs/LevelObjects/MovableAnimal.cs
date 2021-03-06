using Engine;
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

        public MovableAnimal(int animalIndex, bool isInHole) : base(GetSpriteName(isInHole), animalIndex)
        {
            this.isInHole = isInHole;
        }

        private static string GetSpriteName(bool isInHole)
        {
            if (isInHole)
                return "Sprites/LevelObjects/spr_penguin_boxed@8";
            return "Sprites/LevelObjects/spr_penguin@8";
        }
    }
}