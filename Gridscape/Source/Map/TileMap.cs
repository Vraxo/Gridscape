using Raylib_cs;

namespace Gridscape;

partial class TileMap : Clickable
{
    public Texture2D Texture;
    public string TileName;
    public string TileFilePath;
    public TileMapGrid Grid;
    public Node2D TileInstances;

    private TileMapCamera camera;
    private TextBox xTextBox;
    private TextBox yTextBox;
    private LeftPanel leftPanel;
    private TopPanel topPanel;

    public override void Start()
    {
        Size = new(320, 320);
        Layer = (int)ClickableLayer.TileMap;
        Texture = TextureLoader.Instance.Textures["DefaultTexture"];
        TileName = "DefaultTexture";

        camera = GetNode<TileMapCamera>("TileMapCamera");
        xTextBox = GetNode<TextBox>("TopPanel/MapX/TextBox");
        yTextBox = GetNode<TextBox>("TopPanel/MapY/TextBox");
        leftPanel = GetNode<LeftPanel>("LeftPanel");
        topPanel = GetNode<TopPanel>("TopPanel");

        Grid = GetChild<TileMapGrid>("TileMapGrid");
        TileInstances = GetChild<Node2D>("TileInstances");

        base.Start();
    }

    public override void Update()
    {
        UpdatePosition();
        UpdateSize();
        CheckForClicks();
        base.Update();
    }

    public override bool IsMouseOver()
    {
        Vector2 mousePosition = Raylib.GetMousePosition();

        return mousePosition.X > GlobalPosition.X &&
               mousePosition.X < GlobalPosition.X + Size.X * camera.Zoom &&
               mousePosition.Y > GlobalPosition.Y &&
               mousePosition.Y < GlobalPosition.Y + Size.Y * camera.Zoom;
    }

    public List<TileData> GetTileData()
    {
        List<TileData> tileData = [];

        foreach (var tileInstance in TileInstances.Children.Cast<TileInstance>())
        {
            tileData.Add(new()
            {
                X = tileInstance.Position.X,
                Y = tileInstance.Position.Y,
                Name = tileInstance.TileName
            });
        }

        return tileData;
    }

    private void UpdatePosition()
    {
        Position.X = leftPanel.Size.X;
        Position.Y = topPanel.Size.Y;
    }

    private void UpdateSize()
    {
        Size = new(Convert.ToInt32(xTextBox.Text), Convert.ToInt32(yTextBox.Text));
    }

    private void CheckForClicks()
    {
        if (Raylib.IsMouseButtonPressed(MouseButton.Left))
        {
            if (IsMouseOver() && OnTopLeft)
            {
                PlaceTile();
                OnTopLeft = false;
            }
        }
    }

    private void PlaceTile()
    {
        Vector2 relativeMousePosition = Raylib.GetMousePosition() - GlobalPosition;
        
        if (Grid.Snap)
        {
            relativeMousePosition = GetSnappedMousePosition(relativeMousePosition);
        }
        else
        {
            relativeMousePosition = GetAdjustedMousePosition(relativeMousePosition);
        }

        AddTileInstance(relativeMousePosition);
    }

    private void AddTileInstance(Vector2 position)
    {
        TileInstances.AddChild(new TileInstance
        {
            Position = position,
            Size = new(Texture.Width, Texture.Height),
            FilePath = TileFilePath,
            TileName = TileName,
            Texture = Texture
        });
    }

    private Vector2 GetAdjustedMousePosition(Vector2 mousePosition)
    {
        Vector2 adjustedMousePosition = (mousePosition + camera.Position * camera.Zoom) / camera.Zoom;
        Vector2 textureSize = new(Texture.Width, Texture.Height);
        Vector2 centeredMousePosition = adjustedMousePosition - textureSize / 2;

        return centeredMousePosition;
    }

    private Vector2 GetSnappedMousePosition(Vector2 mousePosition)
    {
        Vector2 adjustedMousePosition = (mousePosition + camera.Position * camera.Zoom) / camera.Zoom;

        Vector2 cellPosition = adjustedMousePosition / Grid.Size;

        float snappedX = (float)Math.Floor(cellPosition.X) * Grid.Size.X;
        float snappedY = (float)Math.Floor(cellPosition.Y) * Grid.Size.Y;

        Vector2 snappedPosition = new(snappedX, snappedY);

        Vector2 textureSize = new(Texture.Width, Texture.Height);

        if (textureSize.X > Grid.Size.X || textureSize.Y > Grid.Size.Y)
        {
            snappedPosition -= textureSize / 2;
        }

        return snappedPosition;
    }
}