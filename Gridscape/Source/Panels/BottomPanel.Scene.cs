using Raylib_cs;

namespace Gridscape;

public partial class BottomPanel : Panel
{
    public override void Build()
    {
        AddChild(new HorizontalSlider
        {
            Position = new(30, Size.Y / 2),
            SliderLayer = ClickableLayer.PanelButtons,
            OnUpdate = (slider) =>
            {
                slider.Position.Y = Size.Y / 2;
                slider.Size = new(Raylib.GetScreenWidth() - Position.X - 60, slider.Size.Y);

                float cameraExtraWidth = GetNode<TileMapCamera>().ExtraMapSize.X;
                slider.MaxExternalValue = MathF.Max(0, cameraExtraWidth);
            }
        }, "Slider");
    }
}