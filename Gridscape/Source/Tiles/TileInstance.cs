﻿using Raylib_cs;

namespace Gridscape;

public partial class TileInstance : Node2D
{
    public string TileName;
    public string FilePath;
    public Texture2D Texture;
    public Vector2 OriginalPosition;

    private TileMapCamera camera;

    public override void Start()
    {
        OriginalPosition = Position;
        camera = GetNode<TileMapCamera>();
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

        float x = MathF.Floor(Position.X);
        float y = Position.Y;

        Position = new(x, y);
    }

    private void SignalLeftClickToTileMap()
    {
        if (GetChild<Button>().OnTopLeft)
        {
            GetNode<TileMap>().PlaceTileOnTopOfTile();
            GetChild<Button>().OnTopLeft = false;
        }
    }
}