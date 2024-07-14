using Raylib_cs;

namespace Gridscape;

partial class VerticalSlider : Node2D
{
    public float Value = 0;
    public SliderButton Button;
    public Action<VerticalSlider> OnUpdate = (slider) => { };
    public event EventHandler<float>? ValueChanged;

    public VerticalSlider()
    {
        Size = new(10, 100);
        OriginPreset = OriginPreset.TopCenter;
    }

    public override void Ready()
    {
        Button = GetChild<SliderButton>("SliderButton");
        GetChild<SliderButton>().Layer = ClickableLayer.DialogButtons;

        base.Ready();
    }

    public override void Update()
    {
        UpdateValue();
        Draw();
        OnUpdate(this);
        base.Update();
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
            0,
            (int)Size.Y,
            Color.Gray);
    }

    private void UpdateValue()
    {
        float currentPosition = Button.GlobalPosition.Y;
        float minPos = GlobalPosition.Y;
        float maxPos = minPos + Size.Y;

        float previousValue = Value;

        // Calculate the value relative to the slider's range
        Value = (currentPosition - minPos) / (maxPos - minPos);

        if (Value != previousValue)
        {
            ValueChanged?.Invoke(this, Value);
        }
    }
}
