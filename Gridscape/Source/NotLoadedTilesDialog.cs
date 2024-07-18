using Raylib_cs;
using System.Text.RegularExpressions;

namespace Gridscape;

public partial class NotLoadedTilesDialog : Node2D
{
    public List<string> NotLoadedTiles = [];

    public override void Ready()
    {
        GetNode<ClickManager>().MinLayer = ClickableLayer.DialogButtons;
        Origin = GetChild<Panel>().Size / 2;
        GetChild<Button>().LeftClicked += OnButtonLeftClicked;
        LoadItems();
    }

    public override void Update()
    {
        UpdatePosition();
    }

    private void OnButtonLeftClicked(object? sender, EventArgs e)
    {
        GetNode<ClickManager>().MinLayer = 0;
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
            Label label = new() { Text = tile };
            itemList.AddItem(label);
        }
    }
}