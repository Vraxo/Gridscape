using Raylib_cs;
using Gridscape.Properties;

namespace Gridscape;

public class Program
{
    public Node RootNode;

    public void Run(Node rootNode)
    {
        SetWindowFlags();
        Initialize(rootNode);
        RunLoop();
    }

    private static void SetWindowFlags()
    {
        //Raylib.SetConfigFlags(ConfigFlags.VSyncHint);
        //Raylib.SetConfigFlags(ConfigFlags.Msaa4xHint);
        //Raylib.SetConfigFlags(ConfigFlags.HighDpiWindow);
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
        RootNode.Start();
    }

    private void RunLoop()
    {
        while (!Raylib.WindowShouldClose())
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(new(57, 57, 57, 255));
            RootNode.Tick();
            Raylib.EndDrawing();

            if (Raylib.IsKeyPressed(KeyboardKey.Enter))
            {
                Console.Clear();
                RootNode.PrintChildren();
            }
        }
    }

    private void CreateResources()
    {
        if (!Directory.Exists("Resources"))
        {
            Directory.CreateDirectory("Resources");

            Bitmap icon = Resources.Icon;
            icon.Save("Resources/Icon.png");

            byte[] defaultFont = Resources.RobotoMono;
            File.WriteAllBytes("Resources/RobotoMono.ttf", defaultFont);

            Bitmap defaultTexture = Resources.DefaultTexture;
            defaultTexture.Save("Resources/DefaultTexture.png");
        }
    }

    private void SetIcon()
    {
        Texture2D iconTexture = Raylib.LoadTexture("Resources/Icon.png");
        Image icon = Raylib.LoadImageFromTexture(iconTexture);
        Raylib.SetWindowIcon(icon);
    }
}