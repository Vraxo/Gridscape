using Raylib_cs;

namespace Gridscape;

partial class NotLoadedTilesDialog : Node2D
{
    public List<string> NotLoadedTiles = [];

    public override void Ready()
    {
        GetNode<ClickManager>("ClickManager").MinLayer = ClickableLayer.DialogButtons;
        Origin = GetChild<Panel>("Panel").Size / 2;
        GetChild<Button>("Button").LeftClicked += OnButtonLeftClicked;
        LoadItems();
    }

    public override void Update()
    {
        UpdatePosition();
    }

    private void OnButtonLeftClicked(object? sender, EventArgs e)
    {
        GetNode<ClickManager>("ClickManager").MinLayer = 0;
        Destroy();
    }

    private void UpdatePosition()
    {
        Position.X = Raylib.GetScreenWidth() / 2;
        Position.Y = Raylib.GetScreenHeight() / 2;
    }

    private void LoadItems()
    {
        var itemList = GetChild<ItemList>("ItemList");

        foreach (string tile in NotLoadedTiles)
        {
            itemList.AddItem(new Label
            {
                Text = tile,
                OriginPreset = OriginPreset.TopLeft
            });
        }
    }
}