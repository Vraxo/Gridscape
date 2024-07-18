using Raylib_cs;

namespace Gridscape;

public class HorizontalSliderButton : BaseSliderButton
{
    protected override void UpdatePosition(bool initial = false)
    {
        BaseSlider parent = Parent as BaseSlider;

        if (Pressed)
        {
            GlobalPosition = new(Raylib.GetMousePosition().X, parent.GlobalPosition.Y);
            parent.UpdatePercentageBasedOnMiddleButton();
        }

        UpdatePositionHorizontal(parent, initial);
    }

    private void UpdatePositionHorizontal(BaseSlider parent, bool initial)
    {
        float minX = parent.GlobalPosition.X;
        float maxX = minX + parent.Size.X;

        if (initial && !initialPositionSet)
        {
            GlobalPosition = new(minX, parent.GlobalPosition.Y);
            initialPositionSet = true;
        }
        else
        {
            GlobalPosition = new(Math.Clamp(GlobalPosition.X, minX, maxX), parent.GlobalPosition.Y);
        }
    }
}