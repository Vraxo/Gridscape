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
                float x = Raylib.GetScreenWidth() * 0.35f;
                float y = Raylib.GetScreenHeight() * 0.1f;

                button.Position = new(x, y);
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
                float x = Raylib.GetScreenWidth() * 0.65f;
                float y = Raylib.GetScreenHeight() * 0.1f;

                button.Position = new(x, y);
            }
        };

        AddChild(loadButton, "LoadExistingProjectButton");
    }
}