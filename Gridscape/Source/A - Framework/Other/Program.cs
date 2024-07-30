using Raylib_cs;
using Gridscape.Properties;

namespace Gridscape;

public class Program
{
    public Node RootNode;

    [STAThread]
    public static void Main()
    {
        new Program().Run();
    }

    public void Run()
    {
        SetWindowFlags();
        Initialize(new CreateOrLoadProjectPage());
        RunLoop();
    }

    private static void SetWindowFlags()
    {
        Raylib.SetConfigFlags(ConfigFlags.VSyncHint);
        Raylib.SetConfigFlags(ConfigFlags.Msaa4xHint);
        Raylib.SetConfigFlags(ConfigFlags.HighDpiWindow);
        Raylib.SetConfigFlags(ConfigFlags.ResizableWindow);
    }

    private void Initialize(Node rootNode)
    {
        Raylib.InitWindow(1280, 720, "Gridscape");
        Raylib.SetWindowMinSize(1280, 720);

        CreateResources();
        SetIcon();
        
        RootNode = rootNode;
        RootNode.Program = this;
        RootNode.Build();
    }

    private void RunLoop()
    {
        while (!Raylib.WindowShouldClose())
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(new(57, 57, 57, 255));
            RootNode.Process();
            Raylib.EndDrawing();

            if (Raylib.IsKeyPressed(KeyboardKey.Enter))
            {
                Console.Clear();
                RootNode.PrintChildren();
            }
        }
    }

    private static void CreateResources()
    {
        if (!Directory.Exists("Resources"))
        {
            Directory.CreateDirectory("Resources");
        }

        if (!File.Exists("Resources/Icon.png"))
        {
            Bitmap icon = Resources.Icon;
            icon.Save("Resources/Icon.png");
        }

        if (!File.Exists("Resources/RobotoMono.ttf"))
        {
            byte[] defaultFont = Resources.RobotoMono;
            File.WriteAllBytes("Resources/RobotoMono.ttf", defaultFont);
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