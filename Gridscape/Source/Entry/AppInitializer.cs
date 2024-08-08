using Gridscape.Properties;
using Raylib_cs;

namespace Gridscape;

public class AppInitializer : Node
{
    public override void Build()
    {
        Initialize();
        AddChild(new CreateOrLoadProjectPage());
    }

    private static void Initialize()
    {
        Raylib.MaximizeWindow();
        CreateResources();
        SetIcon();
    }

    private static void CreateResources()
    {
        if (!File.Exists("Resources/Icon.png"))
        {
            Bitmap icon = Resources.Icon;
            icon.Save("Resources/Icon.png");
        }

        if (!File.Exists("Resources/DefaultTile.png"))
        {
            Bitmap defaultTexture = Resources.DefaultTile;
            defaultTexture.Save("Resources/DefaultTile.png");
        }
    }

    private static void SetIcon()
    {
        Texture2D iconTexture = Raylib.LoadTexture("Resources/Icon.png");
        Image icon = Raylib.LoadImageFromTexture(iconTexture);
        Raylib.SetWindowIcon(icon);
    }
}