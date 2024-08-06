using Raylib_cs;

namespace Gridscape;

public partial class BottomPanel : Panel
{
    private LeftPanel leftPanel;

    public override void Start()
    {
        Size = new(0, 35);
        leftPanel = GetNode<LeftPanel>();
        base.Start();
    }

    public override void Update()
    {
        UpdatePosition();
        UpdateSize();
        base.Update();
    }

    private void UpdatePosition()
    {
        float x = leftPanel.Size.X - 1;
        float y = Raylib.GetScreenHeight() - Size.Y;

        Position = new(x, y);
    }

    private void UpdateSize()
    {
        float x = MathF.Ceiling(Raylib.GetScreenWidth() - leftPanel.Size.X + 1);
        float y = Size.Y;

        Size = new(x, y);
    }
}