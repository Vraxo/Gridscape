using Raylib_cs;
using System.Collections.Generic;

namespace Gridscape;

public partial class LeftPanel : Panel
{
    private List<string> notLoadedTiles = new();

    public override void Start()
    {
        GetChild<Button>("Button").LeftClicked += OnAddNewTileButtonLeftClicked;
        base.Start();
    }

    public override void Update()
    {
        UpdateSize();
        base.Update();
    }

    private void UpdateSize()
    {
        float x = Raylib.GetScreenWidth() * 0.15F;
        float y = Raylib.GetScreenHeight();

        Size = new(x, y);
    }

    private void OnAddNewTileButtonLeftClicked(object? sender, EventArgs e)
    {
        OpenDialogForNewTile();
    }

    private void OpenDialogForNewTile()
    {
        OpenFileDialog openFileDialog = new()
        {
            Multiselect = true
        };

        openFileDialog.ShowDialog();

        if (openFileDialog.FileName != "")
        {
            LoadTiles(openFileDialog.FileNames);
            ShowFailedTilesDialog();
        }
    }

    private void LoadTiles(string[] filePaths)
    {
        notLoadedTiles.Clear();

        foreach (string filePath in filePaths)
        {
            try
            {
                TryToLoadTile(filePath);
            }
            catch
            {
                notLoadedTiles.Add(Path.GetFileName(filePath));
            }
        }
    }

    private void TryToLoadTile(string filePath)
    {
        Texture2D texture = Raylib.LoadTexture(filePath);

        if (texture.Id <= 0)
        {
            notLoadedTiles.Add(Path.GetFileName(filePath));
            return;
        }

        AddTexture(filePath, texture);
    }

    private void AddTexture(string filePath, Texture2D texture)
    {
        string name = Path.GetFileNameWithoutExtension(filePath);

        TextureLoader.Instance.Textures.Add(name, texture);

        TileItem tileItem = new()
        {
            TileName = name,
            FilePath = filePath,
            Texture = TextureLoader.Instance.Textures[name],
        };

        GetChild<ItemList>().AddItem(tileItem);
        TileFilePathsContainer.Instance.TileFilePaths.Add(filePath);
    }

    private void ShowFailedTilesDialog()
    {
        if (notLoadedTiles.Count > 0)
        {
            AddChild(new NotLoadedTilesDialog
            {
                NotLoadedTiles = notLoadedTiles
            });
        }
    }
}
