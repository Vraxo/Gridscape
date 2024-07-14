﻿using Raylib_cs;

namespace Gridscape;

class CircleCheckBox : ClickableCircle
{
    public CheckBoxStyle Style = new();
    public bool Checked = false;
    public Action<CircleCheckBox> OnUpdate = (checkBox) => { };
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