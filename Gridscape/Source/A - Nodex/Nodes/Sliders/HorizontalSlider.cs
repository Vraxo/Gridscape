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
    }

    public override void Update()
    {
        UpdateValue();
        Draw();
        OnUpdate(this);
        base.Update();
        Raylib.DrawPixelV(GlobalPosition, Color.Red);
    }

    private void OnLeftButtonLeftClicked(object? sender, EventArgs e)
    {
        MiddleButton.Position.X -= Size.X / MaxPossibleValue;
    }

    private void OnRightButtonLeftClicked(object? sender, EventArgs e)
    {
        MiddleButton.Position.X += Size.X / MaxPossibleValue;
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
        float currentPosition = MiddleButton.Position.X;
        float maxPos = Size.X;

        Value = currentPosition / maxPos;
    }
}