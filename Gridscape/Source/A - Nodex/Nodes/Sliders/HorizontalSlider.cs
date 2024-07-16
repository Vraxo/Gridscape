using Raylib_cs;

namespace Gridscape;

public partial class HorizontalSlider : BaseSlider
{
    public HorizontalSlider()
    {
        Size = new(100, 10);
        OriginPreset = OriginPreset.CenterLeft;
    }

    protected override void MoveMiddleButton(int direction)
    {
        if (MaxPossibleValue == 0)
        {
            return;
        }

        float x = MiddleButton.GlobalPosition.X + direction * (Size.X / MaxPossibleValue);
        float y = MiddleButton.GlobalPosition.Y;

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
            Style.Roundness,
            (int)Size.Y,
            Style.FillColor);
    }

    protected override void UpdateValue()
    {
        float currentPosition = MiddleButton.GlobalPosition.X;
        float minPos = GlobalPosition.X;
        float maxPos = minPos + Size.X;

        float previousValue = Value;

        Value = (currentPosition - minPos) / (maxPos - minPos);

        if (Value != previousValue)
        {
            OnValueChanged();
        }
    }
}