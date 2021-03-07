using Engine;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.IO;

namespace Penguin_Pairs
{
    internal class PenguinPairs : ExtendedGame
    {
        public const string StateName_Title = "TitleScreen";
        public const string StateName_Help = "HelpScreen";
        public const string StateName_LevelMenu = "LevelMenuScreen";
        public const string StateName_Options = "OptionsScreen";
        public const string StateName_Playing = "PlayingScreen";
        public static bool HintsEnabled { get; set; }

        private static List<LevelStatus> progress;

        public static int NumberOfLevels { get { return progress.Count; } }

        public static LevelStatus GetLevelStatus(int levelIndex)
        {
            return progress[levelIndex - 1];
        }

        private void SetLevelStatus(int levelIndex, LevelStatus status)
        {
            progress[levelIndex - 1] = status;
        }

        [STAThread]
        private static void Main()
        {
            PenguinPairs game = new PenguinPairs();
            game.Run();
        }

        public PenguinPairs()
        {
            IsMouseVisible = true;
            HintsEnabled = true;
        }

        protected override void LoadContent()
        {
            base.LoadContent();
            worldSize = new Point(1200, 900);
            windowSize = new Point(1024, 768);

            FullScreen = false;

            LoadProgress();

            GameStateManager.AddGameState(StateName_Title, new TitleMenuState());
            GameStateManager.AddGameState(StateName_Help, new HelpState());
            GameStateManager.AddGameState(StateName_LevelMenu, new LevelMenuState());
            GameStateManager.AddGameState(StateName_Options, new OptionsMenuState());
            GameStateManager.AddGameState(StateName_Playing, new PlayingState());

            GameStateManager.SwitchTo(StateName_Title);
        }

        private void LoadProgress()
        {
            progress = new List<LevelStatus>();
            StreamReader reader = new StreamReader("Content/Levels/levels_status.txt");
            string line = reader.ReadLine();
            while(line != null)
            {
                progress.Add(TextToLevelStatus(line));
                line = reader.ReadLine();
            }
            reader.Close();
        }

        private LevelStatus TextToLevelStatus(string text)
        {
            if (text == "locked") return LevelStatus.Locked;
            if (text == "unlocked") return LevelStatus.Unlocked;
            return LevelStatus.Solved;
        }
    }
}