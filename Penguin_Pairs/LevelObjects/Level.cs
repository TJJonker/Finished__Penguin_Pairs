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

        private void AddPlayingField(List<string> grid, int gridWidth, int gridHeight)
        {

        }

        private int StringToDirection(string direction)
        {
            if (direction == "Right") return 0;
            if (direction == "Up") return 1;
            if (direction == "Left") return 2;
            return 3;
        }
    }
}