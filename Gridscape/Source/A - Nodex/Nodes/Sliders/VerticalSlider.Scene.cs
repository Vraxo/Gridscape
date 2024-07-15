namespace Gridscape;

partial class VerticalSlider : Node2D
{
    public override void Build()
    {
        SliderButton middleButton = new()
        {
            Orientation = SliderOrientation.Vertical,
        };

        AddChild(middleButton, "MiddleButton");

        AddChild(new Button
        {
            Position = new(0, middleButton.Radius * -2),
            Size = new(10, 10),
            Layer = ClickableLayer.PanelButtons,
        }, "TopButton");

        AddChild(new Button
        {
            Size = new(10, 10),
            Layer = ClickableLayer.PanelButtons,
            OnUpdate = (button) =>
            {
                button.Position.Y = Size.Y + (MiddleButton.Radius * 2);
            },
        }, "BottomButton");
    }
}