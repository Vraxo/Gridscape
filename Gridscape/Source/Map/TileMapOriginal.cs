//using Raylib_cs;
//
//namespace Gridscape;
//
//class TileMap : Node
//{
//    public Texture2D Texture;
//    public string TileName;
//    public string TileFilePath;
//    public List<TileData> GridData = [];
//    public bool ShowGrid = true;
//    public bool SnapToGrid = true;
//    public Vector2 GridSize = new(32, 32);
//    public Vector2 Size = new(320, 320);
//
//    private Color outlineColor = new(64, 64, 64, 255);
//    private bool drawing = false;
//    private bool erasing = false;
//
//    public override void RunLoop()
//    {
//        base.RunLoop();
//
//        Texture = TextureLoader.Instance.Textures["DefaultTexture"];
//        TileName = "DefaultTexture";
//
//        AddChild(new TileMapGrid());
//    }
//
//    public override void Update()
//    {
//        Position.X = GetNode<leftPanel>("leftPanel").Size.X;
//        Position.Y = GetNode<topPanel>("topPanel").Size.Y;
//
//        DrawBackground();
//        PlaceTile();
//
//        base.Update();
//    }
//
//    private void DrawBackground()
//    {
//        Size.X = Convert.ToInt32(GetNode<TextBox>("topPanel/MapXTextBox").Text);
//        Size.Y = Convert.ToInt32(GetNode<TextBox>("topPanel/MapYTextBox").Text);
//
//        Raylib.DrawRectangle((int)GlobalPosition.X,
//                             (int)GlobalPosition.Y,
//                             (int)Size.X,
//                             (int)Size.Y,
//                             Color.DarkGray);
//    }
//
//    private void PlaceTile()
//    {
//        Vector2 relativeMousePosition = Raylib.GetMousePosition() - GlobalPosition;
//
//        SnapToGrid = GetNode<CircleCheckBox>("topPanel/SnapToGridCheckBox").Checked;
//
//        if (SnapToGrid)
//        {
//            relativeMousePosition = GetSnappedMousePosition(relativeMousePosition);
//        }
//
//        if (Raylib.IsMouseButtonPressed(MouseButton.Left) && IsMouseOver())
//        {
//            AddChild(new TileInstance
//            {
//                Position = relativeMousePosition,
//                Size = new(Texture.Width, Texture.Height),
//                FilePath = TileFilePath,
//                Texture = Texture
//            });
//
//            GridData.Add(new()
//            {
//                X = GetSnappedMousePosition(Raylib.GetMousePosition() - Position).X,
//                Y = GetSnappedMousePosition(Raylib.GetMousePosition() - Position).Y,
//                TileName = TileName
//            });
//        }
//    }
//
//    private Vector2 GetSnappedMousePosition(Vector2 mousePosition)
//    {
//        float snappedX = (int)(Math.Floor(mousePosition.X / GridSize.X) * GridSize.X);
//        float snappedY = (int)(Math.Floor(mousePosition.Y / GridSize.Y) * GridSize.Y);
//
//        return new(snappedX, snappedY);
//    }
//
//    private bool IsMouseOver()
//    {
//        Vector2 mousePosition = Raylib.GetMousePosition();
//
//        bool matchX1 = mousePosition.X > GlobalPosition.X;
//        bool matchX2 = mousePosition.X < GlobalPosition.X + Size.X;
//
//        bool matchY1 = mousePosition.Y > GlobalPosition.Y;
//        bool matchY2 = mousePosition.Y < GlobalPosition.Y + Size.Y;
//
//        return matchX1 && matchX2 && matchY1 && matchY2;
//    }
//}