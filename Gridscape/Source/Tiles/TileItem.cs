using Raylib_cs;

namespace Gridscape;

partial class TileItem : Node2D
{
    public static readonly float Height = 30F;

    public string TileName;
    public string FilePath;
    public Texture2D Texture;
    public Button Button;

    private TilesPanel parent;
    private Button addNewTileButton;
    private ButtonStyleState defaultUnpressedButtonStyle;

    public override void Start()
    {
        //parent = GetParent<TilesPanel>();
        addNewTileButton = GetNode<Button>("LeftPanel/Button");

        Button = GetChild<Button>("Button");
        Button.LeftClicked += OnButtonLeftClicked;
        defaultUnpressedButtonStyle = Button.Style.Default;
    }

    public override void Update()
    {
        Raylib.DrawPixelV(GlobalPosition, Color.Magenta);
        UpdatePosition();
    }

    private void OnButtonLeftClicked(object? sender, EventArgs e)
    {
        ChangeTileMapTile();
    }

    private void UpdatePosition()
    {
        //Position.X = addNewTileButton.Position.X;
    }

    private void ChangeTileMapTile()
    {
        var tileMap = GetNode<TileMap>("TileMap");

        tileMap.Texture = TextureLoader.Instance.Textures[TileName];
        tileMap.TileName = TileName;
        tileMap.TileFilePath = FilePath;

        UpdateActiveTileItem();
    }

    private void UpdateActiveTileItem()
    {
        //foreach (var tileItem in parent.Children.Cast<TileItem>())
        //{
        //    tileItem.Button.Style.Default = defaultUnpressedButtonStyle;
        //}
        //
        //Button.Style.Default = Button.Style.Pressed;
    }
}