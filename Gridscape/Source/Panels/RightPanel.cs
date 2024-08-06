using Raylib_cs;

namespace Gridscape;

public partial class RightPanel : Panel
{
    private TopPanel topPanel;
    private BottomPanel bottomPanel;

    public RightPanel()
    {
        Position = new(Position.X, 250);
        Size = new(35, 0);
    }

    public override void Start()
    {
        topPanel = GetNode<TopPanel>("TopPanel");
        bottomPanel = GetNode<BottomPanel>("BottomPanel");

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
        float x = Raylib.GetScreenWidth() - Size.X;
        float y = topPanel.Size.Y - 1;

        Position = new(x, y);
    }

    private void UpdateSize()
    {
        float x = Raylib.GetScreenWidth() - Position.X;
        float y = Raylib.GetScreenHeight() - topPanel.Size.Y - bottomPanel.Size.Y + 2;

        Size = new(x, y);
    }
}