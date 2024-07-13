namespace Gridscape;

class ProjectManager
{
    public string SavePath = "";
    public ProjectData ProjectData;
    public bool NewProject = false;

    private static ProjectManager? instance;

    public static ProjectManager Instance
    {
        get
        {
            instance ??= new();
            return instance;
        }
    }
}