namespace Gridscape;

public partial class ItemList : ClickableRectangle
{
    public override void Build()
    {
        AddChild(new VerticalSlider
        {
            OnUpdate = (slider) =>
            {
                slider.Position.X = Size.X - Origin.X - slider.Size.X - slider.Origin.X;
                slider.Position.Y = -Origin.Y + slider.MiddleButton.Radius * 2.5F; // *4
                //slider.Position.Y = slider.MiddleButton.Radius * 2.5F;

                slider.Size = new(slider.Size.X, Size.Y - slider.MiddleButton.Radius * 5); // * 8
            }
        });
    }
}