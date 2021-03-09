using Microsoft.Xna.Framework;

namespace Engine.UI
{
    public class Slider : GameObjectList
    {
        private SpriteGameObject back, front;
        private float minValue, maxValue;
        private float currentValue, previousValue;
        private float padding;

        private float Range { get { return maxValue - minValue; } }
        private float minimumLocalX { get { return padding + front.Width / 2; } }
        private float maximumLocalX { get { return back.Width - padding - front.Width / 2; } }
        private float availableWidth { get { return maximumLocalX - minimumLocalX; } }
        public bool ValueChanged { get { return currentValue != previousValue; } }

        public float Value
        {
            get { return currentValue; }
            set
            {
                currentValue = MathHelper.Clamp(value, minValue, maxValue);
                float fraction = (currentValue - minValue) / Range;
                float newX = minimumLocalX + fraction * availableWidth;
                front.Position = new Vector2(newX, padding);
            }
        }

        public Slider(string backGroundsprite, string foreGroundSprite, float minValue, float maxValue, float padding)
        {
            back = new SpriteGameObject(backGroundsprite);
            AddChild(back);

            front = new SpriteGameObject(foreGroundSprite);
            front.Origin = new Vector2(front.Width / 2, 0);
            AddChild(front);

            this.minValue = minValue;
            this.maxValue = maxValue;
            this.padding = padding;

            previousValue = this.minValue;
            Value = previousValue;
        }

        public override void HandleInput(InputHelper inputHelper)
        {
            base.HandleInput(inputHelper);
            if (!Visible) return;

            previousValue = Value;

            Vector2 mousePos = inputHelper.MousePositionWorld;
            if (inputHelper.MouseLeftButtonDown() && back.BoundingBox.Contains(mousePos))
            {
                float correctedX = mousePos.X - GlobalPosition.X - minimumLocalX;
                float newFraction = correctedX / availableWidth;
                Value = newFraction * Range + minValue;
            }
        }
    }
}