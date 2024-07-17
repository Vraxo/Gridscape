using Raylib_cs;

namespace Gridscape;

public class TileMapBackground : Node2D
{
    private readonly Color color = new(96, 96, 96, 255);
    private TileMap parent;
    private TileMapCamera camera;

    private Vector2 originalPosition;

    public override void Start()
    {
        parent = GetParent<TileMap>();
        camera = GetNode<TileMapCamera>("TileMapCamera");

        originalPosition = Position;
    }

    public override void Update()
    {
        UpdatePosition();
        Draw();
        base.Update();
    }

    private void UpdatePosition()
    {
        Position = (originalPosition - camera.Position) * camera.Zoom;
    }

    private void Draw()
    {
        Vector2 size = parent.Size * camera.Zoom;
        Raylib.DrawRectangleV(GlobalPosition, size, color);
    }
}