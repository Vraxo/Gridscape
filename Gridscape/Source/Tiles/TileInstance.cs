using Raylib_cs;

namespace Gridscape;

partial class TileInstance : Node2D
{
    public string TileName;
    public string FilePath;
    public Texture2D Texture;

    private Vector2 originalPosition;
    private TileMapCamera camera;

    public override void Start()
    {
        originalPosition = Position;
        camera = GetNode<TileMapCamera>("TileMapCamera");
    }

    public override void Update()
    {
        UpdatePosition();
        base.Update();
    }

    private void UpdatePosition()
    {
        Position = (originalPosition - camera.Position) * camera.Zoom;
    }

    private void OnButtonRightClicked(object? sender, EventArgs e)
    {
        Destroy();
    }
}