namespace Gridscape;

public partial class HorizontalSlider : BaseSlider
{
    public override void Build()
    {
        HorizontalSliderButton middleButton = new();
        AddChild(middleButton, "MiddleButton");

        AddChild(new Button
        {
            Position = new(-17.5F, 0),
            Size = new(10, 10),
            Layer = ClickableLayer.PanelButtons,
            OnUpdate = (button) =>
            {
                button.Position.X = -button.Size.X * 2;
            }
        }, "DecrementButton");

        AddChild(new Button
        {
            Size = new(10, 10),
            Layer = ClickableLayer.PanelButtons,
            OnUpdate = (button) =>
            {
                button.Position.X = Size.X + (MiddleButton.Size.X * 1.25F);
            },
        }, "IncrementButton");
    }
}