namespace Gridscape;

partial class HorizontalSlider : Node2D
{
    public override void Build()
    {
        SliderButton middleButton = new()
        {
            Orientation = SliderOrientation.Horizontal,
        };

        AddChild(middleButton, "MiddleButton");

        AddChild(new Button
        {
            Position = new(-18, 0),
            Size = new(10, 10),
            Layer = ClickableLayer.PanelButtons,
        }, "LeftButton");

        AddChild(new Button
        {
            Size = new(10, 10),
            Layer = ClickableLayer.PanelButtons,
            OnUpdate = (button) =>
            {
                button.Position.X = Size.X + (MiddleButton.Radius * 2);
            },
        }, "RightButton");
    }
}