﻿namespace Gridscape;

public partial class VerticalSlider : BaseSlider
{
    public override void Build()
    {
        VerticalSliderButton middleButton = new();
        AddChild(middleButton, "MiddleButton");

        AddChild(new Button
        {
            Position = new(0, middleButton.Size.Y * -2),
            Size = new(10, 10),
            Layer = ClickableLayer.PanelButtons,
            OnUpdate = (button) =>
            {
                button.Position.Y = -Origin.Y - middleButton.Size.Y * 2;
            }
        }, "DecrementButton");

        AddChild(new Button
        {
            Size = new(10, 10),
            Layer = ClickableLayer.PanelButtons,
            OnUpdate = (button) =>
            {
                button.Position.Y = Size.Y - Origin.Y + middleButton.Size.Y * 2 - 1;
            },
        }, "IncrementButton");
    }
}