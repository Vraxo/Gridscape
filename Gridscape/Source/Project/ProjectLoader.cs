using Raylib_cs;

namespace Gridscape;

class ProjectLoader : Node
{
    private ProjectData projectData;
    private ProjectSettings settings;

    public override void Start()
    {
        if (ProjectManager.Instance.NewProject)
        {
            return;
        }

        projectData = ProjectManager.Instance.ProjectData;
        settings = projectData.ProjectSettings;

        LoadProjectSettings();
        LoadTiles();
        LoadTileInstances();
    }
    
    private void LoadProjectSettings()
    {
        LoadCheckBoxes();
        LoadMapSize();
        LoadGridSize();
    }

    private void LoadCheckBoxes()
    {
        GetNode<CircleCheckBox>("TopPanel/ShowGrid/CheckBox").Checked = settings.ShowGrid;
        GetNode<CircleCheckBox>("TopPanel/SnapToGrid/CheckBox").Checked = settings.SnapToGrid;
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

    private void LoadTiles()
    {
        List<string> notLoadedTiles = [];

        foreach (string tileFilePath in projectData.TileFilePaths)
        {
            string name = Path.GetFileNameWithoutExtension(tileFilePath);

            Texture2D texture = Raylib.LoadTexture(tileFilePath);

            if (texture.Id != 0)
            {
                TextureLoader.Instance.Textures.Add(name, texture);

                GetNode<Node>("LeftPanel/TilesPanel").AddChild(new TileItem
                {
                    Position = new(15, 50 + TileFilePathsContainer.Instance.TileFilePaths.Count * TileItem.Height),
                    TileName = name,
                    FilePath = tileFilePath,
                    Texture = TextureLoader.Instance.Textures[name],
                });

                TileFilePathsContainer.Instance.TileFilePaths.Add(tileFilePath);
            }
            else
            {
                notLoadedTiles.Add(tileFilePath);
            }
        }

        if (notLoadedTiles.Count > 0)
        {
            ((Node2D)Parent).AddChild(new NotLoadedTilesDialog
            {
                NotLoadedTiles = 
                [
                    "1",
                    "2",
                    "3",
                    "4",
                    "5",
                    "6",
                    "7",
                    "8",
                    "9",
                    "10",
                    "11",
                    "12",
                    "13",
                ]
            });
        }
    }

    private void LoadTileInstances()
    {
        foreach (TileData tileInstance in projectData.TileData)
        {
            Texture2D texture = TextureLoader.Instance.Textures[tileInstance.Name];
            
            GetNode<Node>("TileMap/TileInstances").AddChild(new TileInstance
            {
                Position = new(tileInstance.X, tileInstance.Y),
                Size = new(texture.Width, texture.Height),
                Texture = texture
            });
        }
    }
}