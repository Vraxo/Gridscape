namespace Gridscape;

class TileFilePathsContainer
{
    public List<string> TileFilePaths = [];

    // Singleton

    private static TileFilePathsContainer? instance;

    public static TileFilePathsContainer Instance
    {
        get
        {
            instance ??= new();
            return instance;
        }
    }
}