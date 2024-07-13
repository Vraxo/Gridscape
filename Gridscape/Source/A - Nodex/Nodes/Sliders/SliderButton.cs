using Raylib_cs;

namespace Gridscape;

class SliderButton : Node2D
{
    public float Radius = 9F;
    public Vector2 TextOrigin = Vector2.Zero;
    public string Text = "";
    public ButtonStyle Style = new();
    public bool Visible = true;
    public bool Pressed = false;
    public Action<SliderButton> OnUpdate = (button) => { };

    private bool alreadyClicked = false;
    private bool initialPositionSet = false;

    public SliderButton()
    {
        InheritPosition = false;
    }

    public override void Start()
    {
        UpdatePosition(initial: true);
    }

    public override void Update()
    {
        UpdatePosition();
        CheckForClicks();
        DrawShape();
        OnUpdate(this);
        base.Update();
    }

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

            if (Raylib.IsMouseButtonDown(MouseButton.Left) && !alreadyClicked)
            {
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

            Raylib.DrawCircleV(
                roundedGlobalPosition,
                Radius,
                Style.Current.FillColor);
        }
    }

    private void UpdatePosition(bool initial = false)
    {
        Node2D parent = (Node2D)Parent;

        if (Pressed)
        {
            GlobalPosition = new(parent.GlobalPosition.X, Raylib.GetMousePosition().Y);
        }

        float minY = parent.GlobalPosition.Y;
        float maxY = minY + parent.Size.Y;

        if (initial && !initialPositionSet)
        {
            GlobalPosition = new(parent.GlobalPosition.X, minY);
            initialPositionSet = true;
        }
        else
        {
            GlobalPosition = new(parent.GlobalPosition.X, Math.Clamp(GlobalPosition.Y, minY, maxY));
        }
    }

    private bool IsMouseOver()
    {
        float distance = MathUtilities.GetDistance(GlobalPosition, Raylib.GetMousePosition());
        bool isMouseOver = distance < Radius;
        return isMouseOver;
    }
}
