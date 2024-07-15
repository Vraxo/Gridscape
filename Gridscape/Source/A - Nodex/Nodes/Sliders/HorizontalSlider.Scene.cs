namespace Gridscape;

public partial class HorizontalSlider : BaseSlider
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
        }, "DecrementButton");

        AddChild(new Button
        {
            Size = new(10, 10),
            Layer = ClickableLayer.PanelButtons,
            OnUpdate = (button) =>
            {
                button.Position.X = Size.X + (MiddleButton.Radius * 2);
            },
        }, "IncrementButton");
    }
}