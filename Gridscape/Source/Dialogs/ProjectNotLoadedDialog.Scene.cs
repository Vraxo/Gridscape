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
                float x = 400 - 35;
                float y = 10;

                button.Position = new(x, y);
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