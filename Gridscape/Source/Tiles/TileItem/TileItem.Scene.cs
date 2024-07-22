namespace Gridscape;

public partial class TileItem : Node2D
{
    public override void Build()
    {
        AddChild(new Button()
        {
            OriginPreset = OriginPreset.TopLeft,
            Layer = ClickableLayer.PanelButtons,
            OnUpdate = (button) =>
            {
                LeftPanel leftPanel = GetNode<LeftPanel>("LeftPanel");
                button.Size = new(leftPanel.Size.X * 0.75F, button.Size.Y);
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