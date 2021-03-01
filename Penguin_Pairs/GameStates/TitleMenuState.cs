using Engine;

namespace Penguin_Pairs
{
    internal class TitleMenuState : GameState
    {
        public TitleMenuState()
        {
            SpriteGameObject titleMenu = new SpriteGameObject("Sprites/spr_titleScreen");
            gameObjects.AddChild(titleMenu);
        }
    }
}