using Engine;

namespace Penguin_Pairs
{
    internal class LevelMenuState : GameState
    {
        public LevelMenuState()
        {
            SpriteGameObject levelMenu = new SpriteGameObject("Sprites/spr_background_levelselect");
            gameObjects.AddChild(levelMenu);
        }
    }
}