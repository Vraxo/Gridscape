using Raylib_cs;

namespace Gridscape;

class ProjectLoader : Node
{
    private ProjectData? projectData;
    private ProjectSettings? settings;

    public override void Start()
    {
        if (ProjectManager.Instance.NewProject)
        {
            return;
        }

        projectData = ProjectManager.Instance.ProjectData;
        settings = projectData.ProjectSettings;

        LoadProjectSettings();
        TryToLoadTileItems();
        TryToLoadTileInstances();
    }
    
    private void LoadProjectSettings()
    {
        LoadCheckBoxes();
        LoadMapSize();
        LoadGridSize();
    }

    private void LoadCheckBoxes()
    {
        GetNode<CheckBox>("TopPanel/ShowGrid/CheckBox").Checked = settings.ShowGrid;
        GetNode<CheckBox>("TopPanel/SnapToGrid/CheckBox").Checked = settings.SnapToGrid;
    }

    private void LoadMapSize()
    {
        GetNode<TextBox>("TopPanel/MapX/TextBox").Text = settings.MapX.ToString();
        GetNode<TextBox>("TopPanel/MapY/TextBox").Text = settings.MapY.ToString();
    }

    private void LoadGridSize()
    {
        GetNode<TextBox>("TopPanel/GridX/TextBox").Text = settings.GridX.ToString();
        GetNode<TextBox>("TopPanel/GridY/TextBox").Text = settings.GridY.ToString();
    }

    private void TryToLoadTileItems()
    {
        List<string> tilesNotLoaded = [];

        foreach (string tileFilePath in projectData.TileFilePaths)
        {
            Texture2D texture = Raylib.LoadTexture(tileFilePath);

            if (texture.Id != 0)
            {
                LoadTileItem(tileFilePath, texture);
            }
            else
            {
                tilesNotLoaded.Add(tileFilePath);
            }
        }

        CreateNotLoadedTilesDialog(tilesNotLoaded);
    }

    private void LoadTileItem(string tileFilePath, Texture2D texture)
    {
        string name = Path.GetFileNameWithoutExtension(tileFilePath);

        TextureLoader.Instance.Textures.Add(name, texture);

        TileItem tileItem = new()
        {
            TileName = name,
            FilePath = tileFilePath,
            Texture = TextureLoader.Instance.Textures[name],
        };

        GetNode<ItemList>("LeftPanel/ItemList").AddChild(tileItem);
        GetNode<TileFilePathsContainer>().TileFilePaths.Add(tileFilePath);
    }

    private void TryToLoadTileInstances()
    {
        foreach (TileData tileInstanceData in projectData.TileData)
        {
            if (!TextureLoader.Instance.Textures.ContainsKey(tileInstanceData.Name))
            {
                return;
            }

            LoadTileInstance(tileInstanceData);
        }
    }

    private void LoadTileInstance(TileData tileInstanceData)
    {
        Texture2D texture = TextureLoader.Instance.Textures[tileInstanceData.Name];

        TileInstance tileItem = new()
        {
            Position = new(tileInstanceData.X, tileInstanceData.Y),
            Size = new(texture.Width, texture.Height),
            Texture = texture
        };

        GetNode<Node2D>("TileMap/TileInstances").AddChild(tileItem);
    }

    private void CreateNotLoadedTilesDialog(List<string> tilesNotLoaded)
    {
        if (tilesNotLoaded.Count > 0)
        {
            TilesNotLoadedDialog tilesNotLoadedDialog = new()
            {
                TilesNotLoaded = tilesNotLoaded
            };

            Parent.AddChild(tilesNotLoadedDialog);
        }
    }
}