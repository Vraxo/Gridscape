using Raylib_cs;

namespace Gridscape;

partial class HorizontalSlider : Node2D
{
    public override void Build()
    {
        SliderButton middleButton = new()
        {
            Orientation = SliderOrientation.Horizontal,
            OnUpdate = (button) =>
            {
                if (button.Pressed)
                {
                    //MiddleButton.Position.X = Raylib.GetMousePosition().X - 10 - MiddleButton.Radius;
                    button.Position.X = Raylib.GetMousePosition().X - Position.X - (Parent as Node2D).Position.X;
                }

                button.Position.X = Math.Clamp(button.Position.X, 0, Size.X);
            }
        };

        AddChild(middleButton, "MiddleButton");

        Button leftButton = new()
        {
            Position = new(-18, 0),
            Size = new(10, 10),
            Layer = ClickableLayer.PanelButtons,
        };

        AddChild(leftButton, "LeftButton");

        Button button = new()
        {
            Size = new(10, 10),
            Layer = ClickableLayer.PanelButtons,
            OnUpdate = (button) =>
            {
                button.Position.X = Size.X + (MiddleButton.Radius * 2);
            },
        };

        AddChild(button, "RightButton");
    }
}