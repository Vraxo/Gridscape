using Raylib_cs;

namespace Gridscape;

partial class RightPanel : Panel
{
    private TopPanel topPanel;
    private BottomPanel bottomPanel;

    public override void Start()
    {
        Position.Y = 250;
        Size = new(35, 0);

        topPanel = GetNode<TopPanel>("TopPanel");
        bottomPanel = GetNode<BottomPanel>("BottomPanel");
    }

    public override void Update()
    {
        UpdatePosition();
        UpdateSize();
        base.Update();
    }

    private void UpdatePosition()
    {
        Position.X = Raylib.GetScreenWidth() - Size.X;
        Position.Y = topPanel.Size.Y - 1;
    }

    private void UpdateSize()
    {
        Size.X = Raylib.GetScreenWidth() - Position.X;
        Size.Y = Raylib.GetScreenHeight() - topPanel.Size.Y - bottomPanel.Size.Y + 2;
    }
}