using Raylib_cs;

namespace Gridscape;

public partial class LeftPanel : Panel
{
    public override void Build()
    {
        AddChild(new Button()
        {
            Text = "Add New Tile",
            Position = new(0, 25),
            Size = new(25, 25),
            OriginPreset = OriginPreset.Center,
            Layer = ClickableLayer.PanelButtons,
            OnUpdate = (button) =>
            {
                button.Position.X = Size.X / 2;
                //button.Position.X = Size.X * 0.05F;
                button.Size = new(Size.X * 0.9F, button.Size.Y);
            },
        });

        AddChild(new ItemList
        {
            Position = new(10, 50),
            Size = new(150, 500),
            ItemSize = new(100, TileItem.Height),
            OnUpdate = (list) =>
            {
                list.Size = new(Size.X * 0.9F, Raylib.GetScreenHeight() - 100);
            }
        });
    }
}