using Engine;
using Microsoft.Xna.Framework;
using System;

namespace Penguin_Pairs
{
    internal class PenguinPairs : ExtendedGame
    {
        public const string StateName_Title = "TitleScreen";
        public const string StateName_Help = "HelpScreen";
        public const string StateName_LevelMenu = "LevelMenuScreen";
        public const string StateName_Options = "OptionsScreen";
        public const string StateName_Playing = "PlayingScreen";

        [STAThread]
        private static void Main()
        {
            PenguinPairs game = new PenguinPairs();
            game.Run();
        }

        public PenguinPairs()
        {
            IsMouseVisible = true;
        }

        protected override void LoadContent()
        {
            base.LoadContent();
            worldSize = new Point(1200, 900);
            windowSize = new Point(1024, 768);

            FullScreen = false;

            GameStateManager.AddGameState(StateName_Title, new TitleMenuState());
            GameStateManager.AddGameState(StateName_Help, new HelpState());
            GameStateManager.AddGameState(StateName_LevelMenu, new LevelMenuState());
            GameStateManager.AddGameState(StateName_Options, new OptionsMenuState());
            GameStateManager.AddGameState(StateName_Playing, new PlayingState());

            GameStateManager.SwitchTo(StateName_Title);
        }
    }
}