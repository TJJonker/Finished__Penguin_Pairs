using Engine;
using Microsoft.Xna.Framework;

namespace Penguin_Pairs
{
    class PairList : GameObjectList
    {
        int nrPairsMade;
        SpriteGameObject[] pairObjects;

        public bool Completed { get { return nrPairsMade == pairObjects.Length; } }

        public PairList(int nrPairs)
        {
            // Add the background image
            AddChild(new SpriteGameObject("Sprites/spr_frame_goal"));

            // Add the sprite object for each pair that the player should make
            Vector2 offset = new Vector2(100, 7);
            pairObjects = new SpriteGameObject[nrPairs];
            for(int i = 0; i < nrPairs; i++)
            {
                pairObjects[i] = new SpriteGameObject("Sprites/spr_penguin_pairs@8", 7);
                pairObjects[i].Position = offset + new Vector2(i * pairObjects[i].Width, 0);
                AddChild(pairObjects[i]);
            }

            nrPairsMade = 0;
        }

        public void AddPair(int penguinIndex)
        {
            pairObjects[nrPairsMade].SheetIndex = penguinIndex;
            nrPairsMade++;
        }

        public override void Reset()
        {
            nrPairsMade = 0;
            for (int i = 0; i < pairObjects.Length; i++)
                pairObjects[i].SheetIndex = 7;
        }
    }
}
