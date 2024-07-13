using System.Text.Json;

namespace Gridscape;

class ProjectSaver : Node
{
    public void Save()
    {
        string savePath = ProjectManager.Instance.SavePath;

        if (string.IsNullOrEmpty(savePath) || !File.Exists(savePath))
        {
            SelectSavePath();
        }
        else
        {
            CreateJsonFile();
        }
    }

    private void SelectSavePath()
    {
        SaveFileDialog saveFileDialog = new SaveFileDialog
        {
            Title = "Save Project",
            Filter = "JSON Files (*.json)|*.json",
            FileName = "GridscapeProject.json"
        };

        if (saveFileDialog.ShowDialog() == DialogResult.OK)
        {
            ProjectManager.Instance.SavePath = saveFileDialog.FileName;
            CreateJsonFile();
        }
    }

    private void CreateJsonFile()
    {
        ProjectData projectData = GetProjectData();

        JsonSerializerOptions options = new JsonSerializerOptions
        {
            WriteIndented = true,
        };

        string jsonString = JsonSerializer.Serialize(projectData, options);
        File.WriteAllText(ProjectManager.Instance.SavePath, jsonString);
    }

    private ProjectData GetProjectData()
    {
        var tileMap = GetNode<TileMap>("TileMap");

        ProjectSettings projectSettings = GetProjectSettings(tileMap);

        ProjectData projectData = new()
        {
            ProjectSettings = projectSettings,
            TileData = tileMap.GetTileData(),
            TileFilePaths = TileFilePathsContainer.Instance.TileFilePaths
        };

        Console.WriteLine(projectData.ProjectSettings.GridX);

        return projectData;
    }

    private ProjectSettings GetProjectSettings(TileMap tileMap)
    {
        ProjectSettings projectSettings = new()
        {
            SavePath = ProjectManager.Instance.SavePath,
            MapX = (int)tileMap.Size.X,
            MapY = (int)tileMap.Size.Y,
            GridX = (int)tileMap.Grid.Size.X,
            GridY = (int)tileMap.Grid.Size.Y,
            ShowGrid = tileMap.Grid.Visible,
            SnapToGrid = tileMap.Grid.Snap
        };

        return projectSettings;
    }
}