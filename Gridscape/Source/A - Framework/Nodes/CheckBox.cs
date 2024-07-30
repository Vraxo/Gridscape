using Raylib_cs;

namespace Gridscape;

public class CheckBox : ClickableRectangle
{
    public Vector2 CheckSize = new(10, 10);
    public ButtonStyle Style = new();
    public ButtonStyle CheckStyle = new();
    public bool Checked = false;
    public Action<CheckBox> OnUpdate = (checkBox) => { };
    public event EventHandler? Toggled;

    public CheckBox()
    {
        Size = new(20, 20);
        OriginPreset = OriginPreset.Center;

        Style.Roundness = 1;

        CheckStyle.Default.FillColor = new(71, 114, 179, 255);
        CheckStyle.Current = CheckStyle.Default;
    }

    public override void Update()
    {
        Draw();
        HandleClicks();
        OnUpdate(this);
        base.Update();
    }

    private void Draw()
    {
        //DrawOutline();
        DrawInside();
    }

    private void DrawInside()
    {
        Rectangle rectangle = new()
        {
            Position = GlobalPosition - Origin,
            Size = Size
        };

        Raylib.DrawRectangleRounded(
            rectangle,
            Style.Current.Roundness,
            (int)Size.Y,
            Style.Current.FillColor);

        DrawOutline(rectangle);
        DrawCheck();
    }

    private void DrawOutline(Rectangle rectangle)
    {
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

    private void DrawCheck()
    {
        if (!Checked)
        {
            return;
        }

        Rectangle rectangle = new()
        {
            Position = GlobalPosition - Origin / 2,
            Size = CheckSize
        };

        Raylib.DrawRectangleRounded(
            rectangle,
            Style.Current.Roundness,
            (int)CheckSize.Y,
            CheckStyle.Current.FillColor);
    }

    private void HandleClicks()
    {
        if (Raylib.IsMouseButtonPressed(MouseButton.Left))
        {
            if (IsMouseOver() && OnTopLeft)
            {
                Checked = !Checked;
                Toggled?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}