namespace Gridscape;

partial class TileItem : Node2D
{
    public override void Build()
    {
        AddChild(new Button()
        {
            OriginPreset = OriginPreset.TopLeft,
            Layer = (int)ClickableLayer.Panels,
            OnUpdate = (button) =>
            {
                button.Size.X = GetNode<Button>("LeftPanel/Button").Size.X;
            },
        });

        AddChild(new TexturedRectangle
        {
            Texture = Texture,
            Size = new(25, 25),
            OriginPreset = OriginPreset.TopLeft
        });

        AddChild(new Label
        {
            Text = TileName,
            Position = new(30, 12.5F),
        });
    }
}