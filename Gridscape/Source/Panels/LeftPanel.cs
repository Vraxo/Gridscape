using Raylib_cs;

namespace Gridscape;

partial class LeftPanel : Panel
{
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
        }
    }

    private void LoadTiles(string[] filePaths)
    {
        foreach (string filePath in filePaths)
        {
            try
            {
                TryToLoadTile(filePath);
            }
            catch 
            { 
            }
        }
    }

    private void TryToLoadTile(string filePath)
    {
        Texture2D texture = Raylib.LoadTexture(filePath);

        if (texture.Id <= 0)
        {
            return;
        }

        AddTexture(filePath, texture);
    }

    private void AddTexture(string filePath, Texture2D texture)
    {
        string name = Path.GetFileNameWithoutExtension(filePath);

        TextureLoader.Instance.Textures.Add(name, texture);

        GetChild<ItemList>().AddItem(new TileItem
        {
            //Position = new(25, y),
            TileName = name,
            FilePath = filePath,
            Texture = TextureLoader.Instance.Textures[name],
        });

        TileFilePathsContainer.Instance.TileFilePaths.Add(filePath);
    }
}