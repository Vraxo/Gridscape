namespace Gridscape;

class ProjectData
{
    public ProjectSettings ProjectSettings { get; set; }
    public List<TileData> TileData { get; set; }
    public List<string> TileFilePaths { get; set; }
}