using Raylib_cs;

namespace Gridscape;

public partial class ProjectNotLoadedDialog : Node2D
{
    public override void Start()
    {
        Origin = GetChild<Panel>().Size / 2;
        GetNode<ClickManager>().MinLayer = ClickableLayer.DialogButtons;
        GetChild<Button>().LeftClicked += OnButtonLeftClicked;
    }

    public override void Update()
    {
        UpdatePosition();
    }

    private void OnButtonLeftClicked(object? sender, EventArgs e)
    {
        GetNode<ClickManager>().MinLayer = 0;
        Destroy();
    }

    private void UpdatePosition()
    {
        Position.X = Raylib.GetScreenWidth() / 2;
        Position.Y = Raylib.GetScreenHeight() / 2;
    }
}