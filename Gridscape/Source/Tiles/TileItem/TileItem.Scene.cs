namespace Gridscape;

public partial class TileItem : Node2D
{
    public override void Build()
    {
        AddChild(new Button()
        {
            OriginPreset = OriginPreset.TopLeft,
            Layer = ClickableLayer.Panels,
            OnUpdate = (button) =>
            {
                button.Size = new(GetNode<Button>("LeftPanel/Button").Size.X, button.Size.Y);
            }
        });

        AddChild(new TexturedRectangle
        {
            Texture = Texture,
            Size = new(25, 25),
            OriginPreset = OriginPreset.TopLeft
        });
        
        AddChild(new TileItemLabel
        {
            Text = TileName,
            Position = new(30, 12.5F),
        });
    }
}