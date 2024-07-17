using Raylib_cs;

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
        if (MaxPossibleValue == 0)
        {
            return;
        }

        float x = MiddleButton.GlobalPosition.X;
        float y = MiddleButton.GlobalPosition.Y + direction * (Size.Y / MaxPossibleValue);

        MiddleButton.GlobalPosition = new(x, y);
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

    protected override void UpdateValue()
    {
        float currentPosition = MiddleButton.GlobalPosition.Y;
        float minPos = GlobalPosition.Y - Origin.Y;
        float maxPos = minPos + Size.Y;

        float previousValue = Value;

        Value = (currentPosition - minPos) / (maxPos - minPos);

        if (Value != previousValue)
        {
            OnValueChanged();
        }
    }
}