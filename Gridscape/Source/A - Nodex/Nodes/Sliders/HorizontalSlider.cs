using Raylib_cs;

namespace Gridscape;

partial class HorizontalSlider : Node2D
{
    public float Value = 0;
    public SliderButton MiddleButton;
    public Action<HorizontalSlider> OnUpdate = (slider) => { };
    public float MaxPossibleValue = 0;
    public SliderStyle Style = new();

    public HorizontalSlider()
    {
        Size = new(100, 9);
        OriginPreset = OriginPreset.CenterLeft;
    }

    public override void Start()
    {
        MiddleButton = GetChild<SliderButton>("MiddleButton");

        GetChild<Button>("LeftButton").LeftClicked += OnLeftButtonLeftClicked;
        GetChild<Button>("RightButton").LeftClicked += OnRightButtonLeftClicked;
    }

    public override void Update()
    {
        UpdateValue();
        Draw();
        OnUpdate(this);
        base.Update();
    }

    private void OnLeftButtonLeftClicked(object? sender, EventArgs e)
    {
        MoveMiddleButton(-1);
    }

    private void OnRightButtonLeftClicked(object? sender, EventArgs e)
    {
        MoveMiddleButton(1);
    }

    private void MoveMiddleButton(int direction)
    {
        float x = MiddleButton.GlobalPosition.X + direction * (Size.X / MaxPossibleValue);
        float y = MiddleButton.GlobalPosition.Y;

        MiddleButton.GlobalPosition = new(x, y);
    }

    private void Draw()
    {
        Rectangle rectangle = new()
        {
            Position = GlobalPosition - Origin,
            Size = Size
        };

        Raylib.DrawRectangleRounded(
            rectangle,
            Style.Roundness,
            (int)Size.Y,
            Style.FillColor);
    }

    private void UpdateValue()
    {
        float currentPosition = MiddleButton.GlobalPosition.X;
        float maxPos = Size.X;

        Value = currentPosition / maxPos;
    }
}