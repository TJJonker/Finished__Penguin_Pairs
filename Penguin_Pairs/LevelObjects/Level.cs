using Engine;
using Microsoft.Xna.Framework;

namespace Penguin_Pairs.LevelObjects
{
    internal class Level : GameObjectList
    {
        private const int TileWidth = 73;
        private const int TileHeight = 72;

        public int LevelIndex { get; private set; }
        private int targetNuberOfPairs;

        private Tile[,] tiles;
        private Animal[,] animalsOnTiles;

        private SpriteGameObject hintArrow;

        public Level(int levelIndex, string filename)
        {
            LevelIndex = levelIndex;
            LoadLevelFromFile(filename);
        }

        private Vector2 GetCellPosition(int x, int y)
        {
            return new Vector2(x * TileWidth, y * TileHeight);
        }
    }
}