namespace Gridscape;

class ProjectManager
{
    public string SavePath = "";
    public ProjectData ProjectData;
    public bool NewProject = false;

    private static ProjectManager? _instance;
    public static ProjectManager Instance
    {
        get
        {
            _instance ??= new();
            return _instance;
        }
    }
}