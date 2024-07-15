namespace Gridscape;

partial class RightPanel : Panel
{
    public override void Build()
    {
        AddChild(new VerticalSlider
        {
            Position = new(0, 25),
            Size = new(10, 0),
            OnUpdate = (slider) =>
            {
                slider.Position.X = Size.X / 2;
                slider.Size = new(slider.Size.X, Size.Y - 50);

                float cameraExtraHeight = GetNode<TileMapCamera>().ExtraMapSize.Y;
                slider.MaxPossibleValue = MathF.Max(0, cameraExtraHeight);
            }
        }, "Slider");
    }
}