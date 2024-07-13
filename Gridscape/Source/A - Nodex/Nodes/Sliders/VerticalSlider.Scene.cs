namespace Gridscape;

partial class VerticalSlider : Node2D
{
    public override void Build()
    {
        AddChild(new SliderButton());
    }
}