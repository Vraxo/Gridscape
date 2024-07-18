using Raylib_cs;

namespace Gridscape;

public partial class HorizontalSlider : BaseSlider
{
    public HorizontalSlider()
    {
        Size = new(100, 10);
        OriginPreset = OriginPreset.CenterLeft;
    }

    public override void UpdatePercentageBasedOnMiddleButton()
    {
        float currentPosition = MiddleButton.GlobalPosition.X;
        float minPos = GlobalPosition.X;
        float maxPos = minPos + Size.X;

        float previousValue = Percentage;

        Percentage = (currentPosition - minPos) / (maxPos - minPos);

        if (Percentage != previousValue)
        {
            OnPercentageChanged();
        }
    }

    protected override void MoveMiddleButton(int direction)
    {
        if (MaxExternalValue == 0)
        {
            return;
        }

        float x = MiddleButton.GlobalPosition.X + direction * (Size.X / MaxExternalValue);
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
}