using Raylib_cs;

namespace Gridscape;

public partial class RightPanel : Panel
{
    private TopPanel topPanel;
    private BottomPanel bottomPanel;

    public override void Ready()
    {
        Position.Y = 250;
        Size = new(35, 0);

        topPanel = GetNode<TopPanel>("TopPanel");
        bottomPanel = GetNode<BottomPanel>("BottomPanel");

        base.Ready();
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
        float x = Raylib.GetScreenWidth() - Position.X;
        float y = Raylib.GetScreenHeight() - topPanel.Size.Y - bottomPanel.Size.Y + 2;

        Size = new(x, y);
    }
}