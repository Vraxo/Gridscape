using Raylib_cs;
using System.Text.RegularExpressions;

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
                button.Position = new(Size.X / 2, button.Position.Y);

                //button.Position.X = Size.X * 0.05F;
                button.Size = new(Size.X * 0.9F, button.Size.Y);
            },
        });

        AddChild(new ItemList
        {
            Position = new(10, 50),
            Size = new(150, 500),
            ItemSize = new(100, TileItem.Height),
            SliderButtonLayer = ClickableLayer.PanelButtons,
            OnUpdate = (list) =>
            {
                list.Size = new(Size.X * 0.9F, Raylib.GetScreenHeight() - 100);
            },
            OnItemCountChanged = (list) =>
            {
                static string PadNumbers(string input)
                {
                    return Regex.Replace(input, "[0-9]+", match => match.Value.PadLeft(10, '0'));
                }

                list.Items = list.Items.Cast<TileItem>()
                       .OrderBy(o => PadNumbers(o.TileName))
                       .Cast<Node2D>()
                       .ToList();
            }
        });
    }
}