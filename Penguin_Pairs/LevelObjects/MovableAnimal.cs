using Engine;
using Microsoft.Xna.Framework;

namespace Penguin_Pairs
{
    internal class MovableAnimal : Animal
    {
        private bool isInHole;

        private Vector2 targetWorldPosition;
        const float speed = 300f;

        private Point startPosition;

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

        private bool IsSeal { get { return AnimalIndex == 7; } }
        private bool IsMultiColoredPenguin { get { return AnimalIndex == 6; } }

        private bool IsMoving { get { return Position != targetWorldPosition; } }

        public MovableAnimal(int animalIndex, Level level, Point gridPosition) : 
            base(level, gridPosition, GetSpriteName(false), animalIndex)
        {
            targetWorldPosition = Position;
            startPosition = gridPosition;
        }

        public override void HandleInput(InputHelper inputHelper)
        {
            if (Visible && BoundingBox.Contains(inputHelper.MousePositionWorld)
                && inputHelper.MouseLeftButtonPressed())
            {
                level.SelectAnimal(this);
            }
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if(IsMoving && Vector2.Distance(Position, targetWorldPosition) < speed * gameTime.ElapsedGameTime.TotalSeconds)
            {
                ApplyCurrentPosition();
            }
        }

        public override void Reset()
        {
            currentGridPosition = startPosition;
            IsInHole = false;

            base.Reset();

            targetWorldPosition = Position;
        }

        private static string GetSpriteName(bool isInHole)
        {
            if (isInHole)
                return "Sprites/LevelObjects/spr_penguin_boxed@8";
            return "Sprites/LevelObjects/spr_penguin@8";
        }

        public void TryMoveInDirection(Point direction)
        {
            if (!CanMoveInDirection(direction))
                return;

            level.RemoveAnimalFromGrid(currentGridPosition);
            while (CanMoveInDirection(direction))
                currentGridPosition += direction;

            targetWorldPosition = level.GetCellPosition(currentGridPosition.X, currentGridPosition.Y);

            Vector2 dir = targetWorldPosition - Position;
            dir.Normalize();
            velocity = dir * speed;
        }

        private bool IsPairWith(MovableAnimal other)
        {
            if (IsSeal || other.IsSeal)
                return false;

            if (IsMultiColoredPenguin || other.IsMultiColoredPenguin)
                return true;

            return AnimalIndex == other.AnimalIndex;
        }

        public bool CanMoveInDirection(Point direction)
        {
            if (!Visible || IsInHole || IsMoving)
                return false;

            // Check the current tile
            Tile.Type tileType = level.GetTileType(currentGridPosition);
            Animal otherAnimal = level.GetAnimal(currentGridPosition);

            if (tileType == Tile.Type.Empty || tileType == Tile.Type.Hole)
                return false;

            if (otherAnimal != this && otherAnimal != null)
                return false;

            // Check what's going on at the next tile
            Point nextPosition = currentGridPosition + direction;
            Tile.Type nextType = level.GetTileType(nextPosition);
            Animal nextAnimal = level.GetAnimal(nextPosition);

            // If the next tile is a wall, stop 
            if (nextType == Tile.Type.Wall)
                return false;

            // If the next tile contains a animal that does not form a pair
            if (nextAnimal is MovableAnimal && !IsPairWith((MovableAnimal)nextAnimal))
                return false;

            return true;
        }

        protected override void ApplyCurrentPosition()
        {
            Position = level.GetCellPosition(currentGridPosition.X, currentGridPosition.Y);

            velocity = Vector2.Zero;

            Tile.Type tileType = level.GetTileType(currentGridPosition);
            if(tileType == Tile.Type.Empty)
            {
                Visible = false;
                ExtendedGame.AssetManager.PlaySoundEffect("Sounds/snd_eat");
                return;
            }

            Animal otherAnimal = level.GetAnimal(currentGridPosition);
            if(otherAnimal != null)
            {
                level.RemoveAnimalFromGrid(currentGridPosition);
                Visible = false;
                otherAnimal.Visible = false;

                // Notify if there is a pair
                if (otherAnimal is MovableAnimal)
                    level.PairFound(this, (MovableAnimal)otherAnimal);
                else
                    ExtendedGame.AssetManager.PlaySoundEffect("Sounds/snd_eat");

                return;
            }

            level.AddAnimalToGrid(this, currentGridPosition);

            if (tileType == Tile.Type.Hole)
                IsInHole = true; 
        }
    }
}