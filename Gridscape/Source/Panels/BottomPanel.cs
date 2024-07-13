using Raylib_cs;

namespace Gridscape;

partial class BottomPanel : Panel
{
    private LeftPanel leftPanel;

    public override void Start()
    {
        Size = new(0, 35);
        leftPanel = GetNode<LeftPanel>("LeftPanel");
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
        Position.X = leftPanel.Size.X - 1;
        Position.Y = Raylib.GetScreenHeight() - Size.Y;
    }

    private void UpdateSize()
    {
        Size = new(Raylib.GetScreenWidth() - leftPanel.Size.X + 1, Size.Y);
    }
}