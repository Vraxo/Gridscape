using Raylib_cs;

namespace Gridscape;

partial class TileInstance : Node2D
{
    public string TileName;
    public string FilePath;
    public Texture2D Texture;
    public Vector2 OriginalPosition;

    private TileMapCamera camera;

    public override void Start()
    {
        OriginalPosition = Position;
        camera = GetNode<TileMapCamera>("TileMapCamera");
        GetChild<Button>("Button").RightClicked += OnButtonRightClicked;
    }

    public override void Update()
    {
        UpdatePosition();
        SignalLeftClickToTileMap();
        base.Update();
    }

    private void OnButtonRightClicked(object? sender, EventArgs e)
    {
        Destroy();
    }

    private void UpdatePosition()
    {
        Position = (OriginalPosition - camera.Position) * camera.Zoom;
        Position.X = MathF.Floor(Position.X);
    }

    private void SignalLeftClickToTileMap()
    {
        if (Raylib.IsMouseButtonPressed(MouseButton.Left))
        {
            GetNode<TileMap>().OnTopLeft = true;
        }
    }
}