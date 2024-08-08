using Raylib_cs;

namespace Gridscape;

public partial class CreateOrLoadProjectPage : Node2D
{
    public override void Build()
    {
        AddChild(new Button
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
        }, "CreateNewProjectButton");

        AddChild(new Button
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
        }, "LoadExistingProjectButton");
    }
}