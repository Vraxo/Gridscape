namespace Gridscape;

class Workspace : Node2D
{
    private static readonly int leftPanelIndex = 1;
    private static readonly int tileMapIndex = 6;

    public override void Start()
    {
        AddChild(new ClickManager());  // 0
        AddChild(new LeftPanel());     // 1
        AddChild(new TopPanel());      // 2
        AddChild(new BottomPanel());   // 3
        AddChild(new RightPanel());    // 4
        AddChild(new TileMapCamera()); // 5
        AddChild(new TileMap());       // 6
        AddChild(new ProjectLoader()); // 7
        AddChild(new NotLoadedTilesDialog());

        Children.Swap(leftPanelIndex, tileMapIndex);
    }
}