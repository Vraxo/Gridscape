using Raylib_cs;

namespace Gridscape;

class TileMapGrid : Node2D
{
    public bool Visible = true;
    public bool Snap = true;

    private TileMap parent;
    private Vector2 mapSize;
    private Vector2 originalPosition;
    private TileMapCamera camera;

    public override void Start()
    {
        Size = new(32, 32);

        originalPosition = Position;

        parent = GetParent<TileMap>();

        camera = GetNode<TileMapCamera>("TileMapCamera");

        GetNode<TextBox>("TopPanel/GridX/TextBox").TextChanged += OnXTextBoxTextChanged;
        GetNode<TextBox>("TopPanel/GridY/TextBox").TextChanged += OnYTextBoxTextChanged;

        GetNode<CircleCheckBox>("TopPanel/ShowGrid/CheckBox").Toggled += OnVisibleCheckBoxToggled;
        GetNode<CircleCheckBox>("TopPanel/SnapToGrid/CheckBox").Toggled += OnSnapCheckBoxToggled;
    }

    public override void Update()
    {
        if (Visible)
        {
            UpdateSize();
            Draw();
        }
    }

    private void OnVisibleCheckBoxToggled(object? sender, EventArgs e)
    {
        Visible = !Visible;
    }

    private void OnSnapCheckBoxToggled(object? sender, EventArgs e)
    {
        Snap = !Snap;
    }

    private void OnXTextBoxTextChanged(object? sender, string e)
    {
        int x = Convert.ToInt32(e);
        Size = new(x, Size.Y);
    }

    private void OnYTextBoxTextChanged(object? sender, string e)
    {
        int y = Convert.ToInt32(e);
        Size = new(Size.X, y);
    }

    private void Draw()
    {
        //Vector2 truePosition = Position;

        //Position = OriginalPosition - GetNode<TileMapCamera>("TileMapCamera").Position;
        Position = (originalPosition - camera.Position) * camera.Zoom;
        DrawVerticalLines();
        DrawHorizontalLines();

        //Position = truePosition;
    }

    private void UpdateSize()
    {
        mapSize = parent.Size;
        Size = Size == new Vector2(0) ? new Vector2(1) : Size;
    }

    private void DrawVerticalLines()
    {
        float zoom = camera.Zoom;
        float cellWidth = Size.X * zoom;
        int numCells = (int)(mapSize.X * zoom / cellWidth);

        for (int i = 0; i < numCells; i++)
        {
            float posX = GlobalPosition.X + cellWidth * i;
            float startY = GlobalPosition.Y;
            float endY = GlobalPosition.Y + mapSize.Y * zoom;

            Raylib.DrawLine(
                (int)posX,
                (int)startY,
                (int)posX,
                (int)endY,
                Color.White);
        }
    }

    private void DrawHorizontalLines()
    {
        float zoom = camera.Zoom;
        float cellHeight = Size.Y * zoom;
        int numCells = (int)(mapSize.Y * zoom / cellHeight);

        for (int i = 0; i <= numCells; i++)
        {
            float startX = GlobalPosition.X;
            float posY = GlobalPosition.Y + cellHeight * i;
            float endX = GlobalPosition.X + mapSize.X * zoom;

            Raylib.DrawLine(
                (int)startX,
                (int)posY,
                (int)endX,
                (int)posY,
                Color.White);
        }
    }
}