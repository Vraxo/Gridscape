namespace Gridscape;

partial class ItemList : ClickableRectangle
{
    public override void Build()
    {
        AddChild(new VerticalSlider
        {
            OnUpdate = (slider) =>
            {
                slider.Position.X = Size.X - Origin.X - slider.Size.X - slider.Origin.X;
                slider.Position.Y = -Origin.Y + slider.MiddleButton.Radius;

                slider.Size = new(slider.Size.X, Size.Y - slider.MiddleButton.Radius * 2);
            }
        });
    }
}