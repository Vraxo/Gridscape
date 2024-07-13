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

        var itemList = GetChild<ItemList>("ItemList");
        itemList.AddItem(new Label { Text = "Item Number 1", InheritsOrigin = true });
        itemList.AddItem(new Label { Text = "Item Number 2", InheritsOrigin = true });
        itemList.AddItem(new Label { Text = "Item Number 3", InheritsOrigin = true });
        itemList.AddItem(new Label { Text = "Item Number 4", InheritsOrigin = true });
        itemList.AddItem(new Label { Text = "Item Number 5", InheritsOrigin = true });
        itemList.AddItem(new Label { Text = "Item Number 6", InheritsOrigin = true });
        itemList.AddItem(new Label { Text = "Item Number 7", InheritsOrigin = true });
        itemList.AddItem(new Label { Text = "Item Number 8", InheritsOrigin = true });
        itemList.AddItem(new Label { Text = "Item Number 9", InheritsOrigin = true });
        itemList.AddItem(new Label { Text = "Item Number 10", InheritsOrigin = true });
        itemList.AddItem(new Label { Text = "Item Number 11", InheritsOrigin = true });
        itemList.AddItem(new Label { Text = "Item Number 12", InheritsOrigin = true });
        itemList.AddItem(new Label { Text = "Item Number 13", InheritsOrigin = true });
        itemList.AddItem(new Label { Text = "Item Number 14", InheritsOrigin = true });
        itemList.AddItem(new Label { Text = "Item Number 15", InheritsOrigin = true });
        itemList.AddItem(new Label { Text = "Item Number 16", InheritsOrigin = true });
        itemList.AddItem(new Label { Text = "Item Number 17", InheritsOrigin = true });
        itemList.AddItem(new Label { Text = "Item Number 18", InheritsOrigin = true });
        itemList.AddItem(new Label { Text = "Item Number 19", InheritsOrigin = true });
        itemList.AddItem(new Label { Text = "Item Number 20", InheritsOrigin = true });
        itemList.AddItem(new Label { Text = "Item Number 21", InheritsOrigin = true });
        itemList.AddItem(new Label { Text = "Item Number 22", InheritsOrigin = true });
        itemList.AddItem(new Label { Text = "Item Number 23", InheritsOrigin = true });
        itemList.AddItem(new Label { Text = "Item Number 24", InheritsOrigin = true });
        itemList.AddItem(new Label { Text = "Item Number 25", InheritsOrigin = true });
        itemList.AddItem(new Label { Text = "Item Number 26", InheritsOrigin = true });
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
                //OriginPreset = OriginPreset.TopLeft
            });
        }
    }
}