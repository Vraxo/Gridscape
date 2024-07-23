using System.Text.RegularExpressions;

namespace Gridscape;

public partial class ProjectNotLoadedDialog : Node2D
{
    public override void Build()
    {
        AddChild(new Panel
        {
            Size = new(400, 250),
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
                button.Position.X = 400 - 35;
                button.Position.Y = 10;
            }
        });

        AddChild(new Label
        {
            Position = new(10, 20),
            InheritsOrigin = true,
            Text = "The project could not be loaded."
        });
    }
}