namespace Gridscape;

public class EntryPoint
{
    [STAThread]
    public static void Main()
    {
        AppInitializer rootNode = new();
        Program program = new(rootNode);
        program.Run();
    }
}