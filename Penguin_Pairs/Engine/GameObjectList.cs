using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Engine
{
    public class GameObjectList : GameObject
    {
        private List<GameObject> children;

        public GameObjectList()
        {
            children = new List<GameObject>();
        }

        public void AddChild(GameObject obj)
        {
            children.Add(obj);
            obj.Parent = this;
        }

        public override void HandleInput(InputHelper inputHelper)
        {
            for (int i = children.Count - 1; i >= 0; i--)
                children[i].HandleInput(inputHelper);
        }

        public override void Update(GameTime gameTime)
        {
            foreach (GameObject obj in children)
                obj.Update(gameTime);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (!Visible) return;
            foreach (GameObject obj in children)
                obj.Draw(gameTime, spriteBatch);
        }

        public override void Reset()
        {
            foreach (GameObject obj in children)
                obj.Reset();
        }
    }
}