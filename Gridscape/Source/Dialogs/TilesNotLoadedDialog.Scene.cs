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

        AddChild(new ItemList
        {
            Position = new(10, 50),
            Size = new(750, 400),
            InheritsOrigin = true,
            SliderButtonLayer = ClickableLayer.DialogButtons,
            OnItemCountChanged = (list) =>
            {
                static string PadNumbers(string input)
                {
                    return Regex.Replace(input, "[0-9]+", match => match.Value.PadLeft(10, '0'));
                }

                list.Items = list.Items.Cast<Label>()
                       .OrderBy(o => PadNumbers(o.Text))
                       .Cast<Node2D>()
                       .ToList();
            }
        });
    }
}