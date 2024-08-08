using Raylib_cs;

namespace Gridscape;

public partial class TileItem : Node2D
{
    public static readonly float Height = 30F;

    public string TileName;
    public string FilePath;
    public Texture2D Texture;
    public Button Button;
    public TileItemLabel Label;

    private ItemList parent;
    private ButtonStateStyle originalDefaultButtonStyle;

    public override void Start()
    {
        parent = GetParent<ItemList>();

        Button = GetChild<Button>();
        Button.LeftClicked += OnButtonLeftClicked;
        Button.RightClicked += OnButtonRightClicked;
        originalDefaultButtonStyle = Button.Style.Default;

        Label = GetChild<TileItemLabel>();
    }

    private void OnButtonLeftClicked(object? sender, EventArgs e)
    {
        ChangeTileMapTile();
    }

    private void OnButtonRightClicked(object? sender, EventArgs e)
    {
        DeleteTile();
    }

    private void ChangeTileMapTile()
    {
        var tileMap = GetNode<TileMap>("TileMap");

        tileMap.Texture = TextureLoader.Instance.Textures[TileName];
        tileMap.TileName = TileName;
        tileMap.TileFilePath = FilePath;

        UpdateActiveTileItem();
    }

    private void DeleteTile()
    {
        GetNode<TileFilePathsContainer>().TileFilePaths.Remove(FilePath);
        TextureLoader.Instance.Remove(TileName);
        parent.RemoveItem(this);
    }

    private void UpdateActiveTileItem()
    {
        foreach (var tileItem in parent.Items.Cast<TileItem>())
        {
            tileItem.Button.Style.Default = originalDefaultButtonStyle;
        }
        
        Button.Style.Default = Button.Style.Pressed;
    }
}