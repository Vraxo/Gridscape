using Raylib_cs;

namespace Gridscape;

class CircleCheckBox : Node2D
{
    public float Radius = 10;
    public CheckBoxStyle Style = new();
    public bool Checked = false;
    public Action<CircleCheckBox> OnUpdate = (checkBox) => { };
    public event EventHandler? Toggled;

    public override void Update()
    {
        Draw();
        CheckForClicks();
        OnUpdate(this);
        base.Update();
    }

    private void Draw()
    {
        DrawOutline();
        DrawCircle();
    }

    private void DrawOutline()
    {
        Raylib.DrawCircleLinesV(GlobalPosition, Radius, Style.OutlineColor);
    }

    private void DrawCircle()
    {
        if (!Checked)
        {
            return;
        }

        Raylib.DrawCircleV(GlobalPosition, Radius / 2, Style.CircleColor);
    }

    private void CheckForClicks()
    {
        if (Raylib.IsMouseButtonPressed(MouseButton.Left))
        {
            if (IsInRange(Raylib.GetMousePosition()))
            {
                Checked = !Checked;
                Toggled?.Invoke(this, EventArgs.Empty);
            }
        }
    }

    private bool IsInRange(Vector2 position)
    {
        float distance = MathUtilities.GetDistance(GlobalPosition, position);
        bool isInRange = distance < Radius;
        return isInRange;
    }
}