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
                    button.Position.X = Raylib.GetMousePosition().X - Position.X - (Parent as Node2D).Position.X;
                }

                button.Position.X = Math.Clamp(button.Position.X, 0, Size.X);
            }
        };

        AddChild(middleButton, "MiddleButton");

        AddChild(new Button
        {
            Position = new(-18, 0),
            Size = new(10, 10),
            Layer = ClickableLayer.PanelButtons,
        },
        "LeftButton");

        AddChild(new Button
        {
            Size = new(10, 10),
            Layer = ClickableLayer.PanelButtons,
            OnUpdate = (button) =>
            {
                button.Position.X = Size.X + (MiddleButton.Radius * 2);
            },
        },
        "RightButton");
    }
}