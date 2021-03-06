using Engine;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.IO;

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

        private void LoadLevelFromFile(string filename)
        {
            StreamReader reader = new StreamReader(filename);

            string title = reader.ReadLine();
            string desciption = reader.ReadLine();

            AddLevelInfoObjects(title, desciption);

            targetNuberOfPairs = int.Parse(reader.ReadLine());

            string[] hint = reader.ReadLine().Split(' ');
            int hintX = int.Parse(hint[0]);
            int hintY = int.Parse(hint[1]);
            int hintDirection = StringToDirection(hint[2]);

            hintArrow = new SpriteGameObject("Sprites/LevelObjects/spr_arrow_hint@4", hintDirection);
            hintArrow.Position = GetCellPosition(hintX, hintY);

            int gridWidth = 0;

            List<string> gridRows = new List<string>();
            string line = reader.ReadLine();
            while(line != null)
            {
                if (line.Length > gridWidth)
                    gridWidth = line.Length;

                gridRows.Add(line);
                line = reader.ReadLine();
            }
            reader.Close();

            AddPlayingField(gridRows, gridWidth, gridRows.Count);
        }

        private void AddLevelInfoObjects(string title, string description)
        {
            // Level info background sprite
            SpriteGameObject levelInfo = new SpriteGameObject("Sprites/spr_level_info");
            levelInfo.SetOriginToCenter();
            levelInfo.Position = new Vector2(600, 820);
            AddChild(levelInfo);

            TextGameObject titleObject = new TextGameObject("Font/HelpFont", Color.Blue, TextGameObject.Alignment.Center);
            titleObject.Text = LevelIndex + " - " + title;
            titleObject.Position = new Vector2(600, 786);
            AddChild(titleObject);

            TextGameObject descriptionObject = new TextGameObject("Font/HelpFont", Color.Blue, TextGameObject.Alignment.Center);
            descriptionObject.Text = description;
            descriptionObject.Position = new Vector2(600, 820);
            AddChild(descriptionObject);
        }

        private void AddPlayingField(List<string> gridRows, int gridWidth, int gridHeight)
        {
            GameObjectList playingField = new GameObjectList();

            Vector2 gridSize = new Vector2(gridWidth * TileWidth, gridHeight * TileHeight);
            playingField.Position = new Vector2(600, 420) - gridSize / 2f;

            tiles = new Tile[gridWidth, gridHeight];
            animalsOnTiles = new Animal[gridWidth, gridHeight];

            for (int y = 0; y < gridHeight; y++)
            {
                string row = gridRows[y];
                for(int x = 0; x < gridWidth; x++)
                {
                    char symbol = ' ';
                    if (x < row.Length)
                        symbol = row[x];

                    AddTile(x, y, symbol);
                    AddAnimal(x, y, symbol);
                }
            }

            for (int y = 0; y < gridHeight; y++)
                for (int x = 0; x < gridWidth; x++)
                    playingField.AddChild(tiles[x, y]);

            for (int y = 0; y < gridHeight; y++)
                for (int x = 0; x < gridWidth; x++)
                    if (animalsOnTiles[x, y] != null)
                        playingField.AddChild(animalsOnTiles[x, y]);

            hintArrow.Visible = false;
            playingField.AddChild(hintArrow);

            AddChild(playingField);
        }

        private void AddTile(int x, int y, char symbol)
        {
            Tile tile = new Tile(CharToTileType(symbol), x, y);
            tile.Position = GetCellPosition(x, y);
            tiles[x, y] = tile;
        }



        private int StringToDirection(string direction)
        {
            if (direction == "Right") return 0;
            if (direction == "Up") return 1;
            if (direction == "Left") return 2;
            return 3;
        }

        private Tile.Type CharToTileType(char symbol)
        {
            if (symbol == ' ') return Tile.Type.Empty;
            if (symbol == '.') return Tile.Type.Normal;
            if (symbol == '#') return Tile.Type.Wall;
            if (symbol == '_') return Tile.Type.Hole;

            if ("BRGYCPMX".Contains(symbol)) return Tile.Type.Hole;

            return Tile.Type.Normal;
        }
    }
}