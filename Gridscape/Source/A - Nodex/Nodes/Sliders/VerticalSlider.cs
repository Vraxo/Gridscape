﻿using Raylib_cs;

namespace Gridscape;

public partial class VerticalSlider : BaseSlider
{
    public VerticalSlider()
    {
        Size = new(10, 100);
        OriginPreset = OriginPreset.TopCenter;
    }

    protected override void MoveMiddleButton(int direction)
    {
        if (MaxExternalValue == 0)
        {
            Console.WriteLine("max external value is 0");
            return;
        }

        float x = MiddleButton.GlobalPosition.X;
        float y = MiddleButton.GlobalPosition.Y + direction * (Size.Y / MathF.Abs(MaxExternalValue));

        MiddleButton.GlobalPosition = new(x, y);
        UpdatePercentageBasedOnMiddleButton();
    }

    protected override void Draw()
    {
        Rectangle rectangle = new()
        {
            Position = GlobalPosition - Origin,
            Size = Size
        };

        Raylib.DrawRectangleRounded(
            rectangle,
            0,
            (int)Size.X,
            Color.Gray);
    }

    public override void UpdatePercentageBasedOnMiddleButton()
    {
        float currentPosition = MiddleButton.GlobalPosition.Y;
        float minPos = GlobalPosition.Y - Origin.Y;
        float maxPos = minPos + Size.Y;

        float previousPercentage = Percentage;

        Percentage = (currentPosition - minPos) / (maxPos - minPos);

        if (Percentage != previousPercentage)
        {
            OnPercentageChanged();
        }
    }
}