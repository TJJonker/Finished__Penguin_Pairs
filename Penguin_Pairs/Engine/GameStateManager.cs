using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Engine
{
    internal class GameStateManager
    {
        private Dictionary<string, GameState> gameStates;
        private GameState currentGameState;

        public GameStateManager()
        {
            gameStates = new Dictionary<string, GameState>();
            currentGameState = null;
        }

        public void AddGameState(string name, GameState state)
        {
            gameStates[name] = state;
        }

        public GameState GetGameState(string name)
        {
            if (gameStates.ContainsKey(name))
                return gameStates[name];
            return null;
        }

        public void SwitchTo(string name)
        {
            if (gameStates.ContainsKey(name))
                currentGameState = gameStates[name];
        }

        public void Update(GameTime gameTime)
        {
            currentGameState?.Update(gameTime);
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            currentGameState?.Draw(gameTime, spriteBatch);
        }

        public void HandleInput(InputHelper inputHelper)
        {
            currentGameState?.HandleInput(inputHelper);
        }

        public void Reset()
        {
            currentGameState?.Reset();
        }
    }
}