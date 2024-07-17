namespace Gridscape;

partial class RightPanel : Panel
{
    public override void Build()
    {
        AddChild(new VerticalSlider
        {
            Position = new(0, 25),
            Size = new(10, 0),
            OriginPreset = OriginPreset.Center,
            OnUpdate = (slider) =>
            {
                slider.Position.X = Size.X / 2;
                slider.Position.Y = Size.Y / 2;
                slider.Size = new(slider.Size.X, Size.Y - 100);

                float cameraExtraHeight = GetNode<TileMapCamera>().ExtraMapSize.Y;
                slider.MaxExternalValue = MathF.Max(0, cameraExtraHeight);
            }
        }, "Slider");
    }
}