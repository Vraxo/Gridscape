using Raylib_cs;

namespace Gridscape;

public abstract class BaseSliderButton : ClickableCircle
{
    public Vector2 TextOrigin = Vector2.Zero;
    public string Text = "";
    public ButtonStyle Style = new();
    public bool Pressed = false;
    public Action<BaseSliderButton> OnUpdate = (button) => { };

    protected bool alreadyClicked = false;
    protected bool initialPositionSet = false;

    public BaseSliderButton()
    {
        Radius = 9F;
        InheritPosition = false;
    }

    public override void Start()
    {
        UpdatePosition(true);
        base.Start();
    }

    public override void Update()
    {
        UpdatePosition();
        CheckForClicks();
        DrawShape();
        OnUpdate(this);
        base.Update();
    }

    protected abstract void UpdatePosition(bool initial = false);

    private void CheckForClicks()
    {
        if (Raylib.IsMouseButtonDown(MouseButton.Left))
        {
            if (!IsMouseOver())
            {
                alreadyClicked = true;
            }
        }

        if (IsMouseOver())
        {
            Style.Current = Style.Hover;

            if (Raylib.IsMouseButtonDown(MouseButton.Left) && !alreadyClicked && OnTopLeft)
            {
                OnTopLeft = false;
                Pressed = true;
                alreadyClicked = true;
            }

            if (Pressed)
            {
                Style.Current = Style.Pressed;
            }
        }
        else
        {
            Style.Current = Style.Default;
        }

        if (Pressed)
        {
            Style.Current = Style.Pressed;
        }

        if (Raylib.IsMouseButtonReleased(MouseButton.Left))
        {
            Pressed = false;
            Style.Current = Style.Default;
            alreadyClicked = false;
        }
    }

    private void DrawShape()
    {
        if (Visible)
        {
            float x = MathF.Round(GlobalPosition.X);
            float y = MathF.Round(GlobalPosition.Y);
            Vector2 roundedGlobalPosition = new(x, y);

            Raylib.DrawCircleV(roundedGlobalPosition, Radius, Style.Current.FillColor);
        }
    }

    public override bool IsMouseOver()
    {
        float distance = MathUtilities.GetDistance(GlobalPosition, Raylib.GetMousePosition());
        return distance < Radius;
    }
}
