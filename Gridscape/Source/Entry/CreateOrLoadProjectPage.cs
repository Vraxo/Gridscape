using System.Text.Json;

namespace Gridscape;

partial class CreateOrLoadProjectPage : Node2D
{
    public override void Start()
    {
        GetChild<Button>("CreateNewProjectButton").LeftClicked += OnCreateNewProjectButtonLeftClicked;
        GetChild<Button>("LoadExistingProjectButton").LeftClicked += OnLoadExistingProjectButtonLeftClicked;
    }

    private void OnCreateNewProjectButtonLeftClicked(object? sender, EventArgs e)
    {
        CreateNewProject();
    }

    private void OnLoadExistingProjectButtonLeftClicked(object? sender, EventArgs e)
    {
        LoadExistingProject();
    }

    private void CreateNewProject()
    {
        ProjectManager.Instance.NewProject = true;
        ChangeScene(new Workspace());
    }

    private void LoadExistingProject()
    {
        OpenFileDialog openFileDialog = new();

        if (openFileDialog.ShowDialog() != DialogResult.OK)
        {
            return;
        }

        string json = File.ReadAllText(openFileDialog.FileName);
        var projectData = JsonSerializer.Deserialize<ProjectData>(json);

        ProjectManager.Instance.ProjectData = projectData;

        ChangeScene(new Workspace());
    }
}