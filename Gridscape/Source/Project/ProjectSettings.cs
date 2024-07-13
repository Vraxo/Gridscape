namespace Gridscape;

class ProjectSettings
{
    public string SavePath { get; set; } = "";
    public int MapX { get; set; } = 320;
    public int MapY { get; set; } = 320;
    public int GridX { get; set; } = 32;
    public int GridY { get; set; } = 32;
    public bool ShowGrid { get; set; } = true;
    public bool SnapToGrid { get; set; } = true;
}