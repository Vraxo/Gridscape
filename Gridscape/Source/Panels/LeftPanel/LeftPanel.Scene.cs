﻿using Raylib_cs;

namespace Gridscape;

partial class LeftPanel : Panel
{
    public override void Build()
    {
        AddChild(new TilesPanel());

        AddChild(new Button()
        {
            Text = "Add New Tile",
            Position = Position + new Vector2(10, 10),
            Size = new(25, 25),
            OriginPreset = OriginPreset.TopLeft,
            Layer = (int)ClickableLayer.PanelButtons,
            OnUpdate = (button) =>
            {
                button.Position.X = Size.X * 0.05F;
                button.Size = new(Size.X * 0.75F, button.Size.Y);
            },
        });

        AddChild(new VerticalSlider
        {
            Position = new(Size.X * 0.925F, 20),
            Size = new(10, 500),
            Layer = ClickableLayer.PanelButtons,
            OnUpdate = (slider) =>
            {
                slider.Position.X = Size.X * 0.9F;
                slider.Size = new(slider.Size.X, Raylib.GetScreenHeight() - 40);
            }
        },
        "Slider");
    }
}