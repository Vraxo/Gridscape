using Raylib_cs;
using System.Text.RegularExpressions;

namespace Gridscape;

public partial class LeftPanel : Panel
{
    private readonly List<string> tilesNotLoaded = [];

    public override void Ready()
    {
        GetChild<Button>().LeftClicked += OnAddNewTileButtonLeftClicked;
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
        tilesNotLoaded.Clear();

        foreach (string filePath in filePaths)
        {
            try
            {
                TryToLoadTile(filePath);
            }
            catch
            {
                tilesNotLoaded.Add(Path.GetFileName(filePath));
            }
        }
    }

    private void TryToLoadTile(string filePath)
    {
        Texture2D texture = Raylib.LoadTexture(filePath);

        if (texture.Id <= 0)
        {
            tilesNotLoaded.Add(Path.GetFileName(filePath));
            return;
        }

        AddTile(filePath, texture);
    }

    private void AddTile(string filePath, Texture2D texture)
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
        //TileFilePathsContainer.Instance.TileFilePaths.Add(filePath);
        GetNode<TileFilePathsContainer>().TileFilePaths.Add(filePath);
    }

    private void ShowFailedTilesDialog()
    {
        if (tilesNotLoaded.Count > 0)
        {
            TilesNotLoadedDialog notLoadedTilesDialog = new()
            {
                TilesNotLoaded = tilesNotLoaded
            };

            AddChild(notLoadedTilesDialog);
        }
    }
}