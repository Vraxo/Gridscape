using System.Text.RegularExpressions;

namespace Gridscape;

public partial class TilesNotLoadedDialog : Node2D
{
    public override void Build()
    {
        AddChild(new Panel
        {
            Size = new(800, 500),
            InheritsOrigin = true
        });

        AddChild(new Button
        {
            Text = "X",
            Size = new(25, 25),
            InheritsOrigin = true,
            Layer = ClickableLayer.DialogButtons,
            Style = new()
            {
                TextColor = Color.Red
            },
            OnUpdate = (button) =>
            {
                button.Position.X = 800 - 35;
                button.Position.Y = 10;
            }
        });

        AddChild(new Label
        {
            Position = new(10, 20),
            InheritsOrigin = true,
            Text = "The following tiles could not be loaded:"
        });

        // Your existing code with modifications
        AddChild(new ItemList
        {
            Position = new(10, 50),
            Size = new(750, 400),
            InheritsOrigin = true,
            SliderButtonLayer = ClickableLayer.DialogButtons,
            OnItemCountChanged = (list) =>
            {
                list.Items.Sort((item1, item2) =>
                {
                    if (item1 is TileItem tileItem1 && item2 is TileItem tileItem2)
                    {
                        string label1 = tileItem1.TileName;
                        string label2 = tileItem2.TileName;

                        return string.Compare(label1, label2, StringComparison.OrdinalIgnoreCase);
                    }

                    return 0;
                });
            }
        });
    }
}