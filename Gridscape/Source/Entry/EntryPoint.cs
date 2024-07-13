namespace Gridscape;

class EntryPoint
{
    [STAThread]
    public static void Main()
    {
        new Program().Run(new CreateOrLoadProjectPage());
    }
}