namespace Gridscape;

partial class ItemList : Node2D
{
    public override void Build()
    {
        AddChild(new VerticalSlider
        {
            Position = new(100, 0),
            OnUpdate = (slider) =>
            {
                slider.Position.X = Size.X - Origin.X - slider.Size.X - slider.Origin.X;
                slider.Position.Y = -Origin.Y + slider.Button.Radius;

                slider.Size = new(slider.Size.X, Size.Y - slider.Button.Radius * 2);
            }
        });
    }
}