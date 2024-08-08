using Raylib_cs;

namespace Gridscape;

public class Program(Node rootNode)
{
    public Node RootNode = rootNode;

    public void Run()
    {
        SetWindowFlags();
        Initialize();
        RunLoop();
    }

    private static void SetWindowFlags()
    {
        Raylib.SetConfigFlags(ConfigFlags.VSyncHint);
        Raylib.SetConfigFlags(ConfigFlags.Msaa4xHint);
        Raylib.SetConfigFlags(ConfigFlags.HighDpiWindow);
        Raylib.SetConfigFlags(ConfigFlags.ResizableWindow);
    }

    private void Initialize()
    {
        if (!Directory.Exists("Resources"))
        {
            Directory.CreateDirectory("Resources");
        }

        Raylib.InitWindow(1280, 720, "Gridscape");
        Raylib.SetWindowMinSize(1280, 720);

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
}