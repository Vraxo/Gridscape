using Raylib_cs;

namespace Gridscape;

public partial class CreateOrLoadProjectPage : Node2D
{
    public override void Build()
    {
        Button createButton = new()
        {
            Text = "Create New Project",
            Size = new(300, 50),
            OriginPreset = OriginPreset.Center,
            OnUpdate = (button) =>
            {
                button.Position.X = Raylib.GetScreenWidth() * 0.35f;
                button.Position.Y = Raylib.GetScreenHeight() * 0.1f;
            }
        };

        AddChild(createButton, "CreateNewProjectButton");

        Button loadButton = new()
        {
            Text = "Load Existing Project",
            Size = new(300, 50),
            OriginPreset = OriginPreset.Center,
            OnUpdate = (button) =>
            {
                button.Position.X = Raylib.GetScreenWidth() * 0.65f;
                button.Position.Y = Raylib.GetScreenHeight() * 0.1f;
            }
        };

        AddChild(loadButton, "LoadExistingProjectButton");
    }
}