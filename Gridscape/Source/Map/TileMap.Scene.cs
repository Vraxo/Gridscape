namespace Gridscape;

public partial class TileMap : Clickable
{
    public override void Build()
    {
        AddChild(new TileMapBackground());

        AddChild(new Node2D(), "TileInstances");

        AddChild(new TileMapGrid());
    }
}