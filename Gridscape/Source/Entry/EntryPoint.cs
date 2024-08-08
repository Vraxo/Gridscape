namespace Gridscape;

public class EntryPoint
{
    [STAThread]
    public static void Main()
    {
        AppInitializer rootNode = new();

        WindowData windowData = new()
        {
            Title = "Gridscape",
            Resolution = new(1280, 720),
            ClearColor = new(57, 57, 57, 255)
        };

        Program program = new(windowData, rootNode);
        program.Run();
    }
}