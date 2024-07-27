using Raylib_cs;

namespace Gridscape;

class CheckBox : ClickableRectangle
{
    public ButtonStyle Style = new();
    public bool Checked = false;
    public Action<CheckBox> OnUpdate = (checkBox) => { };
    public event EventHandler? Toggled;

    public override void Update()
    {
        Draw();
        HandleClicks();
        OnUpdate(this);
        base.Update();
    }

    private void Draw()
    {
        DrawOutline();
        DrawCircle();
    }

    private void DrawInside(Rectangle rectangle)
    {
        Raylib.DrawRectangleRounded(
            rectangle,
            Style.Current.Roundness,
            (int)Size.Y,
            Style.Current.FillColor);
    }

    private void DrawOutline(Rectangle rectangle)
    {
        if (!Checked)
        {
            return;
        }

        if (Style.Current.OutlineThickness > 0)
        {
            Raylib.DrawRectangleRoundedLines(
                rectangle,
                Style.Current.Roundness,
                (int)Size.Y,
                Style.Current.OutlineThickness,
                Style.Current.OutlineColor);
        }
    }

    private void HandleClicks()
    {
        if (IsMouseOver())
        {
            if (Raylib.IsMouseButtonPressed(MouseButton.Left) && OnTopLeft)
            {
                Checked = !Checked;
                Toggled?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}