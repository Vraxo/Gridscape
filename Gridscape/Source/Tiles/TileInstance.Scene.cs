namespace Gridscape;

public partial class TileInstance : Node2D
{
    public override void Build()
    {
        Button button = new()
        {
            Size = Size,
            OriginPreset = OriginPreset.TopLeft,
            Layer = ClickableLayer.Tiles,
            OnUpdate = (button) =>
            {
                button.Size = Size * camera.Zoom;
            },
        };

        AddChild(button);

        TexturedRectangle texturedRectangle = new()
        {
            Size = Size,
            OriginPreset = OriginPreset.TopLeft,
            Texture = Texture,
            OnUpdate = (rectangle) =>
            {
                rectangle.Size = Size * camera.Zoom;
            }
        };

        AddChild(texturedRectangle);
    }
}