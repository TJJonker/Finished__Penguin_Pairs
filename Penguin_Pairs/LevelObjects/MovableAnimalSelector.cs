using Engine;
using Microsoft.Xna.Framework;

namespace Penguin_Pairs
{
    internal class MovableAnimalSelector : GameObjectList
    {
        private Arrow[] arrows;
        private Point[] directions;
        private MovableAnimal selectedAnimal;

        public MovableAnimal SelectedAnimal
        {
            get { return selectedAnimal; }
            set
            {
                selectedAnimal = value;
                Visible = (selectedAnimal != null);
            }
        }

        public MovableAnimalSelector()
        {
            // define the four directions
            directions = new Point[4];
            directions[0] = new Point(1, 0);
            directions[1] = new Point(0, -1);
            directions[2] = new Point(-1, 0);
            directions[3] = new Point(0, 1);

            // add the four arrows
            arrows = new Arrow[4];
            for (int i = 0; i < 4; i++)
            {
                arrows[i] = new Arrow(i);
                arrows[i].Position = new Vector2(directions[i].X * arrows[i].Width, directions[i].Y * arrows[i].Height);
                AddChild(arrows[i]);
            }

            SelectedAnimal = null;
        }

        public override void HandleInput(InputHelper inputHelper)
        {
            if (selectedAnimal == null) return;
            base.HandleInput(inputHelper);

            for(int i = 0; i < 4; i++)
            {
                if (arrows[i].Pressed)
                {
                    SelectedAnimal.TryMoveInDirection(directions[i]);
                    return;
                }
            }
            if (inputHelper.MouseLeftButtonPressed())
                SelectedAnimal = null;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if(SelectedAnimal != null)
            {
                Position = SelectedAnimal.Position;
                for (int i = 0; i < 4; i++)
                    arrows[i].Visible = SelectedAnimal.CanMoveInDirection(directions[i]);
            }
        }

        public override void Reset()
        {
            selectedAnimal = null;
        }
    }
}