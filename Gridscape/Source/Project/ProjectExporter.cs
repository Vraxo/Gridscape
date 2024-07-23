using System.Text.Json;

namespace Gridscape;

class ProjectExporter : Node
{
    public void Export()
    {
        FolderBrowserDialog folderBrowserDialog = new();

        if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
        {
            SaveFiles(folderBrowserDialog.SelectedPath);
        }
    }

    private void SaveFiles(string path)
    {
        path = Path.Combine(path, "ExportData");
        Directory.CreateDirectory(path);
        SaveTileData(path);
        SaveTileFiles(path);
    }

    private void SaveTileData(string path)
    {
        var tileMap = GetNode<TileMap>("TileMap");
        List<TileData> tileData = tileMap.GetTileData();

        JsonSerializerOptions options = new() 
        { 
            WriteIndented = true 
        };

        string jsonString = JsonSerializer.Serialize(tileData, options);
        File.WriteAllText(Path.Combine(path, "Tiles.json"), jsonString);
    }

    private void SaveTileFiles(string path)
    {
        foreach (var tileFilePath in GetNode<TileFilePathsContainer>().TileFilePaths)
        {
            string fileName = Path.GetFileName(tileFilePath);
            string destinationPath = Path.Combine(path, fileName);

            File.Copy(tileFilePath, destinationPath, true);
        }
    }
}