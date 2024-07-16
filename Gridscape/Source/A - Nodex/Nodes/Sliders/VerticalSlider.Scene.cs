﻿namespace Gridscape;

public partial class VerticalSlider : BaseSlider
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
            OnUpdate = (button) =>
            {
                button.Position.Y = -Origin.Y - middleButton.Radius * 2;
            }
        }, "DecrementButton");

        AddChild(new Button
        {
            Size = new(10, 10),
            Layer = ClickableLayer.PanelButtons,
            OnUpdate = (button) =>
            {
                button.Position.Y = Size.Y - Origin.Y + middleButton.Radius * 2;
            },
        }, "IncrementButton");
    }
}